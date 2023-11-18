using System;
using System.IO;

namespace Havoc.Helpers
{
	internal class PathProvider : PathProviderBase
	{
		protected override string BaseFolder => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Havoc");
	}
}
