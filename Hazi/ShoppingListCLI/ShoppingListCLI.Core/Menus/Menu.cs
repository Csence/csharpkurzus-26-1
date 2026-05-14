using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingListCLI.ShoppingListCLI.Core.Menus;

public static class Menu
{
    public static void ShowMenu()
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
}
