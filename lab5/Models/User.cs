namespace lab5.Models
{
    public class User
    {
        public int userId { get; set; }
        public string UserName { get; set; }
        public string Adress { get; set; }
        public string Number { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
