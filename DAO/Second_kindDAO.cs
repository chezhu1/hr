using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAO
{
    public class Second_kindDAO
    {

        string conStr = "Data Source=.;Initial Catalog=HR_DB;Integrated Security=True";

        /// <summary>
        /// II级机构设置查询
        /// </summary>
        /// <returns></returns>

        public async Task<IEnumerable<Second_kind>> Second_KindsAsync()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"select * from [dbo].[config_file_second_kind]";
                return await con.QueryAsync<Second_kind>(sql);
            }
        }
        /// <summary>
        /// II级机构设置添加
        /// </summary>
        /// <returns></returns>
        public async Task<int> Second_AddAsync(Second_kind cfsk)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"insert into [dbo].[config_file_second_kind]([first_kind_id], [first_kind_name], [second_kind_id], [second_kind_name], [second_salary_id], [second_sale_id])" +
                   $"values('{cfsk.first_kind_id}',(select [first_kind_name] from [dbo].[config_file_first_kind] where [first_kind_id]='{cfsk.first_kind_id}')," +
                   $"(SELECT TOP 1  CASE  WHEN [second_kind_id] + 1 < 10 THEN '0' + CAST([second_kind_id] + 1 AS VARCHAR(2)) ELSE CAST([second_kind_id] + 1 AS VARCHAR(2))  END AS FormattedValue FROM [dbo].[config_file_second_kind] ORDER BY fsk_id DESC)," +
                   $"'{cfsk.second_kind_name}','{cfsk.second_salary_id}','{cfsk.second_sale_id}')";
                return await con.ExecuteAsync(sql);
            }
        }
        /// <summary>
        /// II级机构设置修改
        /// </summary>
        /// <returns></returns>
        public async Task<int> Second_UpdateAsync(Second_kind second_Kind)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"UPDATE [dbo].[config_file_second_kind] SET second_salary_id='{second_Kind.second_salary_id}',second_sale_id='{second_Kind.second_sale_id}' where fsk_id='{second_Kind.fsk_id}'";
                return await con.ExecuteAsync(sql);
            }
        }

        /// <summary>
        /// II级机构设置删除
        /// </summary>
        /// <returns></returns>
        public async Task<int> Second_DeleteAsync(int id)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"delete from  [dbo].[config_file_second_kind] where fsk_id='{id}'";
                return await con.ExecuteAsync(sql);
            }
        }
        /// <summary>
        /// 根据id 查询单个值
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Second_kind> Second_FindIdAsync(int id)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"select * from [dbo].[config_file_second_kind] where fsk_id='{id}'";
                return await con.QueryFirstAsync<Second_kind>(sql);
            }
        }
    }
}
