using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

using ShoppingListCLI.ShoppingListCLI.Core.Models;

namespace ShoppingListCLI.Core.Storage;

public class JsonStorage : IStorage
{
    public async Task<List<ShoppingList>> LoadAsync()
    {
        if (!File.Exists("shoppingList.json"))
        {
            return new List<ShoppingList>();
        }

        string json = File.ReadAllText("shoppingList.json");

        return JsonSerializer.Deserialize<List<ShoppingList>>(json) ?? new List<ShoppingList>();

    }

    public async Task SaveAsync(List<ShoppingList> shoppingList)
    {
        string json = JsonSerializer.Serialize(shoppingList);

        File.WriteAllText("shoppingList.json", json);
    }
}
