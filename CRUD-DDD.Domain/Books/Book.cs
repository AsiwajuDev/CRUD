using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_DDD.Domain.Books
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string Category { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }
}
