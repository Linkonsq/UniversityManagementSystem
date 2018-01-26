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
    public partial class OfferCourse : Form
    {
        CourseBusinessLogic cbl = new CourseBusinessLogic();

        string loginUserName;
        string department, subName, section, subID, time, seat;

        public OfferCourse()
        {
            InitializeComponent();
        }

        public OfferCourse(string loginUserName)
        {
            this.loginUserName = loginUserName;
            InitializeComponent();
            FillComboBox();
            button1.BackColor = Color.LightSeaGreen;
            button4.BackColor = Color.LightSeaGreen;
        }

        private void FillComboBox()
        {
            comboBox4.Items.Add("Select One");
            comboBox4.Items.Add("CS");
            comboBox4.Items.Add("EEE");
            comboBox4.Items.Add("BBA");
            comboBox4.SelectedIndex = 0;

            comboBox2.Items.Add("Select One");
            comboBox2.Items.Add("A");
            comboBox2.Items.Add("B");
            comboBox2.Items.Add("C");
            comboBox2.Items.Add("D");
            comboBox2.Items.Add("E");
            comboBox2.Items.Add("F");
            comboBox2.Items.Add("G");
            comboBox2.Items.Add("H");
            comboBox2.Items.Add("I");
            comboBox2.Items.Add("J");
            comboBox2.SelectedIndex = 0;

            comboBox3.Items.Add("Select One");
            comboBox3.Items.Add("20");
            comboBox3.Items.Add("40");
            comboBox3.SelectedIndex = 0;
        }

        private void ExitApp(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminSettings ast = new AdminSettings(this.loginUserName);
            ast.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.department = comboBox4.Items[comboBox4.SelectedIndex].ToString();
            this.subName = textBox3.Text;
            this.section = comboBox2.Items[comboBox2.SelectedIndex].ToString();
            this.subID = textBox1.Text;
            this.time = textBox2.Text;
            this.seat = comboBox3.Items[comboBox3.SelectedIndex].ToString();

            if(comboBox4.SelectedIndex == 0 || textBox3.Text=="" || comboBox2.SelectedIndex==0 || textBox1.Text=="" || textBox2.Text=="" || comboBox3.SelectedIndex==0)
            {
                MessageBox.Show("Please fill all the field");
            }
            else if(cbl.IsExistID(this.subName, this.subID))
            {
                MessageBox.Show("Section with same id already offered\nPlease use another id");
            }
            else if (cbl.IsExistSection(this.subName, this.section))
            {
                MessageBox.Show("Section with same section already offered\nPlease offer another section");
            }
            else if(cbl.IsExistID(this.subName, this.subID) && cbl.IsExistSection(this.subName, this.section))
            {
                MessageBox.Show("Section with same id & section already offered\nPlease offer another section and use another id");
            }
            else if(textBox3.Text.Any(char.IsLower))
            {
                MessageBox.Show("Please use upper case for course name");
            }
            else if(textBox1.Text.Any(char.IsLower) || textBox1.Text.Any(char.IsUpper))
            {
                MessageBox.Show("Please use digit for course section");
            }
            else
            {
                cbl.AddCourse(this.department, this.subID, this.subName, this.section, this.time, this.seat);
                MessageBox.Show("Course offered successfully");
                textBox3.Text = "";
                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }
    }
}
