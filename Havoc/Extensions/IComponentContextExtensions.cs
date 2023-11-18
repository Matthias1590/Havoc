using Autofac.Core;
using Autofac;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Havoc.Extensions
{
	// Copied from https://stackoverflow.com/a/6994144
	public static class IComponentContextExtensions
	{
		public static object ResolveUnregistered(this IComponentContext context, Type serviceType, IEnumerable<Parameter> parameters)
		{
			var scope = context.Resolve<ILifetimeScope>();
			using (var innerScope = scope.BeginLifetimeScope(b => b.RegisterType(serviceType)))
			{
				innerScope.ComponentRegistry.TryGetRegistration(new TypedService(serviceType), out var reg);

				return context.ResolveComponent(reg, parameters);
			}
		}

		public static object ResolveUnregistered(this IComponentContext context, Type serviceType)
		{
			return ResolveUnregistered(context, serviceType, Enumerable.Empty<Parameter>());
		}

		public static object ResolveUnregistered(this IComponentContext context, Type serviceType, params Parameter[] parameters)
		{
			return ResolveUnregistered(context, serviceType, (IEnumerable<Parameter>)parameters);
		}

		public static TService ResolveUnregistered<TService>(this IComponentContext context)
		{
			return (TService)ResolveUnregistered(context, typeof(TService), Enumerable.Empty<Parameter>());
		}

		public static TService ResolveUnregistered<TService>(this IComponentContext context, params Parameter[] parameters)
		{
			return (TService)ResolveUnregistered(context, typeof(TService), (IEnumerable<Parameter>)parameters);
		}
	}
}
