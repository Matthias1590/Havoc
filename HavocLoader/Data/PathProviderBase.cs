using System.IO;

namespace Havoc.Helpers
{
	internal abstract class PathProviderBase : IPathProvider
	{
		protected abstract string BaseFolder { get; }

		public string LogFolder => Path.Combine(BaseFolder, "Logs");

		public string ModFolder => Path.Combine(BaseFolder, "Mods");
	}
}