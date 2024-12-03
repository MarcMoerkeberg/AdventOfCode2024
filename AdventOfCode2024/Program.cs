using AdventOfCode2024;
using System.Reflection;

var navigator = new ConsoleNavigator();

try
{
	Type day = SelectDayToRun();
	MethodInfo method = SelectMethodToRun(day);

	InvokeMethod(day, method);
}
catch (Exception exception)
{
	ConsoleHelper.ProcessException(exception);
}

Type SelectDayToRun()
{
	List<Type> menuitems = MenuItemGenerator.GetClassMenuItems();
	navigator.SetMenuItems(menuitems.Select(menuItem => menuItem.Name).ToList());
	Type selectedDay = typeof(object);

	navigator.SelectMenuItem(selectedIndex =>
	{
		selectedDay = menuitems[selectedIndex];
	});

	return selectedDay;
}

MethodInfo SelectMethodToRun(Type dayClass)
{
	List<MethodInfo> menuItems = MenuItemGenerator.GetMethodMenuItems(dayClass);
	navigator.SetMenuItems(menuItems.Select(menuItem => menuItem.Name).ToList());
	MethodInfo selectedMethod = default!;

	navigator.SelectMenuItem(selectedIndex =>
	{
		selectedMethod = menuItems[selectedIndex];
	});

	return selectedMethod;
}

void InvokeMethod(Type dayClass, MethodInfo method)
{
	object? classInstance = Activator.CreateInstance(dayClass);

	//TODO: Account for async functions
	method.Invoke(classInstance, null);

	//TODO: Consider reworking to call another method or class, when done executing/invocing method.
}