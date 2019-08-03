using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_TEV.Models
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(int id);
        void CreateUser(User user);
        User UpdateUser(int id, User user);
        void DeleteUser(int id);
    }
}
