using CheckOn.DataAccess.Abstract;
using CheckOn.DataAccess.Entities;
using CheckOn.DataAccess.EntityFrameworkCore;
using Phoenix.LayerBases.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOn.DataAccess
{
    public class UserRepository : RepositoryBase<User, int>, IUserRepository
    {
        public UserRepository(CheckOnDatabaseContext context) : base(context)
        {
        }
    }
}
