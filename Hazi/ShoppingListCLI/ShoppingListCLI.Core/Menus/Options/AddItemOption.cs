using System;
using System.Collections.Generic;
using System.Text;

using ShoppingListCLI.Core.Storage;
using ShoppingListCLI.ShoppingListCLI.Core.Models;
using ShoppingListCLI.ShoppingListCLI.Core.Services;

namespace ShoppingListCLI.ShoppingListCLI.Core.Menus.Options;

public class AddItemOption(IStorage storage) : IOption
{
    private readonly IStorage _storage = storage;

    public async void Open()
    {
        Console.Clear();

        List<ShoppingList> shoppingLists = await _storage.LoadAsync();

        Console.WriteLine("===========================\n" +
                  "Új bevásárlólista létrehozása\n" +
                  "===========================");

        ShoppingList shoppingList = AddItemOptionService.ReadUserShoppingListInput();

        shoppingLists.Add(shoppingList);
        await _storage.SaveAsync(shoppingLists);
    }
}
