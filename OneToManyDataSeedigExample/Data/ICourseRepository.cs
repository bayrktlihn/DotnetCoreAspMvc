using System.Collections.Generic;
using Entity;

namespace Data
{
    public interface ICourseRepository : IRepository<Course, int>
    {
        List<Course> FindAllByInstructorId(int instructorId);
    }
}