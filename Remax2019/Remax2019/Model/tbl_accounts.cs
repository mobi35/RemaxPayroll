namespace Remax2019.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_accounts
    {
        public int id { get; set; }

        [StringLength(50)]
        public string employeeId { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [StringLength(50)]
        public string username { get; set; }

        [StringLength(200)]
        public string password { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(50)]
        public string gender { get; set; }

        public int? tries { get; set; }

        public DateTime? date_created { get; set; }

        public int? age { get; set; }

        [StringLength(200)]
        public string address { get; set; }

        [StringLength(30)]
        public string position { get; set; }

        public int? leaveRequest { get; set; }

        public byte[] picture { get; set; }

        public double? basic_salary { get; set; }

        [StringLength(200)]
        public string job_title { get; set; }

        public DateTime? birthdate { get; set; }

        public int? allowable_leaves { get; set; }

        public int? memo_notification { get; set; }

        public int? leave_notification { get; set; }

        public string account_binding { get; set; }

        public DateTime? employed_on { get; set; }

        [StringLength(50)]
        public string account_status { get; set; }
    }
}
