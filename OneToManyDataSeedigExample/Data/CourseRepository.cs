using System.Collections.Generic;
using System.Linq;
using Entity;

namespace Data
{
    public class CourseRepository : ICourseRepository
    {

        private MyDbContext _myDbContext;

        public CourseRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public void Delete(Course entity)
        {
            _myDbContext.Courses.Remove(entity);
            _myDbContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            _myDbContext.Courses.Remove(new Course{Id = id});
            _myDbContext.SaveChanges();
        }

        public List<Course> FindAll()
        {
            return _myDbContext.Courses.ToList();
        }

        public List<Course> FindAllByInstructorId(int instructorId)
        {
            return _myDbContext.Courses.Where(c => c.Instructor.Id == instructorId).ToList();
        }

        public Course FindById(int id)
        {
            return _myDbContext.Courses.FirstOrDefault(c => c.Id == id);
        }

        public Course Save(Course entity)
        {
            if(entity.Id == 0){
                _myDbContext.Courses.Add(entity);
            }else{
                _myDbContext.Courses.Update(entity);
            }
            _myDbContext.SaveChanges();

            return entity;
        }
    }
}