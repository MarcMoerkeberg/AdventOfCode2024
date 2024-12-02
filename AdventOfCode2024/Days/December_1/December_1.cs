namespace AdventOfCode2024.Days.December_1
{
	public class December_1
	{
		private const string _dataFileName = "data.txt";
		public void Run()
		{
			//Get data from columns
			(int[] leftColumn, int[] rightColumn) = GetDataColumns();
			//Sort by size
			//Compare distance between numbers (should always be positive)
			//Add all distances together.
			//Display result to console.
		}

		private static (int[] leftColumn, int[] rightColumn) GetDataColumns()
		{
			string dataFilePath = Path.Combine(FileHelper.GetCurrentDirectory(), _dataFileName);
			string[] fileData = File.ReadAllLines(dataFilePath);
			int[] leftColumn = new int[fileData.Length];
			int[] rightColumn = new int[fileData.Length];

			for (int i = 0; i < fileData.Length; i++)
			{
				string dataRow = fileData[i];
				string[] dataColumnEntries = dataRow.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
				if (dataColumnEntries.Length == 0 || dataColumnEntries.Length > 2)
				{
					Console.WriteLine($"Skipping data row. Had issues parsing filedata into rows at index: {i}", ConsoleColor.DarkYellow);
				}

				leftColumn[i] = int.Parse(dataColumnEntries[0]);
				rightColumn[i] = int.Parse(dataColumnEntries[1]);
			}

			return ValueTuple.Create(leftColumn, rightColumn);
		}
	}
}
