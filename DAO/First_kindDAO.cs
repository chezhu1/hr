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
    public class First_kindDAO
    {

        string conStr = "Data Source=.;Initial Catalog=HR_DB;Integrated Security=True";

        /// <summary>
        /// I级机构设置查询
        /// </summary>
        /// <returns></returns>

        public async Task<IEnumerable<First_kind>> First_KindsAsync()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"select * from [dbo].[config_file_first_kind]";
                return await con.QueryAsync<First_kind>(sql);
            }
        }
        /// <summary>
        ///  I级机构设置添加
        /// </summary>
        /// <param name="first_Kind"></param>
        /// <returns></returns>
        public async Task<int> First_AddAsync(First_kind first_Kind)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string i = "SELECT TOP 1 \r\n    CASE \r\n        WHEN [first_kind_id] + 1 < 10 THEN '0' + CAST([first_kind_id] + 1 AS VARCHAR(2))\r\n        ELSE CAST([first_kind_id] + 1 AS VARCHAR(2))\r\n    END AS FormattedValue\r\nFROM [dbo].[config_file_first_kind] \r\nORDER BY ffk_id DESC";
                string id=await con.QueryFirstAsync<string>(i);

                string sql = $"INSERT INTO [dbo].[config_file_first_kind](first_kind_id, first_kind_name, first_kind_salary_id, first_kind_sale_id) VALUES('{id}','{first_Kind.first_kind_name}','{first_Kind.first_kind_salary_id}','{first_Kind.first_kind_sale_id}')";
                return await con.ExecuteAsync(sql);
            }
        }
        /// <summary>
        /// I级机构设置修改
        /// </summary>
        /// <param name="first_Kind"></param>
        /// <returns></returns>
        public async Task<int> First_UpdateAsync(First_kind first_Kind)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"update [dbo].[config_file_first_kind] set [first_kind_name]='{first_Kind.first_kind_name}',[first_kind_salary_id]='{first_Kind.first_kind_salary_id}',[first_kind_sale_id]='{first_Kind.first_kind_sale_id}' where ffk_id='{first_Kind.ffk_id}'";
                return await con.ExecuteAsync(sql);
            }
        }

        /// <summary>
        /// I级机构设置删除
        /// </summary>
        /// <param name="first_Kind"></param>
        /// <returns></returns>
        public async Task<int> First_DeleteAsync(int id)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"DELETE FROM [dbo].[config_file_first_kind] WHERE ffk_id='{id}'";
                return await con.ExecuteAsync(sql);
            }
        }
        /// <summary>
        /// 根据id一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<First_kind> First_FindIdAsync(int id)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"select * from [dbo].[config_file_first_kind] WHERE ffk_id='{id}'";
                return await con.QueryFirstAsync<First_kind>(sql);
            }
        }
    }
}
