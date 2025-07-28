using Microsoft.EntityFrameworkCore;

namespace Whatsapp.Data
{
    public class WhatsappDbContext: DbContext
    {
        public WhatsappDbContext(DbContextOptions<WhatsappDbContext> options) : base(options)
        {
        }


    }
}
