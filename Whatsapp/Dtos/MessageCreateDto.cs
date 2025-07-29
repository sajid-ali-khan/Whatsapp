namespace Whatsapp.Dtos
{
    public class MessageCreateDto
    {
        public int ContactId { get; set; }
        public int SenderId { get; set; }

        public string Content { get; set; }
    }
}
