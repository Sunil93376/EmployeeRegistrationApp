using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegistrationApp.Domain.Entities
{
    public class Employee
    {

        public int Id { get; private set; }
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? Email { get; private set; }

        private Employee() { }

        public Employee(string firstName, string lastName, string email)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name is required.", nameof(firstName));
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name is required.", nameof(lastName));
            if (!new EmailAddressAttribute().IsValid(email))
                throw new ArgumentException("Invalid email address.", nameof(email));

            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public void Update(string firstName, string lastName, string email)
        {
            // Repeat validation...
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
