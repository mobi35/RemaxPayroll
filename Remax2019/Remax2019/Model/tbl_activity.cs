namespace Remax2019.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_activity
    {
        public int id { get; set; }

        public int? attendance_id { get; set; }

        public byte[] screenshot { get; set; }

        public DateTime? date { get; set; }
    }
}
