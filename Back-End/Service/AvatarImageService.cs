using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enteties;
using infrastructure.Data.Repository;

namespace Service
{
    public class AvatarImageService
    {
        private readonly AvatarImageRepository _repository;

        public AvatarImageService(AvatarImageRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<AvatarImage> GetAll()
        {
            try
            {
                return  _repository.GetAll();
            }
            catch(Exception)
            {
                throw new Exception("Could not get all of the AvatarImages");
            }
        }
        public AvatarImage GetById(int id)
        {
            try
            {
                return _repository.GetById(id);
            }
            catch(Exception)
            {
                throw new Exception("Could not get the item with the following id: " + id);
            }
        }
        public AvatarImage Create(int userId, string pictureUrl)
        {
            try
            {
                return _repository.Create(userId, pictureUrl);
            }
            catch(Exception)
            {
                throw new Exception("Could not create the avata image.");
            }
        }
        public AvatarImage Update(int id, int userId, string pictureUrl)
        {
            try
            {
                return _repository.Update(id, userId, pictureUrl);
            }
            catch(Exception)
            {
                throw new Exception("Could not update the following avatar image with id: " + id);
            }
        }
        public void Delete(int id)
        {
            try
            {
                _repository.Delete(id);
            }
            catch(Exception)
            {
                throw new Exception("Could not delete the following avatar image with id: " + id);
            }
        }
    }
}