using System;

namespace lab2
{
    public class Time
    {
        private int _seconds;

        public int Seconds
        {
            get { return _seconds; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Количество секунд не может быть отрицательным");
                _seconds = value;
            }
        }

        public Time() : this(0) { }

        public Time(int seconds)
        {
            Seconds = seconds;
        }

        public override string ToString()
        {
            int daySeconds = 24 * 60 * 60;
            int normalized = _seconds % daySeconds;

            int hours = normalized / 3600;
            int minutes = (normalized % 3600) / 60;
            int secs = normalized % 60;

            return hours + ":" + minutes.ToString("D2") + ":" + secs.ToString("D2");
        }
    }
}