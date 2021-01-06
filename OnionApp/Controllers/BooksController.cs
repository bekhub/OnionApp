using System.Collections.Generic;
using Domain.Core;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace OnionApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookRepository _repository;
        
        private readonly IOrderService _orderService;

        public BooksController(OrderContext context, IOrderService orderService)
        {
            _repository = new BookRepository(context);
            _orderService = orderService;
        }
        
        [HttpGet]
        public IEnumerable<Book> Books()
        {
            return _repository.List();
        }
        
        [HttpPost]
        public void Buy(int id)
        {
            var book = _repository.Get(id);
            _orderService.MakeOrder(book);
        }
    }
}
