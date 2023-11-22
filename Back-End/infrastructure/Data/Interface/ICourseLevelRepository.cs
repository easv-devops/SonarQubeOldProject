using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enteties;

namespace infrastructure.Data.Interface
{
    public interface ICourseLevelRepository
    {
        IEnumerable<CourseLevel> GetAll();
        CourseLevel GetById(int id);
        CourseLevel Create(string level);
        CourseLevel Update(int id, string level);
        void Delete(int id);
    }
}