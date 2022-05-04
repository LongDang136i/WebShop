using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class OrderDao
    {
    //    WebShopDbContext db = null;
    //    public OrderDao()
    //    {
    //        db = new WebShopDbContext();
    //    }
    //    public long Insert(Order entity)
    //    {
    //        db.Orders.Add(entity);
    //        db.SaveChanges();
    //        return entity.ID;
    //    }

    //    public IEnumerable<Order> ListAll(string searchString, int page, int pageSize)
    //    {
    //        IQueryable<Order> model = db.Orders;
    //        if (!string.IsNullOrEmpty(searchString))
    //        {
    //            model = model.Where(x => x.ShipName.Contains(searchString) || x.ShipEmail.Contains(searchString)).OrderBy(x => x.ID);
    //        }
    //        return model.OrderBy(x => x.ID).ToPagedList(page, pageSize);
    //    }
    }
}
