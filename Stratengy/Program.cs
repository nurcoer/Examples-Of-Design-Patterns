using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratengy
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.CreditCalculaterBase = new After2010CreditCalculater();
            customerManager.SavedCredit();

            customerManager.CreditCalculaterBase = new Before2010CreditCalculater();
            customerManager.SavedCredit();
            Console.ReadLine();
        }
    }

    abstract class CreditCalculaterBase
    {
        public abstract void Calculate();
    }

    class Before2010CreditCalculater : CreditCalculaterBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit Calculated using  before 2010");
        }
    }
    class After2010CreditCalculater : CreditCalculaterBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit Calculated using  after 2010");
        }
    }

    class CustomerManager
    {
        public CreditCalculaterBase CreditCalculaterBase { get; set; }
        public void SavedCredit()
        {
            Console.WriteLine("Customer Manager  business");
            CreditCalculaterBase.Calculate();
        }
    }
}
