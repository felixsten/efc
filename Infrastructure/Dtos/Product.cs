namespace Infrastructure.Dtos;

public class Product
{
    public string ArticleNumber { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? SpecificationAsJson { get; set; }
    public decimal Price { get; set; }
    public string CategoryName { get; set; } = null!;
}
