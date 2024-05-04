using System;
using System.Runtime.InteropServices;

namespace OML.Logging
{
	internal static class ConsoleManager
	{
		// 定义常量以提高可读性
		private const int STD_OUTPUT_HANDLE = -11;
		private const uint UTF8_CODE_PAGE_ID = 65001;

		[DllImport("kernel32", SetLastError = true)]
		private static extern bool AllocConsole();

		[DllImport("kernel32", SetLastError = true)]
		private static extern IntPtr GetStdHandle(int nStdHandle);

		[DllImport("kernel32", SetLastError = true)]
		private static extern bool SetConsoleTitle(string lpConsoleTitle);

		[DllImport("kernel32", SetLastError = true)]
		private static extern bool SetConsoleOutputCP(uint wCodePageID);

		[DllImport("kernel32", SetLastError = true)]
		private static extern bool SetConsoleCtrlHandler(int HandlerRoutine, bool Add);

		[DllImport("kernel32", SetLastError = true)]
		private static extern bool WriteConsole(IntPtr hConsoleHandle, string lpBuffer, uint nNumberOfCharsToWrite, out uint lpNumberOfCharsWritten, IntPtr lpReserved);

		internal static IntPtr ConsoleHandle { get; private set; }
		private static bool isInitialized;

		internal static void Initialize()
		{
			if (!isInitialized)
			{
				AllocConsole();
				SetConsoleTitle("OML Console");
				SetConsoleOutputCP(UTF8_CODE_PAGE_ID);
				SetConsoleCtrlHandler(0, true);
				ConsoleHandle = GetStdHandle(STD_OUTPUT_HANDLE);
				isInitialized = true;
			}
		}
	}
}
