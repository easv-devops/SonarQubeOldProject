using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enteties;
using infrastructure.Data.Repository;

namespace Service
{
    public class CourseLevelService
    {
        private readonly CourseLevelRepository _repository;

        public CourseLevelService(CourseLevelRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CourseLevel> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch(Exception)
            {
                throw new Exception("Could not get all the courseLevels");
            }
        }
        public CourseLevel GetById(int id)
        {
            try
            {
                return _repository.GetById(id);
            }
            catch(Exception)
            {
                throw new Exception("Could not get the wanted CourseLevel with id: " + id);
            }
        }
        public CourseLevel Create(string level)
        {
            try
            {
                return _repository.Create(level);
            }
            catch(Exception)
            {
                throw new Exception("Could not create the wanted Course Level");
            }
        }
        public CourseLevel Update(int id, string level)
        {
            try
            {
                return _repository.Update(id, level);
            }
            catch(Exception)
            {
                throw new Exception("Could not update the wanted Course Level with id: " + id);
            }
        }
        public void Deleete(int id)
        {
            try
            {
                 _repository.Delete(id);
            }
            catch(Exception)
            {
                throw new Exception("Could not deleete the wanted Course Level with id: " + id);
            }
        }
    }
}