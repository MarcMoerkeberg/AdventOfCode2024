using System.Runtime.CompilerServices;

namespace AdventOfCode2024
{
	public static class FileHelper
	{
		/// <summary>
		/// Returns the calling file's parent directory path.
		/// </summary>
		/// <exception cref="DirectoryNotFoundException"></exception>
		public static string GetCallingDirectory([CallerFilePath] string callerFilePath = "")
		{
			string? callinfFileDirectory = Directory.GetParent(callerFilePath)?.FullName ?? string.Empty;
			if (string.IsNullOrEmpty(callinfFileDirectory)) throw new DirectoryNotFoundException("Could not find calling files parent directory.");

			return callinfFileDirectory;
		}
	}
}
