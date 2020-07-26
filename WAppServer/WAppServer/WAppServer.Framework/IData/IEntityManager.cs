using System;
using System.Collections.Generic;
using System.Text;

namespace WAppServer.Framework.IData
{
    public interface IEntityManager<T>
    {
        int Create(T entity);
        int CreateList(List<T> entityList);
        T Get(int id);
        T Get(string where = null, string orderBy = null);
        int Update(T entity);
        int UpdateList(List<T> entityList);
        int Delete(int id);
        int DeleteList(List<int> idList);
        List<T> GetAll();
        List<T> GetList(string where = null, string orderBy = null);
    }
}
