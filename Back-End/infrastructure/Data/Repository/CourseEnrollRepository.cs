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
    public class CourseEnrollRepository : ICourseEnroll
    {
        private readonly NpgsqlDataSource _dataSource;

        
        public CourseEnrollRepository(NpgsqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }
        public IEnumerable<CourseEnroll> GetAll()
        {
            var sql = $@"select * from da_education.course_enroll inner 
                        join da_education.users u on u.id = course_enroll.user_id
                        join da_education.courses c on c.id = course_enroll.course_id;";

            using(var conn = _dataSource.OpenConnection())
            {
                var map = new CustomPropertyTypeMap(typeof(CourseEnroll), (type, columnName) => 
                    type.GetProperties().FirstOrDefault(prop =>
                    GetDescriptionFromAttribute(prop) == columnName.ToLower()));
                
                Dapper.SqlMapper.SetTypeMap(typeof(CourseEnroll), map);

                return conn.Query<CourseEnroll, User, Course, CourseEnroll>(sql, (courseEnroll, user, course) =>
                {
                    courseEnroll.User = user;
                    courseEnroll.Course = course;
                    return courseEnroll;
                }, splitOn: "id, id");
            }
        }
        public CourseEnroll GetById(int id)
        {
            var sql = $@"select * from da_education.course_enroll inner 
                        join da_education.users u on u.id = course_enroll.user_id
                        join da_education.courses c on c.id = course_enroll.course_id
                        where course_enroll.id=@id;";
            
            using(var conn = _dataSource.OpenConnection())
            {
                var map = new CustomPropertyTypeMap(typeof(CourseEnroll), (type, columnName) => 
                    type.GetProperties().FirstOrDefault(prop =>
                    GetDescriptionFromAttribute(prop) == columnName.ToLower()));
                
                Dapper.SqlMapper.SetTypeMap(typeof(CourseEnroll), map);

                return conn.Query<CourseEnroll, User, Course, CourseEnroll>(sql,(courseEnroll, user, course) => 
                {
                    courseEnroll.User = user;
                    courseEnroll.Course = course;
                    return courseEnroll;
                } ,new {id}, splitOn: "id, id").First();
            }
        }
        public CourseEnroll Create(int userId, int courseId)
        {
            var sql = $@"insert into da_education.course_enroll (user_id, course_id) VALUES (@userId, @courseId) returning *;";
            
            using(var conn = _dataSource.OpenConnection())
            {
                var map = new CustomPropertyTypeMap(typeof(CourseEnroll), (type, columnName) => 
                    type.GetProperties().FirstOrDefault(prop =>
                    GetDescriptionFromAttribute(prop) == columnName.ToLower()));
                
                Dapper.SqlMapper.SetTypeMap(typeof(CourseEnroll), map);

                var parameters = new {userId = userId, courseId = courseId};

                return conn.QueryFirst<CourseEnroll>(sql, parameters);
            }
        }
        public CourseEnroll Update(int id, int userId, int courseId)
        {
            var sql = $@"update da_education.course_enroll set user_id = @userId, course_id = @courseId where id=@id returning *;";

            using(var conn = _dataSource.OpenConnection())
            {
                var map = new CustomPropertyTypeMap(typeof(CourseEnroll), (type, columnName) => 
                    type.GetProperties().FirstOrDefault(prop =>
                    GetDescriptionFromAttribute(prop) == columnName.ToLower()));
                
                Dapper.SqlMapper.SetTypeMap(typeof(CourseEnroll), map);

                var parameters = new {id, userId = userId, courseId=courseId};

                return conn.QueryFirst<CourseEnroll>(sql, parameters);
            }
        }
         public void Delete(int id)
        {
            var sql = $@"delete from da_education.course_enroll where id=@id;";

            using(var conn = _dataSource.OpenConnection())
            {
                conn.Execute(sql, new{id});
            }
        }

         private static string GetDescriptionFromAttribute(MemberInfo member)
        {
            return AttributeHelper.GetDescriptionFromAttribute(member);
        }
    }
}