using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LLS.DAL.Entity
{
    public class CourseUsers
    {
        [Key]
        public string id { get; set; }

        [ForeignKey("User")]
        public string userId { get; set; }

        [ForeignKey("Course")]
        public string courseId { get; set; }
        public virtual User User { get; set; }
        public virtual Course Course { get; set; }
    }
}
