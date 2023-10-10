using Antlr.Runtime.Tree;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DAO;


namespace HR.Controllers
{
    public class KFController : Controller
    {
        //I记机构设置
        First_kindDAO first_KindDAO = new First_kindDAO();
        //II记机构设置
        Second_kindDAO second_KindDAO = new Second_kindDAO();
        //III记机构设置
        Third_kindDAO third_KindDAO = new Third_kindDAO();
        //薪酬项目设置
        PublicCharDAO publicCharDAO = new PublicCharDAO();
        //职位分类设置
        Major_kindDAO major_KindDAO = new Major_kindDAO();
        //职位设置
        MajorDAO major_DAO = new MajorDAO();

        // GET: KF
        /// <summary>
        /// 打开I机构
        /// </summary>
        /// <returns></returns>
        public ActionResult First_index()
        {
            return View();
        }
        /// <summary>
        /// I机构设置查询
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> FirstFind()
        {
            return Json(await first_KindDAO.First_KindsAsync(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult FirstAdd()
        {
            return View();
        }
        /// <summary>
        /// I机构设置添加
        /// </summary>
        /// <param name="first_Kind"></param>
        /// <returns></returns>
        public async Task<int> FirstInsert(First_kind first_Kind)
        {
            return await first_KindDAO.First_AddAsync(first_Kind);
            
        }
        /// <summary>
        /// I机构设置删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> FirstDelete(int id)
        {
            return await first_KindDAO.First_DeleteAsync(id);
        }
        /// <summary>
        /// I机构根据id传值
        /// </summary>
        /// <param name="upid"></param>
        /// <returns></returns>
        public async Task<ActionResult> FirstUp(int upid)
        {
            ViewBag.s = await first_KindDAO.First_FindIdAsync(upid);
            return View();
        }
        /// <summary>
        /// I机构设置修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> FirstUpdate(First_kind first_Kind)
        {
            return await first_KindDAO.First_UpdateAsync(first_Kind);
        }
        /// <summary>
        /// 打开II机构
        /// </summary>
        /// <returns></returns>
        public ActionResult Second_index()
        {
            return View();
        }
        /// <summary>
        /// 二级机构查询
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> SecondFind()
        {
            return Json(await second_KindDAO.Second_KindsAsync(), JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// II机构设置删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> SecondDelete(int id)
        {
            return await second_KindDAO.Second_DeleteAsync(id);
        }
        /// <summary>
        /// 打开II机构添加
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> SecondAdd()
        {
            await xlkFind();
            return View();
        }
        /// <summary>
        /// I机构下拉框查询
        /// </summary>
        /// <returns></returns>
        private async Task xlkFind()
        {
            IEnumerable<First_kind> first_Kinds = await first_KindDAO.First_KindsAsync();
            ViewBag.s = first_Kinds;
        }
        /// <summary>
        /// II机构设置添加
        /// </summary>
        /// <param name="first_Kind"></param>
        /// <returns></returns>
        public async Task<int> SecondInsert(Second_kind second_Kind)
        {
            return await second_KindDAO.Second_AddAsync(second_Kind);

        }
        /// <summary>
        /// II根据id传值
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public async Task<ActionResult> SecondUp(int uid)
        {
            ViewBag.s = await second_KindDAO.Second_FindIdAsync(uid);
            return View();
        }
        /// <summary>
        /// II机构设置修改
        /// </summary>
        /// <param name="second_Kind"></param>
        /// <returns></returns>
        public async Task<int> SecondUpdate(Second_kind second_Kind)
        {
            return await second_KindDAO.Second_UpdateAsync(second_Kind);
        }
        /// <summary>
        /// 打开III机构
        /// </summary>
        /// <returns></returns>
        public ActionResult Third_index()
        {
            return View();
        }
        /// <summary>
        /// III机构设置查询
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> ThirdFind()
        {
            return Json(await third_KindDAO.Third_KindsAsync(), JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// III机构设置删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> ThirdDelete(int id)
        {
            return await third_KindDAO.Third_DeleteAsync(id);
        }
        /// <summary>
        /// III机构设置添加
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> ThirdAdd()
        {
            await Second_xlkFind();
            await xlkFind();
            return View();
        }
        /// <summary>
        /// II机构下拉框
        /// </summary>
        /// <returns></returns>
        private async Task Second_xlkFind()
        {
            IEnumerable<Second_kind> second_Kinds = await second_KindDAO.Second_KindsAsync();
            ViewBag.v = second_Kinds;
        }
        /// <summary>
        /// III机构查询单个值
        /// </summary>
        /// <param name="upid"></param>
        /// <returns></returns>
        public async Task<ActionResult> ThirdUp(int ftkid)
        {
            ViewBag.s = await third_KindDAO.Third_FindIdAsync(ftkid);
            return View();
        }
        /// <summary>
        /// III机构修改
        /// </summary>
        /// <param name="third_Kind"></param>
        /// <returns></returns>
        public async Task<int> ThirdUpdate(Third_kind third_Kind)
        {
            return await third_KindDAO.Third_UpdateAsync(third_Kind);
        }

        /// <summary>
        /// III机构添加
        /// </summary>
        /// <param name="third_Kind"></param>
        /// <returns></returns>
        public async Task<int> ThirdInsert(Third_kind third_Kind)
        {
            return await third_KindDAO.Third_AddAsync(third_Kind);
        }

        /// <summary>
        /// 打开薪酬设置
        /// </summary>
        /// <returns></returns>
        public ActionResult Char_index()
        {
            return View();
        }
        /// <summary>
        /// 打开公共属性
        /// </summary>
        /// <returns></returns>
        public ActionResult Char_index1()
        {
            return View();
        }
        /// <summary>
        /// 薪酬项目设置查询
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> CharFind()
        {
            return Json(await publicCharDAO.Char_KindsAsync(), JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 薪酬项目设置删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> CharDelete(int id)
        {
            return await publicCharDAO.Char_DeleteAsync(id);
        }
        /// <summary>
        /// 薪酬项目设置添加
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> CharInsert(PublicChar publicChar)
        {
            return await publicCharDAO.Char_AddAsync(publicChar);
        }
        /// <summary>
        /// 打开薪酬添加
        /// </summary>
        /// <returns></returns>
        public ActionResult CharAdd()
        {
            return View();
        }
        /// <summary>
        /// 打开公共属性添加
        /// </summary>
        /// <returns></returns
        public ActionResult CharGGAdd()
        {
            return View();
        }
        /// <summary>
        /// 公共属性设置查询
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> CharFind1(FenYe<PublicChar> fenYe)
        {
            fenYe = await publicCharDAO.Char_Kind1sAsync(fenYe);
            return Json(fenYe, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 公共属性设置添加
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> CharInsert1(PublicChar publicChar)
        {
            return await publicCharDAO.Char_Add1Async(publicChar);
        }

        public async Task<ActionResult> CascaderFind()
        {
            return Json(await third_KindDAO.GetFindAsync(), JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 职称设置
        /// </summary>
        /// <returns></returns>
        public ActionResult ZhiCheng_index()
        {
            return View();
        }
        /// <summary>
        /// 职称设置查询
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> ZhiChengFind()
        {
            return Json(await publicCharDAO.Zhicheng_KindsAsync(), JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 职称设置添加
        /// </summary>
        /// <param name="publicChar"></param>
        /// <returns></returns>
        public async Task<int> ZhiChenInsert1(PublicChar publicChar)
        {
            return await publicCharDAO.Zhicheng_AddAsync(publicChar);
        }
        /// <summary>
        /// 职位分类设置
        /// </summary>
        /// <returns></returns>
        public ActionResult ZhiWeiFl_index()
        {
            return View();
        }
        /// <summary>
        /// 职位分类设置查询
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> ZhiWeiFl_index1()
        {
            return Json(await major_KindDAO.CmkSelectAsync(), JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 职位分类删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> ZhiWeiFlSc(int id)
        {
            return await major_KindDAO.CmkDeleteAsync(id);
        }
        /// <summary>
        /// 职位分类添加
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> ZhiWeiFlInsert()
        {
            return View();
        }
        public async Task<int> ZhiWeiFlInsert1(Major_kind major_Kind)
        {
            return await major_KindDAO.CmkInsertAsync(major_Kind);
        }

        /// <summary>
        /// 职位设置
        /// </summary>
        /// <returns></returns>
        public ActionResult ZhiWeiSz_index()
        {
            return View();
        }
        /// <summary>
        /// 职位设置查询
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> ZhiWeiSz_index1()
        {
            return Json(await major_DAO.MajorSelectAsync(), JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 职位设置删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> ZhiWeiSz_Sc(int id)
        {
            return await major_DAO.MajorDeleteAsync(id);
        }
        /// <summary>
        /// 职位设置添加
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> ZhiWeiSz_Insert()
        {
            IEnumerable<Major_kind> major_Kinds = await major_KindDAO.CmkSelectAsync();
            ViewBag.v = major_Kinds;
            return View();
        }
        public async Task<int> ZhiWeiSz_Insert1(Major major)
        {
            return await major_DAO.MajorInsertAsync(major);
        }
    }
}