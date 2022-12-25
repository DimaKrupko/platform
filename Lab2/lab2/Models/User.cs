namespace lab2.Models
{
    public partial class User
    {
        public int userId { get; set; }
        public string UserName { get; set; }
        public string Adress { get; set; }
        public string Number { get; set; }

        public ICollection<tickets> Ticket { get; set; }
    }
}