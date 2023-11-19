using Core.Enteties;
using Core.Interfaces;
using Dapper;
using Npgsql;

namespace infrastructure.Data
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

        public void Create(User user)
        {
            var sql = $@"insert into da_education.users (username, email, password, shortDescription)
                        values (@username, @email, @password, @shortDescription)
                        RETURNING *";

            using (var conn = _dataSource.OpenConnection())
            {
                var parameters = new {username = user.Username, email = user.Email,
                                      password = user.Password, shortDescription = user.ShortDescription};
                
                conn.Query<User>(sql, parameters);
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

        public void Update(User user)
        {
            var sql = $@"update da_education.users set username = @username, email = @email,
                        password = @password, shortDescription = @shortDescription where id=@id";

            using(var conn = _dataSource.OpenConnection())
            {
                var parameters = new {username = user.Username, email = user.Email, password = user.Password,
                shortDescription = user.ShortDescription, id = user.Id};
                
                conn.Execute(sql, parameters);
            }
        }
    }
}