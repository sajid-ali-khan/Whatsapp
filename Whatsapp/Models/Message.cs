namespace Whatsapp.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public int SenderId { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; } = DateTime.Now;
        public Contact Contact { get; set; }
    }
}
