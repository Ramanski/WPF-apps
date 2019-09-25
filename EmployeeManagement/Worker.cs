using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    class Worker
    {
        private string _secName;
        private int _salary;
        private int _house;
        public string SecName
        {
            get { return _secName; }
            set { _secName = value.Trim(); }
        }
        public int Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }
        public int House
        {
            get { return _house; }
            set { _house = value; }
        }
    }
}
