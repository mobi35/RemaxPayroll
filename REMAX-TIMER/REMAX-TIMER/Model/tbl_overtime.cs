namespace REMAX_TIMER.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_overtime
    {
        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_ot { get; set; }

        public DateTime? until_time { get; set; }

        public int? employee_Id { get; set; }

        [StringLength(50)]
        public string status { get; set; }

        [StringLength(50)]
        public string name { get; set; }
    }
}
