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
        public ObservableCollection<Classwork> classwork { get; set; }

        public ClassworkList()
        {
            this.classwork = new ObservableCollection<Classwork>();
        }
        public ClassworkList(ObservableCollection<Classwork> classwork)
        {
            this.classwork = classwork;
        }

        public void AddClasswork(Classwork work)
        {
            this.classwork.Add(work);
        }

        public bool DeleteClasswork(Classwork work)
        {
            return this.classwork.Remove(work);
        }

        public ObservableCollection<Classwork> GetClassworkForClass(Class uClass)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Classwork> GetClassworkForDate(DateTime date)
        {
            ObservableCollection<Classwork> ret = new ObservableCollection<Classwork>();
            foreach(Classwork work in classwork)
            {
                if(Nullable.Compare(work.DueDate, date) >= 0)
                {
                    ret.Add(work);
                }
            }
            return ret;
        }
         public int ItemCount()
        {
            return classwork.Count;
        }
    }
}
