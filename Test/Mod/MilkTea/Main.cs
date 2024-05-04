using OML;
using OML.Logging;

namespace MilkTea
{
	public class Main : ModInitialize
	{
		public override void Early() // 早期加载
		{
			Logger Log = new Logger("1");
			Log.Debug("Hi1");
		}
		public override void Client() // 客户端
		{
			Logger Log = new Logger("2");
			Log.Debug("Hi2");
		}
	}
}
