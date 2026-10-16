using lab2;
using System;
using System.Collections.Generic;

namespace Lab2
{
    public static class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Задание 1.4 — Время");
            Task1_4();
            Console.WriteLine();

            Console.WriteLine("Задание 1.5 — Дом");
            Task1_5();
            Console.WriteLine();

            Console.WriteLine("Задание 2.4 — Сотрудники и отделы");
            Task2_4();
            Console.WriteLine();

            Console.WriteLine("Задание 3.4 — Список сотрудников отдела");
            Task3_4();
            Console.WriteLine();

            Console.WriteLine("Задание 4.3 — Создаём Дом");
            Task4_3();
            Console.WriteLine();

            Console.WriteLine("Задание 5.1 — Пистолет стреляет");
            Task5_1();
        }

        private static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                int result;
                if (int.TryParse(input, out result))
                    return result;
                Console.WriteLine("Ошибка: введите целое число!");
            }
        }

        private static int ReadNonNegativeInt(string prompt)
        {
            while (true)
            {
                int value = ReadInt(prompt);
                if (value >= 0)
                    return value;
                Console.WriteLine("Ошибка: число не может быть отрицательным!");
            }
        }

        private static int ReadPositiveInt(string prompt)
        {
            while (true)
            {
                int value = ReadInt(prompt);
                if (value > 0)
                    return value;
                Console.WriteLine("Ошибка: число должно быть больше нуля!");
            }
        }

        private static string ReadNonEmptyString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    return input;
                Console.WriteLine("Ошибка: строка не может быть пустой!");
            }
        }

        private static void Task1_4()
        {
            Console.WriteLine("Введите количество секунд с начала суток:");
            int sec = ReadNonNegativeInt("Секунды: ");

            Time t = new Time(sec);
            Console.WriteLine("Результат: " + t.ToString());

            Console.WriteLine("\n примеры:");
            int[] standard = { 10, 10000, 100000 };
            for (int i = 0; i < standard.Length; i++)
            {
                Time temp = new Time(standard[i]);
                Console.WriteLine(standard[i] + " секунд -> " + temp.ToString());
            }
        }

        // ---------- Задание 1.5 ----------

        private static void Task1_5()
        {
            Console.WriteLine("Введите количество этажей:");
            int floors = ReadPositiveInt("Этажи: ");

            House h = new House(floors);
            Console.WriteLine("Результат: " + h.ToString());

            Console.WriteLine("\n примеры:");
            int[] standard = { 1, 5, 23 };
            for (int i = 0; i < standard.Length; i++)
            {
                House temp = new House(standard[i]);
                Console.WriteLine(standard[i] + " -> " + temp.ToString());
            }
        }

        private static void Task2_4()
        {
            Console.WriteLine("Введите название отдела:");
            string deptName = ReadNonEmptyString("Название отдела: ");

            Console.WriteLine("Введите имена трёх сотрудников:");
            string name1 = ReadNonEmptyString("Сотрудник 1: ");
            string name2 = ReadNonEmptyString("Сотрудник 2: ");
            string name3 = ReadNonEmptyString("Сотрудник 3: ");

            Console.WriteLine("Кого сделать начальником? (1, 2 или 3):");
            int choice = 0;
            while (choice < 1 || choice > 3)
            {
                choice = ReadInt("Ваш выбор: ");
                if (choice < 1 || choice > 3)
                    Console.WriteLine("Ошибка: введите 1, 2 или 3!");
            }

            Department dept = new Department(deptName);
            Employee e1 = new Employee(name1, dept);
            Employee e2 = new Employee(name2, dept);
            Employee e3 = new Employee(name3, dept);

            if (choice == 1) dept.Head = e1;
            else if (choice == 2) dept.Head = e2;
            else dept.Head = e3;

            Console.WriteLine("\nРезультат:");
            Console.WriteLine(e1.ToString());
            Console.WriteLine(e2.ToString());
            Console.WriteLine(e3.ToString());
        }

        private static void Task3_4()
        {
            Console.WriteLine("Введите название отдела:");
            string deptName = ReadNonEmptyString("Название отдела: ");

            Console.WriteLine("Введите имена трёх сотрудников:");
            string name1 = ReadNonEmptyString("Сотрудник 1: ");
            string name2 = ReadNonEmptyString("Сотрудник 2: ");
            string name3 = ReadNonEmptyString("Сотрудник 3: ");

            Console.WriteLine("Кого сделать начальником? (1, 2 или 3):");
            int choice = 0;
            while (choice < 1 || choice > 3)
            {
                choice = ReadInt("Ваш выбор: ");
                if (choice < 1 || choice > 3)
                    Console.WriteLine("Ошибка: введите 1, 2 или 3!");
            }

            DepartmentWithList dept = new DepartmentWithList(deptName);
            EmployeeWithList e1 = new EmployeeWithList(name1, dept);
            EmployeeWithList e2 = new EmployeeWithList(name2, dept);
            EmployeeWithList e3 = new EmployeeWithList(name3, dept);

            if (choice == 1) dept.Head = e1;
            else if (choice == 2) dept.Head = e2;
            else dept.Head = e3;

            Console.WriteLine("\nСотрудники:");
            Console.WriteLine(e1.ToString());
            Console.WriteLine(e2.ToString());
            Console.WriteLine(e3.ToString());

            // Демонстрация: имея ссылку на сотрудника, получаем список всех сотрудников отдела
            Console.WriteLine("\nСписок всех сотрудников отдела (получен через " + e1.Name + "):");
            List<EmployeeWithList> all = e1.GetColleagues();
            for (int i = 0; i < all.Count; i++)
            {
                Console.WriteLine("  " + all[i].Name);
            }
        }

        private static void Task4_3()
        {
            Console.WriteLine("Введите количество этажей:");
            int floors = ReadPositiveInt("Этажи: ");

            HouseFixed h = new HouseFixed(floors);
            Console.WriteLine("Результат: " + h.ToString());

            Console.WriteLine("\n примеры:");
            int[] standard = { 2, 35, 91 };
            for (int i = 0; i < standard.Length; i++)
            {
                HouseFixed temp = new HouseFixed(standard[i]);
                Console.WriteLine(standard[i] + " -> " + temp.ToString());
            }

            Console.WriteLine("\nПопытка изменить этажи:");
            Console.WriteLine("h.Floors = 10; // Ошибка компиляции — свойство только для чтения");
        }

        private static void Task5_1()
        {
            Console.WriteLine("Введите начальное количество патронов:");
            int patrons = ReadNonNegativeInt("Патроны: ");

            Gun gun = new Gun(patrons);
            Console.WriteLine("Пистолет создан: " + gun.ToString());

            Console.WriteLine("Сколько раз выстрелить?");
            int shots = ReadPositiveInt("Выстрелов: ");

            Console.WriteLine("\nРезультат:");
            for (int i = 0; i < shots; i++)
            {
                gun.Shoot();
            }

            Console.WriteLine("\nОсталось патронов: " + gun.Patrons);
        }
    }
}