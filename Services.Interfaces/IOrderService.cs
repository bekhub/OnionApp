using Domain.Core;

namespace Services.Interfaces
{
    public interface IOrderService
    {
        void MakeOrder(Book book);
    }
}
