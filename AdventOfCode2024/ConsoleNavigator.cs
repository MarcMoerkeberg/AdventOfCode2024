namespace AdventOfCode2024
{
	public class ConsoleNavigator
	{
		private List<string> _menuItems;
		private int _selectedMenuItemIndex;
		private const int _minIndex = 0;
		private int _maxIndex => Math.Max(_menuItems.Count - 1, 0);

		public ConsoleNavigator()
		{
			_menuItems = new List<string>();
			_selectedMenuItemIndex = 0;
		}

		public void AddMenuItem(string menuItem) => _menuItems.Add(menuItem);
		public bool RemoveMenuItem(string menuItem) => _menuItems.Remove(menuItem);
		public List<string> GetMenuItems() => _menuItems;
		public void SetMenuItems(List<string> menuItems) => _menuItems = menuItems;
		public void ExitApplication() => Environment.Exit(0);
		public void Reset()
		{
			_selectedMenuItemIndex = 0;
			_menuItems.Clear();
			Console.Clear();
			Console.ResetColor();
		}

		private void MoveUp()
		{
			if (_selectedMenuItemIndex > _minIndex)
			{
				_selectedMenuItemIndex--;
			}
		}

		private void MoveDown()
		{
			if (_selectedMenuItemIndex < _maxIndex)
			{
				_selectedMenuItemIndex++;
			}
		}

		/// <summary>
		/// Renders all menu items to the console.
		/// </summary>
		private void Render()
		{
			Console.Clear();

			for (int i = 0; i < _menuItems.Count; i++)
			{
				if (i == _selectedMenuItemIndex)
				{
					Console.BackgroundColor = ConsoleColor.Gray;
					Console.ForegroundColor = ConsoleColor.Black;
				}

				Console.WriteLine(_menuItems[i]);
				Console.ResetColor();
			}
		}

		/// <summary>
		/// Prompts the user to select an item from the menu and runs the provided action using the selected menuitem's index.<br/>
		/// Resets the console after the action has been executed.
		/// </summary>
		public void SelectMenuItem(Action<int> action)
		{
			int selectedItemIndex = Navigate();

			action(selectedItemIndex);
			Reset();
		}

		/// <summary>
		/// Prompts the user to select an item from the menu and returns the selected items index.
		/// </summary>
		private int Navigate()
		{
			ConsoleKeyInfo keyInfo;

			do
			{
				Render();
				keyInfo = Console.ReadKey();

				switch (keyInfo.Key)
				{
					case ConsoleKey.UpArrow:
						MoveUp();
						break;
					case ConsoleKey.DownArrow:
						MoveDown();
						break;
					case ConsoleKey.Escape:
						ExitApplication();
						break;
				}
			} while (keyInfo.Key != ConsoleKey.Enter);

			return _selectedMenuItemIndex;
		}
	}
}
