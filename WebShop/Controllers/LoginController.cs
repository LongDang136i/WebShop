using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Areas.Admin.Models;
using WebShop.Common;

namespace WebShop.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ClientDao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var Client = dao.GetByID(model.UserName);
                    var ClientSession = new ClientLogin();
                    ClientSession.UserName = Client.UserName;
                    ClientSession.ClientID = Client.ID;
                    var productDao = new ProductDao();
                    ViewBag.NewListProducts = productDao.NewListProduct(4);
                    ViewBag.FeatureListProducts = productDao.FeatureListProduct(4);
                    ViewBag.CategoryList = new CategoryDao().GetAllCategory();
                    Session.Add(CommonConstants.CLIENT_SESSION, ClientSession);
                    return RedirectToAction("", "");

                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa.");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Sai mật khẩu.");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập thất bại.");
                }

            }
            return View();
        }
    }
}