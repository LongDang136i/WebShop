using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShop.Controllers
{
    public class ProductController : Controller
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
        public ActionResult ListProductByCategory(long cateId, int page = 1, int pageSize = 3)
        {
            int totalRecord = 0;
            var productDao = new ProductDao();
            ViewBag.ProductByCategory = productDao.ProductByCategory(cateId,ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)totalRecord / pageSize);
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Prev = page - 1;
            ViewBag.Next = page + 1;

            var category = new CategoryDao().ViewDetail(cateId);
            return View(category);
        }

        public ActionResult AllProduct( int page = 1, int pageSize = 3)
        {
            int totalRecord = 0;
            var productDao = new ProductDao();
            ViewBag.AllProduct= productDao.AllProductList( ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)totalRecord / pageSize);
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Prev = page - 1;
            ViewBag.Next = page + 1;

            return View();
        }

        public ActionResult ProductDetail(long id)
        {
            var model = new ProductDao().ViewDetail(id);
            var productDao = new ProductDao();
            ViewBag.FeatureListProducts = productDao.FeatureListProduct(4);
            ViewBag.CategoryName = new CategoryDao().ViewDetail(model.CategoryID);
            return View(model);
        }
    }
}