namespace lab4.Models
{
    public class Trains
    {
        public int train_id { get; set; }
        public int train_number { get; set; }
        public string train_type { get; set; }

        public ICollection<Tickets> Ticket { get; set; }
    }
}
