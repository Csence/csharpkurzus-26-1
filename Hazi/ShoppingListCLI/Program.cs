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
        Menu menu = new Menu();
        menu.Start();
    }
}
