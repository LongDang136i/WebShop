using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        public ActionResult Index()
        {
            var productDao = new ProductDao();
            ViewBag.NewListProducts = productDao.NewListProduct(4);
            ViewBag.FeatureListProducts = productDao.FeatureListProduct(4);
            ViewBag.CategoryList = new CategoryDao().GetAllCategory();
            return View();
        }

        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model = new MenuDao().ListByIDType(1);
            return PartialView(model);

        }

        [ChildActionOnly]
        public ActionResult TopMenu()
        {
            var model = new MenuDao().ListByIDType(2);
            return PartialView(model);

        }
        [ChildActionOnly]
        public PartialViewResult CategoryList()
        {
            var model = new CategoryDao().GetAllCategory();
            return PartialView(model);

        }

        [ChildActionOnly]
        public ActionResult Slide()
        {
            var model = new SlideDao().ListAll();
            return PartialView(model);

        }
        [ChildActionOnly]
        public ActionResult HeaderCart()
        {
            var cart = Session[Common.CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);

        }
    }
}