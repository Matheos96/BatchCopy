using System;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace BatchCopy
{
	internal static class BatchCopy
	{

		internal static Action<int>? OnProgressChanged { get; set; }

		internal static bool TryCopy(string fileNamesStr, string source, string destination, bool overwrite, out string resultMessage)
		{
			if (!Directory.Exists(source) || !Directory.Exists(destination))
			{
				resultMessage = "Source or destination folder does not exist!";
				return false;
			}

			var fileNames = !string.IsNullOrWhiteSpace(fileNamesStr) ? fileNamesStr.Split(',').Select(f => f.Trim()).ToArray() : Array.Empty<string>();

			var srcFiles = Directory.GetFiles(source);
			if (fileNames.Length > 0) 
				srcFiles = srcFiles.Where(f => fileNames.Contains(Path.GetFileNameWithoutExtension(f), StringComparer.InvariantCultureIgnoreCase)).ToArray();

			// Copy files in parallel to improve performance (at least for scenarios with large files?)
			var processed = 0;
			var fileCount = srcFiles.Length;
			var progress = new ConcurrentQueue<int>();
			Parallel.ForEach(srcFiles, srcFile =>
			{
				File.Copy(srcFile, Path.Combine(destination, Path.GetFileName(srcFile)), overwrite);
				var currentProgress = Interlocked.Increment(ref processed);
				progress.Enqueue(currentProgress);
				OnProgressChanged?.Invoke((int)((float)currentProgress / fileCount * 100));
			});

			resultMessage = $"Successfully copied {srcFiles.Length} files to the destination!";
			return true;
		}
	}
}
