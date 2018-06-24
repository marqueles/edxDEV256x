using System;

namespace edX.DataApp.Lab.CoreConsole
{
    class Program
    {
        
        static void Main(string[] args)
        {
            using(ContosoContext context = new ContosoContext())
            {
                Console.WriteLine("Connection Succesful!");
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine($"{"Product",10}\t{"Price",10}\t{"Cost",10}\t{"Profit",10}");
                Console.WriteLine("---------------------------------------------------------");
                foreach (var product in context.Products)
                {
                    Console.WriteLine($"{product.ProductNumber,10}\t{product.ListPrice,10:C}\t{product.StandardCost,10:C}\t{(product.ListPrice - product.StandardCost),10:C}");
                    
                }
                Console.WriteLine("------------------------------------------------------------");
            }
            System.Console.WriteLine("Application has completed execution. Press any key to exit.");
            System.Console.ReadKey();

        }
    }
}
