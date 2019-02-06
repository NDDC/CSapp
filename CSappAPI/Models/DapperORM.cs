using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace CSappAPI.Models
{
    public static class DapperORM
    {

        public static string connectionString = @"Data Source=WPHMNLWINL10467\\SQLSERVER2K14;Initial Catalog=MaritimaDB;Integrated Security=true";
        private static readonly IDbTransaction commandType;

        public static void ExecuteWithoutReturn(string procedureName, DynamicParameters param)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {

                sqlCon.Open();
                sqlCon.Execute(procedureName, param,commandType:CommandType.StoredProcedure);


            }

        }
        //DapperORM.ExecuteReturnScalar<int>_(_,_);
        public static T ExecuteReturnScalar<T>(string procedureName, DynamicParameters param)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {

                sqlCon.Open();
                return (T)Convert.ChangeType(sqlCon.ExecuteScalar(procedureName, param, commandType: CommandType.StoredProcedure),typeof(T));


            }

        }
        //DarpperORM.ReturnList<CrewModel> <= IEnumerable<CrewModel>
        public static IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {

                sqlCon.Open();
                return sqlCon.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure);


            }

        }

    }
}