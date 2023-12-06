using System.Security.Cryptography;
using System.Text;
using Core.Enteties;
using infrastructure.Data;
using infrastructure.Data.Repository;

namespace Service
{
    public class UserService
    {
        private readonly UserRepository _repository;
        private readonly AuthenticationService _authenticationService;

        public UserService(UserRepository repository, AuthenticationService authenticationService)
        {
            _repository = repository;
            _authenticationService = authenticationService;
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

        public User CreateUser(string username, string email, string password, string shortDescription)
        { try
    {
        // Hash the password before storing in the database
        string hashedPassword = HashPassowrd(password); // Fixed typo in method name

        // Log relevant information
        Console.WriteLine($"Creating user: {username}, {email}, {shortDescription}");

        var user = _repository.Create(username, email, hashedPassword, shortDescription);

        Console.WriteLine(user.Username + user.Password);
        // Generate and return JWT token after user creation
        user.Token = _authenticationService.GenerateJwtToken(user);

        return user;
    }
    catch (Exception ex)
    {
        // Log the exception details
        Console.WriteLine($"Error creating user: {ex.Message}");
        throw new Exception("Could not create this user!", ex);
    }
        }

        public User UpdateUser(int id, string username, string email, string password, string shortDescription)
        {
            try
            {
               return _repository.Update(id, username, email, password, shortDescription);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error updating user: {ex.Message}");
                throw; // Re-throw the exception or handle it appropriately
            }
        }

        public User AuthenticateUser(string username, string password)
        {
            //hashing the pass
            string hashedPassword = HashPassowrd(password);
            
            var user = _repository.GetByUsernameAndPassword(username, hashedPassword);

            if (user == null)
            return null!;

            //generate token
            user.Token = _authenticationService.GenerateJwtToken(user);

           return user;
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

         private string HashPassowrd(string password)
        {
             using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        
    }
}