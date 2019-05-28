using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remax2019
{
  public class LoanCashAdvanceFunction : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }
        //LOANS
     
        public double CutOffDeductions(double annualInterest, int totalDuration, double principalLoan)
        {
            double cutoffDeductions = (principalLoan * Math.Pow((annualInterest / 10) + 1, (totalDuration)) * annualInterest / 10) / (Math.Pow(annualInterest / 10 + 1, (totalDuration)) - 1);
            return cutoffDeductions;
        }

        public string cutoffs;
        public string principalAmount;
        public string CutOffs
        {
            get { return cutoffs; }
            set
            {
                if (cutoffs != value)
                {
                    cutoffs = value;
                    OnPropertyChanged("PrincipalAmount");
                    OnPropertyChanged("MaturityValue");
                    OnPropertyChanged("PayPerCutOff");
                    OnPropertyChanged("PayPerCutOffField");
                    OnPropertyChanged("MaturityValueField");
                }
            }

        }

        public string PrincipalAmount
        {
            get { return principalAmount; }
            set
            {
                if (principalAmount != value)
                {
                    principalAmount = value;
                    OnPropertyChanged("CutOffs");
                    OnPropertyChanged("MaturityValue");
                    OnPropertyChanged("PayPerCutOff");
                    OnPropertyChanged("PayPerCutOffField");
                    OnPropertyChanged("MaturityValueField");
                }
            }

        }
   
        public string PayPerCutOffField
{

            get
            {
                var maturityValue = 0.0;
                try
                {

                    maturityValue = CutOffDeductions(
                        GetInterest(0.3f),
                        Convert.ToInt32(cutoffs),
                        Convert.ToDouble(principalAmount));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                if (Double.IsNaN(maturityValue))
                {
                    return "0";
                }

                try
                {
                    return "" +  decimal.Round(Convert.ToDecimal(maturityValue), 2);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                return "0";

            }
            set
            {
                if (cutOffPay != value)
                {
                    cutOffPay = value;

                }
            }

        }

       

        public string cutOffPay;
        public string PayPerCutOff {

            get
            {
                var maturityValue = 0.0;
                try
                {

                    maturityValue =  CutOffDeductions(
                                        GetInterest(0.3f),
                                        Convert.ToInt32(cutoffs),
                                        Convert.ToDouble(principalAmount));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                if (Double.IsNaN(maturityValue))
                {
                    return "0";
                }

                try
                {
                    return "₱ " + string.Format("{0:N2}", decimal.Round(Convert.ToDecimal(maturityValue), 2));

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                return "0";

            }
            set
            {
                if (cutOffPay != value)
                {
                    cutOffPay = value;

                }
            }

        }
        public string interest;
      
        private string maturityValue;
        public string duration;
        public string MaturityValue
        {
            get
            {

                var maturityValue = 0.0;
                try
                {
                    
                    maturityValue = Convert.ToInt32(cutoffs) * CutOffDeductions(
                                        GetInterest(0.3f),
                                        Convert.ToInt32(cutoffs),
                                        Convert.ToDouble(principalAmount));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                if (Double.IsNaN(maturityValue))
                {
                    return "0";
                }

                try
                {
                    return "₱ " + string.Format("{0:N2}", decimal.Round(Convert.ToDecimal(maturityValue), 2));

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                return "0";
            }
            set
            {
                if (maturityValue.ToString() != value)
                {
                    maturityValue = string.Format("{0:N2}", value);
                    OnPropertyChanged("CutOffs");
                    OnPropertyChanged("MaturityValue");


                }
            }

        }



        public string MaturityValueField
        {
            get
            {

                var maturityValue = 0.0;
                try
                {

                    maturityValue = Convert.ToInt32(cutoffs) * CutOffDeductions(
                                        GetInterest(0.3f),
                                        Convert.ToInt32(cutoffs),
                                        Convert.ToDouble(principalAmount));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                if (Double.IsNaN(maturityValue))
                {
                    return "0";
                }

                try
                {
                    return "" +  decimal.Round(Convert.ToDecimal(maturityValue), 2);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                return "0";
            }
            set
            {
                if (maturityValue.ToString() != value)
                {
                    maturityValue = string.Format("{0:N2}", value);
                    OnPropertyChanged("CutOffs");
                    OnPropertyChanged("MaturityValue");


                }
            }

        }

        public double GetInterest(double interest)
        {
            if (interest > 1)
                return interest / 100;
            return interest;

        }
    }
}
