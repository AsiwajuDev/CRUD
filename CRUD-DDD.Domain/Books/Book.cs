using CRUD_DDD.Domain.Common;

namespace CRUD_DDD.Domain.Books
{
    public class Book : Entity
    {        
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string Category { get; set; }
    }
}
