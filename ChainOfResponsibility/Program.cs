using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {

            Manager manager = new Manager();
            VicePresident vicePresident = new VicePresident();
            President president = new President();

            manager.SetSuccessor(vicePresident);
            vicePresident.SetSuccessor(president);

            Expens expens = new Expens { Detail = "Training ", Amount = 1050 };

            manager.HandleExpense(expens);
            Console.ReadLine();
        }

        class Expens
        {
            public string Detail { get; set; }
            public decimal Amount { get; set; }
        }

        abstract class ExpenseHandleBase
        {
            protected ExpenseHandleBase Successor;

            public abstract void HandleExpense(Expens expens);

            public void SetSuccessor(ExpenseHandleBase successor)
            {
                Successor = successor;
            }
        }

        class Manager : ExpenseHandleBase
        {
            public override void HandleExpense(Expens expens)
            {
                if (expens.Amount<=100)
                {
                    Console.WriteLine("manager handled the expens! ");
                }
                else if(Successor!=null)
                {
                    Successor.HandleExpense(expens);
                }
            }
        }

        class VicePresident : ExpenseHandleBase
        {
            public override void HandleExpense(Expens expens)
            {
                if (expens.Amount > 100  && expens.Amount <= 1000)
                {
                    Console.WriteLine("Vise President handled the expens! ");
                }
                else if (Successor != null)
                {
                    Successor.HandleExpense(expens);
                }
            }
        }

        class President : ExpenseHandleBase
        {
            public override void HandleExpense(Expens expens)
            {
                if (expens.Amount >= 1000)
                {
                    Console.WriteLine("President handled the expens! ");
                }
            }
        }
    }
}
