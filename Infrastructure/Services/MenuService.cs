
using Infrastructure.Entities;
using System.Diagnostics;


namespace Infrastructure.Services;

public class MenuService(ProductService productService)
{
    private readonly ProductService _productService = productService;

    public void ShowMainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("---MENY---");
            Console.WriteLine();
            Console.WriteLine("1. Skapa ny produkt");
            Console.WriteLine("2. Visa alla produkter");
            Console.WriteLine("3. Hitta en produkt");
            Console.WriteLine("4. Uppdatera en produkt");
            Console.WriteLine("5. Ta bort en produkt");

            var option = Console.ReadLine();

            switch (option)
            {
                
                default:
                    Console.WriteLine("Välj ett av alternativen.");
                    break;

            }

            Console.ReadKey();

        }
    }

    

    
}


            

