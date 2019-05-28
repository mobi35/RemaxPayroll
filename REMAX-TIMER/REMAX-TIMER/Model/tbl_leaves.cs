namespace REMAX_TIMER.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_leaves
    {
        public int id { get; set; }

        [StringLength(50)]
        public string type_of_leave { get; set; }

        public string message { get; set; }

        public DateTime? start_of_leave { get; set; }

        public DateTime? end_of_leave { get; set; }

        public int? employeeid { get; set; }

        public DateTime? date { get; set; }

        [StringLength(50)]
        public string status { get; set; }
    }
}
