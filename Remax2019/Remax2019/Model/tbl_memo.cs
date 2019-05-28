namespace Remax2019.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_memo
    {
        public int id { get; set; }

        [StringLength(50)]
        public string memo_title { get; set; }

        public string memo_message { get; set; }

        public DateTime? date { get; set; }

        public byte[] image { get; set; }

        [StringLength(50)]
        public string archived { get; set; }
    }
}
