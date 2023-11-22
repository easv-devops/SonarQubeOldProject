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
            var sql = $@"select * from da_education.avatar_image inner join da_education.users u on avatar_image.user_id = u.id;" ;
            using(var conn = _dataSource.OpenConnection())
            {
                var map = new CustomPropertyTypeMap(typeof(Course), (type, columnName) => 
                    type.GetProperties().FirstOrDefault(prop =>
                    GetDescriptionFromAttribute(prop) == columnName.ToLower()));
                
                Dapper.SqlMapper.SetTypeMap(typeof(Course), map);
                
                return conn.Query<AvatarImage, User, AvatarImage>(sql, (avatarImage, user) => 
                {
                    avatarImage.User = user;
                    return avatarImage;
                }, splitOn : "id");
            }
        }

        public AvatarImage GetById(int id)
        {
            throw new NotImplementedException();
        }

        public AvatarImage Create(int userId, string pictureUrl)
        {
            throw new NotImplementedException();
        }
        public AvatarImage Update(int id, int userId, string pictureUrl)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        
        private static string GetDescriptionFromAttribute(MemberInfo member)
        {
            return AttributeHelper.GetDescriptionFromAttribute(member);
        }
    }
}