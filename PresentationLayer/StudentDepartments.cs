using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class StudentDepartments : Form
    {
        string loginUserName;

        public StudentDepartments()
        {
            InitializeComponent();
        }

        public StudentDepartments(string loginUserName)
        {
            this.loginUserName = loginUserName;
            InitializeComponent();
            button1.BackColor = Color.LightSeaGreen;
            button2.BackColor = Color.LightSeaGreen;
            button3.BackColor = Color.LightSeaGreen;
            button4.BackColor = Color.LightSeaGreen;
            button5.BackColor = Color.LightSeaGreen;
        }

        private void ExitApp(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPage obj = new AdminPage(loginUserName);
            obj.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start obj = new Start();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentsList obj = new StudentsList(loginUserName, "EEE");
            obj.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentsList obj = new StudentsList(loginUserName, "CS");
            obj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentsList obj = new StudentsList(loginUserName, "BBA");
            obj.Show();
        }
    }
}
