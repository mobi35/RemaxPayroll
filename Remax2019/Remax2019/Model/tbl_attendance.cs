namespace Remax2019.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_attendance
    {
        public int id { get; set; }

        [StringLength(50)]
        public string username { get; set; }

        public DateTime? date { get; set; }

        public DateTime? time_in { get; set; }

        public DateTime? time_out { get; set; }

        [StringLength(50)]
        public string isLeave { get; set; }
    }
}
