using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LLS.DAL.Entity
{
    public class Course
    {
        [Key]
        public string id { get; set; }
        public string fulllName { get; set; }
        public string shortName { get; set; }
        public string summary { get; set; }
        public string startDate { get; set; }
        public DateTime? timeCreated { get; set; }
        public DateTime? timeModified { get; set; }
    }
}
