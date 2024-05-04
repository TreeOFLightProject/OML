using System;
using System.IO;
using System.Text.RegularExpressions;

namespace OML.Logging
{
	internal static class FileLogger
	{
		private static bool isInitialized;
		private static StreamWriter logWriter;

		internal static bool Initialize()
		{
			if (!isInitialized)
			{
				string logFile = $@"{Paths.Logs}\{DateTime.Now:yyyy-MM-dd}.log";
				if (!Directory.Exists(Paths.Logs))
				{
					Directory.CreateDirectory(Paths.Logs);
				}

				HandleExistingLogFile(logFile);

				logWriter = File.AppendText(logFile);
				isInitialized = true;
				return true;
			}
			else
			{
				return false;
			}
		}

		private static void HandleExistingLogFile(string logFile)
		{
			if (File.Exists(logFile))
			{
				int num = 1;
				string numberedLogFile = Regex.Replace(logFile, @"(.+)(\.log)", "$1_" + num + "$2");

				while (File.Exists(numberedLogFile))
				{
					num++;
					numberedLogFile = Regex.Replace(logFile, @"(.+)(\.log)", "$1_" + num + "$2");
				}

				File.Move(logFile, numberedLogFile);
			}
		}

		internal static void Write(string message)
		{
			logWriter.WriteLine(message);
			logWriter.Flush();
		}
	}
}
