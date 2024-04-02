using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9
{
    class ProductionLine
    {
        private string _state;

        public string State
        {
            get { return _state; }
            set
            {
                Console.WriteLine("Зміна стану: " + value);
                _state = value;
            }
        }

        public Memento CreateMemento()
        {
            return new Memento(_state);
        }

        public void SetMemento(Memento memento)
        {
            _state = memento.State;
            Console.WriteLine("Стан відновлено: " + _state);
        }
    }

    class Memento
    {
        public string State { get; }

        public Memento(string state)
        {
            State = state;
        }
    }

    class Caretaker
    {
        public Memento Memento { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ProductionLine line = new ProductionLine();
            Caretaker caretaker = new Caretaker();

            line.State = "Початковий стан";

            caretaker.Memento = line.CreateMemento();

            line.State = "Збій стану";

            line.SetMemento(caretaker.Memento);
        }
    }
}
