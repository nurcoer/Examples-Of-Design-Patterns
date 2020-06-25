using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customer = new CustomerManager();
            customer.MessageSenderBase = new SmsSender(); 
            customer.UpdateCustomer();

            Console.ReadLine();
        }
    }

   abstract class MessageSenderrBase
    {
        public void Save()
        {
            Console.WriteLine("Message saved!");
        }

        public abstract void Send(Body body);
    }

   class Body
    {
        public string Title{ get; set; }
        public string Text { get; set; }
    }

    class SmsSender : MessageSenderrBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was send vis Sms Sender", body.Title);
        }
    }

    class EMailSender : MessageSenderrBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was send vis Email Sender", body.Title);
        }
    }

    class CustomerManager
    {
        public MessageSenderrBase MessageSenderBase { get; set; }
        public void UpdateCustomer()
        {
            MessageSenderBase.Send(new Body { Title= "About the course!"});
            Console.WriteLine("customer updated");
        }
    }
}
