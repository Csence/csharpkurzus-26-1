using ShoppingListCLI.Core.Storage;
using ShoppingListCLI.ShoppingListCLI.Core.Menus.Options;

namespace ShoppingListCLI.ShoppingListCLI.Core.Menus;

public class Menu
{
    internal static void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("=========================\n" +
                          "ShoppingListCLI\n" +
                          "=========================");

        Console.WriteLine("1 - Új bevásárlólista");
        Console.WriteLine("2 - Bevásárlólisták megnyitása");
        Console.WriteLine("3 - Bevásárlólista törlés");
        Console.WriteLine("4 - Kilépés");
        Console.Write("Válassz egy opciót(szám): ");
    }

    public void Start()
    {
        IStorage storage = new JsonStorage();
        ShowMenu();

        while (true)
        {
            #pragma warning disable CS8602 // Dereference of a possibly null reference.
            string input = Console.ReadLine().Trim();
            #pragma warning restore CS8602 // Dereference of a possibly null reference.

            bool isValidInput = Enum.TryParse<MenuOptions>(input, out MenuOptions option);
            if (!isValidInput)
            {
                Console.WriteLine("Hibás input, próbáld újra!");
            }
            else if (option == MenuOptions.AddItem)
            {
                AddItemOption addItemOption = new AddItemOption(storage);
                addItemOption.Open();
            }
            else if (option == MenuOptions.ViewList)
            {
                ViewItemsOption viewItemsOption = new ViewItemsOption(storage);
                viewItemsOption.Open();
            }
            else if (option == MenuOptions.RemoveList)
            {
                RemoveItemOption removeItemOption = new RemoveItemOption(storage);
                removeItemOption.Open();
            }
            else if (option == MenuOptions.Exit)
            {
                return;
            }
        }
    }
}
