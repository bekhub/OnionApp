using Domain.Core;

namespace Infrastructure.Data
{
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(OrderContext context) : base(context) { }
    }
}
