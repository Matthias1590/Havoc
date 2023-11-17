using Havoc.Debugging;
using System.IO;

namespace Havoc
{
	public class HavocLoader
	{
		private readonly ILogger _logger;

		public HavocLoader(ILogger logger)
		{
			_logger = logger;

			Load();
		}

		internal void Load()
		{
			_logger.Info("Loading mods");

			File.WriteAllText("C:\\Users\\matth\\Documents\\tmrmwef\\test.txt", "havoc loader!");
		}
	}
}
