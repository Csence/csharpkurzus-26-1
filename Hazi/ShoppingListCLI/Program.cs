using System.Numerics;

using Microsoft.VisualBasic.FileIO;

using ShoppingListCLI.Core.Storage;
using ShoppingListCLI.ShoppingListCLI.Core.Menus;
using ShoppingListCLI.ShoppingListCLI.Core.Menus.Options;
using ShoppingListCLI.ShoppingListCLI.Core.Models;

namespace ShoppingListCLI;

internal class Program
{
    static void Main(string[] args)
    {
        IStorage storage = new JsonStorage();

        Menu.ShowMenu();

        while (true)
        {
            string input = Console.ReadLine().Trim();
            bool isValidInput = Enum.TryParse<MenuOptions>(input, out MenuOptions option);
            if (option == MenuOptions.AddItem)
            {
                AddItemOption.Open();
            } else if (option == MenuOptions.ViewList)
            {
                ViewItemsOption.Open();
            }
            else if (option == MenuOptions.RemoveList)
            {
                RemoveItemOption.Open();
            }

            if (input == "4")
            {
                return;
            }
        }
        
    }
}
