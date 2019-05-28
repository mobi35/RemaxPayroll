namespace REMAX_TIMER.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_payroll_configuration
    {
        public int id { get; set; }

        public TimeSpan? working_hours { get; set; }

        public TimeSpan? working_start { get; set; }

        public TimeSpan? working_end { get; set; }

        [StringLength(50)]
        public string payroll_type { get; set; }

        public TimeSpan? allowed_ot_hours { get; set; }

        public double? double_pay_if_holiday { get; set; }

        [StringLength(50)]
        public string first_cutoff { get; set; }

        [StringLength(50)]
        public string second_cutoff { get; set; }
    }
}
