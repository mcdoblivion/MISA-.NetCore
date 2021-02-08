using MISA.Common.Models;

namespace MISA.Service.Interfaces
{
    public interface IBaseService<TEntity>
    {
        ServiceResult GetData();

        ServiceResult Insert(TEntity entity);

        ServiceResult Delete(string id);

        ServiceResult Update(TEntity entity, string id);
    }
}