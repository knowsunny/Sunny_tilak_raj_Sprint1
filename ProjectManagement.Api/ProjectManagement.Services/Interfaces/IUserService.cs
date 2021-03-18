using ProjectManagement.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Services.Interfaces
{
    public interface IUserService
    {
        User Create(User user);

        bool Update(User user);

        List<User> GetAllUsers();

        User GetUserByUserId(long Id);

        User UserLogin(User user);

        bool Delete(long id);
    }


}
