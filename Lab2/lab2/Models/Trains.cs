namespace lab2.Models
{
    public partial class Trains
    {

        public int train_id { get; set; }
        public int train_number { get; set; }
        public string train_type { get; set; }

        public ICollection<tickets> Ticket { get; set; }
    }
}
