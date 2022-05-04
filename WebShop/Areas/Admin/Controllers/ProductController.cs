using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShop.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index(string searchString, int page = 1, int pageSize = 4)
        {
            var dao = new ProductDao();
            var model = dao.ListAll(searchString, page, pageSize);
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
            var Product = new ProductDao().ViewDetail(id);
            return View(Product);
        }
        [HttpPost]
        public ActionResult Create(Product Product)
        {
            var dao = new ProductDao();
            long id = dao.Insert(Product);
            if (id > 0)
            {
                return RedirectToAction("Index", "Product");
            }
            else
            {
                ModelState.AddModelError("", "Thêm sản phẩm thành công");
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult Edit(Product Product)
        {
            var dao = new ProductDao();

            var result = dao.Update(Product);
            if (result)
            {
                return RedirectToAction("Index", "Product");
            }
            else
            {
                ModelState.AddModelError("", "Sửa sản phẩm thành công");
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ProductDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}