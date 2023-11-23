using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Core.Enteties;
using Dapper;
using infrastructure.Data.Interface;
using infrastructure.Helpers;
using Npgsql;

namespace infrastructure.Data.Repository
{
    public class CourseLevelRepository : ICourseLevelRepository
    {
        private readonly NpgsqlDataSource _dataSource;

        public CourseLevelRepository(NpgsqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public IEnumerable<CourseLevel> GetAll()
        {
            var sql = $@"select * from da_education.course_level;";
            using(var conn = _dataSource.OpenConnection())
            {
                return conn.Query<CourseLevel>(sql);
            }
        }

        public CourseLevel GetById(int id)
        {
            var sql = $@"select * from da_education.course_level where id = @id";
            using(var conn = _dataSource.OpenConnection())
            {
                return conn.QueryFirst<CourseLevel>(sql, new{id});
            }
        }
         public CourseLevel Create(string level)
        {
            var sql = $@"insert into da_education.course_level (level) values (@level) returning *;";

            using(var conn = _dataSource.OpenConnection())
            {
                var parameters = new {level = level};
                return conn.QueryFirst<CourseLevel>(sql, parameters);
            }
        }

        public CourseLevel Update(int id, string level)
        {
            var sql = $@"update da_education.course_level set level=@level where id=@id returning *;";
            using(var conn = _dataSource.OpenConnection())
            {
                var parameters = new {id, level};
                return conn.QueryFirst<CourseLevel>(sql, parameters);
            }
        }
         public void Delete(int id)
        {
            var sql = $@"delete from da_education.course_level where id=@id;";
            using(var conn = _dataSource.OpenConnection())
            {
                conn.Execute(sql, new {id});
            }
        }

       
    }
}