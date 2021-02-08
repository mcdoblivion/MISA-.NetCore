using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.DataLayer.Interfaces
{
    public interface IDbContext<TEntity>
    {
        IEnumerable<TEntity> GetData(string sqlCommand = null, object parameters = null,
            CommandType commandType = CommandType.Text);

        int InsertObject(TEntity entity);

        int UpdateObject(TEntity entity, string id);

        int DeleteObject(string id);
    }
}