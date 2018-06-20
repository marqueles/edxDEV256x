using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace edX.DataApp.Lab.Console
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
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT COUNT(CustomerId) AS CustomerCount, SalesPerson AS Contributor FROM Customers GROUP BY SalesPerson ORDER BY CustomerCount DESC";
                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    System.Console.WriteLine($"Contributor: {await reader.GetFieldValueAsync<string>(1),30}\t{await reader.GetFieldValueAsync<int>(0):000} Customers");
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
