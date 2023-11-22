using System.Data.Common;
using System.Reflection;
using Core.Enteties;
using Dapper;
using infrastructure.Data.Interface;
using infrastructure.Helpers;
using Npgsql;

namespace infrastructure.Data.Repository
{
    public class AvatarImageRepository : IAvatarImageRepository
    {
        private readonly NpgsqlDataSource _dataSource;

        public AvatarImageRepository(NpgsqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public IEnumerable<AvatarImage> GetAll()
        {
            var sql = $@"select * from da_education.avatar_image 
            inner join da_education.users u on avatar_image.user_id = u.id;";
            
            using(var conn = _dataSource.OpenConnection())
            {
                var map = new CustomPropertyTypeMap(typeof(AvatarImage), (type, columnName) => 
                    type.GetProperties().FirstOrDefault(prop =>
                    GetDescriptionFromAttribute(prop) == columnName.ToLower()));
                
                Dapper.SqlMapper.SetTypeMap(typeof(AvatarImage), map);
                
                return conn.Query<AvatarImage, User, AvatarImage>(sql, (avatarImage, user) => 
                {
                    avatarImage.User = user;
                    return avatarImage;
                }, splitOn : "id");
            }
        }

        public AvatarImage GetById(int id)
        {
            var sql = $@"select * from da_education.avatar_image
            inner join da_education.users u on avatar_image.user_id = u.id where avatar_image.id=@id;";

            using(var conn = _dataSource.OpenConnection())
            {
                var map = new CustomPropertyTypeMap(typeof(AvatarImage), (type, columnName) => 
                    type.GetProperties().FirstOrDefault(prop =>
                    GetDescriptionFromAttribute(prop) == columnName.ToLower()));
                
                Dapper.SqlMapper.SetTypeMap(typeof(AvatarImage), map);

                return conn.Query<AvatarImage, User, AvatarImage>(sql, (avatarImage, user) => 
                {
                    avatarImage.User = user;
                    return avatarImage;
                }, new{id}, splitOn: "id, id").First();
            }
        }

        public AvatarImage Create(int userId, string pictureUrl)
        {
            var sql = $@"insert into da_education.avatar_image (user_id, picture_url) values
                        (@userId, @pictureUrl) returning *;";
            
            using(var conn = _dataSource.OpenConnection())
            {
                var map = new CustomPropertyTypeMap(typeof(AvatarImage), (type, columnName) => 
                    type.GetProperties().FirstOrDefault(prop =>
                    GetDescriptionFromAttribute(prop) == columnName.ToLower()));
                
                Dapper.SqlMapper.SetTypeMap(typeof(AvatarImage), map);

                var parameters = new {userId = userId, pictureUrl = pictureUrl};

                return conn.QueryFirst<AvatarImage>(sql, parameters);
            }
        }
        public AvatarImage Update(int id, int userId, string pictureUrl)
        {
            var sql = $@"update da_education.avatar_image set user_id=@userId, picture_url=@pictureUrl
            where id=@id returning *;";

            using(var conn = _dataSource.OpenConnection())
            {
                var map = new CustomPropertyTypeMap(typeof(AvatarImage), (type, columnName) => 
                    type.GetProperties().FirstOrDefault(prop =>
                    GetDescriptionFromAttribute(prop) == columnName.ToLower()));
                
                Dapper.SqlMapper.SetTypeMap(typeof(AvatarImage), map);

                var parameters = new {id, userId = userId, pictureUrl = pictureUrl};
                return conn.QueryFirst<AvatarImage>(sql,parameters);
            }
        }
        public void Delete(int id)
        {
            var sql = $@"delete from da_education.avatar_image where id=@id;";
            
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