using OnlineHotel.Infra.Domain.Interfaces;
using OnlineHotel.Infra.Data.Context;

namespace OnlineHotel.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlineHotelContext _context;

        public UnitOfWork(OnlineHotelContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
