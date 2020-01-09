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
            listEmployee[0] = new Employee(1, "Employee1", "11111111A");
            listEmployee[1] = new Employee(1, "Employee2", "22222222B");
            listEmployee[2] = new Employee(1, "Employee3", "33333333C");
            listEmployee[3] = new Employee(1, "Employee4", "44444444D");

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
            var queryLambda = employeeCache.Where(emp => (emp.Value.Name == name)).Select(emp => emp.Value.DNI);

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
