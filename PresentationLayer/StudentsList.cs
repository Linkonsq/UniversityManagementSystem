using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;

namespace PresentationLayer
{
    public partial class StudentsList : Form
    {
        StudentBusinessLogic sbl = new StudentBusinessLogic();

        string loginUserName, department;

        public StudentsList()
        {
            InitializeComponent();
        }

        public StudentsList(string loginUserName, string department)
        {
            this.loginUserName = loginUserName;
            this.department = department;
            InitializeComponent();
            FillListBox();
            button1.BackColor = Color.LightSeaGreen;
            button3.BackColor = Color.LightSeaGreen;
            button4.BackColor = Color.LightSeaGreen;
        }

        private void FillListBox()
        {
            listBox1.DataSource = sbl.GetStudentList(department);
        }

        private void ExitApp(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentDepartments obj = new StudentDepartments(loginUserName);
            obj.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start obj = new Start();
            obj.Show();
        }

        private void ItemClick(object sender, MouseEventArgs e)
        {
            string selectedItem = listBox1.SelectedItem.ToString();

            this.Hide();
            StudentInfo si = new StudentInfo(selectedItem, loginUserName, department);
            si.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddStudent si = new AddStudent(loginUserName, department);
            si.Show();
        }
    }
}
