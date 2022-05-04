using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
namespace Model.DAO
{
    public class UserDao
    {
        WebShopDbContext db = null;
        public UserDao()
        {
            db = new WebShopDbContext();
        }
        public long Insert(User entity)
        {  
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            

        }
        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                user.Name = entity.Name;
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.Phone = entity.Phone;
                if(!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
            
        }

        public User ViewDetail (int id)
        {
            return db.Users.Find(id);
        }
        public User GetByID(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }
        public int Login(string userName, string password)

        {
            var result = db.Users.SingleOrDefault(x => x.UserName == userName);          
                
            if (result==null)
            {
                return 0;

            }
            else
            {
                if (result.Status==false)
                {
                    return -1;

                }
                else
                {
                    if (result.Password == password)
                    {
                        return 1;

                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }


        public IEnumerable<User> ListAll(string searchString, int page,int pageSize)
        {
            IQueryable<User> model = db.Users;
            if(!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString)).OrderByDescending(x => x.ID);
            }
            return model.OrderByDescending(x=>x.ID).ToPagedList(page,pageSize);
        }
    }
}
