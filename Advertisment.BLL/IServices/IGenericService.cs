using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertisment.BLL.IServices
{
    public interface IGenericService
    {
        Task<TEntity> GetByIdAsync<TEntity, IdType>(IdType id);
        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>();
        Task DeleteByIdAsync<IdType>(IdType id);
        Task<TEntity> UpdateAsync<TEntity>(TEntity entity);
        Task InsertAsync<TEntity>(TEntity entity);
    }
}
