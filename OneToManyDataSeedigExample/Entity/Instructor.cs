using System.Collections.Generic;

namespace Entity
{
    public class Instructor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Course> Courses { get; set; }
    }
}