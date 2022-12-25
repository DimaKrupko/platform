using System.Data.SqlClient;

class Ticket
{
    static void Main()
    {
        string connectionString = "Data Source=localhost;Database=TicketDB;Trusted_Connection=True;";

        string queryString =
            "SELECT * from tickets where userId = 2 ";

        using (SqlConnection connection =
            new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(queryString, connection);


            try
            {
                connection.Open();
                SqlDataReader ticket = command.ExecuteReader();
                while (ticket.Read())
                {
                    Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}", ticket[0], ticket[1], ticket[2], ticket[3], ticket[4], ticket[5], ticket[6], ticket[7], ticket[8]);
                }
                ticket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
