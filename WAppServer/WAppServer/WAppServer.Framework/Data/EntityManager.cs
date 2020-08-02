using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Text;

using Dapper;

using WAppServer.Framework.IData;

namespace WAppServer.Framework.Data
{
    public class EntityManager : IEntityManager<IEntity>
    {
        protected SqlConnection SqlConnection { get; set; }

        public EntityManager(SqlConnection sqlConnection)
        {
            SqlConnection = sqlConnection;
        }

        /****************************** Basic CRUD Operations ***********************************/
        public int Create(IEntity entity)
        {
            string sql = $"INSERT INTO {IEntity.TableName}";

            List<string> propertyList = GetPropertyListForEntity();
            var names = string.Join(",", propertyList);
            var values = string.Join(",", propertyList.Select(x => "@" + x).ToList());
            sql += $" ({names}) VALUES ({values});";

            int result = SqlConnection.Execute(sql, entity);
            return result;
        }

        public int CreateList(IEnumerable<IEntity> entityList)
        {
            string sql = $"INSERT INTO {IEntity.TableName}";

            List<string> propertyList = GetPropertyListForEntity();
            var names = string.Join(",", propertyList);
            var values = string.Join(",", propertyList.Select(x => "@" + x).ToList());
            sql += $" ({names}) VALUES ({values});";

            int result = SqlConnection.Execute(sql, entityList);
            return result;
        }

        public int Delete(int id)
        {
            string sql = $"DELETE FROM {IEntity.TableName} WHERE ID = {id};";
            int result = SqlConnection.Execute(sql);
            return result;
        }

        public int DeleteList(IEnumerable<int> idList)
        {
            string sql = $"DELETE FROM {IEntity.TableName} WHERE ID = @ID;";
            int result = SqlConnection.Execute(sql, idList);
            return result;
        }

        public IEntity Get(int id)
        {
            string sql = $"SELECT TOP 1 * FROM {IEntity.TableName} WHERE ID = {id};";
            IEntity firstOrDefaultEntities = SqlConnection.QueryFirstOrDefault<IEntity>(sql);
            return firstOrDefaultEntities;
        }

        public IEntity Get(string where = null, string orderBy = null)
        {
            string sql = $"SELECT TOP 1 * FROM  {IEntity.TableName}";
            if (string.IsNullOrEmpty(where))
                sql += $" WHERE {where}";
            if (string.IsNullOrEmpty(orderBy))
                sql += $" ORDER BY {orderBy};";
            IEntity firstOrDefaultEntities = SqlConnection.QueryFirstOrDefault<IEntity>(sql);
            return firstOrDefaultEntities;
        }

        public IEnumerable<IEntity> GetList(string where = null, string orderBy = null)
        {
            string sql = $"SELECT * FROM  {IEntity.TableName}";
            if (string.IsNullOrEmpty(where))
                sql += $" WHERE {where}";
            if (string.IsNullOrEmpty(orderBy))
                sql += $" ORDER BY {orderBy};";
            IEnumerable<IEntity> listOfEntities = SqlConnection.Query<IEntity>(sql).ToList();
            return listOfEntities;
        }

        public IEnumerable<IEntity> GetAll()
        {
            string sql = $"SELECT * FROM  {IEntity.TableName};";
            IEnumerable<IEntity> listOfEntities = SqlConnection.Query<IEntity>(sql).ToList();
            return listOfEntities;           
        }

        public int Update(IEntity entity)
        {
            string sql = $"UPDATE {IEntity.TableName} SET ";

            List<string> propertyList = GetPropertyListForEntity();
            var values = string.Join(",", propertyList.Select(x => x + " = @" + x).ToList());
            sql += $" ({values}) WHERE ID = @ID;";

            int result = SqlConnection.Execute(sql, entity);
            return result;
        }

        public int UpdateList(IEnumerable<IEntity> entityList)
        {
            string sql = $"UPDATE {IEntity.TableName} SET ";

            List<string> propertyList = GetPropertyListForEntity();
            var values = string.Join(",", propertyList.Select(x => x + " = @" + x).ToList());
            sql += $" ({values}) WHERE ID = @ID;";

            int result = SqlConnection.Execute(sql, entityList);
            return result;
        }

        /****************************** Private Functions ***********************************/
        private List<string> GetPropertyListForEntity()
        {
            List<string> propertyList = new List<string>();
            PropertyInfo[] properties = typeof(IEntity).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var propertyName = property.Name;
                propertyList.Add(propertyName);
            }
            return propertyList;
        }
    }
}
