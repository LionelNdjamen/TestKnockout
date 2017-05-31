using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Getting_Start.Models
{
    //[Table("Customer")]
    public class Customer
    {
        //[Key]
        //[DataMember(Name = "CustomerID", EmitDefaultValue = true, Order = 1, IsRequired = true)]
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public bool Suppression { get; set; }
        public string Sexe { get; set; }

        public Customer() { }

        public Customer(int id, string firstName, string lastName, int age, bool suppression, string sexe)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Suppression = suppression;
            Sexe = sexe;
        }
        public Customer(string firstName, string lastName, int age, bool suppression, string sexe)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Suppression = suppression;
            Sexe = sexe;
        }

        public Customer(Customer c)
        {
            Id = c.Id;
            FirstName = c.FirstName;
            LastName = c.LastName;
            Age = c.Age;
            Suppression = c.Suppression;
            Sexe = c.Sexe;
        }

    }
}