using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LLS.DAL.Entity
{
    public class Role
    {

        [Key]
        public string id { get; set; }

        public string title { get; set; }
        public string description { get; set; }
        public ICollection<RolePermissions> RolePermissions { get; set; }
    }
}
