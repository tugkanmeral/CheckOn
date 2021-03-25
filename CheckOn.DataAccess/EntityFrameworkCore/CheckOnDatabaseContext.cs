using CheckOn.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Phoenix.LayerBases.DataAccess;
using Phoenix.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOn.DataAccess.EntityFrameworkCore
{
    public class CheckOnDatabaseContext : DbContextBase
    {
        public DbSet<Cafe> Cafes { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
