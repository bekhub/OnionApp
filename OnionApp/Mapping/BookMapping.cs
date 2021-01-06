using AutoMapper;
using Domain.Core;
using OnionApp.Models;

namespace OnionApp.Mapping
{
    public class BookMapping : Profile
    {
        public BookMapping()
        {
            CreateMap<Book, BookModel.List>();
            CreateMap<Book, BookModel.Get>();
            CreateMap<BookModel.Add, Book>()
                .ForMember(x => x.Id, o => o.Ignore());
            CreateMap<BookModel.Edit, Book>()
                .ForMember(x => x.Id, o => o.Ignore());
        }
    }
}
