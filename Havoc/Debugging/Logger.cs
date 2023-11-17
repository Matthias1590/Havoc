using System;
using System.Runtime.InteropServices;

namespace Havoc.Debugging
{
	internal class Logger : ILogger
	{
		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool AllocConsole();

		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool FreeConsole();

        public Logger()
        {
			AllocConsole();
        }

		~Logger()
		{
			FreeConsole();
		}

        public void Debug(string format, params object[] parameters)
		{
			Console.WriteLine($"[DBG] {format}", parameters);
		}

		public void Error(string format, params object[] parameters)
		{
			Console.WriteLine($"[ERR] {format}", parameters);
		}

		public void Error(Exception exception, string format, params object[] parameters)
		{
			Console.WriteLine($"[ERR] {format}", parameters);
			Console.WriteLine($"[ERR] {exception}");
		}

		public void Info(string format, params object[] parameters)
		{
			Console.WriteLine($"[INF] {format}", parameters);
		}

		public void Warning(string format, params object[] parameters)
		{
			Console.WriteLine($"[WRN] {format}", parameters);
		}

		public void Warning(Exception exception, string format, params object[] parameters)
		{
			Console.WriteLine($"[WRN] {format}", parameters);
			Console.WriteLine($"[WRN] {exception}");
		}
	}
}
