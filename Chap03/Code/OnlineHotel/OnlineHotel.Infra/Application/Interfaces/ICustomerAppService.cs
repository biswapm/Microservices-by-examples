using System;
using System.Collections.Generic;
using OnlineHotel.Infra.Application.EventSourcedNormalizers;
using OnlineHotel.Infra.Application.ViewModels;

namespace OnlineHotel.Infra.Application.Interfaces
{
    public interface ICustomerAppService : IDisposable
    {
        void Register(CustomerViewModel customerViewModel);
        IEnumerable<CustomerViewModel> GetAll();
        CustomerViewModel GetById(Guid id);
        void Update(CustomerViewModel customerViewModel);
        void Remove(Guid id);
        IList<CustomerHistoryData> GetAllHistory(Guid id);
    }
}
