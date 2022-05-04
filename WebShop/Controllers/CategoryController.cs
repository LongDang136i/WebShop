using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShop.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        

        [ChildActionOnly]
        public PartialViewResult CategoryList()
        {
            var model = new CategoryDao().GetAllCategory();
            return PartialView(model);

        }
    }
}