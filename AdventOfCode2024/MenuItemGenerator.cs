using System.Reflection;

namespace AdventOfCode2024
{
	public static class MenuItemGenerator
	{
		/// <summary>
		/// Returns all public classes from the in the AdventOfCode2024.Days namespace.
		/// </summary>
		public static List<Type> GetClassMenuItems()
		{
			var classes = Assembly.GetExecutingAssembly()
				.GetTypes()
				.Where(t =>
					t.IsClass &&
					!t.IsNested &&
					!string.IsNullOrEmpty(t.Namespace) &&
					t.Namespace.Contains("AdventOfCode2024.Days.December", StringComparison.InvariantCultureIgnoreCase)
				)
				.ToList();

			return classes;
		}

		/// <summary>
		/// Returns all public methods from <paramref name="classType"/>.
		/// </summary>
		public static List<MethodInfo> GetMethodMenuItems(Type classType)
		{
			List<MethodInfo> publicMethods = classType.GetMethods()
			.Where(method => method.IsPublic && method.DeclaringType == classType)
			.ToList();

			return publicMethods;
		}
	}
}