using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Image : IEntity
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }

        public Product Product { get; set; }
    }
}
