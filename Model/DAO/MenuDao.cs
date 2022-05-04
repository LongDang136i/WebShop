using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class MenuDao
    {
        WebShopDbContext db = null;
        public MenuDao()
        {
            db = new WebShopDbContext();
        }

        public List<Menu> ListByIDType(int idtype)
        {
            return db.Menus.Where(x => x.IDType == idtype).ToList();
        }

    }
}
