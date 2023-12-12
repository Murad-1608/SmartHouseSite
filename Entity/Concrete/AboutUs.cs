using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class AboutUs : IEntity
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string YoutubeLink { get; set; }
    }
}
