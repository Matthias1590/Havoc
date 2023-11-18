using Havoc.Registries;

namespace Havoc.Mod.Registries
{
	internal class ItemRegistry : ListRegistry<GrabbableObject>, IItemRegistry
	{
        /**
		 * playersManager = Object.FindObjectOfType<StartOfRound>();
		 * terminalScript = Object.FindObjectOfType<Terminal>();
		 */

        public ItemRegistry()
        {
            
        }
    }
}
