using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enteties;

namespace infrastructure.Data.Interface
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAll();
        Course GetById(int id);
        Course Create(Course course);
        Course Update(int id ,Course course);
        void Delete(int id);   
    }
}