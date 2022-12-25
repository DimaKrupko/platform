using lab2.Models;
using Microsoft.EntityFrameworkCore;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

string connectionString = "Data Source=localhost;Database=TicketDB;Integrated Security=True;Trust Server Certificate=true";
var optionsBuilder = new DbContextOptionsBuilder<TicketContext>();
var options = optionsBuilder
    .UseSqlServer(connectionString)
    .Options;
var db = new TicketContext(options);

var tickets = db.Tickets;
var user = db.User;
var trains = db.Trains;

foreach (var ticket in tickets)
{
    Console.WriteLine("\t{0}\t{1}\t\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}",
       ticket.carriage_number, ticket.carriage_type, ticket.date_departure, ticket.time_arrival,  ticket.destination, ticket.distance, ticket.cost, ticket.surcharge_urgency, ticket.surcharge_type
     );
}
foreach (var us in user)
{
    Console.WriteLine("\t{0}\t{1}\t{2}",
       us.UserName, us.Adress, us.Number
     );
}
foreach (var train in trains)
{
    Console.WriteLine("\t{0}\t{1}",
       train.train_number, train.train_type
     );
}
Console.ReadLine();
