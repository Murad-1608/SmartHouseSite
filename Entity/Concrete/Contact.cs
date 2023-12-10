using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Contact : IEntity
    {
        public Guid Id { get; set; }
        public string Tiktok { get; set; }
        public string LinkedIn { get; set; }
        public string Telegram { get; set; }
        public string Whatsapp { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string Youtube { get; set; }
    }
}
