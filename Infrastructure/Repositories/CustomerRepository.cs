
using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class CustomerRepository(DataContext context) : BaseRepository<CustomerEntity>(context)
    {
        private readonly DataContext _context = context;

        public override IEnumerable<CustomerEntity> GetAll()
        {
            return _context.Customers.Include(i => i.Address).Include(i => i.Role).ToList();
        }

        public override CustomerEntity GetOne(Expression<Func<CustomerEntity, bool>> expression)
        {
            var entity = _context.Customers.Include(i => i.Address).Include(i => i.Role).FirstOrDefault(expression);
            return entity!;
        }
    }
}
