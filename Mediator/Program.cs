using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();

            Teacher engin = new Teacher(mediator) { Name = "engin" };

            mediator.Teacher = engin;

            Student nur = new Student(mediator) { Name = "Nur" };
            Student ali = new Student(mediator) { Name = "Ali" };

            mediator.Students = new List<Student> { nur, ali };

            engin.SendNewImageUrl("Slide1.jpg");
            engin.RecieveQuestion("is it true?", ali);

            Console.ReadLine();
        }
    }

    abstract class CourseMember
    {
        protected Mediator Mediator;

        public CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    class Teacher : CourseMember
    {
        public string Name { get;  set; }

        public Teacher (Mediator mediator):base(mediator) { }

        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher received a question from {0},{1}", student.Name, question);
        }

        public void SendNewImageUrl (string url)
        {
            Console.WriteLine("Teacher Changed slide:{0}", url);
            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("Teacher answered  question {0},{1}",student.Name,answer);
        }

    }

    class Student : CourseMember
    {
        public string Name { get; set; }

        public Student(Mediator mediator) : base(mediator) { }

        public void RecieveImage(string url)
        {
            Console.WriteLine("Student Received image: {0}", url);
        }

        public void ReceiveAnswer(string answer)
        {
            Console.WriteLine("Student received answer : {0}",answer);
        }
    }

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(url);
            }
        }

        public void SendQuestion(string question,Student student)
        {
            Teacher.RecieveQuestion(question, student);
        }

        public void SendAnswer(string answer, Student student)
        {
            student.ReceiveAnswer(answer);
        }
    }
}
