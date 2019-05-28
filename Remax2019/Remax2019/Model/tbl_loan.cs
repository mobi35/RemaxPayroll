namespace Remax2019.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_loan
    {
        public int id { get; set; }

        [StringLength(50)]
        public string employee_id { get; set; }

        public string reason { get; set; }

        public double? principal_loan { get; set; }

        public double? maturity_value { get; set; }

        public double? cut_off_payment { get; set; }

        public int? cut_off_terms { get; set; }

        public int? remaining_cut_off { get; set; }

        public DateTime? issued_date { get; set; }

        [StringLength(50)]
        public string status { get; set; }

        [StringLength(50)]
        public string accepted_by { get; set; }
    }
}
