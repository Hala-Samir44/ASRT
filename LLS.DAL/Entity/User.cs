using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LLS.DAL.Entity
{
    public class User
    {
        [Key]
        public string id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime? firstAccess { get; set; }
        public DateTime? lastAccess { get; set; }
        public string timezone { get; set; }
        [ForeignKey("Role")]
        public string roleId { get; set; }
        public virtual Role Role { get; set; }
    }
}

