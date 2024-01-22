using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public partial class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public virtual DbSet<ProductEntity> Products { get; set; }
    public virtual DbSet<CategoryEntity> Categories { get; set; }


}
