using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enteties;

namespace infrastructure.Data.Interface
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        User GetByUsernameAndPassword(string username, string hashedPassword);

        User Create(string username, string email, string password, string shortDescription);
        User Update(int id, string username, string email, string password, string shortDescription);
        void Delete(int id);
    }
}