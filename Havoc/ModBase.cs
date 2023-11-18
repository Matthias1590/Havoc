using Havoc.Mod.Registries;
using Serilog;

namespace Havoc.Helpers
{
	public abstract class ModBase : IMod
	{
		protected ILogger Logger { get; }

        public abstract string DisplayName { get; }

        protected ModBase(ILogger logger)
        {
            Logger = logger;
        }

        public virtual void Initialize()
        {
        }

        public virtual void RegisterItems(IRegistry<Item> itemRegistry)
        {
        }
	}
}
