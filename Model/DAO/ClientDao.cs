using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ClientDao
    {
        WebShopDbContext db = null;
        public ClientDao()
        {
            db = new WebShopDbContext();
        }
        public bool CheckUserName(string userName)
        {
            return db.Clients.Count(x => x.UserName == userName) > 0;
        }

        public bool CheckEmail(string email)
        {
            return db.Clients.Count(x => x.Email == email) > 0;
        }

        public long Insert(Client entity)
        {
            db.Clients.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        
        public bool Update(Client entity)
        {
            try
            {
                var Client = db.Clients.Find(entity.ID);
                Client.Name = entity.Name;
                Client.Address = entity.Address;
                Client.Email = entity.Email;
                Client.Phone = entity.Phone;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    Client.Password = entity.Password;
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public Client ViewDetail(int id)
        {
            return db.Clients.Find(id);
        }
        public Client GetByID(string ClientName)
        {
            return db.Clients.SingleOrDefault(x => x.UserName == ClientName);
        }
        public int Login(string clientName, string password)

        {
            var result = db.Clients.SingleOrDefault(x => x.UserName == clientName);

            if (result == null)
            {
                return 0;

            }
            else
            {
                if (result.Status == false)
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
    }
}
