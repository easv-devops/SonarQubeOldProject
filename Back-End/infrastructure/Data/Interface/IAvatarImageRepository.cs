using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enteties;

namespace infrastructure.Data.Interface
{
    public interface IAvatarImageRepository
    {
        IEnumerable<AvatarImage> GetAll();
        AvatarImage GetById(int id);
        AvatarImage Create(int userId, string pictureUrl);
        AvatarImage Update(int id, int userId, string pictureUrl);
        void Delete(int id);
    }
}