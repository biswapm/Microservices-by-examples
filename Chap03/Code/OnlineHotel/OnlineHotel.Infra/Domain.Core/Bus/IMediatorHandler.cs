using System.Threading.Tasks;
using OnlineHotel.Infra.Domain.Core.Commands;
using OnlineHotel.Infra.Domain.Core.Events;


namespace OnlineHotel.Infra.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
