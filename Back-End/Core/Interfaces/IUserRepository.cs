using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enteties;

namespace Core.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Create(User user);
        User Update(int id ,User user);
        void Delete(int id);
    }
}