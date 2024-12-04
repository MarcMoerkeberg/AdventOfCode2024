namespace AdventOfCode2024.Extensions
{
	public static class IntegerExtensions
	{
		/// <summary>
		/// Returns the difference between the numbers.<br/>
		/// Developer note: Does not handle negative numbers (for now).
		/// </summary>
		public static int DifferenceBetween(this int target, int comparison)
		{
			//TODO: Handle negative numbers
			return target > comparison
				? target - comparison
				: comparison - target;
		}

		/// <summary>
		/// Checks wether the <paramref name="target"/> is greather than or equal to <paramref name="comparison"/>.
		/// </summary>
		public static bool IsGreaterThanOrEqual(this int target, int comparison) => target >= comparison;

		/// <summary>
		/// Checks wether the <paramref name="target"/> is less than or equal to <paramref name="comparison"/>.
		/// </summary>
		public static bool IsLessThanOrEqual(this int target, int comparison) => comparison >= target;
	}
}
