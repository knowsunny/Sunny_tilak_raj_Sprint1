using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Entities;
using ProjectManagement.Services.Interfaces;

namespace ProjectManagement.Services
{
    public class UserService: IUserService
    {

        public User Get(int userId)
        {
            throw new NotImplementedException();
        }

        public IOrderedQueryable<User> GetUserByUserId(int Id)
        {
            throw new NotImplementedException();
        }

        public IOrderedQueryable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create(User user)
        {
            throw new NotImplementedException();
        }

         public Task<bool> UserLogin(User user)
        {
            throw new NotImplementedException();
        }
    }
}
