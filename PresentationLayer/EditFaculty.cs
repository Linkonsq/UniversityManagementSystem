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
    public partial class EditFaculty : Form
    {
        FacultyBusinessLogic fbl = new FacultyBusinessLogic();

        string selectedItem, loginUserName, department;
        string gender, bloodGroup;

        public EditFaculty()
        {
            InitializeComponent();
        }

        public EditFaculty(string selectedItem, string loginUserName, string department)
        {
            this.selectedItem = selectedItem;
            this.loginUserName = loginUserName;
            this.department = department;
            InitializeComponent();
            FillComboBox();
            button1.BackColor = Color.LightSeaGreen;
            button3.BackColor = Color.LightSeaGreen;
            button4.BackColor = Color.LightSeaGreen;
            List<string> facultyInfo = fbl.GetFacultyInfo(selectedItem, department);
            textBox1.Text = facultyInfo[0];
            textBox2.Text = facultyInfo[1];
            textBox3.Text = facultyInfo[2];
            textBox8.Text = facultyInfo[3];
            textBox4.Text = facultyInfo[4];
            textBox5.Text = facultyInfo[5];
            textBox7.Text = facultyInfo[6];
            textBox6.Text = facultyInfo[7];
            gender = facultyInfo[8];
            if(gender == "Male")
            {
                radioButton1.Checked = true;
            }
            else if (gender == "Female")
            {
                radioButton2.Checked = true;
            }
            bloodGroup = facultyInfo[9];
            if(bloodGroup == "A+")
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
            textBox12.Text = facultyInfo[10];
            textBox11.Text = facultyInfo[11];
            textBox10.Text = facultyInfo[12];

            if (department == "CS")
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

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != selectedItem && fbl.IsExistCSFaculty(textBox1.Text)) || (textBox1.Text != selectedItem && fbl.IsExistEEEFaculty(textBox1.Text)) || (textBox1.Text != selectedItem && fbl.IsExistBBAFaculty(textBox1.Text)))
            {
                MessageBox.Show("Faculty with same User Name already exist.\nPlease use another UserName.");
            }
            else if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox8.Text == "" || textBox4.Text == "" || textBox5.Text == ""
                || textBox7.Text == "" || textBox6.Text == "" || comboBox1.SelectedIndex == 0 || textBox12.Text == "" || textBox11.Text == "" || textBox10.Text == "" || pictureBox1.Image == null)
            {
                MessageBox.Show("Please fill all the information correctly.");
            }
            else if (textBox1.Text.Length != 7)
            {
                MessageBox.Show("Please use 7 character for a User Name.");
            }
            else
            {
                string bloodGroup = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                string gender;

                if (radioButton1.Checked == true)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }

                fbl.UpdateFaculty(selectedItem, textBox1.Text, textBox2.Text, textBox3.Text, textBox8.Text, textBox4.Text, textBox5.Text, textBox7.Text, textBox6.Text, gender, bloodGroup, textBox12.Text, textBox11.Text, textBox10.Text, pictureBox1.Image, department);
                this.Hide();
                FacultyInfo fi = new FacultyInfo(selectedItem, loginUserName, department);
                fi.Show();

                MessageBox.Show("Faculty information updated successfully.");
            }
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

        private void ExitApp(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FacultyPage obj = new FacultyPage();
            obj.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            FacultyInfo fi = new FacultyInfo(selectedItem, loginUserName, department);
            fi.Show();
        }
    }
}
