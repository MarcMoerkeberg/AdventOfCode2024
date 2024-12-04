using AdventOfCode2024.Extensions;

namespace AdventOfCode2024.Days.December_2
{
	public class December_2
	{
		private const string _dataFileName = "data.txt";

		public void PartOne()
		{
			int[][] reports = GetReportsFromDataFile();

			int numberOfValidReports = 0;
			foreach (int[] report in reports)
			{
				numberOfValidReports += IsReportSave(report)
					? 1
					: 0;
			}
		}

		private int[][] GetReportsFromDataFile()
		{
			string dataFilePath = Path.Combine(FileHelper.GetCallingDirectory(), _dataFileName);
			string[] fileData = File.ReadAllLines(dataFilePath);
			int[][] reports = new int[fileData.Length][];

			for (int i = 0; i < fileData.Length; i++)
			{
				string[] reportLevelAsString = fileData[i].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
				int[] report = new int[reportLevelAsString.Length];

				for (int j = 0; j < reportLevelAsString.Length; j++)
				{
					report[j] = int.Parse(reportLevelAsString[j]);
				}

				reports[i] = report;
			}

			return reports;
		}

		private bool IsReportSave(int[] report)
		{
			int? previous = null;
			int? next = null;
			int differnece = 0;

			foreach (int reportLevel in report)
			{

			}

			throw new NotImplementedException();
		}

		private bool IsDifferenceGreaterThan(int a, int b, int greaterThan)
		{
			int distanceBetweenNumbers = a.DifferenceBetween(b);

			return distanceBetweenNumbers > greaterThan;
		}
	}
}
