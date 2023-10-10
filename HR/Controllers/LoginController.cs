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
    public class LoginController : Controller
    {
        UsersDAO usersDAO=new UsersDAO();

        // GET: Login
        public ActionResult Login_Index()
        {
            return View();
        }

        public async Task<ActionResult> LoginDLx(Users users)
        {
            Users userss = await usersDAO.User_Login(users);
            if (userss != null)
            {
                //存值
                TempData["users"] = userss;
                return Content("<script>alert('登录成功！');location.href='/Main/Index'</script>");
            }
            else
            {
                return Content("<script>alert('登录失败！');location.href='/Login/Login_Index'</script>");
                //return RedirectToAction("TreaUpdate",new { id = trea.id});
            }
        }
    }
}