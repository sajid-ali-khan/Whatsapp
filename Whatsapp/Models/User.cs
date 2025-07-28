namespace Whatsapp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Phone { get; set; }

        public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
