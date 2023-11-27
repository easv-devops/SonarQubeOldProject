using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enteties;
using infrastructure.Data.Repository;

namespace Service
{
    public class ResourcesService
    {
        private readonly ResourcesRepository _repository;

        public ResourcesService(ResourcesRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Resources> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch(Exception)
            {
                throw new Exception("Could not get all the resource");
            }
        }
         public Resources GetById(int id)
        {
          try
          {
            return _repository.GetById(id);
          }
          catch(Exception)
          {
            throw new Exception("Could not find the particular resource");
          }
        }
        public Resources Create(string name, string type, string link, int courseId)
        {
            try
            {
                return _repository.Create(name, type, link, courseId);
            }
            catch(Exception)
            {
                throw new Exception("Could not create the particular resource");
            }
        }

        public Resources Update(int id, string name, string type, string link, int courseId)
        {
            try
            {
                return _repository.Update(id, name, type, link, courseId);
            }
            catch(Exception)
            {
                throw new Exception("Could not update the particular resource!");
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
                throw new Exception("Could not update the particular resource with id: " + id);
            }
        }
    }
}