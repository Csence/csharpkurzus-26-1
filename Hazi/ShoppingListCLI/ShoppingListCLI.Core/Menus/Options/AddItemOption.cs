using System;
using System.Collections.Generic;
using System.Text;

using ShoppingListCLI.Core.Storage;
using ShoppingListCLI.ShoppingListCLI.Core.Models;

namespace ShoppingListCLI.ShoppingListCLI.Core.Menus.Options;

public static class AddItemOption
{
    public async static void Open()
    {
        Console.Clear();
        var storage = new JsonStorage();
        List<ShoppingList> list = await storage.LoadAsync();

        Console.WriteLine("===========================\n" +
                  "Új bevásárlólista létrehozása\n" +
                  "===========================");
        Console.Write("Add meg a bevásárlólista nevét: ");

        string shoppingListName = Console.ReadLine();
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
                Menu.ShowMenu();
            }
        }
        list.Add(shoppingList);
        await storage.SaveAsync(list);
    }
}
