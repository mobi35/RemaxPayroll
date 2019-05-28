namespace Remax2019.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_cash_advance
    {
        public int id { get; set; }

        [StringLength(50)]
        public string employee_id { get; set; }

        public double? cash_advance { get; set; }

        public string reason { get; set; }

        [StringLength(50)]
        public string accepted_by { get; set; }

        [StringLength(50)]
        public string status { get; set; }

        public DateTime? issued_on { get; set; }
    }
}
