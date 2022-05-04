using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShop.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Contact contact)
        {
            var dao = new ContactDao();
            long id = dao.Insert(contact);
            if (id > 0)
            {
                ViewBag.Success = "Gửi liên hệ thành công.";
                return View("Index");
            }
            else
            {
                ModelState.AddModelError("", "Gửi liên hệ thành công");
            }
            return View("Index");
        }
    }
}