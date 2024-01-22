
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

[Index(nameof(CategoryName), IsUnique = true)]
public class CategoryEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string CategoryName { get; set; } = null!;


    public virtual ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();
}
