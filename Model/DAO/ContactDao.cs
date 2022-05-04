using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
     public class ContactDao
    {
        WebShopDbContext db = null;

        public ContactDao()
        {
            db = new WebShopDbContext();
        }

        public long Insert(Contact entity)
        {
            db.Contacts.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public IEnumerable<Contact> ListAll(string searchString, int page, int pageSize)
        {
            IQueryable<Contact> model = db.Contacts;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Email.Contains(searchString)).OrderBy(x => x.ID);
            }
            return model.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }
    }
}
