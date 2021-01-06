using Domain.Core;

namespace Infrastructure.Data
{
    public class BookRepository : BaseRepository<Book>
    {
        public BookRepository(OrderContext context) : base(context) { }
    }
}
