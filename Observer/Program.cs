using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerObserver = new CustomerObserver();
            productManager productManager = new productManager();
            
            productManager.Attach(customerObserver);
            productManager.Attach(new EmpoyeeObserver());
            productManager.Detach(customerObserver);

            productManager.UpdatePrice();

            Console.ReadLine();
        }
    }

    class productManager
    {
        List<Observer> _observers = new List<Observer>();
        public void UpdatePrice()
        {
            Console.WriteLine("Product price changed");
            Notify();
        }

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }
        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }
        private void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }

    abstract class Observer
    {
        public abstract void Update();
    }

    class CustomerObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Massege to customer: Product price cahnged!");
        }
    }
    class EmpoyeeObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Massege to employee: Product price cahnged!");
        }
    }
}
