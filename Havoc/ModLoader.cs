using Autofac;
using Havoc.Extensions;
using Havoc.Helpers;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Havoc
{
	public class ModLoader
	{
		private readonly IComponentContext _componentContext;
		private readonly ILogger _logger;
		private readonly IPathProvider _pathProvider;

		public ModLoader(IComponentContext componentContext, ILogger logger, IPathProvider pathProvider)
		{
			_componentContext = componentContext;
			_logger = logger;
			_pathProvider = pathProvider;
		}

		public void LoadMods()
		{
			LoadMods(_pathProvider.ModFolder);
		}

		private void LoadMods(string folder)
		{
			_logger.Information("Loading mods in '{folder}'", folder);

			var mods = GetModsInFolder(folder);

			_logger.Information("Loaded {modCount} mod(s)", mods.Count());

			foreach (var mod in mods)
			{
				_logger.Information("Initializing '{modName}'", mod.DisplayName);

				mod.Initialize();
			}
		}

		private IEnumerable<IMod> GetModsInFolder(string folder)
		{
			return Directory.EnumerateFiles(folder)
				.Where(file =>
				{
					var isMod = false;
					try
					{
						isMod = FileIsMod(file);
					}
					catch (Exception e)
					{
						_logger.Error(e, "Could not load assembly '{file}'", file);
						return false;
					}

					if (!isMod)
					{
						_logger.Information("Skipping '{file}' since it's not a mod", file);
					}

					_logger.Information("Loading '{file}' mod", file);
					return isMod;
				})
				.Select(GetModFromFile);
		}

		private IMod GetModFromFile(string file)
		{
			return GetModFromAssembly(Assembly.LoadFrom(file));
		}

		private IMod GetModFromAssembly(Assembly assembly)
		{
			// FIXME: If there's multiple mods in a single assembly, create some MultipleMod instance that contains all mods in the assembly
			return GetModTypesFromAssembly(assembly)
				.Select(_componentContext.ResolveUnregistered)
				.Cast<IMod>()
				.Single();
		}

		private bool FileIsMod(string file)
		{
			return AssemblyIsMod(Assembly.LoadFrom(file));
		}

		private bool AssemblyIsMod(Assembly assembly)
		{
			return GetModTypesFromAssembly(assembly).Any();
		}

		private IEnumerable<Type> GetModTypesFromAssembly(Assembly assembly)
		{
			return assembly.ExportedTypes.Where(TypeIsMod);
		}

		private bool TypeIsMod(Type type)
		{
			return typeof(IMod).IsAssignableFrom(type);
		}
	}
}
