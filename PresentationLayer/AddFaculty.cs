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
    public partial class AddFaculty : Form
    {
        FacultyBusinessLogic fbl = new FacultyBusinessLogic();

        string loginUserName, department;

        public AddFaculty()
        {
            InitializeComponent();
        }

        public AddFaculty(string loginUserName, string department)
        {
            this.loginUserName = loginUserName;
            this.department = department;
            InitializeComponent();
            FillComboBox();
            button1.BackColor = Color.LightSeaGreen;
            button2.BackColor = Color.LightSeaGreen;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (fbl.IsExistCSFaculty(textBox1.Text) || fbl.IsExistEEEFaculty(textBox1.Text) || fbl.IsExistBBAFaculty(textBox1.Text))
            {
                MessageBox.Show("Faculty with same User Name already exist.\nPlease use another UserName.");
            }
            else if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox8.Text == "" || textBox4.Text == "" || textBox5.Text == ""
                || textBox7.Text == "" || textBox6.Text == "" ||comboBox1.SelectedIndex == 0 || textBox12.Text == "" || textBox11.Text == "" || textBox10.Text == "" || pictureBox1.Image == null)
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
                string sex;

                if (radioButton1.Checked == true)
                {
                    sex = "Male";
                }
                else
                {
                    sex = "Female";
                }

                fbl.AddFaculty(textBox1.Text, textBox2.Text, textBox3.Text, textBox8.Text, textBox4.Text, textBox5.Text, textBox7.Text, textBox6.Text, sex, bloodGroup, textBox12.Text, textBox11.Text, textBox10.Text, pictureBox1.Image, department);
                this.Hide();
                FacultyList fl = new FacultyList(loginUserName, department);
                fl.Show();

                MessageBox.Show("Faculty added successfully.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FacultyList fl = new FacultyList(loginUserName, department);
            fl.Show();
        }
    }
}
