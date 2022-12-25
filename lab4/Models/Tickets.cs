using System.Reflection.PortableExecutable;

namespace lab4.Models
{
    public  class Tickets
    {
        public int ticket_id { get; set; }
        public int carriage_number { get; set; }
        public string carriage_type { get; set; }
        public string date_departure { get; set; }
        public string time_arrival { get; set; }
        public string destination { get; set; }
        public string distance { get; set; }
        public int cost { get; set; }
        public int surcharge_urgency { get; set; }
        public int surcharge_type { get; set; }
        public int userId { get; set; }
        public int train_id { get; set; }


        public virtual Trains TrainsNavigation { get; set; }
        public virtual User UserNavigation { get; set; }
    }
}
