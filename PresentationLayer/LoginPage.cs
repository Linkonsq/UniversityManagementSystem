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
    public partial class LoginPage : Form
    {
        AdminBusinessLogic abl = new AdminBusinessLogic();
        FacultyBusinessLogic fbl = new FacultyBusinessLogic();
        StudentBusinessLogic sbl = new StudentBusinessLogic();

        string loginUserName, department;

        public LoginPage()
        {
            InitializeComponent();
            button1.BackColor = Color.LightSeaGreen;
            button2.BackColor = Color.LightSeaGreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 8)
            {
                if (abl.IsValidAdmin(textBox1.Text, textBox2.Text))
                {
                    loginUserName = textBox1.Text;
                    this.Hide();
                    AdminPage obj = new AdminPage(loginUserName);
                    obj.Show();
                    MessageBox.Show("LogIn Successful");
                }
                else
                {
                    MessageBox.Show("Please check your UserName and Password");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
            else if (textBox1.Text.Length == 7)
            {
                if (fbl.IsValidCSFaculty(textBox1.Text, textBox2.Text))
                {
                    loginUserName = textBox1.Text;
                    department = "CS";
                    this.Hide();
                    FacultyPage fp = new FacultyPage(loginUserName, department);
                    fp.Show();
                    MessageBox.Show("LogIn Successful");
                }
                else if (fbl.IsValidEEEFaculty(textBox1.Text, textBox2.Text))
                {
                    loginUserName = textBox1.Text;
                    department = "EEE";
                    this.Hide();
                    FacultyPage fp = new FacultyPage(loginUserName, department);
                    fp.Show();
                    MessageBox.Show("LogIn Successful");
                }
                else if (fbl.IsValidBBAFaculty(textBox1.Text, textBox2.Text))
                {
                    loginUserName = textBox1.Text;
                    department = "BBA";
                    this.Hide();
                    FacultyPage fp = new FacultyPage(loginUserName, department);
                    fp.Show();
                    MessageBox.Show("LogIn Successful");
                }
                else
                {
                    MessageBox.Show("Please check your UserName and Password");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
            else if (textBox1.Text.Length == 6)
            {
                if (sbl.IsValidCSStudent(textBox1.Text, textBox2.Text))
                {
                    loginUserName = textBox1.Text;
                    department = "CS";
                    this.Hide();
                    StudentPage sp = new StudentPage(loginUserName, department);
                    sp.Show();
                    MessageBox.Show("LogIn Successful");
                }
                else if (sbl.IsValidEEEStudent(textBox1.Text, textBox2.Text))
                {
                    loginUserName = textBox1.Text;
                    department = "EEE";
                    this.Hide();
                    StudentPage sp = new StudentPage(loginUserName, department);
                    sp.Show();
                    MessageBox.Show("LogIn Successful");
                }
                else if (sbl.IsValidBBAStudent(textBox1.Text, textBox2.Text))
                {
                    loginUserName = textBox1.Text;
                    department = "BBA";
                    this.Hide();
                    StudentPage sp = new StudentPage(loginUserName, department);
                    sp.Show();
                    MessageBox.Show("LogIn Successful");
                }
                else
                {
                    MessageBox.Show("Please check your UserName and Password");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Please check your UserName and Password");
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start obj = new Start();
            obj.Show();
        }

        private void ExitApp(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void TextEnter(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.LightBlue;
        }

        private void TextLeave(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.White;
        }
    }
}
