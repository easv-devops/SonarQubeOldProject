using Core.Enteties;
using infrastructure.Data.Repository;

namespace Service
{
    public class CourseService
    {
        private readonly CourseRepository _repository;

        public CourseService(CourseRepository repository)
        {
            _repository = repository;
        }

        public Course GetById(int id)
        {
          try
          {
            return _repository.GetById(id);
          }
          catch(Exception)
          {
            throw new Exception("Could not find the particular course");
          }
        }

        public IEnumerable<Course> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch(Exception)
            {
                throw new Exception("Could not get all the courses");
            }
        }

        public Course Create(Course course)
        {
            try
            {
                return _repository.Create(course);
            }
            catch(Exception)
            {
                throw new Exception("Could not create the particular course " + course);
            }
        }

        public Course Update(int id, Course course)
        {
            try
            {
                return _repository.Update(id, course);
            }
            catch(Exception)
            {
                throw new Exception("Could not update the particular course " + course);
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
                throw new Exception("Could not update the particular course with id: " + id);
            }
        }
    }
}