using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Third_kindDAO
    {
        string conStr = "Data Source=.;Initial Catalog=HR_DB;Integrated Security=True";

        /// <summary>
        /// III级机构设置查询
        /// </summary>
        /// <returns></returns>

        public async Task<IEnumerable<Third_kind>> Third_KindsAsync()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"select * from [dbo].[config_file_third_kind]";
                return await con.QueryAsync<Third_kind>(sql);
            }
        }
        /// <summary>
        /// III级机构设置删除
        /// </summary>
        /// <returns></returns>
        public async Task<int> Third_DeleteAsync(int id)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"delete from [dbo].[config_file_third_kind] where ftk_id='{id}'";
                return await con.ExecuteAsync(sql);
            }
        }
        /// <summary>
        /// III级机构设置修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> Third_UpdateAsync(Third_kind third_Kind)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"update [dbo].[config_file_third_kind] set third_kind_sale_id='{third_Kind.third_kind_sale_id}',third_kind_is_retail='{third_Kind.third_kind_is_retail}' where ftk_id='{third_Kind.ftk_id}'";
                return await con.ExecuteAsync(sql);
            }
        }

        /// <summary>
        /// 根据id 查询单个值
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Third_kind> Third_FindIdAsync(int id)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"select * from [dbo].[config_file_third_kind] where ftk_id='{id}'";
                return await con.QueryFirstAsync<Third_kind>(sql);
            }
        }

        /// <summary>
        /// III机构设置的添加
        /// </summary>
        /// <param name="cfsk"></param>
        /// <returns></returns>
        public async Task<int> Third_AddAsync(Third_kind third_Kind)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {

                string i = "SELECT TOP 1 \r\n    CASE \r\n        WHEN [third_kind_id] + 1 < 10 THEN '0' + CAST([third_kind_id] + 1 AS VARCHAR(2))\r\n        ELSE CAST([third_kind_id] + 1 AS VARCHAR(2))\r\n    END AS FormattedValue\r\nFROM [dbo].[config_file_third_kind] \r\nORDER BY ftk_id DESC";
                string id = await con.QueryFirstAsync<string>(i);
                string sql = $"insert into [dbo].[config_file_third_kind](first_kind_id, first_kind_name, second_kind_id, second_kind_name, third_kind_id, third_kind_name, third_kind_sale_id, third_kind_is_retail)values('{third_Kind.first_kind_id}',(select [first_kind_name] from [dbo].[config_file_first_kind] where [first_kind_id]='{third_Kind.first_kind_id}'),'{third_Kind.second_kind_id}',(select [second_kind_name] from [dbo].[config_file_second_kind] where [second_kind_id]='{third_Kind.second_kind_id}'),'{id}','{third_Kind.third_kind_name}','{third_Kind.third_kind_sale_id}','{third_Kind.third_kind_is_retail}')";
                return await con.ExecuteAsync(sql);
            }
        }

        public async Task<IEnumerable<First_cascader>> GetFindAsync()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"select first_kind_id as value,first_kind_name as label from [dbo].[config_file_first_kind]";
                List<First_cascader> first_Cascaders = new List<First_cascader>() { };
                List<First_cascader> fir = con.Query<First_cascader>(sql).ToList();
                foreach (var item in fir)
                {
                    string sql_1 = $"select second_kind_id as value,second_kind_name as label from [dbo].[config_file_second_kind] where first_kind_id={item.value} ";
                    First_cascader cf = new First_cascader()
                    {
                        value = item.value,
                        label = item.label,
                        children= con.Query<Second_cascader>(sql_1).ToList(),
                    };
                    first_Cascaders.Add(cf);
                }
                return first_Cascaders;
            }
        }
    }
}
