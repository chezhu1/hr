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
    public class UsersDAO
    {
        string conStr = "Data Source=.;Initial Catalog=HR_DB;Integrated Security=True";

        /// <summary>
        /// 薪酬项目查询
        /// </summary>
        /// <returns></returns>
        public async Task<Users> User_Login(Users users)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"select * from [dbo].[users] where u_name='{users.u_name}' and u_password='{users.u_password}'";
                try
                {
                    return await con.QueryFirstAsync<Users>(sql);
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}
