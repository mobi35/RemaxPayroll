using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Remax2019.Model;

namespace Remax2019
{
   public static class DatabaseConnection
   {

       public readonly static RemaxDatabase database1 = new RemaxDatabase()
       {
           Configuration = {LazyLoadingEnabled = false}
       };

        public static tbl_payroll_configuration config()
        {

            RemaxDatabase db = new RemaxDatabase();

            return db.tbl_payroll_configuration.FirstOrDefault();
        }
    }
}
