using System.ComponentModel;
using System.Reflection;
using Core.Enteties;
using Dapper;
using infrastructure.Data.Interface;
using Npgsql;

namespace infrastructure.Data.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly NpgsqlDataSource _dataSource;
        public CourseRepository(NpgsqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }
        
        public IEnumerable<Course> GetAll()
        {
            var sql = $@"select * from da_education.courses;";
            using(var conn = _dataSource.OpenConnection())
            {
                var map = new CustomPropertyTypeMap(typeof(Course), (type, columnName) => 
                    type.GetProperties().FirstOrDefault(prop =>
                    GetDescriptionFromAttribute(prop) == columnName.ToLower()));
                
                Dapper.SqlMapper.SetTypeMap(typeof(Course), map);

                return conn.Query<Course>(sql);

            }
        }

        public Course GetById(int id)
        {
            var sql = $@"select * from da_education.courses where id=@id;";
            using (var conn = _dataSource.OpenConnection())
            {
                var map = new CustomPropertyTypeMap(typeof(Course), (type, columnName) => 
                    type.GetProperties().FirstOrDefault(prop =>
                    GetDescriptionFromAttribute(prop) == columnName.ToLower()));
                
                Dapper.SqlMapper.SetTypeMap(typeof(Course), map);

                return conn.QueryFirst<Course>(sql, new {id});
            }   
        }
        public Course Create(Course course)
        {
            var sql = $@"insert into da_education.courser (name, expirience_level,
                                                            description, owner_id, price)
                         values (@name, @expirience_level, @description, @owner_id, @price)";
            
            using(var conn = _dataSource.OpenConnection())
            {
               var parameters =  new {name = course.Name, expirience_level = course.ExpirienceLevel,
                description = course.Descrpition, owner_id = course.OwnerId, price = course.Price};
               
               return conn.QueryFirst<Course>(sql, parameters);
            }
        }

        public Course Update(int id, Course course)
        {
            var sql = $@"update da_education.courses set name=@name, @expirience_level = expirience_level,
            description = @description, owner_id = @owner_id, price = @price";

            using(var conn = _dataSource.OpenConnection())
            {
                var parameters =  new {name = course.Name, expirience_level = course.ExpirienceLevel,
                description = course.Descrpition, owner_id = course.OwnerId, price = course.Price, id};

                conn.Execute(sql, parameters);
                return course;
            }
        }
        
        public void Delete(int id)
        {
            var sql = $@"delete from da_education.courses where id=@id";
            using(var conn = _dataSource.OpenConnection())
            {
               conn.Execute(sql, new {id}); 
            }
        }


        static string GetDescriptionFromAttribute(MemberInfo member)
        {
            if (member == null) return null;

            var attrib = (DescriptionAttribute)Attribute.GetCustomAttribute(member, typeof(DescriptionAttribute), false);
            return (attrib?.Description ?? member.Name).ToLower();
        }
    }
}