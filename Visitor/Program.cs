using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {

            Manager engin = new Manager { Name="engin  ", Salary= 1000};
            Manager salih = new Manager { Name = "salih ", Salary = 900 };

            Worker derin = new Worker { Name = "derin ", Salary = 800 };
            Worker ali = new Worker { Name = "ali ", Salary = 800 };

            engin.Subordinates.Add(salih);
            engin.Subordinates.Add(derin);
            salih.Subordinates.Add(ali);

            OrganizationalStructure organizationalStructure = new OrganizationalStructure(engin);
            PayrolVisitor payrolVisitor = new PayrolVisitor();
            PayriseVisitor payriseVisitor = new PayriseVisitor();

            organizationalStructure.Accept(payrolVisitor);
            organizationalStructure.Accept(payriseVisitor);


            Console.ReadLine();
        }
    }
    class OrganizationalStructure
    {
        public EmployeeBase Employee;

        public OrganizationalStructure(EmployeeBase firstEmployee)
        {
            Employee = firstEmployee;
        }
        public void  Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }
    }

    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitor);
        public string  Name{ get; set; }
        public decimal Salary{ get; set; }
    }

    class Manager : EmployeeBase
    {
        public Manager()
        {
            Subordinates = new List<EmployeeBase>();
        }
        public List<EmployeeBase> Subordinates { get; set; }
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);

            foreach (var employee in Subordinates)
            {
                employee.Accept(visitor);
            }
        }
    }

    class Worker : EmployeeBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }

    abstract class VisitorBase
    {
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);
    }

    class PayrolVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} paid {1}", worker.Name, worker.Salary);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} paid {1}", manager.Name, manager.Salary);
        }
    }

    class PayriseVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} salary increased to {1}", worker.Name, worker.Salary * (decimal)1.1);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} salary increased to {1}", manager.Name, manager.Salary*(decimal)1.2);
        }
    }
}
