using System;
using System.Collections.Generic;
using System.Text;

using ShoppingListCLI.ShoppingListCLI.Core.Models;

namespace ShoppingListCLI.Core.Storage;

internal interface IStorage
{
    Task SaveAsync(List<ShoppingList> shoppingList);

    Task<List<ShoppingList>> LoadAsync();
}
