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
    public partial class ChangePassword : Form
    {
        StudentBusinessLogic sbl = new StudentBusinessLogic();
        FacultyBusinessLogic fbl = new FacultyBusinessLogic();

        string loginUserName, department;

        public ChangePassword()
        {
            InitializeComponent();
        }

        public ChangePassword(string loginUserName, string department)
        {
            this.loginUserName = loginUserName;
            this.department = department;
            InitializeComponent();
            button1.BackColor = Color.LightSeaGreen;
            button2.BackColor = Color.LightSeaGreen;
        }

        private void ExitApp(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(loginUserName.Length == 6)
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Please fill all the information correctly");
                }
                else if (textBox2.Text != textBox3.Text)
                {
                    MessageBox.Show("The new password and confirmation password do not match");
                }
                else if (department == "CS")
                {
                    if (sbl.IsValidCSStudent(loginUserName, textBox1.Text))
                    {
                        sbl.ChangePassword(loginUserName, textBox3.Text, department);
                        MessageBox.Show("Password Changed Successfully");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Wrong Current Password");
                    }
                }
                else if (department == "EEE")
                {
                    if (sbl.IsValidEEEStudent(loginUserName, textBox1.Text))
                    {
                        sbl.ChangePassword(loginUserName, textBox3.Text, department);
                        MessageBox.Show("Password Changed Successfully");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Wrong Current Password");
                    }
                }
                else if (department == "BBA")
                {
                    if (sbl.IsValidBBAStudent(loginUserName, textBox1.Text))
                    {
                        sbl.ChangePassword(loginUserName, textBox3.Text, department);
                        MessageBox.Show("Password Changed Successfully");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Wrong Current Password");
                    }
                }
            }
            else if(loginUserName.Length == 7)
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Please fill all the information correctly");
                }
                else if (textBox2.Text != textBox3.Text)
                {
                    MessageBox.Show("The new password and confirmation password do not match");
                }
                else if (department == "CS")
                {
                    if (fbl.IsValidCSFaculty(loginUserName, textBox1.Text))
                    {
                        fbl.ChangePassword(loginUserName, textBox3.Text, department);
                        MessageBox.Show("Password Changed Successfully");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Wrong Current Password");
                    }
                }
                else if (department == "EEE")
                {
                    if (fbl.IsValidEEEFaculty(loginUserName, textBox1.Text))
                    {
                        fbl.ChangePassword(loginUserName, textBox3.Text, department);
                        MessageBox.Show("Password Changed Successfully");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Wrong Current Password");
                    }
                }
                else if (department == "BBA")
                {
                    if (fbl.IsValidBBAFaculty(loginUserName, textBox1.Text))
                    {
                        fbl.ChangePassword(loginUserName, textBox3.Text, department);
                        MessageBox.Show("Password Changed Successfully");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Wrong Current Password");
                    }
                }
            }
        }

        private void TextEnter(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.LightBlue;
        }

        private void TextLeave(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(loginUserName.Length == 7)
            {
                this.Hide();
                FacultyPage fp = new FacultyPage(loginUserName, department);
                fp.Show();
            }
            else
            {
                this.Hide();
                StudentPage sp = new StudentPage(loginUserName, department);
                sp.Show();
            }
        }
    }
}