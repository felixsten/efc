
using Infrastructure.Entities;
using System.Diagnostics;


namespace Infrastructure.Services;

public class MenuService
{
    private readonly ProductService _productService;
    private readonly CustomerService _customerService;

    public MenuService(ProductService productService, CustomerService customerService)
    {
        _productService = productService;
        _customerService = customerService;
    }

    public void ShowMainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("---MENY---");
            Console.WriteLine();
            Console.WriteLine("1. Skapa ny produkt");
            Console.WriteLine("2. Visa alla produkter");
            Console.WriteLine("3. Uppdatera en produkt");
            Console.WriteLine("4. Ta bort en produkt");
            Console.WriteLine("5. Skapa ny kund");
            Console.WriteLine("6. Visa alla kunder");
            Console.WriteLine("7. Uppdatera kund)");
            Console.WriteLine("8. Ta bort kund");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateProductMenu();
                    break;
                case "2":
                    GetProductsMenu();
                    break;
                case "3":
                    UpdateProductMenu();
                    break;
                case "4":
                    DeleteProductMenu();
                    break;
                case "5":
                    CreateCustomerMenu();
                    break;
                case "6":
                    GetCustomersMenu();
                    break;
                case "7":
                    UpdateCustomerMenu();
                    break;
                case "8":
                    DeleteCustomerMenu();
                    break;

                
                default:
                    Console.WriteLine("Välj ett av alternativen.");
                    break;

            }

            Console.ReadKey();

        }
    }

    public void CreateProductMenu()
    {
        Console.Clear();
        Console.WriteLine("Skapa produkt");

        Console.WriteLine("Produkt titel: ");
        var title = Console.ReadLine()!;

        Console.WriteLine("Produkt pris: ");
        decimal price = decimal.Parse(Console.ReadLine()!);

        Console.WriteLine("Produkt kategori: ");
        var categoryName = Console.ReadLine()!;

        var result = _productService.CreateProduct(title, price, categoryName);
        if (result != null)
        {
            Console.Clear();
            Console.WriteLine("Produkt skapades.");
            Console.ReadKey();
        }

    }

    public void GetProductsMenu()
    {
        Console.Clear();
        var products = _productService.GetProducts();
        foreach(var product in products)
        {
            Console.WriteLine($"{product.Title} - {product.Category.CategoryName} ({product.Price} sek)");
        }

        Console.ReadKey();
    }


    public void UpdateProductMenu()
    {
        Console.Clear();
        Console.Write("Ange produkt ID");
        var id = int.Parse(Console.ReadLine()!);
        var product = _productService.GetProductById(id);

        if (product != null)
        {
            Console.WriteLine($"{product.Title} - {product.Category.CategoryName} ({product.Price} sek)");
            Console.WriteLine();

            Console.Write("Ange ny produkt titel: ");
            product.Title = Console.ReadLine()!;

            var newProduct = _productService.UpdateProduct(product);
            Console.WriteLine($"{product.Title} - {product.Category.CategoryName} ({product.Price} sek)");
        }
        else
        {
            Console.WriteLine("Ingen produkt hittades");
        }

        Console.ReadKey();

    }

    public void DeleteProductMenu()
    {
        Console.Clear();
        Console.Write("Ange produkt ID");
        var id = int.Parse(Console.ReadLine()!);
        var product = _productService.GetProductById(id);

        if (product != null)
        {
            _productService.DeleteProduct(product.Id);
            Console.WriteLine("Produkt togs bort");
        }
        else
        {
            Console.WriteLine("Ingen produkt hittades");
        }

        Console.ReadKey();

    }


    public void CreateCustomerMenu()
    {
        Console.Clear();
        Console.WriteLine("Lägg till ny kund");

        Console.WriteLine("Förnamn: ");
        var firstName = Console.ReadLine()!;

        Console.WriteLine("Efternamn: ");
        var lastName = Console.ReadLine()!;

        Console.WriteLine("Email: ");
        var email = Console.ReadLine()!;

        Console.WriteLine("Gata: ");
        var streetName = Console.ReadLine()!;

        Console.WriteLine("Postkod: ");
        var postalCode = Console.ReadLine()!;

        Console.WriteLine("Stad: ");
        var city = Console.ReadLine()!;

        Console.WriteLine("Roll: ");
        var roleName = Console.ReadLine()!;





        var result = _customerService.CreateCustomer(firstName, lastName, email, roleName, streetName, postalCode, city);
        if (result != null)
        {
            Console.Clear();
            Console.WriteLine("Kund skapades.");
            Console.ReadKey();
        }

    }

    public void GetCustomersMenu()
    {
        Console.Clear();
        var customers = _customerService.GetCustomers();
        foreach (var customer in customers)
        {
            Console.WriteLine($"{customer.FirstName} {customer.LastName} ({customer.Role.RoleName})");
            Console.WriteLine($"{customer.Address.StreetName}, {customer.Address.PostalCode}, {customer.Address.City}");
        }

        Console.ReadKey();
    }

    public void UpdateCustomerMenu()
    {
        Console.Clear();
        Console.Write("Ange kundens email");
        var email = Console.ReadLine()!;

        var customer = _customerService.GetCustomerByEmail(email);

        if (customer != null)
        {
            Console.WriteLine();
            Console.WriteLine($"{customer.FirstName} {customer.LastName} ({customer.Role.RoleName})");
            Console.WriteLine($"{customer.Address.StreetName}, {customer.Address.PostalCode}, {customer.Address.City}");
            Console.WriteLine();

            Console.Write("Ange nytt efternamn: ");
            customer.LastName = Console.ReadLine()!;

            var newCustomer = _customerService.UpdateCustomer(customer);
            Console.WriteLine($"{newCustomer.FirstName} {newCustomer.LastName} ({newCustomer.Role.RoleName})");
            Console.WriteLine($"{newCustomer.Address.StreetName}, {newCustomer.Address.PostalCode}, {newCustomer.Address.City}");
        }
        else
        {
            Console.WriteLine("Ingen kund hittades");
        }

        Console.ReadKey();
    }

    public void DeleteCustomerMenu()
    {
        Console.Clear();
        Console.Write("Ange kundens email");
        var email = Console.ReadLine()!;

        var customer = _customerService.GetCustomerByEmail(email);

        if (customer != null)
        {
            _customerService.DeleteCustomer(customer.Id);
            Console.WriteLine("Kund togs bort");
        }
        else
        {
            Console.WriteLine("Ingen produkt hittades");
        }

        Console.ReadKey();

    }

}




