using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enteties;
using infrastructure.Data.Repository;

namespace Service
{
    public class CourseEnrollService
    {
        private readonly CourseEnrollRepository _repository;

        public CourseEnrollService(CourseEnrollRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CourseEnroll> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch(Exception)
            {
                throw new Exception("Could not get the wanted list!");
            }
        }
        public CourseEnroll GetById(int id)
        {
            try
            {
                return _repository.GetById(id);
            }
            catch(Exception)
            {
                throw new Exception("Could not get the wanted course enroll!");
            }
        }
        public CourseEnroll Create(int userId, int courseId)
        {
            try
            {
                return _repository.Create(userId, courseId);
            }
            catch(Exception)
            {
                throw new Exception("Could not create the wanted course enroll!");
            }
        }
        public CourseEnroll Update(int id, int userId, int courseId)
        {
            try
            {
                return _repository.Update(id, userId, courseId);
            }
            catch(Exception)
            {
                throw new Exception("Could not update the wanted course enroll!");
            }
        }
        public void Delete(int id)
        {
            try
            {
                 _repository.Delete(id);
            }
            catch(Exception)
            {
                throw new Exception("Could not delete the wanted course enroll with id: " + id);
            }
        }
    }
}