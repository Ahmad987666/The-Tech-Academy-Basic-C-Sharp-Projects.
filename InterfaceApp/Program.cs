using System;

namespace InterfaceApp
{
    //defining an interface called IQuittable
    public interface IQuittable
    {
        //defining a method signature for Quit
        void Quit();
    }

    //employee class that implements the IQuittable interface
    public class Employee : IQuittable
    {
        //property for the employee's name
        public string Name { get; set; }
        //property for the employee's ID
        public string Id { get; set; }

        //implementing the Quit() method from the IQuittable interface
        public void Quit()
        {
            //displaying a message that the employee has quit
            Console.WriteLine($"{Name} with ID {Id} has quit.");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            //creating an instance of the Employee class
            Employee employee = new Employee
            {
                Name = "John Doe",
                Id = "12345"
            };

            //using polymorphism to treat the employee as an IQuittable
            IQuittable quittableEmployee = employee;

            //calling the Quit method to display the quit message
            quittableEmployee.Quit();
        }
    }
}