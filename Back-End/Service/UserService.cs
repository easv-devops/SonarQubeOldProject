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

        public User GetUserById(int id)
        {
            try
            {
                return _repository.GetById(id);
            }
            catch(Exception)
            {
                throw new Exception("The wanted user cannot be found");
            }
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

        public User CreateUser(User user)
        {
            try
            {
                return _repository.Create(user);
            }
            catch(Exception)
            {
                throw new Exception("Could not create this user " + user);
            }
        }

        public User UpdateUser(int id, User user)
        {
            try
            {
               return _repository.Update(id, user);
            }
            catch(Exception ex)
            {
        Console.WriteLine($"Error updating user: {ex.Message}");
        throw; // Re-throw the exception or handle it appropriately
            }
        }
        public void DeleteUser(int id)
        {
            try
            {
                 _repository.Delete(id);
            }
            catch(Exception)
            {
                throw new Exception("Could not delete the user with the following id " + id );
            }

        }

        
    }
}