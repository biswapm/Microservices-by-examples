using OnlineHotel.Infra.Domain.Models;

namespace OnlineHotel.Infra.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByEmail(string email);
    }
}