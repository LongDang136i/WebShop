using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class SlideDao
    {
        WebShopDbContext db =null;
        public SlideDao()
        {
            db = new WebShopDbContext();

        }
        public List<Slide> ListAll()
        {
           return db.Slides.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }
    }
}
