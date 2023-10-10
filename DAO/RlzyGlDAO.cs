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
    public class RlzyGlDAO
    {
        string conStr = "Data Source=.;Initial Catalog=HR_DB;Integrated Security=True";
        //职称查询
        public async Task<IEnumerable<PublicChar>> PublicChars_ZC_SelectXLKAsync()
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = "select * from [dbo].[config_public_char] where attribute_kind='职称'";
                return await connection.QueryAsync<PublicChar>(sql);
            }
        }
        //国籍查询
        public async Task<IEnumerable<PublicChar>> PublicChar_GJ_SelectXlkAsync()
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = $"select * from [dbo].[config_public_char] where attribute_kind='国籍'";
                return await connection.QueryAsync<PublicChar>(sql);
            }
        }
        //民族查询
        public async Task<IEnumerable<PublicChar>> PublicChars_MZ_SelectXLKAsync()
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = "select * from [dbo].[config_public_char] where attribute_kind='民族'";
                return await connection.QueryAsync<PublicChar>(sql);
            }
        }
        //宗教信仰查询
        public async Task<IEnumerable<PublicChar>> PublicChars_ZJXY_SelectXLKAsync()
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = "select * from [dbo].[config_public_char] where attribute_kind='宗教信仰'";
                return await connection.QueryAsync<PublicChar>(sql);
            }
        }
        //政治面貌查询
        public async Task<IEnumerable<PublicChar>> PublicChars_ZZMM_SelectXLKAsync()
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = "select * from [dbo].[config_public_char] where attribute_kind='政治面貌'";
                return await connection.QueryAsync<PublicChar>(sql);
            }
        }
        //教育年限查询
        public async Task<IEnumerable<PublicChar>> PublicChars_JYNX_SelectXLKAsync()
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = "select * from [dbo].[config_public_char] where attribute_kind='教育年限'";
                return await connection.QueryAsync<PublicChar>(sql);
            }
        }
        //学历查询
        public async Task<IEnumerable<PublicChar>> PublicChars_XL_SelectXLKAsync()
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = "select * from [dbo].[config_public_char] where attribute_kind='学历'";
                return await connection.QueryAsync<PublicChar>(sql);
            }
        }
        //学历专业查询
        public async Task<IEnumerable<PublicChar>> PublicChars_XLZY_SelectXLKAsync()
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = "select * from [dbo].[config_public_char] where attribute_kind='专业'";
                return await connection.QueryAsync<PublicChar>(sql);
            }
        }
        //薪酬设置查询
        public async Task<IEnumerable<PublicChar>> PublicChars_XCSZ_SelectXLKAsync()
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = "select * from [dbo].[config_public_char] where attribute_kind='薪酬设置'";
                return await connection.QueryAsync<PublicChar>(sql);
            }
        }
        //特长查询
        public async Task<IEnumerable<PublicChar>> PublicChars_TC_SelectXLKAsync()
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = "select * from [dbo].[config_public_char] where attribute_kind='特长'";
                return await connection.QueryAsync<PublicChar>(sql);
            }
        }
        //爱好查询
        public async Task<IEnumerable<PublicChar>> PublicChars_AH_SelectXLKAsync()
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = "select * from [dbo].[config_public_char] where attribute_kind='爱好'";
                return await connection.QueryAsync<PublicChar>(sql);
            }
        }
        //人力资源档案添加
        public async Task<int> Human_file_Insert_Async(Human_file human_File,Major major,Major_kind major_Kind,First_kind first_Kind,Second_kind second_Kind,Third_kind third_Kind)
        {
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                var first_kind_name = $"select first_kind_name from config_file_first_kind where first_kind_id={first_Kind.first_kind_id}";
                var second_kind_name = $"select second_kind_name from config_file_second_kind where second_kind_id={second_Kind.second_kind_id}";
                var third_kind_name = $"select third_kind_name from config_file_third_kind where third_kind_id={third_Kind.third_kind_id}";
                var major_kind_name = $"select [major_kind_name] from  [dbo].[config_major_kind] where [major_kind_id] ='{major_Kind.major_kind_id}'";
                var major_name = $"select [major_name] from [dbo].[config_major]  where  [major_id]='{major.major_id}'";
                string sql = $"insert into [dbo].[human_file]" +
                    $"( first_kind_id, first_kind_name, second_kind_id, second_kind_name, third_kind_id, third_kind_name, human_name, human_address, human_postcode, human_pro_designation," +
                    $"human_major_kind_id, human_major_kind_name, human_major_id, hunma_major_name, human_telephone, human_mobilephone, human_bank, human_account, human_qq, human_email," +
                    $"human_hobby, human_speciality, human_sex, human_religion, human_party, human_nationality, human_race, human_birthday, human_birthplace, human_age," +
                    $"human_educated_degree, human_educated_years, human_educated_major, human_society_security_id, human_id_card, remark, salary_standard_name,human_histroy_records, human_family_membership,register," +
                    $"regist_time)" +
                    $"values('{first_Kind.first_kind_id}',({first_kind_name}),'{second_Kind.second_kind_id}',({second_kind_name}),'{third_Kind.third_kind_id}',({third_kind_name}),'{human_File.human_name}','{human_File.human_address}','{human_File.human_postcode}','{human_File.human_pro_designation}'" +
                    $",'{major_Kind.major_kind_id}',({major_kind_name}),'{major.major_id}',({major_name}),'{human_File.human_telephone}','{human_File.human_mobilephone}','{human_File.human_bank}','{human_File.human_account}','{human_File.human_qq}','{human_File.human_email}'" +
                    $",'{human_File.human_hobby}','{human_File.human_speciality}','{human_File.human_sex}','{human_File.human_religion}','{human_File.human_party}','{human_File.human_nationality}','{human_File.human_race}','{human_File.human_birthday}','{human_File.human_birthplace}','{human_File.human_age}'" +
                    $",'{human_File.human_educated_degree}','{human_File.human_educated_years}','{human_File.human_educated_major}','{human_File.human_society_security_id}','{human_File.human_id_card}','{human_File.remark}','{human_File.salary_standard_name}','{human_File.human_histroy_records}','{human_File.human_family_membership}','{human_File.register}'" +
                    $",'{human_File.regist_time}')";
                return await connection.ExecuteAsync(sql);
            }
        }
    }
}
