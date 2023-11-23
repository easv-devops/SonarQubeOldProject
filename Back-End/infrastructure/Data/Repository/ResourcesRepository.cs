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
    public class ResourcesRepository : IResourcesRepository

    {
        private readonly NpgsqlDataSource _dataSource;

        public ResourcesRepository(NpgsqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public IEnumerable<Resources> GetAll()
        {
            var sql = $@"select * from da_education.resources 
            inner join da_education.courses c on c.id = resources.course_id;";
            using(var conn = _dataSource.OpenConnection())
            {
                var map = new CustomPropertyTypeMap(typeof(Resources), (type, columnName) => 
                    type.GetProperties().FirstOrDefault(prop =>
                    GetDescriptionFromAttribute(prop) == columnName.ToLower()));
                
                Dapper.SqlMapper.SetTypeMap(typeof(Resources), map);

                return conn.Query<Resources, Course, Resources>(sql, (resources, course) => 
                {
                    resources.Course = course;
                    return resources;
                }, splitOn: "id, id");
            }
        }

        public Resources GetById(int id)
        {
            var sql = $@"select * from  da_education.resources 
                inner join da_education.courses c on c.id = resources.course_id where resources.id=@id;";

            using(var conn = _dataSource.OpenConnection())
            {
                var map = new CustomPropertyTypeMap(typeof(Resources), (type, columnName) => 
                    type.GetProperties().FirstOrDefault(prop =>
                    GetDescriptionFromAttribute(prop) == columnName.ToLower()));
                
                Dapper.SqlMapper.SetTypeMap(typeof(Resources), map);

                return conn.Query<Resources, Course, Resources>(sql, (resoucre, course) => 
                {
                    resoucre.Course = course;
                    return resoucre;
                }, new {id}, splitOn: "id, id").First();
            }
        }
        public Resources Create(string name, string type, string link, int courseId)
        {
            var sql = $@"insert  into da_education.resources (name, type, link, course_id)
             values (@name, @type, @link, @courseId) returning *;";

            using(var conn = _dataSource.OpenConnection())
            {
                var map = new CustomPropertyTypeMap(typeof(Resources), (type, columnName) => 
                    type.GetProperties().FirstOrDefault(prop =>
                    GetDescriptionFromAttribute(prop) == columnName.ToLower()));
                
                Dapper.SqlMapper.SetTypeMap(typeof(Resources), map);

                var parameters = new {name, type, link, courseId};

                return conn.QueryFirst<Resources>(sql, parameters);
            }
        }

        public Resources Update(int id, string name, string type, string link, int courseId)
        {
            var sql = $@"update da_education.resources set 
            name = @name, type = @type, link = @link, course_id = @courseId 
            where id = @id returning *;";

            using(var conn = _dataSource.OpenConnection())
            {
                 var map = new CustomPropertyTypeMap(typeof(Resources), (type, columnName) => 
                    type.GetProperties().FirstOrDefault(prop =>
                    GetDescriptionFromAttribute(prop) == columnName.ToLower()));
                
                Dapper.SqlMapper.SetTypeMap(typeof(Resources), map);

                var parameters = new {id, name, type, link, courseId};

                return conn.QueryFirst<Resources>(sql, parameters);
            }
        }

        public void Delete(int id)
        {
            var sql = $@"delete from da_education.resources where id=@id;";
            using(var conn = _dataSource.OpenConnection())
            {
                conn.Execute(sql, new {id});
            }
        }

         private static string GetDescriptionFromAttribute(MemberInfo member)
        {
            return AttributeHelper.GetDescriptionFromAttribute(member);
        }
    }
}