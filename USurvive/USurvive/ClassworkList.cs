using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USurvive
{
    public class ClassworkList
    {
        ObservableCollection<Classwork> classwork { get; set; }

        public ClassworkList()
        {
            this.classwork = new ObservableCollection<Classwork>();
        }
        public ClassworkList(ObservableCollection<Classwork> classwork)
        {
            this.classwork = classwork;
        }

        public void addClasswork(Classwork work)
        {
            this.classwork.Add(work);
        }

        public bool deleteClasswork(Classwork work)
        {
            return false;
        }

        public ObservableCollection<Classwork> getClassworkForClass(Class uClass)
        {
            throw new NotImplementedException();
        }

         public int ItemCount()
        {
            return classwork.Count;
        }
    }
}
