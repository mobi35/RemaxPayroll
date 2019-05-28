namespace Remax2019.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_employee_payroll
    {
        public int id { get; set; }

        [StringLength(50)]
        public string username { get; set; }

        public DateTime? day { get; set; }

        public double? earned { get; set; }
    }
}
