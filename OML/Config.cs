using System.Collections.Generic;

namespace OML
{
	internal class Config
	{
		private static readonly HashSet<string> NameUsed = new HashSet<string>();
		protected Config(string ConfigName)
		{
			if (!NameUsed.Contains(ConfigName))
			{
				NameUsed.Add(ConfigName);
			}
			else
			{
				throw new System.Exception($"Config name '{ConfigName}' is already used!");
			}
		}
	}
}
