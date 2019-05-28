namespace Remax2019.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_deductions
    {
        public int id { get; set; }

        public double? government_tax { get; set; }

        public double? sss_tax { get; set; }

        public double? pagibig_tax { get; set; }

        public double? gsis_tax { get; set; }

        public double? philhealth_tax { get; set; }

        [StringLength(50)]
        public string employee_id { get; set; }

        public DateTime? covered_date { get; set; }

        public double? total_salary { get; set; }

        public double? tardy { get; set; }

        public double? absent { get; set; }

        public double? holiday_bonus { get; set; }

        public double? cutoff_total_salary { get; set; }
        public double? loan { get; set; }
        public double? cash_advance { get; set; }
    }
}
