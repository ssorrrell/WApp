using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WAppServer.Framework.Data;

namespace WAppServer.Objects.Models
{
    public class ActivityLogManager : EntityManager
    {
        public ActivityLogManager(SqlConnection sqlConnection) : base(sqlConnection)
        {
        }
    }
}
