using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LLS.DAL.Entity
{
    public class Experiment
    {
        [Key]
        public string id { get; set; }
        public string name { get; set; }
        public string expUrl { get; set; }
        public int version { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string search { get; set; }
        public bool visible { get; set; }
    }
}
