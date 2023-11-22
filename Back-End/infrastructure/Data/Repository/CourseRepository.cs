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
            var sql = $@"select * from da_education.courses 
            left join
            da_education.course_level cl on cl.id = courses.experience_level
            left join da_education.users u on u.id = courses.owner_id;";
            using(var conn = _dataSource.OpenConnection())
            {
                var map = new CustomPropertyTypeMap(typeof(Course), (type, columnName) => 
                    type.GetProperties().FirstOrDefault(prop =>
                    GetDescriptionFromAttribute(prop) == columnName.ToLower()));
                
                Dapper.SqlMapper.SetTypeMap(typeof(Course), map);

                return conn.Query<Course, CourseLevel, User, Course>(sql, (course, courseLevel, owner) => 
                {
                    course.CourseLevel = courseLevel;
                    course.Owner = owner;
                    return course;
                }, splitOn: "id, id");

            }
        }

        public Course GetById(int id)
        {
            var sql = $@"select * from da_education.courses 
            left join
            da_education.course_level cl on cl.id = courses.experience_level
            left join da_education.users u on u.id = courses.owner_id
            where courses.id=@id";
            using(var conn = _dataSource.OpenConnection())
            {
                var map = new CustomPropertyTypeMap(typeof(Course), (type, columnName) => 
                    type.GetProperties().FirstOrDefault(prop =>
                    GetDescriptionFromAttribute(prop) == columnName.ToLower()));
                
                Dapper.SqlMapper.SetTypeMap(typeof(Course), map);

                return conn.Query<Course, CourseLevel, User, Course>(sql,(course, courseLevel, owner) => 
                {
                    course.CourseLevel = courseLevel;
                    course.Owner = owner;
                    return course;
                } ,new {id}, splitOn: "id, id").First();
            }   
        }
        public Course Create(string name, int experience_level, string description, int ownerId, decimal price)
        {
            var sql = $@"insert into da_education.courses (name, experience_level,
                                                            description, owner_id, price)
                         values (@name, @experience_level, @description, @ownerId, @price)
                         Returning *";
            
            using(var conn = _dataSource.OpenConnection())
            {
                var map = new CustomPropertyTypeMap(typeof(Course), (type, columnName) => 
                    type.GetProperties().FirstOrDefault(prop =>
                    GetDescriptionFromAttribute(prop) == columnName.ToLower()));
                
                Dapper.SqlMapper.SetTypeMap(typeof(Course), map);

               var parameters =  new {name = name, experience_level = experience_level,
                description = description, ownerId = ownerId, price = price};
               
               return conn.QueryFirst<Course>(sql, parameters);
            }
        }
        public Course Update(int id, string name, int expirienceLevel,
                             string description, int ownerId, decimal price)
        {
            var sql = $@"update da_education.courses set name=@name, experience_level =@expirience_level,
            description = @description, owner_id = @owner_id, price = @price where id=@id
            returning *";

            using(var conn = _dataSource.OpenConnection())
            {
                var map = new CustomPropertyTypeMap(typeof(Course), (type, columnName) => 
                    type.GetProperties().FirstOrDefault(prop =>
                    GetDescriptionFromAttribute(prop) == columnName.ToLower()));
                
                Dapper.SqlMapper.SetTypeMap(typeof(Course), map);

                var parameters =  new {name = name, expirience_level = expirienceLevel,
                description = description, owner_id = ownerId, price = price, id};

                return conn.QueryFirst<Course>(sql, parameters);
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