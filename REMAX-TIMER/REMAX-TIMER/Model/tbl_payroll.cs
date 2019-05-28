namespace REMAX_TIMER.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_payroll
    {
        public int id { get; set; }

        [StringLength(50)]
        public string employeeId { get; set; }

        public DateTime? accumulated_hours { get; set; }

        public DateTime? late_hours { get; set; }

        public DateTime? overtime_hours { get; set; }

        public DateTime? date { get; set; }

        public double? pay { get; set; }

        public DateTime? start_date { get; set; }

        public DateTime? end_date { get; set; }

        [StringLength(50)]
        public string processed { get; set; }
    }
}
