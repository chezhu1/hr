using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Major_kindDAO
    {
        string strCon = "Data Source=.;Initial Catalog=HR_DB;Integrated Security=True";
        //CMK查询职业
        public async Task<IEnumerable<Major_kind>> CmkSelectAsync()
        {
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                string sql = "select * from config_major_kind";
                return await connection.QueryAsync<Major_kind>(sql);
            }
        }
        //CMK删除职业
        public async Task<int> CmkDeleteAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                string sql = $"Delete from config_major_kind where mfk_id={id}";
                return await connection.ExecuteAsync(sql);
            }
        }
        //CMK添加职业
        public async Task<int> CmkInsertAsync(Major_kind major_Kind)
        {
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                string i = "SELECT TOP 1 \r\n    CASE \r\n        WHEN [major_kind_id] + 1 < 10 THEN '0' + CAST([major_kind_id] + 1 AS VARCHAR(2))\r\n        ELSE CAST([major_kind_id] + 1 AS VARCHAR(2))\r\n    END AS FormattedValue\r\nFROM [dbo].[config_major_kind] \r\nORDER BY mfk_id DESC";
                string id = await connection.QueryFirstAsync<string>(i);


                string sql = $"insert into config_major_kind(major_kind_id, major_kind_name) values('{id}','{major_Kind.major_kind_name}')";
                return await connection.ExecuteAsync(sql);
            }
        }
    }
}
