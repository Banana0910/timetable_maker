using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
