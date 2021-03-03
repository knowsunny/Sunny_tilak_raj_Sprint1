using ProjectManagement.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> Create(User user);

        Task<bool> Update(User user);
        User Get(int userId);

        IOrderedQueryable<User> GetAllUsers();

        IOrderedQueryable<User> GetUserByUserId(int Id);

        Task<bool> UserLogin(User user);
    }


}
