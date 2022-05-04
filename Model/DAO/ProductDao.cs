using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ProductDao
    {
        WebShopDbContext db = null;

        public ProductDao()
        {
            db = new WebShopDbContext();
        }

        #region Admin
        public long Insert(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Delete(int id)
        {
            try
            {
                var Product = db.Products.Find(id);
                db.Products.Remove(Product);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }
        public bool Update(Product entity)
        {
            try
            {
                var Product = db.Products.Find(entity.ID);
                Product.ProductName = entity.ProductName;
                Product.CategoryID = entity.CategoryID;
                Product.Price = entity.Price;
                Product.PromotionPrice = entity.PromotionPrice;
                Product.Image = entity.Image;
                Product.Detail = entity.Detail;
                Product.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);
        }



        public IEnumerable<Product> ListAll(string searchString, int page, int pageSize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.ProductName.Contains(searchString) || x.ProductName.Contains(searchString)).OrderBy(x => x.ID);
            }
            return model.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }


        #endregion


        #region Client
        public List<Product> NewListProduct(int top)
        {
            return db.Products.OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }

        public List<Product> FeatureListProduct(int top)
        {
            return db.Products.Where(x => x.TopHot != null && x.TopHot >DateTime.Now).OrderByDescending(x=>x.CreateDate).Take(top).ToList();
        }

        public List<Product> ProductByCategory(long cateId, ref int totalRecord, int pageIndex=1, int pageSize=2)
        {
            totalRecord = db.Products.Where(x => x.CategoryID == cateId).Count();
            var model= db.Products.Where(x => x.CategoryID == cateId).OrderBy(x=>x.ID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return model;
        }

        public List<Product> AllProductList( ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.Products.Count();
            var model = db.Products.OrderBy(x => x.ID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return model;
        }


        #endregion
    }
}

