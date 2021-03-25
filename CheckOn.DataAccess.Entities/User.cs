using Phoenix.LayerBases.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOn.DataAccess.Entities
{
    public class User : IEntity<int>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}
