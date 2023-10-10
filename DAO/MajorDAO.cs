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
    public class MajorDAO
    {
        //职位设置表
        string strCon = "Data Source=.;Initial Catalog=HR_DB;Integrated Security=True";
        //查询
        public async Task<IEnumerable<Major>> MajorSelectAsync()
        {
            using (SqlConnection connection=new SqlConnection(strCon))
            {
                string sql = "select * from config_major"; ;
                return await connection.QueryAsync<Major>(sql);
            }
        }
        //删除
        public async Task<int> MajorDeleteAsync(int id)
        {
            using (SqlConnection connection=new SqlConnection(strCon))
            {
                string sql = $"Delete from config_major where mak_id='{id}'";
                return await connection.ExecuteAsync(sql);
            }
        }
        //添加
        public async Task<int> MajorInsertAsync(Major major)
        {
            using(SqlConnection connection=new SqlConnection(strCon))
            {
                string sql = $"Insert into [dbo].[config_major](major_kind_id, major_kind_name, major_id, major_name) values((select [major_kind_id] from  [dbo].[config_major_kind]where major_kind_name='{major.major_kind_name}'),'{major.major_kind_name}','{major.major_id}','{major.major_name}')";
                return await connection.ExecuteAsync(sql);
            }
        }
    }
}
