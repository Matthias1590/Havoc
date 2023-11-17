using System;

namespace Havoc.Debugging
{
	public interface ILogger
	{
		void Debug(string format, params object[] parameters);
		void Info(string format, params object[] parameters);
		void Warning(string format, params object[] parameters);
		void Warning(Exception exception, string format, params object[] parameters);
		void Error(string format, params object[] parameters);
		void Error(Exception exception, string format, params object[] parameters);
	}
}
