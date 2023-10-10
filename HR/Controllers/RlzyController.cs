using DAO;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HR.Controllers
{
    public class RlzyController : Controller
    {
        //I记机构设置
        First_kindDAO first_KindDAO = new First_kindDAO();
        //II记机构设置
        Second_kindDAO second_KindDAO = new Second_kindDAO();
        //III记机构设置
        Third_kindDAO third_KindDAO = new Third_kindDAO();
        //职位发布DAO层
        ZhiWeiFaBuDAO zhiWeiFaBuDAO = new ZhiWeiFaBuDAO();
        //人力资源管理DAO
        RlzyGlDAO rlzyGlDAO = new RlzyGlDAO();
        // GET: Rlzy
        public async Task<ActionResult> Rlzy_Dj_Insert()
        {
            await xlkFind1();
            await xlkFind2();
            await xlkFind3();
            await xlkFind4();
            await xlkFind5();
            await xlkFind6();
            await xlkFInd7();
            await xlkFInd8();
            await xlkFInd9();
            await xlkFInd10();
            await xlkFInd11();
            await xlkFInd12();
            await xlkFInd13();
            await xlkFInd14();
            await xlkFInd15();
            await xlkFInd16();
            return View();
        }
        /// <summary>
        /// 一级下拉框
        /// </summary>
        /// <returns></returns>
        public async Task xlkFind1()
        {
            IEnumerable<First_kind> first_Kinds = await zhiWeiFaBuDAO.First_KindsSelectXlkAsync();
            ViewBag.s = first_Kinds;
        }
        /// <summary>
        /// 二级下拉框
        /// </summary>
        /// <returns></returns>
        public async Task xlkFind2()
        {
            IEnumerable<Second_kind> first_Kinds = await zhiWeiFaBuDAO.Second_KindsAsync();
            ViewBag.ss = first_Kinds;
        }
        /// <summary>
        /// 三级下拉框
        /// </summary>
        /// <returns></returns>
        public async Task xlkFind3()
        {
            IEnumerable<Third_kind> third_Kinds = await zhiWeiFaBuDAO.ThirdSelectXlkAsync();
            ViewBag.sss = third_Kinds;
        }
        /// <summary>
        /// 职位分类下拉框
        /// </summary>
        /// <returns></returns>
        public async Task xlkFind4()
        {
            IEnumerable<Major_kind> major_Kinds = await zhiWeiFaBuDAO.Major_KindSelectXlkAsync();
            ViewBag.zw = major_Kinds;
        }
        /// <summary>
        /// 职位，名称下拉框
        /// </summary>
        /// <returns></returns>
        public async Task xlkFind5()
        {
            IEnumerable<Major> majors = await zhiWeiFaBuDAO.Major_SelectXlkAsync();
            ViewBag.mc = majors;
        }
        //职称查询
        public async Task xlkFind6()
        {
            IEnumerable<PublicChar> publicChars=await rlzyGlDAO.PublicChars_ZC_SelectXLKAsync();
            ViewBag.zc= publicChars;
        }
        //国籍查询
        public async Task xlkFInd7()
        {
            IEnumerable<PublicChar> publicChars = await rlzyGlDAO.PublicChar_GJ_SelectXlkAsync();
            ViewBag.gj=publicChars;
        }
        //民族查询
        public async Task xlkFInd8()
        {
            IEnumerable<PublicChar> publicChars = await rlzyGlDAO.PublicChars_MZ_SelectXLKAsync();
            ViewBag.mz= publicChars;
        }
        //宗教信仰
        public async Task xlkFInd9()
        {
            IEnumerable<PublicChar> publicChars = await rlzyGlDAO.PublicChars_ZJXY_SelectXLKAsync();
            ViewBag.zjxy= publicChars;
        }
        //政治面貌
        public async Task xlkFInd10()
        {
            IEnumerable<PublicChar> publicChars = await rlzyGlDAO.PublicChars_ZZMM_SelectXLKAsync();
            ViewBag.zzmm= publicChars;
        }
        //学历
        public async Task xlkFInd11()
        {
            IEnumerable<PublicChar> publicChars = await rlzyGlDAO.PublicChars_XL_SelectXLKAsync();
            ViewBag.xl= publicChars;
        }
        //教育年限
        public async Task xlkFInd12()
        {
            IEnumerable<PublicChar> publicChars = await rlzyGlDAO.PublicChars_JYNX_SelectXLKAsync();
            ViewBag.jynx= publicChars;
        }
        //薪酬设置
        public async Task xlkFInd13()
        {
            IEnumerable<PublicChar> publicChars = await rlzyGlDAO.PublicChars_XCSZ_SelectXLKAsync();
            ViewBag.xcsz = publicChars;
        }
        //特长
        public async Task xlkFInd14()
        {
            IEnumerable<PublicChar> publicChars = await rlzyGlDAO.PublicChars_TC_SelectXLKAsync();
            ViewBag.tc = publicChars;
        }
        //爱好
        public async Task xlkFInd15()
        {
            IEnumerable<PublicChar> publicChars = await rlzyGlDAO.PublicChars_AH_SelectXLKAsync();
            ViewBag.ah = publicChars;
        }
        //学历专业
        public async Task xlkFInd16()
        {
            IEnumerable<PublicChar> publicChars = await rlzyGlDAO.PublicChars_XLZY_SelectXLKAsync();
            ViewBag.xlzy = publicChars;
        }
        //人力资源档案添加
        public async Task<int> Rlzy_Dj_Insert1(Human_file human_File, Major major, Major_kind major_Kind, First_kind first_Kind, Second_kind second_Kind, Third_kind third_Kind)
        {
            return await rlzyGlDAO.Human_file_Insert_Async(human_File,major,major_Kind,first_Kind,second_Kind,third_Kind);
        }
        
    }
}