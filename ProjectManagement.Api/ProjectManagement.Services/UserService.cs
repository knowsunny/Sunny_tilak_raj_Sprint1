using System;
using System.Collections.Generic;
using System.Linq;
using ProjectManagement.Entities;
using ProjectManagement.Services.Interfaces;
using ProjectManagement.Data.Interfaces;

namespace ProjectManagement.Services
{
    public class UserService: IUserService
    {
        private readonly IBaseRepository<User> _repository;
        private readonly IUserRepository _userRepository;

        public UserService(IBaseRepository<User> repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public User GetUserByUserId(long Id)
        {
            var result = _repository.Get(Id);
            return (User)result;
        }

        public List<User> GetAllUsers()
        {
            var result = _repository.Get();
            return result.Cast<User>().ToList();
        }

        public bool Update(User user)
        {
            var ret = true;
            var result = _repository.Update(user);
            return ret;
        }

        public User Create(User user)
        {
            var result=_repository.Add(user);
            return (User)result;
        }

         public User UserLogin(User user)
        {
            String Id = user.Email;
            String password = user.Password;
            var result = _userRepository.GetUserByEmailPassword(Id,password);
            return result;
        }

        public bool Delete(long Id)
        {
            var result = _repository.Delete(Id);
            return result;
        }
    }
}
