﻿using ProjectManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagement.Data.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByEmailPassword(String email, String password);
    }
}
