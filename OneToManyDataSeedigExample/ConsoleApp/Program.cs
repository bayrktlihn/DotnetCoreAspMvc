using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DbContextOptions<MyDbContext> options = new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;Port=3306;Database=weqe;Uid=root;Pwd=parolagelecek;").Options;

            MyDbContext myDbContext = new MyDbContext(options);


            IInstructorRepository instructorRepository = new InstructorRepository(myDbContext);

            Instructor instructor = instructorRepository.FindById(1);

            System.Console.WriteLine(instructor.FirstName);
            System.Console.WriteLine(instructor.LastName);
            System.Console.WriteLine(instructor.Courses[0].Instructor.FirstName);

            
        }
    }
}
