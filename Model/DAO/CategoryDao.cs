using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class CategoryDao
    {
        WebShopDbContext db = null;
        public CategoryDao()
        {
            db = new WebShopDbContext();
        }
        public long Insert(Category entity)
        {
            db.Categories.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Delete(int id)
        {
            try
            {
                var category = db.Categories.Find(id);
                db.Categories.Remove(category);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }
        public bool Update(Category entity)
        {
            try
            {
                var category = db.Categories.Find(entity.ID);
                category.CategoryName = entity.CategoryName;
                category.MetaTitle = entity.MetaTitle;
                category.ParentID = entity.ParentID;
                category.Status = entity.Status;
                
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public Category ViewDetail(long id)
        {
            return db.Categories.Find(id);
        }
               

        public IEnumerable<Category> ListAll(string searchString, int page, int pageSize)
        {
            IQueryable<Category> model = db.Categories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.CategoryName.Contains(searchString) || x.CategoryName.Contains(searchString)).OrderBy(x => x.ID);
            }
            return model.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }


        public List<Category> GetAllCategory()
        {
            return db.Categories.Where(x => x.Status == true).ToList();
        }
    }
}
