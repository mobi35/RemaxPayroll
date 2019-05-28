namespace REMAX_TIMER.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_job_title
    {
        public int id { get; set; }

        [StringLength(50)]
        public string job_title { get; set; }

        public double? salary { get; set; }
    }
}
