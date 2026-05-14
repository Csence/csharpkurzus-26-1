using System;
using System.Collections.Generic;
using System.Text;

using ShoppingListCLI.Core.Storage;
using ShoppingListCLI.ShoppingListCLI.Core.Models;
using ShoppingListCLI.ShoppingListCLI.Core.Services;

namespace ShoppingListCLI.ShoppingListCLI.Core.Menus.Options;

internal class ViewItemsOption(IStorage storage) : IOption
{
    private readonly IStorage _storage = storage;

    public async void Open()
    {
        List<ShoppingList> shoppingLists = await _storage.LoadAsync();

        Console.Clear();
        ViewItemsOptionService.
                ShowUserShoppingLists(shoppingLists);

        Console.WriteLine("Nyomj meg egy gombot a visszalépéshez...");
        Console.ReadKey();
        Menu.ShowMenu();
    }
}
