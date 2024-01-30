using Infrastructure.Contexts;
using Infrastructure.Dtos;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class ProductRepository(DataContext context) : BaseRepository<ProductEntity>(context)
{
    private readonly DataContext _context = context;

    public override IEnumerable<ProductEntity> GetAll()
    {
        return _context.Products.Include(i => i.Category).ToList();
    }

    public override ProductEntity GetOne(Expression<Func<ProductEntity, bool>> expression)
    {
        var entity = _context.Products.Include(i => i.Category).FirstOrDefault(expression);
        return entity!;
    }
}
