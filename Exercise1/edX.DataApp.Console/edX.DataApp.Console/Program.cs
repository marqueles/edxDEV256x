using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace edX.DataApp.Console
{
    class Program
    {
        static async Task RunAsync()
        {
            string connectionString = @"Data Source=trialdbmarcosserver1.database.windows.net;Initial Catalog=ContosoDB;Persist Security Info=True;User ID=marcosjgserver1;Password=Nonsomus1";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                System.Console.WriteLine("Connection Successful");
                IEnumerable<Customer> customers = await new GenericQuery().RunLogic(connection);
                foreach(Customer customer in customers)
                {
                    System.Console.WriteLine($"[{customer.Id}] {customer.Company} {customer.Email} {customer.Phone}");
                }
            }
            
            
        }
        static void Main(string[] args)
        {
            RunAsync().Wait();
            System.Console.WriteLine("Application has completed execution. Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
