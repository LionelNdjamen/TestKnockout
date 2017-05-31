using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Getting_Start.Models
{
    public class Sexe
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public Sexe() { }

        public Sexe(int id, string description)
        {
            Id = id;
            Description = description; 
        }
    }
}