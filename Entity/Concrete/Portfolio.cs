using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Portfolio : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
    }
}
