using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    //简历管理DAO
    public class JianLiGLDAO
    {
        string conStr = "Data Source=.;Initial Catalog=HR_DB;Integrated Security=True";
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
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                string sql = "select * from [dbo].[config_public_char] where attribute_kind='民族'";
                return await connection.QueryAsync<PublicChar>(sql);
            }
        }
        //宗教信仰查询
        public async Task<IEnumerable<PublicChar>> PublicChars_ZJXY_SelectXLKAsync()
        {
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                string sql = "select * from [dbo].[config_public_char] where attribute_kind='宗教信仰'";
                return await connection.QueryAsync<PublicChar>(sql);
            }
        }
        //政治面貌查询
        public async Task<IEnumerable<PublicChar>> PublicChars_ZZMM_SelectXLKAsync()
        {
            using (SqlConnection connection=new SqlConnection(conStr))
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
        //根据id查询一条数据传值
        public async Task<Major_release> Major_releaseSelectIdAsync(int id)
        {
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                string sql = $"select * from [dbo].[engage_major_release] where mre_id='{id}'";
                return await connection.QueryFirstAsync<Major_release>(sql);
            }
        }
        //添加
        public async Task<int> Engage_resume_InsertAsync(Engage_resume engage_Resume,Major major)
        {
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                var major_kind_name = $"select [major_kind_name] from  [dbo].[config_major_kind] where [major_kind_id] ='{major.major_kind_id}'";
                var major_name = $"select [major_name] from [dbo].[config_major]  where  [major_id]='{major.major_id}'";
                string sql = $"insert into [dbo].[engage_resume]( human_name, engage_type, human_address, human_postcode, human_major_kind_id, human_major_kind_name, human_major_id, human_major_name, human_telephone, human_homephone," +
                    $" human_mobilephone, human_email, human_hobby, human_specility, human_sex, human_religion, human_party, human_nationality, human_race, human_birthday," +
                    $" human_age, human_educated_degree, human_educated_years, human_educated_major, human_college, human_idcard, human_birthplace, demand_salary_standard, human_history_records, remark, " +
                    $" regist_time,check_status,interview_status,pass_check_status) " +
                    $"values('{engage_Resume.human_name}','{engage_Resume.engage_type}','{engage_Resume.human_address}','{engage_Resume.human_postcode}','{major.major_kind_id}',({major_kind_name}),'{major.major_id}',({major_name}),'{engage_Resume.human_telephone}','{engage_Resume.human_homephone}'," +
                    $"'{engage_Resume.human_mobilephone}','{engage_Resume.human_email}','{engage_Resume.human_hobby}','{engage_Resume.human_specility}','{engage_Resume.human_sex}','{engage_Resume.human_religion}','{engage_Resume.human_party}','{engage_Resume.human_nationality}','{engage_Resume.human_race}','{engage_Resume.human_birthday}'," +
                    $"'{engage_Resume.human_age}','{engage_Resume.human_educated_degree}','{engage_Resume.human_educated_years}','{engage_Resume.human_educated_major}','{engage_Resume.human_college}','{engage_Resume.human_idcard}','{engage_Resume.human_birthplace}','{engage_Resume.demand_salary_standard}','{engage_Resume.human_history_records}','{engage_Resume.remark}'," +
                    $"'{engage_Resume.regist_time}',0,0,0)";
                return await connection.ExecuteAsync(sql);
            }
        }




        //筛选
        public async Task<IEnumerable<First_cascader>> ERXiaAsync()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"select major_kind_id as value,major_kind_name as label from [dbo].[config_major_kind]";
                List<First_cascader> first_Cascaders = new List<First_cascader>() { };
                List<First_cascader> fir = con.Query<First_cascader>(sql).ToList();
                foreach (var item in fir)
                {
                    string sql_1 = $"select major_id as value,major_name as label from [dbo].[config_major] where major_kind_id={item.value} ";
                    First_cascader cf = new First_cascader()
                    {
                        value = item.value,
                        label = item.label,
                        children = con.Query<Second_cascader>(sql_1).ToList(),
                    };
                    first_Cascaders.Add(cf);
                }
                return first_Cascaders;
            }
        }

        public async Task<IEnumerable<Lian>> GetFindAsync()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"select * from [dbo].[config_file_first_kind]";
                IEnumerable<First_kind> first_Cascaders = await con.QueryAsync<First_kind>(sql);
                List<Lian> fir = new List<Lian>();
                foreach (First_kind item in first_Cascaders)
                {

                    Lian cf = new Lian()
                    {
                        value = item.first_kind_id,
                        label = item.first_kind_name,
                        children = (List<Lian>)await Cha(item.first_kind_id),
                    };
                    fir.Add(cf);
                }
                return fir;
            }

        }


        public async Task<IEnumerable<Lian>> Cha(string id)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"select [second_kind_id],[second_kind_name] from [dbo].[config_file_second_kind] where [first_kind_id]='{id}'";
                IEnumerable<Second_kind> first_Cascaders = await con.QueryAsync<Second_kind>(sql);
                List<Lian> fir = new List<Lian>();
                foreach (Second_kind item in first_Cascaders)
                {

                    Lian cf = new Lian()
                    {
                        value = item.second_kind_id,
                        label = item.second_kind_name,
                        children = (List<Lian>)await Cha1(item.second_kind_id),
                    };
                    fir.Add(cf);
                }
                return fir;
            }

        }

        public async Task<IEnumerable<Lian>> Cha1(string id)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $"select [third_kind_id],[third_kind_name] from [dbo].[config_file_third_kind] where [second_kind_id]='{id}'";
                IEnumerable<Third_kind> first_Cascaders = await con.QueryAsync<Third_kind>(sql);
                List<Lian> fir = new List<Lian>();
                foreach (Third_kind item in first_Cascaders)
                {

                    Lian cf = new Lian()
                    {
                        value = item.third_kind_id,
                        label = item.third_kind_name,

                    };
                    fir.Add(cf);
                }
                return fir;
            }

        }

        public async Task<FenYe<Engage_resume>> ERSelectAsync(FenYe<Engage_resume> er, string tj)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                DynamicParameters dd = new DynamicParameters();
                dd.Add("@pageSize", er.PageSize);
                dd.Add("@keyName", "res_id");
                dd.Add("@tableName", "engage_resume");
                dd.Add("@currentPage", er.CurrentPage);
                dd.Add("@where", tj);
                dd.Add("@row", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = "exec [dbo].[FenYe] @pageSize, @keyName, @tableName, @currentPage, @where, @row out";
                er.List = await con.QueryAsync<Engage_resume>(sql, dd);
                er.Rows = dd.Get<int>("row");
                return er;
            }
        }
        public async Task<Engage_resume> ERSelectIdAsync(string id)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $@"select * from engage_resume where res_id = '{id}'";
                return await con.QueryFirstAsync<Engage_resume>(sql);
            }
        }
        public async Task<int> ERUpdateAsync(Engage_resume er)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $@"update [dbo].[engage_resume] set engage_type = '{er.engage_type}',human_email = '{er.human_email}',
                human_telephone = '{er.human_telephone}',human_homephone = '{er.human_homephone}',human_mobilephone = '{er.human_mobilephone}',
                human_address = '{er.human_address}',human_postcode = '{er.human_postcode}',human_nationality = '{er.human_nationality}',
                human_birthplace = '{er.human_birthplace}',human_birthday = '{er.human_birthday}',human_race = '{er.human_race}',
                human_religion = '{er.human_religion}',human_party = '{er.human_party}',human_idcard = '{er.human_idcard}',
                human_age = '{er.human_age}',human_college = '{er.human_college}',human_educated_degree = '{er.human_educated_degree}',
                human_educated_years = '{er.human_educated_years}',human_educated_major = '{er.human_educated_major}',
                demand_salary_standard = '{er.demand_salary_standard}',human_specility = '{er.human_specility}',human_hobby = '{er.human_hobby}',
                human_history_records = '{er.human_history_records}',remark = '{er.remark}',recomandation = '{er.recomandation}',
                checker = '张三',check_time = '{er.check_time}',check_status = 1 where res_id = '{er.res_id}'";
                return await con.ExecuteAsync(sql);
            }
        }
        //面试管理_面试结果登记
        public async Task<FenYe<Engage_resume>> ERSelect_Ms_Async(FenYe<Engage_resume> fenYe)
        {
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageSize", fenYe.PageSize);
                dynamicParameters.Add("@keyName", "res_id");
                dynamicParameters.Add("@tableName", "engage_resume");
                dynamicParameters.Add("@currentPage", fenYe.CurrentPage);
                dynamicParameters.Add("@row", direction: ParameterDirection.Output, dbType: DbType.Int32);
                dynamicParameters.Add("@where", "check_status=1");
                string sql = "exec [dbo].[FenYe] @pageSize, @keyName, @tableName, @currentPage, @where, @row out";
                fenYe.List = await connection.QueryAsync<Engage_resume>(sql, dynamicParameters);
                fenYe.Rows = dynamicParameters.Get<int>("row");
                return fenYe;
            }
        }
        //面试登记面试表添加
        public async Task<int> ER_Interview_InsertAsync(Engage_interview engage_Interview)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                var major_kind_id = $"select [major_kind_id] from  [dbo].[config_major_kind] where [major_kind_name] ='{engage_Interview.human_major_kind_name}'";
                var major_id = $"select [major_id] from [dbo].[config_major]  where  [major_name]='{engage_Interview.human_major_name}'";

                string sql = $"insert into [dbo].[engage_interview]( human_name, interview_amount, human_major_kind_id, human_major_kind_name, human_major_id, human_major_name, image_degree, native_language_degree, foreign_language_degree, response_speed_degree," +
                    $"EQ_degree, IQ_degree, multi_quality_degree, register, checker,  resume_id,  interview_comment,  interview_status, check_status,registe_time)" +
                    $"values('{engage_Interview.human_name}','1',({major_kind_id}),'{engage_Interview.human_major_kind_name}',({major_id}),'{engage_Interview.human_major_name}','{engage_Interview.image_degree}','{engage_Interview.native_language_degree}','{engage_Interview.foreign_language_degree}','{engage_Interview.response_speed_degree}'," +
                    $"'{engage_Interview.EQ_degree}','{engage_Interview.IQ_degree}','{engage_Interview.multi_quality_degree}','{engage_Interview.register}','{engage_Interview.checker}','{engage_Interview.resume_id}','{engage_Interview.interview_comment}','1','1','{engage_Interview.registe_time}')";
                sql += $" " +
                    $" update engage_resume set interview_status=1 where res_id={engage_Interview.resume_id}";
                return await  connection.ExecuteAsync(sql);
            }
        }
        //面试登记面试筛选分页
        public async Task<FenYe<Engage_interview>> ERSelect_MsSx_Async(FenYe<Engage_interview> fenYe)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageSize", fenYe.PageSize);
                dynamicParameters.Add("@keyName", "ein_id");
                dynamicParameters.Add("@tableName", "engage_interview");
                dynamicParameters.Add("@currentPage", fenYe.CurrentPage);
                dynamicParameters.Add("@row", direction: ParameterDirection.Output, dbType: DbType.Int32);
                dynamicParameters.Add("@where", " interview_status=1");
                string sql = "exec [dbo].[FenYe] @pageSize, @keyName, @tableName, @currentPage, @where, @row out";
                fenYe.List = await connection.QueryAsync<Engage_interview>(sql, dynamicParameters);
                fenYe.Rows = dynamicParameters.Get<int>("row");
                return fenYe;
            }
        }
        //面试根据id查单个
        public async Task<Engage_interview> EISelectIdAsync(string id)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $@"select * from engage_interview where ein_id = '{id}'";
                return await con.QueryFirstAsync<Engage_interview>(sql);
            }
        }
        //面试筛选确认登记
        public async Task<int> ER_Update_DjAsync(Engage_interview engage_Interview)
        {
            using (SqlConnection connection=new SqlConnection(conStr))
            {

                string sql = $"Update engage_resume set pass_checkComment='{engage_Interview.check_comment}' , pass_check_status = 1  where  res_id={engage_Interview.resume_id}";
                return await connection.ExecuteAsync(sql);
            }
        }
        //录用申请Index分页
        public async Task<FenYe<Engage_resume>> ERSelect_Lysq_Async(FenYe<Engage_resume> fenYe)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageSize", fenYe.PageSize);
                dynamicParameters.Add("@keyName", "res_id");
                dynamicParameters.Add("@tableName", "engage_resume");
                dynamicParameters.Add("@currentPage", fenYe.CurrentPage);
                dynamicParameters.Add("@row", direction: ParameterDirection.Output, dbType: DbType.Int32);
                dynamicParameters.Add("@where", " pass_check_status=1");
                string sql = "exec [dbo].[FenYe] @pageSize, @keyName, @tableName, @currentPage, @where, @row out";
                fenYe.List = await connection.QueryAsync<Engage_resume>(sql, dynamicParameters);
                fenYe.Rows = dynamicParameters.Get<int>("row");
                return fenYe;
            }
        }
        //面试根据resid查单个
        public async Task<Engage_interview> EISelectresIdAsync(string id)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = $@"select * from engage_interview where resume_id = '{id}'";
                return await con.QueryFirstAsync<Engage_interview>(sql);
            }
        }
        //面试录用申请通过确认按钮
        public async Task<int> ER_Update_SqAsync(Engage_resume engage_Resume)
        {
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                string sql = $"Update engage_resume set pass_checkComment='{engage_Resume.pass_checkComment}' , pass_check_status = 2  where  res_id={engage_Resume.res_id}";
                return await connection.ExecuteAsync(sql);
            }
        }
        //面试录用申请不通过按钮
        public async Task<int> ER_Update_SqAsync1(Engage_interview engage_Interview,int c)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                int a = c++;
                string sql = $"Update engage_interview set interview_amount={a}+1 , interview_status = 0  where  resume_id={engage_Interview.ein_id}  " +
                    $"" +
                    $"Update engage_resume set pass_check_status = 0 where  res_id={engage_Interview.ein_id}";
                return await connection.ExecuteAsync(sql);
            }
        }

        //录用审批Index分页
        public async Task<FenYe<Engage_resume>> ERSelect_Lysp_Async(FenYe<Engage_resume> fenYe)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageSize", fenYe.PageSize);
                dynamicParameters.Add("@keyName", "res_id");
                dynamicParameters.Add("@tableName", "engage_resume");
                dynamicParameters.Add("@currentPage", fenYe.CurrentPage);
                dynamicParameters.Add("@row", direction: ParameterDirection.Output, dbType: DbType.Int32);
                dynamicParameters.Add("@where", " pass_check_status=2");
                string sql = "exec [dbo].[FenYe] @pageSize, @keyName, @tableName, @currentPage, @where, @row out";
                fenYe.List = await connection.QueryAsync<Engage_resume>(sql, dynamicParameters);
                fenYe.Rows = dynamicParameters.Get<int>("row");
                return fenYe;
            }
        }
        //录用审批不通过按钮
        public async Task<int> ER_Update_SpAsync(Engage_resume engage_Resume)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = $"Update engage_resume set pass_checkComment='{engage_Resume.pass_checkComment}' , pass_check_status = 1  where  res_id={engage_Resume.res_id}";
                return await connection.ExecuteAsync(sql);
            }
        }
        //录用审批通过按钮
        public async Task<int> ER_Update_SpAsync1(Engage_resume engage_Resume)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = $"Update engage_resume set pass_checkComment='{engage_Resume.pass_checkComment}' , pass_check_status = 3  where  res_id={engage_Resume.res_id}";
                return await connection.ExecuteAsync(sql);
            }
        }
        //录用管理录用查询分页方法
        public async Task<FenYe<Engage_resume>> ERSelect_Lycx_Async(FenYe<Engage_resume> fenYe)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageSize", fenYe.PageSize);
                dynamicParameters.Add("@keyName", "res_id");
                dynamicParameters.Add("@tableName", "engage_resume");
                dynamicParameters.Add("@currentPage", fenYe.CurrentPage);
                dynamicParameters.Add("@row", direction: ParameterDirection.Output, dbType: DbType.Int32);
                dynamicParameters.Add("@where", " pass_check_status=3");
                string sql = "exec [dbo].[FenYe] @pageSize, @keyName, @tableName, @currentPage, @where, @row out";
                fenYe.List = await connection.QueryAsync<Engage_resume>(sql, dynamicParameters);
                fenYe.Rows = dynamicParameters.Get<int>("row");
                return fenYe;
            }
        }

    }
}
