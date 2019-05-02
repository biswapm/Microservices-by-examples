using System.Linq;
using OnlineHotel.Infra.Domain.Interfaces;
using OnlineHotel.Infra.Domain.Models;
using OnlineHotel.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace OnlineHotel.Infra.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(OnlineHotelContext context)
            : base(context)
        {

        }

        public Customer GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        }
    }
}
