using Autofac;
using Havoc.Debugging;

namespace Havoc
{
	internal static class HavocInitializer
	{
		static HavocInitializer()
		{
			var container = BuildContainer();

			var loader = container.Resolve<HavocLoader>();

			loader.Load();
		}
		
		private static IContainer BuildContainer()
		{
			var builder = new ContainerBuilder();

			AddDependencies(builder);

			return builder.Build();
		}

		private static void AddDependencies(ContainerBuilder builder)
		{
			builder.RegisterType<HavocLoader>();
			builder.RegisterType<Logger>().As<ILogger>();
		}
	}
}
