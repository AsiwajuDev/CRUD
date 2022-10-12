namespace CRUD_DDD.Domain.Common
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
