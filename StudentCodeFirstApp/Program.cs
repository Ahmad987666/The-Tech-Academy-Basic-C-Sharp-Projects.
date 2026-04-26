using System;
using Microsoft.EntityFrameworkCore;

// This class represents one student in the database
public class Student
{
    // This property becomes the primary key because it is named Id
    public int Id { get; set; }

    // This property stores the student's first name
    public string FirstName { get; set; } = "";

    // This property stores the student's last name
    public string LastName { get; set; } = "";
}

// This class represents the database connection and tables
public class StudentContext : DbContext
{
    // This DbSet becomes the Students table in the database
    public DbSet<Student> Students { get; set; }

    // This method configures which database EF Core will use
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // This tells EF Core to create/use a SQLite database file named Student.db
        optionsBuilder.UseSqlite("Data Source=Student.db");
    }
}

// This is the main class where the program starts
class Program
{
    // Main method runs when the console app starts
    static void Main(string[] args)
    {
        // Create a database context object so we can work with the database
        using StudentContext context = new StudentContext();

        // Make sure the database is created if it does not already exist
        context.Database.EnsureCreated();

        // Create one Student object
        Student student = new Student()
        {
            // Set the student's first name
            FirstName = "John",

            // Set the student's last name
            LastName = "Doe"
        };

        // Add the student object to the Students table
        context.Students.Add(student);

        // Save the new student record to the database
        context.SaveChanges();

        // Display a message so we know the student was added
        Console.WriteLine("One student was added to the Student database.");
    }
}