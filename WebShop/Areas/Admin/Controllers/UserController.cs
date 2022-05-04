using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Common;
using PagedList;

namespace WebShop.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchString,int page=1, int pageSize=3)
        {
            var dao = new UserDao();
            var model = dao.ListAll(searchString,page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Create (User user)
        {
            var dao = new UserDao();
            var encryptedMd5Pass = Encryptor.MD5Hash(user.Password);
            user.Password = encryptedMd5Pass;
            long id = dao.Insert(user);
            if(id>0)
            {
                return RedirectToAction("Index", "User");
            }
            else
            {
                ModelState.AddModelError("", "Thêm người dùng thành công");
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            var dao = new UserDao();
            
            if(!string.IsNullOrEmpty(user.Password))
            {
                var encryptedMd5Pass = Encryptor.MD5Hash(user.Password);
                user.Password = encryptedMd5Pass;
            }
                
            var result = dao.Update(user);
            if (result)
            {
                return RedirectToAction("Index", "User");
            }
            else
            {
                ModelState.AddModelError("", "Sửa người dùng thành công");
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete (int id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("Index");
        }






    }
}