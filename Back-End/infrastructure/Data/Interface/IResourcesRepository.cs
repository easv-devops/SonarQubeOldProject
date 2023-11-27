using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enteties;

namespace infrastructure.Data.Interface
{
    public interface IResourcesRepository
    {
        IEnumerable<Resources> GetAll();
        Resources GetById(int id);
        Resources Create(string name, string type, string link, int courseId);
        Resources Update(int id, string name, string type, string link, int courseId);
        void Delete (int id);
    }
}