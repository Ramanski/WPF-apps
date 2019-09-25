using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace EmployeeManagement.ViewModel
{
    class ViewModel
    {
        private ObservableCollection<string> _names;
        private HashSet<string> _posts;
        private HashSet<string> _cities;
        private HashSet<string> _streets;

        public Worker worker;
        private string _post;
        private string _city;
        private string _street;

        public ViewModel()
        {
            _names = new ObservableCollection<string>();
            _posts = new HashSet<string>();
            _cities = new HashSet<string>();
            _streets = new HashSet<string>();
            worker = new Worker();
        }

        public void addName()
        {
            _names.Add(worker.SecName);
        }
        public ObservableCollection<string> Names
        {
            get { return _names; }
            set { _names = value; }
        }
        public HashSet<string> Posts
        {
            get { return _posts; }
            set { _posts = value; }
        }
        public HashSet<string> Cities
        {
            get { return _cities; }
            set { _cities = value; }
        }
        public HashSet<string> Streets
        {
            get { return _streets; }
            set { _streets = value; }
        }
        public string Post
        {
            get { return _post; }
            set { _post = value; }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }
    }
}
