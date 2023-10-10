using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class PublicCharDAO
    {
        string conStr = "Data Source=.;Initial Catalog=HR_DB;Integrated Security=True";

        /// <summary>
        /// 薪酬项目查询
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PublicChar>> Char_KindsAsync()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"select * from [dbo].[config_public_char] where attribute_kind='薪酬设置'";
                return await con.QueryAsync<PublicChar>(sql);
            }
        }

        /// <summary>
        /// 职称设置查询
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PublicChar>> Zhicheng_KindsAsync()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"select * from [dbo].[config_public_char] where attribute_kind='职称'";
                return await con.QueryAsync<PublicChar>(sql);
            }
        }

        /// <summary>
        /// 公共属性查询
        /// </summary>
        /// <returns></returns>
        public async Task<FenYe<PublicChar>> Char_Kind1sAsync(FenYe<PublicChar> fenYe)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageSize", fenYe.PageSize);
                dynamicParameters.Add("@keyName", "pbc_id");
                dynamicParameters.Add("@tableName", "config_public_char");
                dynamicParameters.Add("@currentPage", fenYe.CurrentPage);
                dynamicParameters.Add("@rows", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = "exec [dbo].[proc_GGFenYe] @pageSize, @keyName, @tableName, @currentPage, @rows out";
                fenYe.List = await con.QueryAsync<PublicChar>(sql, dynamicParameters);
                fenYe.Rows = dynamicParameters.Get<int>("rows");
                return fenYe;
            }
        }

        /// <summary>
        /// 薪酬项目添加
        /// </summary>
        /// <returns></returns>
        public async Task<int> Char_AddAsync(PublicChar publicChar)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"INSERT INTO [dbo].[config_public_char](attribute_kind,attribute_name) VALUES('薪酬设置','{publicChar.attribute_name}')";
                return await con.ExecuteAsync(sql);
            }
        }

        /// <summary>
        /// 职称设置添加
        /// </summary>
        /// <returns></returns>
        public async Task<int> Zhicheng_AddAsync(PublicChar publicChar)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"INSERT INTO [dbo].[config_public_char](attribute_kind,attribute_name) VALUES('职称','{publicChar.attribute_name}')";
                return await con.ExecuteAsync(sql);
            }
        }

        /// <summary>
        /// 公共属性添加
        /// </summary>
        /// <param name="publicChar"></param>
        /// <returns></returns>
        public async Task<int> Char_Add1Async(PublicChar publicChar)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"INSERT INTO [dbo].[config_public_char](attribute_kind,attribute_name) VALUES('{publicChar.attribute_kind}','{publicChar.attribute_name}')";
                return await con.ExecuteAsync(sql);
            }
        }

        /// <summary>
        /// 薪酬项目删除
        /// </summary>
        /// <returns></returns>
        public async Task<int> Char_DeleteAsync(int id)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"DELETE FROM [dbo].[config_public_char] WHERE pbc_id='{id}'";
                return await con.ExecuteAsync(sql);
            }
        }
    }
}
