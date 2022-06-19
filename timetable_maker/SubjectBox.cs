using System;
using System.Drawing;
using System.Windows.Forms;

namespace timetable_maker
{
    public partial class SubjectBox : UserControl
    {
        public SubjectBox()
        {
            InitializeComponent();
            name.GotFocus += new System.EventHandler(Remove_placeholder);
            teacher.GotFocus += new System.EventHandler(Remove_placeholder);
            name.LostFocus += new System.EventHandler(Add_placeholder);
            teacher.LostFocus += new System.EventHandler(Add_placeholder);
        }

        public void writeName(string text) {
            name.Text = text;
            name.ForeColor = Color.Black;
        } 

        public void writeTeacher(string text) {
            teacher.Text = text;
            teacher.ForeColor = Color.Black;
        }

        public void clearName() {
            name.Text = "이름";
            name.ForeColor = Color.Gray;
        }

        public void clearTeacher() {
            teacher.Text = "선생님";
            teacher.ForeColor = Color.Gray;
        }

        private void Add_placeholder(object sender, EventArgs e) {
            TextBox textbox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textbox.Text)) {
                textbox.ForeColor = Color.Gray;
                textbox.Text = textbox.Tag.ToString();
            }
        }

        private void Remove_placeholder(object sender, EventArgs e) {
            TextBox textbox = (TextBox)sender;
            textbox.ForeColor = Color.Black;
            if (textbox.Tag.ToString() == textbox.Text) 
                textbox.Text = "";
        }
    }
}
