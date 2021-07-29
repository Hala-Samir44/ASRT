using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LLS.DAL.Entity
{
    public class CourseExperiments
    {
        [Key]
        public string id { get; set; }
        [ForeignKey("Course")]
        public string courseId { get; set; }
        [ForeignKey("Experiment")]
        public string experimentId { get; set; }
        public virtual Course Course { get; set; }
        public virtual Experiment Experiment { get; set; }

    }
}
