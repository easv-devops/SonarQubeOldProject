using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enteties;

namespace infrastructure.Data.Interface
{
    public interface ICourseEnroll
    {
        IEnumerable<CourseEnroll>  GetAll();
        CourseEnroll GetById(int id);
        CourseEnroll Create(int userId, int courseId);
        CourseEnroll Update(int id, int userId, int courseId);
        void Delete(int id);  
    }
}