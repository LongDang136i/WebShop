using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Common;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
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
                    ClientSession.Name = Client.Name;
                    var productDao = new ProductDao();
                    Session.Add(CommonConstants.CLIENT_SESSION, ClientSession);
                    ViewBag.Success = "Đăng nhập thành công.";
                    return RedirectToRoute("Home");

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

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            var dao = new ClientDao();
            if (dao.CheckUserName(model.UserName))
            {
                ModelState.AddModelError("", "Tên đăng nhập tồn tại");

            }
            else if (dao.CheckEmail(model.Email))
            {
                ModelState.AddModelError("", "Email tồn tại");

            }
            else
            {
                var client = new Client();
                client.UserName = model.UserName;
                client.Password = Encryptor.MD5Hash(model.Password);
                client.Email = model.Email;
                client.Name = model.Name;
                client.Address = model.Address;
                client.Phone = model.Phone;
                client.Status = true;
                var result = dao.Insert(client);
                if(result>0)
                {
                    ViewBag.Success = "Đăng kí thành công.";
                    model = new RegisterModel();
                }
                else
                {
                    ModelState.AddModelError("", "Đăng kí thất bại.");
                }    
            }
            return View();
        }
    }
}