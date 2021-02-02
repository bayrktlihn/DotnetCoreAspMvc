using System.Collections.Generic;
using System.Linq;
using Data;
using Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebUI
{
    public static class DataSeeding
    {
        public static void Seed(this IApplicationBuilder applicationBuilder){
            IServiceScope scope = applicationBuilder.ApplicationServices.CreateScope();
            MyDbContext myDbContext = scope.ServiceProvider.GetService<MyDbContext>();

            myDbContext.Database.Migrate();


            List<Instructor> instructors = new List<Instructor>();
            instructors.Add(new Instructor{FirstName = "Alian", LastName = "Bayraktar", Email = "alihan.bayraktar@siemens.com"});
            instructors.Add(new Instructor{FirstName = "Mina", LastName = "Turgut", Email = "mina.turgut@siemens.com"});
            instructors.Add(new Instructor{FirstName = "Serdar", LastName = "Gürleyen", Email = "serdar.gurleyen@siemens.com"});
            instructors.Add(new Instructor{FirstName = "Zeki", LastName = "Gülen", Email = "zeki.gulen@siemens.com"});
            instructors.Add(new Instructor{FirstName = "Adil", LastName = "Özçaycı", Email = "adil.ozcayci@siemens.com"});


            List<Course> courses = new List<Course>();
            courses.Add(new Course{Title = "Scrum", Instructor = instructors[1]});
            courses.Add(new Course{Title = "Spring", Instructor = instructors[0]});
            courses.Add(new Course{Title = "Java", Instructor = instructors[0]});
            courses.Add(new Course{Title = "Csharp", Instructor = instructors[1]});
            courses.Add(new Course{Title = "Design Patterns", Instructor = instructors[2]});
            courses.Add(new Course{Title = "Html Css Javascript", Instructor = instructors[3]});
            


            if(myDbContext.Database.GetPendingMigrations().Count() == 0){
                if(myDbContext.Instructors.Count() == 0){
                    myDbContext.Instructors.AddRange(instructors);
                }

                if(myDbContext.Courses.Count() == 0){
                    myDbContext.Courses.AddRange(courses);
                }

                myDbContext.SaveChanges();
                
            }
           

        }
    }
}