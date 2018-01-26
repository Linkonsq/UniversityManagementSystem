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
    public partial class FacultyInfo : Form
    {
        FacultyBusinessLogic fbl = new FacultyBusinessLogic();

        string selectedItem, loginUserName, department;

        public FacultyInfo()
        {
            InitializeComponent();
        }

        public FacultyInfo(string loginUserName, string department)
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
            List<string> csFacultyInfo = fbl.GetFacultyInfo(loginUserName, department);
            //label3.Text = label2.Text;
            label26.Text = csFacultyInfo[0];
            label25.Text = csFacultyInfo[2];
            label24.Text = csFacultyInfo[3];
            label23.Text = csFacultyInfo[4];
            label4.Text = csFacultyInfo[5];
            label20.Text = csFacultyInfo[6];
            label21.Text = csFacultyInfo[7];
            label6.Text = csFacultyInfo[8];
            label18.Text = csFacultyInfo[9];
            label14.Text = csFacultyInfo[10];
            label22.Text = csFacultyInfo[11];
            label16.Text = csFacultyInfo[12];

            if (department == "CS")
            {
                pictureBox1.Image = fbl.GetCSFacultyImage(loginUserName);
            }
            else if (department == "EEE")
            {
                pictureBox1.Image = fbl.GetEEEFacultyImage(loginUserName);
            }
            else if (department == "BBA")
            {
                pictureBox1.Image = fbl.GetBBAFacultyImage(loginUserName);
            }
        }

        public FacultyInfo(string selectedItem, string loginUserName, string department)
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
            List<string> csFacultyInfo = fbl.GetFacultyInfo(selectedItem, department);
            label27.Text = csFacultyInfo[0];
            label26.Text = csFacultyInfo[1];
            label25.Text = csFacultyInfo[2];
            label24.Text = csFacultyInfo[3];
            label23.Text = csFacultyInfo[4];
            label4.Text = csFacultyInfo[5];
            label20.Text = csFacultyInfo[6];
            label21.Text = csFacultyInfo[7];
            label6.Text = csFacultyInfo[8];
            label18.Text = csFacultyInfo[9];
            label14.Text = csFacultyInfo[10];
            label22.Text = csFacultyInfo[11];
            label16.Text = csFacultyInfo[12];

            if(department == "CS")
            {
                pictureBox1.Image = fbl.GetCSFacultyImage(selectedItem);
            }
            else if (department == "EEE")
            {
                pictureBox1.Image = fbl.GetEEEFacultyImage(selectedItem);
            }
            else if (department == "BBA")
            {
                pictureBox1.Image = fbl.GetBBAFacultyImage(selectedItem);
            }
        }

        private void ExitApp(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to dlete this faculty?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                fbl.DeleteFaculty(label27.Text, department);
                this.Hide();
                FacultyList fl = new FacultyList(loginUserName, department);
                fl.Show();
                MessageBox.Show("Faculty deleted successfully.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditFaculty ef = new EditFaculty(selectedItem, loginUserName, department);
            ef.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start st = new Start();
            st.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (fbl.IsExistCSFaculty(this.loginUserName) || fbl.IsExistEEEFaculty(this.loginUserName) || fbl.IsExistBBAFaculty(this.loginUserName))
            {
                this.Hide();
                FacultyPage fp = new FacultyPage(loginUserName, department);    //for faculty
                fp.Show();
            }
            else
            {
                this.Hide();
                FacultyList fl = new FacultyList(loginUserName, department);       //for admin
                fl.Show();
            }

            //if (loginUserName != null && loginUserName.Length == 8)
            //{
            //    this.Hide();
            //    FacultyList fl = new FacultyList(loginUserName, department);
            //    fl.Show();
            //}
            //else if (loginUserName != null && loginUserName.Length == 7)
            //{
            //    this.Hide();
            //    FacultyPage fp = new FacultyPage(loginUserName, department);
            //    fp.Show();
            //}
        }
    }
}
