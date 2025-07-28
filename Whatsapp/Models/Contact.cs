namespace Whatsapp.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public int User1Id { get; set; }
        public int User2Id { get; set; }
        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
