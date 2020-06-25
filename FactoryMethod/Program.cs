using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {

            CustomerManager customerManager = new CustomerManager(new LoggerFactory() );
            customerManager.Save();

            Console.ReadLine();
        }
    }

    public class LoggerFactory:ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //Business to decide factory
            return new EdLogger();
        }
    }
    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //Business to decide factory
            return new EdLogger();
        }
    }

    public interface ILogger
    {
        void log();
    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public class EdLogger : ILogger
    {
        public void log()
        {
            Console.WriteLine("Logged with EdLogger!! ");
        }
    }

    public class CustomerManager
    {
        private ILoggerFactory _loggerFactory;

        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        public void Save()
        {
            Console.WriteLine("Saved!!");
            ILogger logger = _loggerFactory.CreateLogger();
            logger.log();
        }
    }
}
