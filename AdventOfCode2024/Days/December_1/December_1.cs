﻿namespace AdventOfCode2024.Days.December_1
{
	public class December_1
	{
		private const string _dataFileName = "data.txt";

		public void PartOne()
		{
			(int[] leftColumn, int[] rightColumn) = GetDataColumns();
			Array.Sort(leftColumn);
			Array.Sort(rightColumn);

			int distanceBetweenNumbers = 0;
			for (int i = 0; i < leftColumn.Length; i++)
			{
				distanceBetweenNumbers += GetDistanceBetweenNumbers(leftColumn[i], rightColumn[i]);
			}

			ConsoleHelper.ProcessResult("Resulting distance between numbers are: ", distanceBetweenNumbers);
		}

		public void PartTwo()
		{
			(int[] leftColumn, int[] rightColumn) = GetDataColumns();
			Array.Sort(rightColumn);

			int similarityScore = 0;
			foreach (int leftRow in leftColumn)
			{
				//Some timecomplexity here, this should be 0(n), could be more performant with some spin on a binary search.
				//Making the array smaller could maybe also increase performance.
				int matchesInRightColumnCount = rightColumn.Count(rightRow => rightRow == leftRow);

				similarityScore += matchesInRightColumnCount * leftRow;
			}

			ConsoleHelper.ProcessResult("Total similarity score: ", similarityScore);
		}

		private static (int[] leftColumn, int[] rightColumn) GetDataColumns()
		{
			string dataFilePath = Path.Combine(FileHelper.GetCallingDirectory(), _dataFileName);
			string[] fileData = File.ReadAllLines(dataFilePath);
			int[] leftColumn = new int[fileData.Length];
			int[] rightColumn = new int[fileData.Length];

			for (int i = 0; i < fileData.Length; i++)
			{
				string dataRow = fileData[i];
				string[] dataColumnEntries = dataRow.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
				if (dataColumnEntries.Length == 0 || dataColumnEntries.Length > 2)
				{
					Console.WriteLine($"Skipping data row. Had issues parsing filedata into rows at index: {i}.", ConsoleColor.DarkYellow);
				}

				leftColumn[i] = int.Parse(dataColumnEntries[0]);
				rightColumn[i] = int.Parse(dataColumnEntries[1]);
			}

			return ValueTuple.Create(leftColumn, rightColumn);
		}

		private static int GetDistanceBetweenNumbers(int a, int b) => a > b
			? a - b
			: b - a;
	}
}
