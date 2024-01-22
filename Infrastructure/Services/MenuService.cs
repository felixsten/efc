using Infrastructure.Dtos;


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

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateNewProductMenu();
                    break;
                case "2":
                    ViewAllProductsMenu();
                    break;
                default:
                    Console.WriteLine("Välj ett av alternativen.");
                    break;

            }

            Console.ReadKey();

        }
    }

    public void CreateNewProductMenu()
    {
        var form = new Product();

        Console.Write("Ange artikelnummer för den nya produkten: ");
        form.ArticleNumber = Console.ReadLine()!;

        Console.Write("Ange titel på produkten: ");
        form.Title = Console.ReadLine()!;

        Console.Write("Ange beskrivning av produkten: ");
        form.Description = Console.ReadLine()!;

        Console.Write("Ange specifikation: ");
        form.SpecificationAsJson = Console.ReadLine()!;

        Console.Write("Ange pris på produkten: ");
        string input = Console.ReadLine()!;

        try
        {
            form.Price = decimal.Parse(input);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input");
        }

        Console.Write("Ange kategori som produkten tillhör: ");
        form.CategoryName = Console.ReadLine()!;

        Console.Clear();


        var result = _productService.CreateProduct(form);
        if (result)
            Console.WriteLine($"Produkten {form.ArticleNumber}, {form.Title} skapades.");
        else
            Console.WriteLine("Produkten kunde inte skapas");



        Console.ReadKey();
    }

    public void ViewAllProductsMenu()
    {
        var listproducts = _productService.GetAllProducts();

        Console.Clear();

        foreach (var product in listproducts)
        {
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine($"Artikelnummer: {product.ArticleNumber}, Titel: {product.Title}");
            Console.WriteLine($"Beskrivning: {product.Description}, Specifikation: {product.SpecificationAsJson}");
            Console.WriteLine($"Pris: {product.Price}");
            Console.WriteLine($"Kategori: {product.CategoryName}");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine(" ");
        }
    }

}
