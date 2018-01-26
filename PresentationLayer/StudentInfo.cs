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
    public partial class StudentInfo : Form
    {
        StudentBusinessLogic sbl = new StudentBusinessLogic();

        string selectedItem, loginUserName, department;

        public StudentInfo()
        {
            InitializeComponent();
            AutoScroll = true;
        }

        public StudentInfo(string loginUserName, string department)
        {
            this.loginUserName = loginUserName;
            this.department = department;
            InitializeComponent();
            button3.BackColor = Color.LightSeaGreen;
            button4.BackColor = Color.LightSeaGreen;
            label2.Visible = false;
            label27.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            AutoScroll = true;
            List<string> GetStudentInfo = sbl.GetStudentInfo(this.loginUserName, this.department);
            label27.Text = GetStudentInfo[0];
            label26.Text = GetStudentInfo[0];
            label25.Text = GetStudentInfo[2];
            label24.Text = GetStudentInfo[3];
            label23.Text = GetStudentInfo[4];
            label4.Text = GetStudentInfo[5];
            label20.Text = GetStudentInfo[6];
            label21.Text = GetStudentInfo[7];
            label6.Text = GetStudentInfo[8];
            label14.Text = GetStudentInfo[9];
            label22.Text = GetStudentInfo[10];
            label16.Text = GetStudentInfo[11];
            label28.Text = GetStudentInfo[12];
            label30.Text = GetStudentInfo[13];
            label18.Text = GetStudentInfo[14];
            label34.Text = GetStudentInfo[15];
            label36.Text = GetStudentInfo[16];
            label32.Text = GetStudentInfo[17];
            label38.Text = GetStudentInfo[18];

            if (department == "CS")
            {
                pictureBox1.Image = sbl.GetCSStudentImage(this.loginUserName);
            }
            else if (department == "EEE")
            {
                pictureBox1.Image = sbl.GetEEEStudentImage(this.loginUserName);
            }
            else if (department == "BBA")
            {
                pictureBox1.Image = sbl.GetBBAStudentImage(this.loginUserName);
            }

            AutoScroll = true;
        }

        public StudentInfo(string selectedItem, string loginUserName, string department)
        {
            this.selectedItem = selectedItem;
            this.loginUserName = loginUserName;
            this.department = department;
            InitializeComponent();
            button1.BackColor = Color.LightSeaGreen;
            button2.BackColor = Color.LightSeaGreen;
            button3.BackColor = Color.LightSeaGreen;
            button4.BackColor = Color.LightSeaGreen;
            label3.Text = "Password :";
            List<string> GetStudentInfo = sbl.GetStudentInfo(selectedItem, department);
            label27.Text = GetStudentInfo[0];
            label26.Text = GetStudentInfo[1];
            label25.Text = GetStudentInfo[2];
            label24.Text = GetStudentInfo[3];
            label23.Text = GetStudentInfo[4];
            label4.Text = GetStudentInfo[5];
            label20.Text = GetStudentInfo[6];
            label21.Text = GetStudentInfo[7];
            label6.Text = GetStudentInfo[8];
            label14.Text = GetStudentInfo[9];
            label22.Text = GetStudentInfo[10];
            label16.Text = GetStudentInfo[11];
            label28.Text = GetStudentInfo[12];
            label30.Text = GetStudentInfo[13];
            label18.Text = GetStudentInfo[14];
            label34.Text = GetStudentInfo[15];
            label36.Text = GetStudentInfo[16];
            label32.Text = GetStudentInfo[17];
            label38.Text = GetStudentInfo[18];

            if (department == "CS")
            {
                pictureBox1.Image = sbl.GetCSStudentImage(selectedItem);
            }
            else if (department == "EEE")
            {
                pictureBox1.Image = sbl.GetEEEStudentImage(selectedItem);
            }
            else if (department == "BBA")
            {
                pictureBox1.Image = sbl.GetBBAStudentImage(selectedItem);
            }

            AutoScroll = true;
        }

        private void ExitApp(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start st = new Start();
            st.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (sbl.IsExistCSStudent(this.loginUserName) || sbl.IsExistEEEStudent(this.loginUserName) || sbl.IsExistBBAStudent(this.loginUserName))
            {
                this.Hide();
                StudentPage sp = new StudentPage(this.loginUserName, this.department);      //for student
                sp.Show();
            }
            else
            {
                this.Hide();
                StudentsList sl = new StudentsList(this.loginUserName, this.department);       //for admin
                sl.Show();
            }

            //if (loginUserName != null && loginUserName.Length == 8)
            //{
            //    this.Hide();
            //    StudentsList sl = new StudentsList(loginUserName, department);
            //    sl.Show();
            //}
            //else if (loginUserName != null && loginUserName.Length == 6)
            //{
            //    this.Hide();
            //    StudentPage sp = new StudentPage(loginUserName, department);
            //    sp.Show();
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditStudent es = new EditStudent(selectedItem, loginUserName, department);
            es.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to dlete this student?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                sbl.DeleteStudent(label27.Text, department);
                this.Hide();
                StudentsList sl = new StudentsList(loginUserName, department);
                sl.Show();
                MessageBox.Show("Student deleted successfully.");
            }
        }
    }
}
