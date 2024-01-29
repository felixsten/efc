
using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories
{
    public class CustomerRepository(DataContext context) : BaseRepository<CustomerEntity>(context)
    {
        private readonly DataContext _context = context;
    }
}
