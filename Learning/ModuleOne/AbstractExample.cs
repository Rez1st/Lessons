using System;

namespace ModuleOne
{
    public interface IQuackable
    {
        void Quack();
    }

    public abstract class DuckBase
    {
        public DuckBase()
        {
        }

        private string _name { get; set; }

        private ConsoleColor _color { get; set; }

        public ConsoleColor Color
        {
            get => _color;
            set
            {
                switch (value)
                {
                    case ConsoleColor.Red:
                        Color = ConsoleColor.DarkRed;
                        break;
                    case ConsoleColor.Yellow:
                        Color = ConsoleColor.DarkYellow;
                        break;
                    default:
                        Color = ConsoleColor.White;
                        break;
                }
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _name = value;
                }
            }
        }

        protected abstract string Fly();
    }

    public class WildDuck : DuckBase, IQuackable
    {
        public void Quack()
        {
            throw new NotImplementedException();
        }

        protected override string Fly()
        {
            throw new NotImplementedException();
        }
    }

    public class RubberDuck : DuckBase, IQuackable
    {
        public void Quack()
        {
            throw new NotImplementedException();
        }

        protected override string Fly()
        {
            throw new NotImplementedException();
        }
    }
}