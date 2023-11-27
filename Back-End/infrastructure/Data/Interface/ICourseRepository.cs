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
        Course Create(string name, int courseLevelId, string description, int ownerId, decimal price);
        Course Update(int id , string name, int courseLevelId, string description, int ownerId, decimal price);
        void Delete(int id);   
    }
}