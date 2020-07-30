using System;
using System.Collections.Generic;
using System.Text;

namespace WAppServer.Framework.IData
{
    public interface IEntityManager<T>
    {
        int Create(T entity);
        int CreateList(IEnumerable<T> entityList);
        T Get(int id);
        T Get(string where = null, string orderBy = null);
        int Update(T entity);
        int UpdateList(IEnumerable<T> entityList);
        int Delete(int id);
        int DeleteList(IEnumerable<int> idList);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetList(string where = null, string orderBy = null);
    }
}
