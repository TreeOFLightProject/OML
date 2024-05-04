using System;
using System.IO;

namespace OML
{
	/// <summary>
	/// Provides paths related to the OML application.
	/// </summary>
	public static class Paths
	{
		/// <summary>
		/// Gets the home directory for OML.
		/// </summary>
		public static string Home => Path.Combine(Environment.CurrentDirectory, "OML");

		/// <summary>
		/// Gets the directory for OML config.
		/// </summary>
		public static string Config => Path.Combine(Home, "config");

		/// <summary>
		/// Gets the directory for OML logs.
		/// </summary>
		public static string Logs => Path.Combine(Home, "logs");

		/// <summary>
		/// Gets the directory for OML mods.
		/// </summary>
		public static string Mods => Path.Combine(Home, "mods");
	}
}
