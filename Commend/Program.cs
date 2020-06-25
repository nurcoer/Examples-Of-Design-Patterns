using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commend
{
    class Program
    {
        static void Main(string[] args)
        {
            StockManager stockManager = new StockManager();
            BuyStock buyStock = new BuyStock(stockManager);
            SellStock sellStock = new SellStock(stockManager);
            StockControler stockControler = new StockControler();

            stockControler.TakeOrder(buyStock);
            stockControler.TakeOrder(sellStock);
            stockControler.TakeOrder(buyStock);


            stockControler.PlaceOrders();

            Console.ReadLine();

        }
    }

    class  StockManager
    {
        private string _name = "Laptop";
        private int _quantity = 10;

        public void Buy()
        {
            Console.WriteLine("Stock : {0},{1} bounght!",_name,_quantity);
        }
        public void Sell()
        {
            Console.WriteLine("Stock : {0},{1} Sold!", _name, _quantity);
        }
    }

    interface IOrder
    {
        void Execute();
    }

    class BuyStock : IOrder
    {
        private StockManager _stockManager;

        public BuyStock(StockManager stockManager)
        {
            _stockManager = stockManager;
        }

        public void Execute()
        {
            _stockManager.Buy();
        }
    }

    class SellStock : IOrder
    {

        private StockManager _stockManager;

        public SellStock(StockManager stockManager)
        {
            _stockManager = stockManager;
        }

        public void Execute()
        {
            _stockManager.Sell();
        }
    }

    class StockControler
    {
        List<IOrder> _orders = new List<IOrder>();

        public void TakeOrder(IOrder order)
        {
            _orders.Add(order);
        }

        public  void PlaceOrders()
        {
            foreach (var order in _orders)
            {
                order.Execute();
            }
            _orders.Clear();
        }
    }
}
