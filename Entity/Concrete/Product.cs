using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Product : IEntity
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string PhotoUrl { get; set; }

        public virtual Category Category { get; set; }
        public List<Image> Images { get; set; }
    }
}
