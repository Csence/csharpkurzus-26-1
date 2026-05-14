using System;
using System.Collections.Generic;
using System.Text;

using ShoppingListCLI.Core.Storage;
using ShoppingListCLI.ShoppingListCLI.Core.Models;

namespace ShoppingListCLI.ShoppingListCLI.Core.Menus.Options;

internal class RemoveItemOption : IOption
{

    public async static void Open()
    {
        Console.Clear();
        Console.WriteLine("===========================\n" +
                          "Bevásárlólista törlése\n" +
                          "===========================");
        Console.Write("Add meg a törölni kívánt bevásárlólista nevét: ");
        string shoppingListName = Console.ReadLine();
        var storage = new JsonStorage();
        List<ShoppingList> shoppingLists = await storage.LoadAsync();

        List<ShoppingList> shoppingListToRemove = shoppingLists.Where(list => list.Name == shoppingListName).ToList();
        
        if (shoppingListToRemove.Count != 0)
        {

            foreach (var item in shoppingListToRemove)
            {
                shoppingLists.Remove(item);
            }

            await storage.SaveAsync(shoppingLists);
            Console.WriteLine("A bevásárlólista sikeresen törölve.");
        }
        else
        {
            Console.WriteLine("Nem található ilyen nevű bevásárlólista.");
        }
        Console.WriteLine("Nyomj meg egy gombot a visszalépéshez...");
        Console.ReadKey();
        Menu.ShowMenu();
    }
}
