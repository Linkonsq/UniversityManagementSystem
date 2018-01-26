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
    public partial class AddAdmin : Form
    {
        AdminBusinessLogic blc = new AdminBusinessLogic();

        string loginUserName;

        public AddAdmin()
        {
            InitializeComponent();
        }

        public AddAdmin(string loginUserName)
        {

            this.loginUserName = loginUserName;
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
            this.Hide();
            AdminSettings obj = new AdminSettings(loginUserName);
            obj.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(blc.IsExistAdmin(textBox1.Text))
            {
                MessageBox.Show("Admin with same User Name already exist.\nPlease use another UserName.");
            }
            else if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == ""
                || textBox7.Text == "" || textBox8.Text == "")
            {
                MessageBox.Show("Please fill all the information correctly.");
            }
            else if (textBox1.Text.Length != 8)
            {
                MessageBox.Show("Please use 8 character for a User Name.");
            }
            else
            {
                blc.AddAdmin(textBox1.Text, textBox2.Text, textBox3.Text, textBox8.Text, textBox4.Text, textBox5.Text, textBox7.Text, textBox6.Text);
                this.Hide();
                AdminSettings obj = new AdminSettings(loginUserName);
                obj.Show();

                MessageBox.Show("Admin added successfully.");
            }
        }

        private void TextLeave(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.White;
        }

        private void TextEnter(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.LightBlue;
        }
    }
}
