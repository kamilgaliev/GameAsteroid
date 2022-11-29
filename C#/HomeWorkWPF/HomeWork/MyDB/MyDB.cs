using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.MyDB
{
    class MyDB
    {
        public ObservableCollection<Employee.Employee> EmplDb { get; set; }
        public ObservableCollection<Department.Department> DepDb { get; set; }

        public MyDB()
        {
            this.DepDb = new ObservableCollection<Department.Department>
            {
                new Department.Department() { Id = 1, Name ="Отдел 1"},
                new Department.Department() { Id = 2, Name = "Отдел 2" }
            };

            this.EmplDb = new ObservableCollection<Employee.Employee>
            {
                new Employee.Employee() { Id = 1, Name = "Vasya", Age = 22, IdDep = 1, DepName = "Отдел 1"},
                new Employee.Employee() { Id = 2, Name = "Petya", Age = 25, IdDep = 2, DepName = "Отдел 2"},
                new Employee.Employee() { Id = 3, Name = "Kolya", Age = 23, IdDep = 1, DepName = "Отдел 1"}
            };
        }
        
    }
}
