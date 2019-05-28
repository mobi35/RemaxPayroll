namespace REMAX_TIMER.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_holidays
    {
        public int id { get; set; }

        [StringLength(50)]
        public string holiday_title { get; set; }

        public DateTime? datetime { get; set; }
    }
}
