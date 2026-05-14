using System;
using System.Collections.Generic;
using System.Text;

using ShoppingListCLI.Core.Storage;
using ShoppingListCLI.ShoppingListCLI.Core.Models;

namespace ShoppingListCLI.ShoppingListCLI.Core.Menus.Options;

internal class ViewItemsOption : IOption
{
    public async static void Open()
    {
        var storage = new JsonStorage();
        List<ShoppingList> shoppingLists = await storage.LoadAsync();

        Console.Clear();
        Console.WriteLine("===========================\n" +
                          "Bevásárlólista megnyitása\n" +
                          "===========================\n\n");
        foreach (ShoppingList list in shoppingLists)
        {
            Console.WriteLine("Bevásárlólista neve: " + list.Name);
            Console.WriteLine("Elemek:");
            foreach (Item item in list.Items)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("     -Elem neve: " + item.ItemName);
                Console.WriteLine("     -Elem mennyiség(db/g): " + item.Quantity.ToString());
            }
            Console.WriteLine("==============================");
        }

        Console.WriteLine("Nyomj meg egy gombot a visszalépéshez...");
        Console.ReadKey();
        Menu.ShowMenu();
    }
}
