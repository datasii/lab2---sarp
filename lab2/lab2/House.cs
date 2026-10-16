using System;

namespace lab2
{
    public class House
    {
        private int _floors;

        public int Floors
        {
            get { return _floors; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Количество этажей должно быть положительным");
                _floors = value;
            }
        }

        public House() : this(1) { }

        public House(int floors)
        {
            Floors = floors;
        }

        private string GetFloorWord()
        {
            int lastTwo = _floors % 100;
            int last = _floors % 10;

            if (lastTwo >= 11 && lastTwo <= 14)
                return "этажей";

            if (last == 1)
                return "этаж";
            if (last == 2 || last == 3 || last == 4)
                return "этажа";
            return "этажей";
        }

        public override string ToString()
        {
            return "дом с " + _floors + " " + GetFloorWord();
        }
    }
}