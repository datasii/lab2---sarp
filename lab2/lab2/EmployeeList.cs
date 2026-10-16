using System;
using System.Collections.Generic;

namespace lab2
{
    public class DepartmentWithList
    {
        private string _name;
        private EmployeeWithList _head;
        private List<EmployeeWithList> _employees;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public EmployeeWithList Head
        {
            get { return _head; }
            set { _head = value; }
        }

        public DepartmentWithList(string name)
        {
            Name = name;
            _employees = new List<EmployeeWithList>();
        }

        public void AddEmployee(EmployeeWithList emp)
        {
            _employees.Add(emp);
        }
        public List<EmployeeWithList> GetEmployees()
        {
            return _employees;
        }

        public override string ToString()
        {
            return Name;
        }
    }
    public class EmployeeWithList
    {
        private string _name;
        private DepartmentWithList _department;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public DepartmentWithList Department
        {
            get { return _department; }
            set { _department = value; }
        }

        public EmployeeWithList(string name, DepartmentWithList department)
        {
            Name = name;
            Department = department;
            department.AddEmployee(this); // автоматически добавляемся в отдел
        }
        public List<EmployeeWithList> GetColleagues()
        {
            return _department.GetEmployees();
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