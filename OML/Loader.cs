using System;
using System.IO;
using Newtonsoft.Json.Linq;
using OML.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace OML.Loader
{
	internal static class Loader
	{
		private static readonly Logger Log = new Logger("OML/Loader");
		public static readonly JArray ModList = new JArray();

		internal static void Initialize()
		{
			Log.Info($"Game args: [{string.Join(" ", Environment.GetCommandLineArgs())}]");

			AddModInfo("OML", "OMLLoader", typeof(Loader));

			List<string> modsDirectory = ScanModsDirectory();
			if (modsDirectory.Count != 0)
			{
				foreach (string item in modsDirectory)
				{
					try
					{
						string jsonContent = File.ReadAllText($"{item}\\starlight.mod.json");
						ModList.Add(JsonConvert.DeserializeObject<JObject>(jsonContent));
					}
					catch (Exception e)
					{
						Log.Error($"Error loading Mod configuration file from {item}\n{e}");
					}
				}
			}
		}

		private static void AddModInfo(string name, string id, Type modType)
		{
			Assembly assembly = Assembly.GetAssembly(modType);
			AssemblyName assemblyName = assembly.GetName();
			Version version = assemblyName.Version;
			ModList.Add(new JObject
			{
				["name"] = name,
				["id"] = id,
				["version"] = $"{version.Major}.{version.Minor}.{version.Build}",
			});
		}

		private static List<string> ScanModsDirectory()
		{
			if (!Directory.Exists(Paths.Mods))
			{
				Directory.CreateDirectory(Paths.Mods);
				return new List<string>();
			}

			// 获取所有Mods子目录中包含starlight.mod.json文件的路径，并添加到ModsDirectory数组中
			return Directory.GetDirectories(Paths.Mods)
							 .Where(ModPath => File.Exists(Path.Combine(ModPath, "starlight.mod.json")))
							 .ToList();
		}
	}
}
