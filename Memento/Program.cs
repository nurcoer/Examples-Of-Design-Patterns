 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {

            Book book = new Book
            {
                Isbn = "123456",
                Title = "Sefiller",
                Author = "Victor Hugo"
            };

            book.ShowBook();

            CareTaker history = new CareTaker();
            history.Memento = book.CreateUndo();

            book.Isbn = "654313";

            book.ShowBook();

            book.RestoreFromUndo(history.Memento);

            book.ShowBook();
            Console.ReadLine();
        }
    }

    class Book
    {
        private string _title;
        private string _author;
        private string _isbn;
        private DateTime _lastEdited;

        public string Isbn
        {
            get { return _isbn; }
            set
            {
                _isbn = value;
                SetLastEdited();
            }
           
        }


        public string Author
        {
            get { return _author; }
            set
            {
                _author = value;
                SetLastEdited();
            }
        }


        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                SetLastEdited();
            }
        }

        private void SetLastEdited()
        {
            _lastEdited = DateTime.UtcNow;
        }
        
        public Memento CreateUndo()
        {
            return new Memento(_isbn, _title, _author, _lastEdited);
        }
        public void RestoreFromUndo(Memento memento)
        {
            _title = memento.Title;
            _author = memento.Author;
            _isbn = memento.Isbn;
            _lastEdited = memento.LastEdited;
        }

        public void ShowBook()
        {
            Console.WriteLine("{0},{1},{2} edited:{3}",Isbn,Title,Author,_lastEdited);
        }
    }

    class Memento
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public DateTime LastEdited { get; set; }

        public Memento(string auther,string isbn,string title, DateTime lastEdited)
        {
            Isbn = isbn;
            Author = auther;
            Title = title;
            LastEdited = lastEdited;
        }
    }

    class CareTaker
    {
        public Memento Memento { get; set; }
    }
}
