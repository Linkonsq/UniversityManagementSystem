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
    public partial class EditStudent : Form
    {
        StudentBusinessLogic sbl = new StudentBusinessLogic();

        string selectedItem, loginUserName, department;
        string gender, bloodGroup, maritalStatus;

        public EditStudent()
        {
            InitializeComponent();
        }

        public EditStudent(string selectedItem, string loginUserName, string department)
        {
            this.selectedItem = selectedItem;
            this.loginUserName = loginUserName;
            this.department = department;
            InitializeComponent();
            FillComboBox();
            button1.BackColor = Color.LightSeaGreen;
            button2.BackColor = Color.LightSeaGreen;
            button3.BackColor = Color.LightSeaGreen;
            AutoScroll = true;
            List<string> studentInfo = sbl.GetStudentInfo(selectedItem, department);
            textBox1.Text = studentInfo[0];
            textBox2.Text = studentInfo[1];
            textBox3.Text = studentInfo[2];
            textBox8.Text = studentInfo[3];
            textBox4.Text = studentInfo[4];
            textBox5.Text = studentInfo[5];
            textBox7.Text = studentInfo[6];
            textBox6.Text = studentInfo[7];
            textBox9.Text = studentInfo[8];
            textBox13.Text = studentInfo[9];
            textBox14.Text = studentInfo[10];
            textBox15.Text = studentInfo[11];
            gender = studentInfo[12];
            if (gender == "Male")
            {
                radioButton1.Checked = true;
            }
            else if (gender == "Female")
            {
                radioButton2.Checked = true;
            }
            bloodGroup = studentInfo[16];
            if (bloodGroup == "A+")
            {
                comboBox1.SelectedIndex = 1;
            }
            else if (bloodGroup == "A-")
            {
                comboBox1.SelectedIndex = 2;
            }
            else if (bloodGroup == "B+")
            {
                comboBox1.SelectedIndex = 3;
            }
            else if (bloodGroup == "B-")
            {
                comboBox1.SelectedIndex = 4;
            }
            else if (bloodGroup == "AB+")
            {
                comboBox1.SelectedIndex = 5;
            }
            else if (bloodGroup == "AB-")
            {
                comboBox1.SelectedIndex = 6;
            }
            else if (bloodGroup == "O+")
            {
                comboBox1.SelectedIndex = 7;
            }
            else if (bloodGroup == "O-")
            {
                comboBox1.SelectedIndex = 8;
            }
            textBox12.Text = studentInfo[13];
            textBox11.Text = studentInfo[14];
            maritalStatus = studentInfo[15];
            if(maritalStatus == "Married")
            {
                checkBox1.Checked = true;
            }
            else if(maritalStatus == "Unmarried")
            {
                checkBox2.Checked = true;
            }
            textBox16.Text = studentInfo[17];
            textBox17.Text = studentInfo[18];

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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = !checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = !checkBox2.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentInfo si = new StudentInfo(this.selectedItem, this.loginUserName, this.department);
            si.Show();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != selectedItem && sbl.IsExistCSStudent(textBox1.Text)) || (textBox1.Text != selectedItem && sbl.IsExistEEEStudent(textBox1.Text)) || (textBox1.Text != selectedItem && sbl.IsExistBBAStudent(textBox1.Text)))
            {
                MessageBox.Show("Student with same User Name already exist.\nPlease use another UserName.");
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
                bloodGroup = comboBox1.Items[comboBox1.SelectedIndex].ToString();

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

                sbl.UpdateStudent(selectedItem, textBox1.Text, textBox2.Text, textBox3.Text, textBox8.Text, textBox4.Text, textBox5.Text, textBox7.Text, textBox6.Text, textBox9.Text, textBox13.Text, textBox14.Text, textBox15.Text, gender, textBox12.Text, textBox11.Text, maritalStatus, bloodGroup, textBox16.Text, textBox17.Text, pictureBox1.Image, department);
                this.Hide();
                StudentInfo fl = new StudentInfo(loginUserName, department);
                fl.Show();

                MessageBox.Show("Student information updated successfully.");
            }
        }
    }
}
