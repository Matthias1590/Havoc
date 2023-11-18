using Havoc.Helpers;
using Havoc.Registries;
using Serilog;

namespace ExampleMod
{
	public class ExampleMod : ModBase
	{
		public override string DisplayName { get; } = "Example mod";

		private readonly IItemRegistry _itemRegistry;

		public ExampleMod(ILogger logger, IItemRegistry itemRegistry)
			: base(logger)
		{
			_itemRegistry = itemRegistry;
		}

		public override void Initialize()
		{
			Logger.Information("Hello from {modName}", DisplayName);

			On.MenuManager.ConfirmHostButton += (original, self) =>
			{
				Logger.Information("Start hosting!");

				original(self);
			};

			On.MenuManager.ClickHostButton += (original, self) =>
			{
				Logger.Information("Host?");

				original(self);
			};

			Logger.Information("Added hooks");
		}
	}
}
