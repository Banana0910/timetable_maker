using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace timetable_maker
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }

    public class Subject {
        public string[] name { get; set; }
        public string[] teacher { get; set; }
    }

    public class TimeTable {
        public List<Subject> weekday { get; set; }
        public TimeTable() {
            this.weekday = new List<Subject>();
        }
    }
}
