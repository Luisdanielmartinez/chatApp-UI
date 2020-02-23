using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.RepositoryInterface
{
    public interface IRepository<T>
    {
        Task<int> Save(T obj);
        Task<T> GetOneAsync(string id);
    }
}
