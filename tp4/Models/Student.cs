using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace tp4.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public long phone_number { get; set; }
        public string university { get; set; }
        public string course { get; set; }
        public string timestamp { get; set; }

        public Student(int id, string firstName, string lastName)
        {
            id = id;
            firstName = firstName;
            lastName = lastName;
           
        }
    }
}