using ShoppingListCLI.ShoppingListCLI.Core.Menus;

namespace ShoppingListCLI;

internal class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.Start();
    }
}
