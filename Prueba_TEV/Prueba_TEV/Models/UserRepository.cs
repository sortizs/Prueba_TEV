using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba_TEV.Models
{
    public class UserRepository : IDisposable, IUserRepository
    {
        private DataContext dataContext = new DataContext();

        public IEnumerable<User> GetUsers()
        {
            return dataContext.User;
        }

        public User GetUser(int id)
        {
            return dataContext.User.FirstOrDefault(x => x.ID == id);
        }

        public void CreateUser(User user)
        {
            dataContext.User.Add(user);
            dataContext.SaveChanges();
        }

        public User UpdateUser(int id, User data)
        {
            User user = dataContext.User.FirstOrDefault(x => x.ID == id);
            user.Name = data.Name;
            user.LastName = data.LastName;
            user.Address = data.Address;
            user.UpdateDate = DateTime.Today;
            dataContext.SaveChanges();
            return user;
        }

        public void DeleteUser(int id)
        {
            User user = dataContext.User.FirstOrDefault(x => x.ID == id);
            if (user != null)
            {
                dataContext.User.Remove(user);
                dataContext.SaveChanges();
            }
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (dataContext != null)
                {
                    dataContext.Dispose();
                    dataContext = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}