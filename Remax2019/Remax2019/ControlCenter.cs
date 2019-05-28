using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Remax2019.Model;

namespace Remax2019
{
   public class ControlCenter
    {

        private readonly RemaxDatabase database = new RemaxDatabase()
        {
            Configuration = { AutoDetectChangesEnabled = false, ValidateOnSaveEnabled = false }
        };
        public static string TitleCase(string word)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;

            return textInfo.ToTitleCase(word);
        }


    
        public string NewId()
        {
            var selectEmployee = database.tbl_accounts.OrderByDescending(a => a.employeeId).FirstOrDefault(a => a.employeeId != null);
            var createId = "";
            if (selectEmployee != null)
            {
                int generateID = Convert.ToInt32(selectEmployee.employeeId.Substring(3));
                generateID++;
                createId = "RM-" + generateID;
            }
            else
            {
                createId = "RM-10000000";
            }
            return createId;
        }

        public tbl_accounts Accounts(int id)
        {
            var account = database.tbl_accounts.FirstOrDefault(a => a.id == id);
            return account;
        }

        public tbl_job_title JobTitle(int id)
        {
            var jobTitle = database.tbl_job_title.FirstOrDefault(a => a.id == id);
            return jobTitle;
        }
        public tbl_memo Memo(int id)
        {
            var memo = database.tbl_memo.FirstOrDefault(a => a.id == id);
            return memo;
        }

        public tbl_holidays Holiday(int id)
        {
            var holiday = database.tbl_holidays.FirstOrDefault(a => a.id == id);
            return holiday;
        }


        public static double? Ph_Taxation(double? salary)
        {
            double? excess = 0;
            double? tax = 0;
            salary *= 12;
            if (salary >= 250000 && salary <= 400000)
            {
                excess = salary - 250000;
                tax = excess * 0.20;
                tax /= 12;
            }else if (salary >= 400000 && salary <= 800000)
            {
                excess = salary - 400000;
                tax = excess * 0.25;
                tax += 30000;
                tax /= 12;
            }else if (salary >= 800000 && salary <= 2000000)
            {
                excess = salary - 800000;
                tax = excess * 0.30;
                tax += 130000;
                tax /= 12;
            }
            else if (salary >= 2000000 && salary <= 8000000)
            {
                excess = salary - 2000000;
                tax = excess * 0.32;
                tax += 490000;
                tax /= 12;
            }
            else if (salary > 8000000)
            {
                excess = salary - 8000000;
                tax = excess * 0.35;
                tax += 2410000;
                tax /= 12;
            }
            else
            {
                tax = 0;
            }

            return tax;
        }
        public static int? GiveBirthday(DateTime? dateOfBirth)
        {
            var birthDate = 0;
            try
            {
                if (dateOfBirth.Value.Month >= DateTime.Now.Month)
                {
                    birthDate = DateTime.Now.Year - dateOfBirth.Value.Year;
                    birthDate -= 1;
                }
                else
                {
                    birthDate = DateTime.Now.Year - dateOfBirth.Value.Year;
                   
                }
            }
            catch (Exception e)
            {

            }
            return birthDate;
        }


        public static void UpdateBirthdays()
        {
            var listOfUsers = DatabaseConnection.database1.tbl_accounts.ToList();
            foreach (var a in listOfUsers)
            {
                a.age =  GiveBirthday(a.birthdate);
                DatabaseConnection.database1.SaveChanges();
            }

        }

      


    }
}
