using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IYFRaipur.Services
{
    public interface IIdentifiable
    {
        string Id { get; set; }
    }

    public interface ISalonRepository<T>
    {
        Task<T> GetSalonAsync(string id);
        Task<IList<T>> GetSalonsAsync();
    }
}
