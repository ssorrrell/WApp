using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WAppServer.Framework.Data;

namespace WAppServer.Objects.CurrentConditions
{
    public class CurrentConditionsManager : EntityManager
    {
        public CurrentConditionsManager(SqlConnection sqlConnection) : base(sqlConnection)
        {
        }
    }
}
