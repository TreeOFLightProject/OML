using System;
using System.Threading;
using System.Windows.Forms;
using OML.Logging;

namespace OML
{
	internal static class Main
	{
		internal static readonly Logger ModLogger = new Logger("OML");

		internal static void Start()
		{
			try
			{
				Initialize();

				Thread thread = new Thread(() =>
				{
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);
					Window.ErrorWindow form = new Window.ErrorWindow();
					Application.Run(form);
				});
				thread.SetApartmentState(ApartmentState.STA);
				thread.Start();
				thread.Join();

				ModLogger.Info("OML initialized successfully!");
			}
			catch (Exception e)
			{
				Thread thread = new Thread(() =>
				{
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);
					Window.ErrorWindow form = new Window.ErrorWindow();
					Application.Run(form);
				});
				thread.SetApartmentState(ApartmentState.STA);
				thread.Start();
				thread.Join();
			}
		}

		private static void Initialize()
		{
			// 初始化控制台
			ConsoleManager.Initialize();

			// 初始化文件日志
			FileLogger.Initialize();

			// 初始化 ModLoader 类
			Loader.Loader.Initialize();
		}
	}
}
