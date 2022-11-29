using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Employee
{
    public class Employee : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private int age;
        private int iddep;
        private string depname;

        public int Id 
        {
            get { return this.id; } 
            set 
            { 
                if(this.id != value)
                {
                    this.id = value;
                    this.NotifyPropertyChanged("Id");
                }
            } 
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.NotifyPropertyChanged("Name");
                }
            }
        }
        public int Age
        {
            get { return this.age; }
            set
            {
                if (this.age != value)
                {
                    this.age = value;
                    this.NotifyPropertyChanged("Age");
                }
            }
        }

        public int IdDep
        {
            get { return this.iddep; }
            set
            {
                if (this.iddep != value)
                {
                    this.iddep = value;
                    this.NotifyPropertyChanged("IdDept");
                }
            }
        }

        public string DepName
        {
            get { return this.depname; }
            set
            {
                if (this.depname != value)
                {
                    this.depname = value;
                    this.NotifyPropertyChanged("DepName");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string v)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(v));

        }
    }
}
