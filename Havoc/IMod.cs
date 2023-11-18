using Havoc.Mod.Registries;

namespace Havoc
{
	public interface IMod
	{
		string DisplayName { get; }

		void Initialize();
	}
}
