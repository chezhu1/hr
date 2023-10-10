using DAO;
using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HR.Controllers
{
    public class ZPController : Controller
    {
        //I记机构设置
        First_kindDAO first_KindDAO = new First_kindDAO();
        //II记机构设置
        Second_kindDAO second_KindDAO = new Second_kindDAO();
        //III记机构设置
        Third_kindDAO third_KindDAO = new Third_kindDAO();
        //职位发布DAO层
        ZhiWeiFaBuDAO zhiWeiFaBuDAO = new ZhiWeiFaBuDAO();
        //简历管理DAO层
        JianLiGLDAO jianLiGLDAO=new JianLiGLDAO();
        //招聘管理控制器
        // GET: ZP
        //职位发布登记
        public async Task<ActionResult> Zw_Index_DengJi()
        {
            await xlkFind1();
            await xlkFind2();
            await xlkFind3();
            await xlkFind4();
            await xlkFind5();
            await xlkFind6();
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
            ViewBag.a= first_Kinds;
        }
        /// <summary>
        /// 三级下拉框
        /// </summary>
        /// <returns></returns>
        public async Task xlkFind3()
        {
            IEnumerable<Third_kind> third_Kinds=await zhiWeiFaBuDAO.ThirdSelectXlkAsync();
            ViewBag.ss = third_Kinds;
        }
        /// <summary>
        /// 职位分类下拉框
        /// </summary>
        /// <returns></returns>
        public async Task xlkFind4()
        {
            IEnumerable<Major_kind> major_Kinds = await zhiWeiFaBuDAO.Major_KindSelectXlkAsync();
            ViewBag.zw= major_Kinds;
        }
        /// <summary>
        /// 职位，名称下拉框
        /// </summary>
        /// <returns></returns>
        public async Task xlkFind5()
        {
            IEnumerable<Major> majors = await zhiWeiFaBuDAO.Major_SelectXlkAsync();
            ViewBag.mc= majors;
        }
        /// <summary>
        /// 登记人下拉框
        /// </summary>
        /// <returns></returns>
        public async Task xlkFind6()
        {
            IEnumerable<Users> users = await zhiWeiFaBuDAO.User_SelectXlkAsync();
            ViewBag.user= users;
        }

        //职业发布登记添加
        public async Task<int> ZhiYeFBInsert(Major_release major_Release)
        {
            return await zhiWeiFaBuDAO.ZhiWeiFB_InsertAsync(major_Release);
        }
        //职位发布变更
        public ActionResult Zw_Index_Update()
        {
           return View();
        }
        //分页查询
        public async Task<ActionResult> Zw_Index_Update1(FenYe<Major_release> fenYe)
        {
            fenYe = await zhiWeiFaBuDAO.ZhiWeiBG_SelectAsync(fenYe);
            return Json(fenYe, JsonRequestBehavior.AllowGet);
        }
        //职业发布删除
        public async Task<int> Zw_Index_Delete(int id)
        {
           return await  zhiWeiFaBuDAO.ZhiWeiBG_DeleteAsync(id);
        }
        //职业发布变更点击修改跳转
        public async Task<ActionResult> Zw_Index_Update2(int id)
        {
            ViewBag.xgs=await zhiWeiFaBuDAO.Major_release_SelectIdAsync(id);
            return View();
        }
        //职业发布变更修改
        public async Task<int> Zw_Index_Update3(Major_release major_Release)
        {
            return await zhiWeiFaBuDAO.ZhiWeiBG_XgAsync(major_Release);
        }

        //职位发布查询
        public ActionResult Zw_Index_Select()
        {
            return View();
        }
        //职业发布分页查询
        public async Task<ActionResult> Zw_Index_Select1(FenYe<Major_release> fenYe)
        {
            fenYe = await zhiWeiFaBuDAO.ZhiWeiBG_SelectAsync(fenYe);
            return Json(fenYe, JsonRequestBehavior.AllowGet);
        }
        //简历管理登记
        public async Task<ActionResult> Jl_Dj_Index()
        {
            await xlkFind5();
            await xlkFind4();
            await GjXlk();
            await MZXlk();
            await ZJXYXlk();
            await ZZMMXlk();
            await JYNXXlk();
            await XLXlk();
            await XLZYXlk();
            await TCXlk();
            await AHXlk();
            return View();
        }
        //国籍下拉框查询
        public async Task GjXlk()
        {
            IEnumerable<PublicChar> publicChars = await jianLiGLDAO.PublicChar_GJ_SelectXlkAsync();
            ViewBag.Gj = publicChars;
        }
        //民族下拉框查询
        public async Task MZXlk()
        {
            IEnumerable<PublicChar> publicChars = await jianLiGLDAO.PublicChars_MZ_SelectXLKAsync();
            ViewBag.MZ = publicChars;
        }
        //宗教信仰下拉框查询
        public async Task ZJXYXlk()
        {
            IEnumerable<PublicChar> publicChars = await jianLiGLDAO.PublicChars_ZJXY_SelectXLKAsync();
            ViewBag.ZJXY = publicChars;
        }
        //政治面貌下拉框查询
        public async Task ZZMMXlk()
        {
            IEnumerable<PublicChar> publicChars = await jianLiGLDAO.PublicChars_ZZMM_SelectXLKAsync();
            ViewBag.ZZMM = publicChars;
        }
        //教育年限下拉框查询
        public async Task JYNXXlk()
        {
            IEnumerable<PublicChar> publicChars = await jianLiGLDAO.PublicChars_JYNX_SelectXLKAsync();
            ViewBag.JYNX = publicChars;
        }
        //学历下拉框查询
        public async Task XLXlk()
        {
            IEnumerable<PublicChar> publicChars = await jianLiGLDAO.PublicChars_XL_SelectXLKAsync();
            ViewBag.XL = publicChars;
        }
        //学历专业下拉框查询
        public async Task XLZYXlk()
        {
            IEnumerable<PublicChar> publicChars = await jianLiGLDAO.PublicChars_XLZY_SelectXLKAsync();
            ViewBag.XLZY = publicChars;
        }
        //特长下拉框查询
        public async Task TCXlk()
        {
            IEnumerable<PublicChar> publicChars = await jianLiGLDAO.PublicChars_TC_SelectXLKAsync();
            ViewBag.TC = publicChars;
        }
        //爱好下拉框查询
        public async Task AHXlk()
        {
            IEnumerable<PublicChar> publicChars = await jianLiGLDAO.PublicChars_AH_SelectXLKAsync();
            ViewBag.AH = publicChars;
        }
        public ActionResult WSC()
        {
            var file = HttpContext.Request.Files["file"];//获取上传文件对象
                                                         //生成文件名
            string name = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            //获取后缀名
            string ext = file.FileName.Substring(file.FileName.LastIndexOf('.'));
            //相对路径
            string path = $"~/Uploaders/{DateTime.Now.ToString("yyyy/MM/dd/")}" + name + ext;
            //绝对路径
            string jpath = Server.MapPath(path);
            ViewBag.WSC = jpath;
            //创建上传文件对应的文件夹
            (new FileInfo(jpath)).Directory.Create();
            file.SaveAs(jpath);
            return Content("上传成功");
        }
        //简历登记添加
        public async Task<int> Jl_Dj_Insert(Engage_resume engage_Resume,Major major)
        {
            return await jianLiGLDAO.Engage_resume_InsertAsync(engage_Resume,major);
        }
        //简历筛选主页面
        public  ActionResult Jl_SX_Index()
        {
            return View();
        }
        /// <summary>
        /// 级联职位
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> ERXia()
        {
            IEnumerable cs = await jianLiGLDAO.ERXiaAsync();
            return Json(cs, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 级联机构
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> EMRXia()
        {
            IEnumerable cs = await jianLiGLDAO.GetFindAsync();
            return Json(cs, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 打开面试结果登记
        /// </summary>
        /// <returns></returns>
        public ActionResult InterviewList()
        {
            return View();
        }
        /// <summary>
        /// 打开简历筛选查询
        /// </summary>
        /// <returns></returns>
        public ActionResult ResumeList(string str)
        {
            ViewBag.str = str;
            return View();
        }
        /// <summary>
        /// 简历筛选查询
        /// </summary>
        /// <param name="ee"></param>
        /// <param name="tj"></param>
        /// <returns></returns>
        public async Task<ActionResult> ERFenYe(FenYe<Engage_resume> ee, string tj)
        {
            ee = await jianLiGLDAO.ERSelectAsync(ee, tj);
            return Json(ee, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 打开简历复核
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> ResumeDetails(string id)
        {
            ViewBag.s = await jianLiGLDAO.ERSelectIdAsync(id);
            return View();
        }
        /// <summary>
        /// 推荐
        /// </summary>
        /// <param name="ee"></param>
        /// <returns></returns>
        public async Task<int> ERUpdate(Engage_resume ee)
        {
            return await jianLiGLDAO.ERUpdateAsync(ee);
        }
        /// <summary>
        /// 打开有效简历查询
        /// </summary>
        /// <returns></returns>
        public ActionResult ValidResume()
        {
            return View();
        }
        /// <summary>
        /// 打开有效简历查询详情
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public async Task<ActionResult> ResumeSelect(string id)
        {
            ViewBag.s = await jianLiGLDAO.ERSelectIdAsync(id);
            return View();
        }
        /// <summary>
        /// 已复核
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public ActionResult ValidList(string str)
        {
            ViewBag.str = str;
            return View();
        }
        //招聘管理_面试管理_面试结果登记Index
        public ActionResult Msgl_Dj()
        {
            return View();
        }
        //招聘管理_面试结果登记查询
        public async Task<ActionResult> Msgl_Dj1(FenYe<Engage_resume> fenYe)
        {
            fenYe=await jianLiGLDAO.ERSelect_Ms_Async(fenYe);
            return Json(fenYe, JsonRequestBehavior.AllowGet);
        }
        //招聘管理_面试登记页面跳转
        public async Task<ActionResult> Msgl_DJ_DJ(string id)
        {
            ViewBag.s = await jianLiGLDAO.ERSelectIdAsync(id);
            return View();
        }
        //招聘管理_面试登记确认登记
        public async Task<int> Msgl_DJ_DJ1(Engage_interview engage_Interview)
        {
            return await jianLiGLDAO.ER_Interview_InsertAsync(engage_Interview);
        }
        //招聘管理_面试管理_面试筛选Index
        public ActionResult Msgl_Sx()
        {
            return View();
        }
        //招聘管理_面试筛选分页
        public async Task<ActionResult> Msgl_Sx1(FenYe<Engage_interview> fenYe)
        {
            fenYe = await jianLiGLDAO.ERSelect_MsSx_Async(fenYe);
            return Json(fenYe, JsonRequestBehavior.AllowGet);
        }
        //招聘管理_页面筛选跳转
        public async Task<ActionResult> Msgl_Sx_Sx(string id,string id1)
        {
            ViewBag.s = await jianLiGLDAO.ERSelectIdAsync(id);
            ViewBag.ss = await jianLiGLDAO.EISelectIdAsync(id1);
            return View();
        }
        //招聘管理_页面筛选跳转页面确认按钮
        public async Task<int> Msgl_Sx_Sx1(Engage_interview engage_Interview)
        {
            return await jianLiGLDAO.ER_Update_DjAsync(engage_Interview);
        }
        //录用申请Index
        public ActionResult Lygl_Sq_Index()
        {
            return View();
        }
        //录用申请Index分页
        public async Task<ActionResult> Lygl_Sq_Index1(FenYe<Engage_resume> fenYe)
        {
            fenYe = await jianLiGLDAO.ERSelect_Lysq_Async(fenYe);
            return Json(fenYe, JsonRequestBehavior.AllowGet);
        }
        //录用申请Index申请按钮跳转
        public async Task<ActionResult> Lygl_Sq_Sq(string id)
        {
            ViewBag.s = await jianLiGLDAO.ERSelectIdAsync(id);
            return View();
        }
        //录用申请确认按钮通过方法
        public async Task<int> Lygl_Sq_Qr(Engage_resume engage_Resume)
        {
            return await jianLiGLDAO.ER_Update_SqAsync(engage_Resume);
        }
        //录用申请确认按钮不通过方法
        public async Task<int> Lygl_Sq_Qx(Engage_interview engage_Interview)
        {
            int a=1;
            return await jianLiGLDAO.ER_Update_SqAsync1(engage_Interview,a++);
        }
        //录用审批Index
        public ActionResult Lygl_Sp_Index()
        {
            return View();
        }
        //录用审批Index分页
        public async Task<ActionResult> Lygl_Sp_Index1(FenYe<Engage_resume> fenYe)
        {
            fenYe = await jianLiGLDAO.ERSelect_Lysp_Async(fenYe);
            return Json(fenYe, JsonRequestBehavior.AllowGet);
        }
        //录用审批跳转按钮
        public async Task<ActionResult> Lygl_Sp_Sp(string id)
        {
            ViewBag.s = await jianLiGLDAO.ERSelectIdAsync(id);
            return View();
        }
        //录用审批通过按钮
        public async Task<int> Lygl_Sp_Qr(Engage_resume engage_Resume)
        {
            return await jianLiGLDAO.ER_Update_SpAsync1(engage_Resume);
        }
        //录用审批不通过按钮
        public async Task<int> Lygl_Sp_Qx(Engage_resume engage_Resume)
        {
            return await jianLiGLDAO.ER_Update_SpAsync(engage_Resume);
        }
        //录用管理录用查询主页
        public ActionResult Lygl_Cx_Index()
        {
            return View();
        }
        //录用查询主页分页方法
        public async Task<ActionResult> Lygl_Cx_Index1(FenYe<Engage_resume> fenYe)
        {
            fenYe = await jianLiGLDAO.ERSelect_Lycx_Async(fenYe);
            return Json(fenYe, JsonRequestBehavior.AllowGet);
        }
        //录用管理录用查询跳转按钮
        public async Task<ActionResult> Lygl_Cx_Cx(string id)
        {
            ViewBag.s = await jianLiGLDAO.ERSelectIdAsync(id);
            return View();
        }
    }

}
