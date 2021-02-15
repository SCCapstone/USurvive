using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USurvive
{
    public class ClassList
    {
        public ObservableCollection<Class> classes { get; set; }

        public ClassList()
        {
            this.classes = new ObservableCollection<Class>();
        }
        public ClassList(ObservableCollection<Class> classes)
        {
            this.classes = classes;
        }

        public void AddClass(Class uClass)
        {
            classes.Add(uClass);
        }


    }
}
