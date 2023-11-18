using Havoc.Mod.Registries;

namespace Havoc
{
	public interface IMod
	{
		/// <summary>
		/// The display name for the mod.
		/// </summary>
		string DisplayName { get; }

		/// <summary>
		/// Gets called after all mods are loaded. You can access any resources you want here.
		/// </summary>
		void Initialize();

		/// <summary>
		/// Gets called after all mods are loaded. Add new items here.
		/// </summary>
		/// <param name="itemRegistry">The item registry</param>
		void RegisterItems(IRegistry<Item> itemRegistry);
	}
}
