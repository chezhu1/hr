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
    public class ZhiWeiFaBuDAO
    {
        string conStr = "Data Source=.;Initial Catalog=HR_DB;Integrated Security=True";
        //职位发布登记一级下拉款
        public async Task<IEnumerable<First_kind>> First_KindsSelectXlkAsync()
        {
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                string sql = $"  select * from [dbo].[config_file_first_kind]";
                return await connection.QueryAsync<First_kind>(sql);
            }
        }
        //职位发布登记二级下拉框
        public async Task<IEnumerable<Second_kind>> Second_KindsAsync()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"select * from [dbo].[config_file_second_kind]";
                return await con.QueryAsync<Second_kind>(sql);
            }
        }

        //职位发布登记三级获取下拉款
        public async Task<IEnumerable<Third_kind>> ThirdSelectXlkAsync()
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = $"select * from [dbo].[config_file_third_kind]";
                return await connection.QueryAsync<Third_kind>(sql);
            }
        }
        //职位发布登记分类下拉框
        public async Task<IEnumerable<Major_kind>> Major_KindSelectXlkAsync()
        {
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                string sql = "select * from config_major_kind";
                return await connection.QueryAsync<Major_kind>(sql);
            }
        }
        //职位发布登记名称下拉框
        public async Task<IEnumerable<Major>> Major_SelectXlkAsync()
        {
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                string sql = $"  select * from [dbo].[config_major]";
                return await connection.QueryAsync<Major>(sql);
            }
        }
        //职位发布登记登记人下拉框加载
        public async Task<IEnumerable<Users>> User_SelectXlkAsync()
        {
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                string sql = "Select * from [dbo].[users]";
                return await connection.QueryAsync<Users>(sql);
            }
        }
        //职位发布登记添加
        public async Task<int> ZhiWeiFB_InsertAsync(Major_release major_Release)
        {
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                string sql = $"insert into [dbo].[engage_major_release](first_kind_id, first_kind_name, second_kind_id, second_kind_name, third_kind_id, third_kind_name,major_kind_id, major_kind_name, major_id, major_name, human_amount, engage_type, deadline,    register, regist_time,major_describe, engage_required) " +
                    $"values('{major_Release.first_kind_id}'" +
                    $",(select first_kind_name from [dbo].[config_file_first_kind] where  first_kind_id='{major_Release.first_kind_id}')," +
                    $"'{major_Release.second_kind_id}',(  select second_kind_name from [dbo].[config_file_second_kind] where  second_kind_id='{major_Release.second_kind_id}')," +
                    $"'{major_Release.third_kind_id}',( select third_kind_name from [dbo].[config_file_third_kind] where  third_kind_id='{major_Release.third_kind_id}'),'{major_Release.major_kind_id}'," +
                    $"( select [major_kind_name] from  [dbo].[config_major_kind] where [major_kind_id] ='{major_Release.major_kind_id}'),'{major_Release.major_id}',(select [major_name] from [dbo].[config_major]  where  [major_id]='{major_Release.major_id}')," +
                    $"'{major_Release.human_amount}','{major_Release.engage_type}','{major_Release.deadline}','{major_Release.register}','{major_Release.regist_time}','{major_Release.major_describe}','{major_Release.engage_required}')";
                return await connection.ExecuteAsync(sql);
            }
        }
        //职位发布变更分页查询
        public async Task<FenYe<Major_release>> ZhiWeiBG_SelectAsync(FenYe<Major_release> fenYe)
        {
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageSize", fenYe.PageSize);
                dynamicParameters.Add("@keyName", "mre_id");
                dynamicParameters.Add("@tableName", "engage_major_release");
                dynamicParameters.Add("@currentPage", fenYe.CurrentPage);
                dynamicParameters.Add("@rows", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = "exec [dbo].[proc_GGFenYe] @pageSize, @keyName, @tableName, @currentPage, @rows out";
                fenYe.List = await connection.QueryAsync<Major_release>(sql, dynamicParameters);
                fenYe.Rows = dynamicParameters.Get<int>("rows");
                return fenYe;
            }
        }
        //职位发布变更删除
        public async Task<int> ZhiWeiBG_DeleteAsync(int id)
        {
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                string sql = $" delete from [dbo].[engage_major_release] where [mre_id]='{id}'";
                return await  connection.ExecuteAsync(sql);
            }
        }
        //根据id查询一条数据
        public async Task<Major_release> Major_release_SelectIdAsync(int id)
        {
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                string sql = $"select * from [dbo].[engage_major_release] where mre_id='{id}'";
                return await connection.QueryFirstAsync<Major_release>(sql);
            }
        }
        //职位发布变更修改
        public async Task<int> ZhiWeiBG_XgAsync(Major_release major_Release)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = $"update [dbo].[engage_major_release] set engage_type='{major_Release.engage_type}',human_amount='{major_Release.human_amount}',regist_time='{major_Release.regist_time}',major_describe='{major_Release.major_describe}',engage_required='{major_Release.engage_required}' where mre_id='{major_Release.mre_id}'";
                return await connection.ExecuteAsync(sql);
            }
        }


    }
}
