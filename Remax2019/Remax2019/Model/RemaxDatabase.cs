namespace Remax2019.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RemaxDatabase : DbContext
    {
        public RemaxDatabase()
            : base("name=RemaxDatabase")
        {
        }

        public virtual DbSet<tbl_accounts> tbl_accounts { get; set; }
        public virtual DbSet<tbl_activity> tbl_activity { get; set; }
        public virtual DbSet<tbl_attendance> tbl_attendance { get; set; }
        public virtual DbSet<tbl_cash_advance> tbl_cash_advance { get; set; }
        public virtual DbSet<tbl_deductions> tbl_deductions { get; set; }
        public virtual DbSet<tbl_employee_payroll> tbl_employee_payroll { get; set; }
        public virtual DbSet<tbl_holidays> tbl_holidays { get; set; }
        public virtual DbSet<tbl_job_title> tbl_job_title { get; set; }
        public virtual DbSet<tbl_leaves> tbl_leaves { get; set; }
        public virtual DbSet<tbl_loan> tbl_loan { get; set; }
        public virtual DbSet<tbl_memo> tbl_memo { get; set; }
        public virtual DbSet<tbl_overtime> tbl_overtime { get; set; }
        public virtual DbSet<tbl_payroll> tbl_payroll { get; set; }
        public virtual DbSet<tbl_payroll_configuration> tbl_payroll_configuration { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_accounts>()
                .Property(e => e.account_binding)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_payroll>()
                .Property(e => e.processed)
                .IsUnicode(false);
        }
    }
}
