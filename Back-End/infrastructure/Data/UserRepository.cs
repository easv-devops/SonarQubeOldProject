using Dapper;
using Npgsql;

namespace infrastructure.Data
{
    public class UserRepository
    {
        private readonly NpgsqlDataSource _dataSource;

    public UserRepository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }
    
    }
}