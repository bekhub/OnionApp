namespace OnionApp.Models
{
    public class BookModel
    {
        public class Add
        {
            public string Name { get; set; }

            public decimal Price { get; set; }
        }
        
        public class Base : Add
        {
            public int Id { get; set; }
        }
        
        public class List : Base { }
        
        public class Edit : Base { }
        
        public class Get : Edit { }
    }
}
