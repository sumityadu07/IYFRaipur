using System;
using IYFRaipur.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IYFRaipur.Services
{
    public interface IIdentifiable
    {
        string UserName { get; set; }
    }
    public interface IRepository<T>
    {
        #region Save Document
        Task SaveCouncelor(DataClass data);
        Task SavePreacher(DataClass data);
        Task SaveFacilitator(DataClass data);
        #endregion

        #region GetCurrentDocument
        Task<T> GetCurrentCouncelor();
        Task<T> GetCurrentPreacher();
        Task<T> GetCurrentFacilitator();
        #endregion

        #region GetCollection
        Task<IList<T>> GetCouncelors();
        Task<IList<T>> GetPreachers();
        Task<IList<T>> GetFacilitators();
        #endregion
        Task<T> GetDocumentAsync(string id);
    }
}