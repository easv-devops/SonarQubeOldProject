using Core.Enteties;
using Dapper;
using infrastructure.Data.Interface;
using Npgsql;

namespace infrastructure.Data.Repository
{
    public class UserRepository  : IUserRepository
    {
        private readonly NpgsqlDataSource _dataSource;

    public UserRepository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }

        public IEnumerable<User> GetAll()
        {
            var sql = $@"SELECT * FROM da_education.users";
            using(var conn = _dataSource.OpenConnection())
            {
                return conn.Query<User>(sql);
            }
        }

        public User GetById(int id)
        {
            var sql = $@"select * from da_education.users where id=@id;";

            using(var conn = _dataSource.OpenConnection())
            {
                return conn.QueryFirst<User>(sql, new {id});
            }
        }
        public User GetByUsernameAndPassword(string username, string hashedPassword)
        {
            var sql = $@"select * from da_education.users where username=@username and password=@password;";

            using(var conn = _dataSource.OpenConnection())
            {
                return conn.QueryFirst<User>(sql, new {username, password = hashedPassword});
            }
        }

        public User Create(string username, string email, string password, string shortDescription)
        {
            var sql = $@"insert into da_education.users (username, email, password, shortdescription)
                        values (@username, @email, @password, @shortDescription)
                        RETURNING *";

            using (var conn = _dataSource.OpenConnection())
            {
                var parameters = new {username = username, email = email,
                                      password = password, shortDescription = shortDescription};
                
                return conn.QueryFirst<User>(sql, parameters);
            }
        }
        public User Update(int id, string username, string email, string password, string shortDescription)
        {
            var sql = $@"update da_education.users set username = @username, email = @email,
                        password = @password, shortdescription = @shortdescription where id=@id";

            using(var conn = _dataSource.OpenConnection())
            {
                var parameters = new {username = username, email = email, password = password,
                shortdescription = shortDescription, id};
                
                return conn.QueryFirst<User>(sql, parameters);
            }
        }
        public void Delete(int id)
        {  
            var sql = $@"delete from da_education.users where id=@id";
            using(var conn = _dataSource.OpenConnection())
            {
                conn.Execute(sql, new {id});
            }
        }

        
    }
}