using System;
using System.ComponentModel.DataAnnotations;

namespace CarInsurance.Models
{
    // This model represents one insurance customer
    public class Insuree
    {
        // Primary key for the database
        public int Id { get; set; }

        // Customer first name
        [Required]
        public string FirstName { get; set; } = "";

        // Customer last name
        [Required]
        public string LastName { get; set; } = "";

        // Customer email
        [Required]
        public string EmailAddress { get; set; } = "";

        // Customer date of birth
        [Required]
        public DateTime DateOfBirth { get; set; }

        // Car year
        [Required]
        public int CarYear { get; set; }

        // Car make
        [Required]
        public string CarMake { get; set; } = "";

        // Car model
        [Required]
        public string CarModel { get; set; } = "";

        // Whether the customer has had a DUI
        public bool DUI { get; set; }

        // Number of speeding tickets
        public int SpeedingTickets { get; set; }

        // Whether the customer wants full coverage
        public bool FullCoverage { get; set; }

        // Final calculated quote
        public decimal Quote { get; set; }
    }
}