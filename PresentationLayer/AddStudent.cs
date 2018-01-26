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
    public partial class AddStudent : Form
    {
        StudentBusinessLogic sbl = new StudentBusinessLogic();

        string loginUserName, department;//, maritalStatus;

        public AddStudent()
        {
            InitializeComponent();
            AutoScroll = true;
        }

        public AddStudent(string loginUserName, string department)
        {
            this.loginUserName = loginUserName;
            this.department = department;
            InitializeComponent();
            FillComboBox();
            button1.BackColor = Color.LightSeaGreen;
            button2.BackColor = Color.LightSeaGreen;
            button3.BackColor = Color.LightSeaGreen;
            AutoScroll = true;
        }

        private void FillComboBox()
        {
            comboBox1.Items.Add("Select One");
            comboBox1.Items.Add("A+");
            comboBox1.Items.Add("A-");
            comboBox1.Items.Add("B+");
            comboBox1.Items.Add("B-");
            comboBox1.Items.Add("AB+");
            comboBox1.Items.Add("AB-");
            comboBox1.Items.Add("O+");
            comboBox1.Items.Add("O-");
            comboBox1.SelectedIndex = 0;
        }

        private void ExitApp(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String imagelocation = "";

            try
            {
                OpenFileDialog dialog = new OpenFileDialog();

                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All files(*.*)|*.*";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imagelocation = dialog.FileName;
                    pictureBox1.ImageLocation = imagelocation;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("an error occured", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = !checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = !checkBox2.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sbl.IsExistCSStudent(textBox1.Text) || sbl.IsExistEEEStudent(textBox1.Text) || sbl.IsExistBBAStudent(textBox1.Text))
            {
                MessageBox.Show("Student with same Student ID already exist.\nPlease use another Student ID.");
            }
            else if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox8.Text == "" || textBox4.Text == "" || textBox5.Text == ""
                || textBox7.Text == "" || textBox6.Text == "" || textBox9.Text == "" || textBox13.Text == "" || textBox14.Text == "" || textBox15.Text == ""
                || comboBox1.SelectedIndex == 0 || textBox12.Text == "" || textBox11.Text == "" || textBox16.Text == "" || textBox17.Text == "" || pictureBox1.Image == null)
            {
                MessageBox.Show("Please fill all the information correctly.");
            }
            else if (textBox1.Text.Length != 6)
            {
                MessageBox.Show("Please use 6 character for a User Name.");
            }
            else
            {
                string bloodGroup = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                string gender, maritalStatus;
                
                if (radioButton1.Checked == true)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }

                if (checkBox1.Checked == true)
                {
                    maritalStatus = "Married";
                }
                else
                {
                    maritalStatus = "Unmarried";
                }

                sbl.AddStudent(textBox1.Text, textBox2.Text, textBox3.Text, textBox8.Text, textBox4.Text, textBox5.Text, textBox7.Text, textBox6.Text, textBox9.Text, textBox13.Text, textBox14.Text, textBox15.Text, gender, textBox12.Text, textBox11.Text, maritalStatus, bloodGroup, textBox16.Text, textBox17.Text, pictureBox1.Image, department);
                this.Hide();
                StudentsList fl = new StudentsList(loginUserName, department);
                fl.Show();

                MessageBox.Show("Student added successfully.");
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentsList sl = new StudentsList(loginUserName, department);
            sl.Show();
        }
    }
}
