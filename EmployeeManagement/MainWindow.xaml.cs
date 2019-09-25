using EmployeeManagement.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Xml;

namespace EmployeeManagement
{
    
    public partial class MainWindow : Window
    {
        const string path = @"C:\Users\Dondan\source\repos\WPF-apps\EmployeeManagement\Resources\workers.xml";
        XmlDocument xDoc;
        ViewModel.ViewModel workerView;

        public MainWindow()
        {
            InitializeComponent();
            FileInfo fileInfo = new FileInfo(path);
            if (!fileInfo.Exists)
            {
                MessageBox.Show($"There is no such file in the directory {path}");
            }
            else
            {
                workerView = new ViewModel.ViewModel();
                secName.DataContext =workerView.worker;
                salary.DataContext = workerView.worker;
                post.DataContext = workerView;
                City.DataContext = workerView;
                street.DataContext = workerView;
                house.DataContext = workerView.worker;
                listbox.DataContext = workerView.Names;
                xDoc = new XmlDocument();
                xDoc.Load(path);
                readFile();
            }
        }

        public void readFile() {

            //Добавление рабочих через объекты класса вручную

            /*
            Worker worker1 = new Worker { secName = "Gates", city = "Washington", house = "34", post = "Director", salary = "99999$", street = "Fith avenue" };
            workers = new List<Worker> { worker1 };
            */

            //Чтение xml и разбивка узлов файла по спискам HashSet

            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("second_name");
                    if (attr != null)
                    {
                        workerView.Names.Add(attr.Value);
                    }
                }

                foreach (XmlNode childnode in xnode.ChildNodes)
                { 
                    switch (childnode.Name)
                    {
                        case "post":
                            workerView.Posts.Add(childnode.InnerText);
                            break;
                        case "city":
                            workerView.Cities.Add(childnode.InnerText);
                            break;
                        case "street":
                            workerView.Streets.Add(childnode.InnerText);
                            break;
                        default: //MessageBox.Show($"Cann`t find childnode name {childnode.Name}");
                            break;
                    }
                }
                    
            }
        }

        public void saveToFile()
        {
            XmlElement xRoot = xDoc.DocumentElement;
            XmlElement workerElem = xDoc.CreateElement("worker");
            XmlAttribute nameAttr = xDoc.CreateAttribute("second_name");
            XmlElement salElem = xDoc.CreateElement("salary");
            XmlElement postElem = xDoc.CreateElement("post");
            XmlElement cityElem = xDoc.CreateElement("city");
            XmlElement strElem = xDoc.CreateElement("street");
            XmlElement houseElem = xDoc.CreateElement("house");

            nameAttr.AppendChild(xDoc.CreateTextNode(workerView.worker.SecName));
            salElem.AppendChild(xDoc.CreateTextNode(workerView.worker.Salary.ToString()));
            postElem.AppendChild(xDoc.CreateTextNode(workerView.Post));
            cityElem.AppendChild(xDoc.CreateTextNode(workerView.City));
            strElem.AppendChild(xDoc.CreateTextNode(workerView.Street));
            houseElem.AppendChild(xDoc.CreateTextNode(workerView.worker.House.ToString()));

            workerElem.Attributes.Append(nameAttr);
            workerElem.AppendChild(salElem);
            workerElem.AppendChild(postElem);
            workerElem.AppendChild(cityElem);
            workerElem.AppendChild(strElem);
            workerElem.AppendChild(houseElem);
            xRoot.AppendChild(workerElem);
            xDoc.Save(path);
        }

        public void clearBoxes()
        {
            secName.Text = "";
            salary.Text = "";
            post.Text = "";
            City.Text = "";
            street.Text = "";
            house.Text = "";
        }

        private void Save_worker_Click(object sender, RoutedEventArgs e)
        {
            saveToFile();
            MessageBox.Show($"File has been saved!\nYou can find it at {path}");
            //Adding name to the listbox
            workerView.addName();
            clearBoxes();
        }
    }
}
