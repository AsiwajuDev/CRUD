using CRUD_DDD.Domain.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD_DDD.Persistence.Books
{
    public class BookEntityTypeConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)  
        {
            builder.ToTable("Books"); // the ToTable() method to specify the name of the table for the entity in the database

            builder.HasKey(a => a.Id); // the HasKey() method to specify the primary key for the entity  
        }
    }
}
