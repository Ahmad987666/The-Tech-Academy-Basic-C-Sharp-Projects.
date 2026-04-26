using System;

namespace EmployeeComparisonApp
{
    //employee class with properties for name and ID
    public class Employee
    {
        //creating properties for the employee's ID, first name, and last name
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //overloading the == operator to compare two Employee objects based on their ID
    public static bool operator ==(Employee emp1, Employee emp2)
        {
            //if both employees are null, they are considered equal
            if (ReferenceEquals(emp1, emp2))
            {
                return true;
            }

            //if one is null and the other is not, they are not equal
            if (emp1 is null || emp2 is null)
            {
                return false;
            }

            //compare the Id properties
            return emp1.Id == emp2.Id;
        }

    //overloading the != operator to compare two Employee objects based on their ID
    public static bool operator !=(Employee emp1, Employee emp2)
        {
            //return the opposite of the == operator
            return !(emp1 == emp2);
        }

        //override the Equals() for consistency with the overloaded operators
        public override bool Equals(object obj)
        {
            //check if the object is an Employee and compare based on ID
            if (obj is Employee otherEmployee)
            {
                //return true if the IDs are the same, false otherwise
                return this.Id == otherEmployee.Id;
            }
            //if the object is not an Employee, return false
            return false;
        }

        //override GetHashCode() for consistency with Equals()
        public override int GetHashCode()
        {
            //return the hash code of the Id property
            return Id.GetHashCode();
        }
    }

    public class Program
    {
        //creating the Main method to test the Employee class and overloaded operators
        public static void Main(string[] args)
        {
            //creating employee 1
            Employee employee1 = new Employee
            {
                Id = "001",
                FirstName = "Alice",
                LastName = "Smith"
            };

            //creating employee 2 with the same ID as employee 1
            Employee employee2 = new Employee
            {
                Id = "001",
                FirstName = "Bob",
                LastName = "Johnson"
            };

            //comparing employee 1 and employee 2 using the overloaded == operator
            bool areEqual = employee1 == employee2;
            //displaying the result of the comparison
            Console.WriteLine($"Are employee 1 and employee 2 equal? {areEqual}");

            //comparing employee 1 and employee 2 using the overloaded != operator
            bool areNotEqual = employee1 != employee2;
            //displaying the result of the comparison
            Console.WriteLine($"Are employee 1 and employee 2 not equal? {areNotEqual}");
        }
    }
}