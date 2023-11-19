using Core.Enteties;
using infrastructure.Data;

namespace Service
{
    public class UserService
    {
        private readonly UserRepository _repository;

        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<User> GetUsers()
        {
            try
            {
               return _repository.GetAll();
            }
            catch(Exception )
            {
                throw new Exception("Could not get users!");
            }
        }

        
    }
}