using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;

namespace timetable_maker
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
        private bool verify_json() {
            string jsonString = File.ReadAllText(path_box.Text);
            try {
                TimeTable timetable = JsonSerializer.Deserialize<TimeTable>(jsonString);
                if (timetable.weekday.Count == 5) {
                    for (int i = 0; i < 5; i++) {
                        if (i != 2) {
                            if (timetable.weekday[i].name.Length != 7 || timetable.weekday[i].teacher.Length != 7)
                                return false;
                        } else {
                            if (timetable.weekday[i].name.Length != 6 || timetable.weekday[i].teacher.Length != 6)
                                return false;
                        }
                    }
                } else {
                    return false;
                }
                return true;
            } catch {
                return false;
            }
        }

        private void load_json() {
            string jsonString = File.ReadAllText(path_box.Text);
            TimeTable timetable = JsonSerializer.Deserialize<TimeTable>(jsonString);
            for(int i = 0; i < 5; i++) {
                Subject target = timetable.weekday[i];
                for (int j = 0; j < ((i == 2) ? 6 : 7); j++) {
                    SubjectBox sb = (SubjectBox)main_panel.Controls[i].Controls[j];
                    sb.name.Text = target.name[j];
                    sb.teacher.Text = target.teacher[j];
                    sb.name.ForeColor = Color.Black;
                    sb.teacher.ForeColor = Color.Black;
                }
            }
        }

        private void save_json() {
            TimeTable timetable = new TimeTable();
            for (int i = 0; i < 5; i++) {
                Subject target = new Subject() {
                    
                }
            }
        }


        private void load_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() {
                Filter = "JSON Files(*.json)|*.json",
                FileName = path_box.Text
            };
            if (ofd.ShowDialog() == DialogResult.OK) {
                path_box.Text = ofd.FileName;
                if (verify_json()) {
                    load_json();
                    MessageBox.Show("정상적으로 로드됨", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else {
                    MessageBox.Show("올바른 파일이 아님..", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    path_box.Text = "";
                }
            }

        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            verify_json();
        }
    }
    public class Subject {
        public string[] name { get; set; }
        public string[] teacher { get; set; }
    }

    public class TimeTable {
        public List<Subject> weekday { get; set; }
    }
}
