using Apache.Ignite.Core;
using Apache.Ignite.Core.Cache;
using System;

namespace Node1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the List of Employees
            Employee[] listEmployee = new Employee[4];
            listEmployee[0] = new Employee(1, "Employee1", "11111111A");
            listEmployee[1] = new Employee(2, "Employee2", "22222222B");
            listEmployee[2] = new Employee(3, "Employee3", "33333333C");
            listEmployee[3] = new Employee(4, "Employee4", "44444444D");

            // Start Ignite Node
            IIgnite ignite = Ignition.Start();

            // Create the Sharing Memory Cache between Nodes for Employees
            ICache<int, Employee> employeeCache = ignite.GetOrCreateCache<int, Employee>("myCache");

            // Publish the list in cache
            for (int i = 0; i < 4; i++)
            {
                employeeCache.Put(listEmployee[i].Id, listEmployee[i]);
            }

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
