using System;

namespace Lab2
{
    public class Gun
    {
        private int _patrons;

        public int Patrons
        {
            get { return _patrons; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Количество патронов не может быть отрицательным");
                _patrons = value;
            }
        }

        public Gun() : this(5) { }

        public Gun(int patrons)
        {
            Patrons = patrons;
        }

        public void Shoot()
        {
            if (_patrons > 0)
            {
                Console.WriteLine("Бах!");
                _patrons--;
            }
            else
            {
                Console.WriteLine("Клац!");
            }
        }

        public override string ToString()
        {
            return "Пистолет (патронов: " + _patrons + ")";
        }
    }
}