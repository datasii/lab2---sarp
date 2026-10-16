using System;

namespace lab2
{
    public class Department
    {
        private string _name;
        private Employee _head;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Employee Head
        {
            get { return _head; }
            set { _head = value; }
        }

        public Department(string name)
        {
            Name = name;
        }

        public Department(string name, Employee head)
        {
            Name = name;
            Head = head;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Employee
    {
        private string _name;
        private Department _department;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Department Department
        {
            get { return _department; }
            set { _department = value; }
        }

        public Employee(string name, Department department)
        {
            Name = name;
            Department = department;
        }

        public override string ToString()
        {
            if (Department.Head == this)
            {
                return Name + " начальник отдела " + Department.Name;
            }

            string headName = Department.Head != null ? Department.Head.Name : "не назначен";
            return Name + " работает в отделе " + Department.Name +
                   ", начальник которого " + headName;
        }
    }
}