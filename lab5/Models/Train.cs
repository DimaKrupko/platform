using System.Reflection.PortableExecutable;

namespace lab5.Models
{
    public class Train
    {
        public int train_id { get; set; }
        public int train_number { get; set; }
        public string train_type { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
