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

        try
        {
            string json = File.ReadAllText("shoppingList.json");

            return JsonSerializer.Deserialize<List<ShoppingList>>(json) ?? new List<ShoppingList>();
        }
        catch (IOException e)
        {
            Console.WriteLine("Hiba történt a fájl olvasása közben: " + e.Message);
            return new List<ShoppingList>();
        }
        catch (JsonException e)
        {
            Console.WriteLine("Hiba történt a JSON deszerializálása közben: " + e.Message);
            return new List<ShoppingList>();
        }
        catch (Exception e)
        {
            Console.WriteLine("Váratlan hiba történt: " + e.Message);
            return new List<ShoppingList>();
        }
    }

    public async Task SaveAsync(List<ShoppingList> shoppingList)
    {
        try 
        {
            string json = JsonSerializer.Serialize(shoppingList);

            File.WriteAllText("shoppingList.json", json);
        }
        catch (IOException e)
        {
            Console.WriteLine("Hiba történt a fájl írása közben: " + e.Message);
        }
        catch (JsonException e)
        {
            Console.WriteLine("Hiba történt a JSON szerializálása közben: " + e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Váratlan hiba történt: " + e.Message);
        }
    }
}
