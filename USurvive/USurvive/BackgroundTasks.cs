using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace USurvive
{
    class BackgroundTasks
    {
        public BackgroundTasks()
        {
            
        }
        
        public static void backWork()
        {
            while (true)
            {
                foreach (Classwork classwork in Globals.cwList.classwork)
                {
                    if (DateTime.Compare(classwork.notificationTime, DateTime.Now) <= 0)
                    {
                        if (!classwork.shownNotification)
                        {
                            classwork.ShowNotification();
                        }
                    }
                }

                //After done, sleep for 100 ms
                Thread.Sleep(100);
            }
        }
    }
}
