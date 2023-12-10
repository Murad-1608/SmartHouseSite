using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Category : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Information { get; set; }

        public List<Product> Products { get; set; }


    }
}
