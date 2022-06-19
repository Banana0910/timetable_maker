using System;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Collections.Specialized;
using System.Threading;
using System.IO;
using System.Net;
using System.Drawing;
using System.Xml;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace timetable_maker
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private bool verifyXml() {
            if (string.IsNullOrEmpty(pathBox.Text)) return false;
            if (!File.Exists(pathBox.Text)) return false;
            string xmlString = File.ReadAllText(pathBox.Text);
            try {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlString);
                return (doc.GetElementsByTagName("weekday").Count == 5) ? true : false;
            } catch { return false; }
        }

        private void loadXml() {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(File.ReadAllText(pathBox.Text));
            XmlNodeList weekdays = doc.GetElementsByTagName("weekday");
            for (int i = 0; i < 5; i++) {
                XmlNode target = weekdays[i];
                int count = (i == 2) ? 6 : 7;
                for (int j = 0; j < count; j++) {
                    SubjectBox sb = (SubjectBox)mainPanel.Controls[i].Controls[j];
                    sb.writeName(target.ChildNodes[j].Attributes["name"].InnerText);
                    string teacher = target.ChildNodes[j].Attributes["teacher"].InnerText;
                    if (string.IsNullOrEmpty(teacher)) sb.clearTeacher();
                    else sb.writeTeacher(teacher);
                }
            }
        }

        private XmlDocument createXml() {
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "UTF-8", null));
            XmlElement timetable = doc.CreateElement("timetable");
            for (int i = 0; i < 5; i++) {
                int count = (i == 2) ? 6 : 7;   
                XmlElement weekday = doc.CreateElement("weekday");
                for (int j = 0; j < count; j++) {
                    SubjectBox sb = (SubjectBox)mainPanel.Controls[i].Controls[j];
                    if (!string.IsNullOrWhiteSpace(sb.name.Text)) {
                        XmlElement element = doc.CreateElement("subject");
                        element.SetAttribute("name", sb.name.Text);
                        element.SetAttribute("teacher", (sb.teacher.ForeColor == Color.Gray) ? "" : sb.teacher.Text);
                        weekday.AppendChild(element);
                    } else { return null; }
                }
                timetable.AppendChild(weekday);
            }
            doc.AppendChild(timetable);
            return doc;
        }

        private void saveXml() {
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "UTF-8", null));
            XmlElement timetable = doc.CreateElement("timetable");
            for (int i = 0; i < 5; i++) {
                int count = (i == 2) ? 6 : 7;   
                XmlElement weekday = doc.CreateElement("weekday");
                for (int j = 0; j < count; j++) {
                    SubjectBox sb = (SubjectBox)mainPanel.Controls[i].Controls[j];
                    if (!string.IsNullOrWhiteSpace(sb.name.Text)) {
                        XmlElement element = doc.CreateElement("subject");
                        element.SetAttribute("name", sb.name.Text);
                        element.SetAttribute("teacher", sb.teacher.Text);
                        weekday.AppendChild(element);
                    } else {
                        MessageBox.Show("공란이 있거나 저장 중 오류가 발생함..", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                timetable.AppendChild(weekday);
            }
            doc.AppendChild(timetable);

            if (pathBox.Text == "") {
                SaveFileDialog sfd = new SaveFileDialog() {
                    FileName = "timetable",
                    DefaultExt = ".xml",
                    Filter = "XML Files(*.xml)|*.xml"
                };
                if (sfd.ShowDialog() == DialogResult.OK) {
                    pathBox.Text = sfd.FileName;
                    doc.Save(pathBox.Text);
                    MessageBox.Show("성공적으로 저장되었음!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void loadBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() {
                Filter = "XML Files(*.xml)|*.xml",
                FileName = pathBox.Text
            };
            if (ofd.ShowDialog() == DialogResult.OK) {
                pathBox.Text = ofd.FileName;
                if (verifyXml()) {
                    loadXml();
                    MessageBox.Show("정상적으로 로드됨", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else {
                    MessageBox.Show("올바른 파일이 아님..", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    pathBox.Text = "";
                }
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            XmlDocument doc = createXml();
            if (doc == null) {
                MessageBox.Show("공란이 있거나 저장 중 오류가 발생함..", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(pathBox.Text)) {
                SaveFileDialog sfd = new SaveFileDialog() {
                    FileName = "timetable",
                    DefaultExt = ".xml",
                    Filter = "XML Files(*.xml)|*.xml"
                };
                if (sfd.ShowDialog() == DialogResult.OK) {
                    pathBox.Text = sfd.FileName;
                } else { return; }
            }
            doc.Save(pathBox.Text);
            MessageBox.Show("성공적으로 저장되었음!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void saveAsBtn_Click(object sender, EventArgs e)
        {
            XmlDocument doc = createXml();
            if (doc == null) {
                MessageBox.Show("공란이 있거나 저장 중 오류가 발생함..", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog() {
                FileName = "timetable",
                DefaultExt = ".xml",
                Filter = "XML Files(*.xml)|*.xml"
            };
            if (sfd.ShowDialog() == DialogResult.OK) {
                pathBox.Text = sfd.FileName;
            }
            doc.Save(pathBox.Text);
            MessageBox.Show("성공적으로 저장되었음!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Main_Load(object sender, EventArgs e) {
            pathBox.Text = Properties.Settings.Default.timetable_path;
            if (File.Exists(pathBox.Text)) {
                if (verifyXml()) loadXml();
                else pathBox.Text = "";
            } else { pathBox.Text = ""; }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e) {
            Properties.Settings.Default.timetable_path = pathBox.Text;
            Properties.Settings.Default.Save();
        }

        private void neisLoadBtn_Click(object sender, EventArgs e)
        {
            new Thread(() => {
                try {
                    neisGroup.Enabled = false;
                    WebClient wc = new WebClient() {
                        QueryString = new NameValueCollection() {
                            {"KEY", "f0491ec9a1784e2cb92d2a4070f1392b"},
                            {"ATPT_OFCDC_SC_CODE", "S10"},
                            {"SD_SCHUL_CODE", "9010277"},
                            {"AY", "2022"},
                            {"GRADE", gradeBox.Text},
                            {"CLASS_NM", classBox.Text},
                            {"SEM", sessionBox.Text}
                        },
                        Encoding = Encoding.UTF8
                    };
                    string xmlString = wc.DownloadString("https://open.neis.go.kr/hub/hisTimetable");
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(xmlString);

                    List<string[]> timetable = new List<string[]>() { new string[7], new string[7], new string[6], new string[7], new string[7] };
                    XmlNodeList nodelist = doc.SelectNodes("hisTimetable/row");
                    foreach (XmlNode x in nodelist) {
                        DateTime datetime = DateTime.ParseExact(x.SelectSingleNode("ALL_TI_YMD").InnerText, "yyyyMMdd", new CultureInfo("ko-kr"));
                        if (datetime.DayOfWeek != DayOfWeek.Saturday && datetime.DayOfWeek != DayOfWeek.Sunday) {
                            string subject_name = x.SelectSingleNode("ITRT_CNTNT").InnerText;
                            subject_name = Regex.Replace(subject_name, @"\[\S+\]", "");
                            timetable[(int)datetime.DayOfWeek-1][int.Parse(x.SelectSingleNode("PERIO").InnerText)-1] = subject_name;
                            resetTeacherBtn_Click(sender, e);
                        }
                    }

                    for (int i = 0; i < 5; i++) {
                        int count = timetable[i].Length;
                        for (int j = 0; j < count; j++) {
                            SubjectBox target = (SubjectBox)mainPanel.Controls[i].Controls[j];
                            if (string.IsNullOrEmpty(timetable[i][j])) target.clearName();
                            else target.writeName(timetable[i][j]);
                        }
                    }
                    neisGroup.Enabled = true;
                } catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }).Start();
        }

        private void resetNameBtn_Click(object sender, EventArgs e)
        {
            foreach (Control week in mainPanel.Controls) {
                foreach (Control subject in week.Controls) {
                    ((SubjectBox)subject).clearName();
                }
            }
        }

        private void resetTeacherBtn_Click(object sender, EventArgs e)
        {
            foreach (Control week in mainPanel.Controls) {
                foreach (Control subject in week.Controls) {
                    ((SubjectBox)subject).clearTeacher();
                }
            }
        }
    }
}
