using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LLS.DAL.Entity
{
    public class RolePermissions
    {
        [Key]
        public string id { get; set; }
        [ForeignKey("Role")]
        public string roleId { get; set; }
        [ForeignKey("Permission")]
        public string permissionId { get; set; }
        public virtual Permission Permission { get; set; }
        public virtual Role Role { get; set; }
    }
}
