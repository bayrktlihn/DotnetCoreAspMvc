using System.Collections.Generic;
using System.Linq;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class InstructorRepository : IInstructorRepository
    {

        private MyDbContext _myDbContext;
        public InstructorRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        

        public void Delete(Instructor entity)
        {
            _myDbContext.Instructors.Remove(entity);
            _myDbContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            _myDbContext.Instructors.Remove(new Instructor{Id = id});
            _myDbContext.SaveChanges();
        }

        public List<Instructor> FindAll()
        {
            return _myDbContext.Instructors.Include(p => p.Courses).ToList();
        }

        public Instructor FindById(int id)
        {
            return _myDbContext.Instructors.Include(p => p.Courses).Where(p => p.Id == id).FirstOrDefault();
        }

        public Instructor Save(Instructor entity)
        {
           if(entity.Id == 0){
               _myDbContext.Instructors.Add(entity);
           }
           else{
               _myDbContext.Instructors.Update(entity);
           }

           _myDbContext.SaveChanges();

           return entity;
        }
    }
}