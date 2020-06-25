using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new  Factory1() );
            productManager.GetAll();
            Console.ReadLine();
        }
    }

    public abstract  class Caching
    {
        public abstract void Cache();
    }
    public abstract class Logging
    {
        public abstract void Log();
    }

    public class Log4NetLogger : Logging
    {
        public override void Log()
        {
            Console.WriteLine(" logged with Log4NetLogged");
        }
    }
    public class NLogger : Logging
    {
        public override void Log()
        {
            Console.WriteLine(" logged with NLogged");
        }
    }

    public class ReddisCach : Caching
    {
        public override void Cache()
        {
            Console.WriteLine(" Cached with ReddisCache");
        }
    }
    public class MemCach : Caching
    {
        public override void Cache()
        {
            Console.WriteLine(" Cached with MemCach");
        }
    }

    public abstract class CrossCuttingConcernsFactory
    {
        public abstract Logging CreeateLogger();
        public abstract Caching CreateCaching();
    }

    public class Factory : CrossCuttingConcernsFactory
    {
        public override Caching CreateCaching()
        {
            return new ReddisCach();
        }

        public override Logging CreeateLogger()
        {
            return new Log4NetLogger();
        }
    }

    public class Factory1 : CrossCuttingConcernsFactory
    {
        public override Caching CreateCaching()
        {
            return new ReddisCach();
        }

        public override Logging CreeateLogger()
        {
            return new NLogger();
        }
    }

    public class ProductManager
    {
        private CrossCuttingConcernsFactory _crossCuttingConcernsFactory;
        private Logging _logging;
        private Caching _caching;

        public ProductManager(CrossCuttingConcernsFactory crossCuttingConcernsFactory)
        {
            _crossCuttingConcernsFactory = crossCuttingConcernsFactory;
            _logging = _crossCuttingConcernsFactory.CreeateLogger();
            _caching = _crossCuttingConcernsFactory.CreateCaching();
        }

        public void GetAll()
        {
            _logging.Log();
            _caching.Cache();
            Console.WriteLine("Products Listed");
        }
    }
}
