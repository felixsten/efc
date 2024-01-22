using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

public class ProductEntity
{
    [Key]
    public string ArticleNumber { get; set; } = null!;

    [Required]
    public string Title { get; set; } = null!;


    public string? Description { get; set; }
    public string? SpecificationAsJson { get; set; }

    [Required]
    [Column(TypeName = "money")]
    public decimal Price { get; set; }

    [Required]
    [ForeignKey(nameof(CategoryEntity))]
    public int CategoryId { get; set; }

    public virtual CategoryEntity Category { get; set; } = null!;
}
