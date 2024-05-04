using System;
using System.Runtime.InteropServices;

namespace OML.Logging
{
	public class Logger
	{
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr SetConsoleTextAttribute(IntPtr hConsoleOutput, int attributes);

		private readonly string logName;

		public Logger(string logName)
		{
			this.logName = logName;
		}

		private void Log(string message, string logLevel, int attributes)
		{
			string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			message = $"{currentTime} [{logLevel}/{logName}]: {message}";
			FileLogger.Write(message);
			SetConsoleTextAttribute(ConsoleManager.ConsoleHandle, attributes);
			Console.WriteLine(message);
		}

		public void Info(string message) => Log(message, "Info", 15);

		public void Warn(string message) => Log(message, "Warn", 14);

		public void Error(string message) => Log(message, "Error", 12);

		public void Fatal(string message) => Log(message, "Fatal", 4);

		public void Debug(string message) => Log(message, "Debug", 8);

		public void Message(string message) => Log(message, "Message", 11);
	}
}
