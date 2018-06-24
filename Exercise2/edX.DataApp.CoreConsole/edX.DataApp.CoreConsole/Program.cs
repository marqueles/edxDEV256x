using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace edX.DataApp.CoreConsole
{
    class Program
    {
        static async Task RunAsync()
        {
            using(ContosoContext context = new ContosoContext())
            {
                var creator = context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                await creator.ExistsAsync();
                Console.WriteLine("Connection Succesfull");

            }
        }
        static void Main(string[] args)
        {
            RunAsync().Wait();
            Console.WriteLine("Application has completed execution. Press any key to exit.");
            Console.ReadKey();

        }
    }
}
