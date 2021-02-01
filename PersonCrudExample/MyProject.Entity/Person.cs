using System;

namespace MyProject.Entity
{
    public class Person
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}