using Autofac;
using Havoc.Extensions;
using Havoc.Helpers;
using Serilog;
using System;
using System.IO;
using UnityEngine;

namespace Havoc
{
	internal static class Initializer
	{
		private static bool _initialized = false;

		public static void Initialize()
		{
			if (_initialized)
			{
				return;
			}

			_initialized = true;

			var container = BuildContainer();

			var modLoader = container.Resolve<ModLoader>();

			try
			{
				modLoader.LoadMods();
			}
			catch (Exception e)
			{
				Log.Fatal(e, "Failed to load mods");
				throw;
			}
		}

		private static IContainer BuildContainer()
		{
			var builder = new ContainerBuilder();

			RegisterDependencies(builder);

			return builder.Build();
		}

		private static void RegisterDependencies(ContainerBuilder builder)
		{
			var dataPathProvider = new PathProvider();
			builder.RegisterInstance(dataPathProvider).As<IPathProvider>().SingleInstance();

			builder.RegisterLogger(logger => logger
				.WriteTo.File(
					path: Path.Combine(dataPathProvider.LogFolder, "log-.txt"),
					rollingInterval: RollingInterval.Day,
					rollOnFileSizeLimit: true
				)
				.WriteTo.Seq("http://localhost:5341"));

			Log.Information("Initializing Havoc");

			builder.RegisterType<ModLoader>().AsSelf().SingleInstance();

			// Registries
			//builder.RegisterType<>();

			// TODO: Some sort of config.
			// Could replace the path provider
			// and contain the seq url
		}
	}
}
