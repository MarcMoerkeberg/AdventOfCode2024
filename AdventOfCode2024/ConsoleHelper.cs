namespace AdventOfCode2024
{
	public static class ConsoleHelper
	{
		/// <summary>
		/// Writes <paramref name="exception"/>.Message to the console, along with a stack trace and exits the application with error code (1).
		/// </summary>
		public static void ProcessException(Exception exception)
		{
			Console.Clear();
			Console.ResetColor();
			Console.WriteLine("An unhandled exception was thrown by the application:");

			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(exception.Message);
			Console.ResetColor();

			Console.WriteLine(exception.StackTrace);
			Console.ResetColor();

			Environment.Exit(1);
		}

		/// <summary>
		/// Writes <paramref name="message"/> to the console, along with the result and waits for any key to be pressed before continuing.
		/// </summary>
		public static void ProcessResult<T>(string message, T result) where T : struct
		{
			Console.Clear();
			Console.ResetColor();
			Console.Write(message);

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(result.ToString());
			Console.ResetColor();

			Console.WriteLine();
			Console.WriteLine("Press any key to continue.");
			Console.ReadKey();
		}
	}
}
