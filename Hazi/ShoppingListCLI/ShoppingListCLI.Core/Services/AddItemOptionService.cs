using ShoppingListCLI.ShoppingListCLI.Core.Models;

namespace ShoppingListCLI.ShoppingListCLI.Core.Services;

internal static class AddItemOptionService
{

    internal static ShoppingList ReadUserShoppingListInput()
    {
        Console.Write("Add meg a bevásárlólista nevét: ");

        string? shoppingListName = Console.ReadLine();
        if (shoppingListName.Equals("")
            | shoppingListName == null)
        {
            Console.WriteLine("A bevásárlólista neve nem lehet üres!\n" +
                "Próbáld újra!");
            return ReadUserShoppingListInput();
        }

        ShoppingList shoppingList = new ShoppingList();
        shoppingList.Items = new List<Item>();
        shoppingList.Name = shoppingListName;
        bool isAddingItems = true;
        while (isAddingItems)
        {
            Console.Write("Szeretnél elemet adni a bevásárlólistához(I/n): ");
            string input = Console.ReadLine().ToLower();
            if (input == "i")
            {
                Console.Write("Add meg az elem nevét: ");
                string itemName = Console.ReadLine();
                Console.Write("Add meg az elem mennyiségét(db/g): ");
                string itemQuantity = Console.ReadLine();
                Item item = new Item();
                item.ItemName = itemName;
                item.Quantity = int.Parse(itemQuantity);
                shoppingList.Items.Add(item);
            }
            else if (input == "n")
            {
                isAddingItems = false;
            }
            else
            {
                Console.WriteLine("Érvénytelen input! Kérem válassz 'I' vagy 'N' opciót!");
            }
        }
        return shoppingList;
    }
}