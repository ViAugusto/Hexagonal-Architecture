using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string? Name { get; private set; }
        public string? Email { get; private set; }
        public string? City { get; private set; }

        public User(Guid id, string name, string email, string city)
        {
            Id = id;
            Name = name;
            Email = email;
            City = city;
        }

        public static User CreateUser(string name, string email, string city)
        {
            var id = Guid.NewGuid();
            Validate(name, email, city);
            return new User(id, name, email, city);
        }

        private static void Validate(string name, string email, string city)
        {
            if (string.IsNullOrEmpty(name) || name.Length < 3)
                throw new InvalidNameException("Invalid Name");

            if (string.IsNullOrEmpty(email) || !email.Contains('@'))
                throw new InvalidEmailException("Invalid Email");

            if (string.IsNullOrEmpty(city) || city.Length < 3)
                throw new InvalidCityException("Invalid City");
        }

    }
}
