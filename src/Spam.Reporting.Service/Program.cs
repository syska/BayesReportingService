using System;
using System.IO;

namespace Spam.Reporting.Service
{
	class Program
	{
		static void Main(string[] args)
		{
			var path = "." + Path.DirectorySeparatorChar;
			if (args.Length > 0)
				path = args[0];

			var watcher = new FileSystemWatcher(path, "*.*");
			watcher.Renamed += WatcherOnRenamed;
			watcher.EnableRaisingEvents = true;
			watcher.IncludeSubdirectories = true;
			Console.WriteLine("Listening on: {0}", path);
			Console.ReadLine();
		}

		private static void WatcherOnRenamed(object sender, RenamedEventArgs renamedEventArgs)
		{
			
			Console.WriteLine("From: {0}, To: {1}", renamedEventArgs.OldFullPath, renamedEventArgs.FullPath);
		}
	}
}
