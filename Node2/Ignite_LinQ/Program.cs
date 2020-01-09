using Apache.Ignite.Core;
using Apache.Ignite.Core.Cache;
using System;
using System.Linq;

namespace Node2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the List of Employees
            Employee[] listEmployee = new Employee[4];
            listEmployee[0] = new Employee(5, "Employee5", "55555555E");
            listEmployee[1] = new Employee(6, "Employee6", "66666666F");
            listEmployee[2] = new Employee(7, "Employee7", "77777777G");
            listEmployee[3] = new Employee(8, "Employee8", "88888888H");

            // Start Ignite Node
            IIgnite ignite = Ignition.Start();

            // Create the Sharing Memory Cache between Nodes for Employees
            ICache<int, Employee> employeeCache = ignite.GetOrCreateCache<int, Employee>("myCache");

            // Publish the list in cache
            for (int i = 0; i < 4; i++)
            {
                employeeCache.Put(listEmployee[i].Id, listEmployee[i]);
            }

            // Ask for a name to search
            Console.WriteLine("Type the name of employeer");
            String name = Console.ReadLine();


            // Looking for it on cache. Can be used 2 methods
            //  1- Lambda
            //var queryLambda = employeeCache.Where(emp => (emp.Value.Name == name)).Select(emp => emp.Value.DNI);

            // 2 -  LINQ
            var queryLinQ = (from x in employeeCache where x.Value.Name == name select x.Value.DNI);


            // Showing the DNI associated to employee
            Console.WriteLine("The employee " + name + " has the DNI: " + queryLinQ.FirstOrDefault());

            // Wait for the window doesn't close
            Console.ReadKey();
        }
    }

    public class Employee
    {
        public int Id;
        public String Name;
        public String DNI;

        public Employee(int id, String n, String d)
        {
            this.Id = id;
            this.Name = n;
            this.DNI = d;
        }
    }
}
