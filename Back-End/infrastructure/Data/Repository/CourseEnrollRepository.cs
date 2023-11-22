using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enteties;
using infrastructure.Data.Interface;
using Npgsql;

namespace infrastructure.Data.Repository
{
    public class CourseEnrollRepository : ICourseEnroll
    {
        private readonly NpgsqlDataSource _dataSource;

        
        public CourseEnrollRepository(NpgsqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }
        public IEnumerable<CourseEnroll> GetAll()
        {
            throw new NotImplementedException();
        }
        public CourseEnroll GetById(int id)
        {
            throw new NotImplementedException();
        }
        public CourseEnroll Create(int userId, int courseId)
        {
            throw new NotImplementedException();
        }
        public CourseEnroll Update(int id, int userId, int courseId)
        {
            throw new NotImplementedException();
        }
         public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}