using Autofac;
using Autofac.Builder;
using Serilog;
using System;

namespace Havoc.Extensions
{
	internal static class ContainerBuilderExtensions
	{
		public static IRegistrationBuilder<ILogger, SimpleActivatorData, SingleRegistrationStyle> RegisterLogger(this ContainerBuilder builder, Func<LoggerConfiguration, LoggerConfiguration> configure)
		{
			Log.Logger = configure(new LoggerConfiguration()).CreateLogger();

			return builder.RegisterInstance(Log.Logger).As<ILogger>().SingleInstance();
		}
	}
}
