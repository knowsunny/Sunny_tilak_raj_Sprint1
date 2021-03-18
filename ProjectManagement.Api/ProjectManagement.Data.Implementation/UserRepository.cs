using ProjectManagement.Data.Interfaces;
using ProjectManagement.Entities;
using ProjectManagement.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagement.Data.Implementation
{
    public class UserRepository : IUserRepository
    {
        private PMContext _context;
        public UserRepository(PMContext context)
        {
            _context = context;
        }

        public User GetUserByEmailPassword(String email,String password)
        {
            var result = _context.Users.Where(x => x.Email == email && x.Password==password).FirstOrDefault();
            return result;
        }
    }
}
