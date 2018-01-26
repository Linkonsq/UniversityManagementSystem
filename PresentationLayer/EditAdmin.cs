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
    public partial class EditAdmin : Form
    {
        AdminBusinessLogic blc = new AdminBusinessLogic();

        string selectedItem, loginUserName;

        public EditAdmin()
        {
            InitializeComponent();
        }

        public EditAdmin(string selectedItem, string loginUserName)
        {
            this.selectedItem = selectedItem;
            this.loginUserName = loginUserName;
            InitializeComponent();
            button1.BackColor = Color.LightSeaGreen;
            button2.BackColor = Color.LightSeaGreen;
            List<string> adminInfo = blc.GetAdminInfo(selectedItem);
            textBox1.Text = adminInfo[0];
            textBox2.Text = adminInfo[1];
            textBox3.Text = adminInfo[2];
            textBox8.Text = adminInfo[3];
            textBox4.Text = adminInfo[4];
            textBox5.Text = adminInfo[5];
            textBox7.Text = adminInfo[6];
            textBox6.Text = adminInfo[7];
        }

        private void ExitApp(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!=selectedItem  && blc.IsExistAdmin(textBox1.Text))
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
                blc.UpdateAdmin(selectedItem, textBox1.Text, textBox2.Text, textBox3.Text, textBox8.Text, textBox4.Text, textBox5.Text, textBox7.Text, textBox6.Text);
                //selectedItem = textBox1.Text;
                this.Hide();
                AdminInfo obj = new AdminInfo(selectedItem, loginUserName);
                obj.Show();
                MessageBox.Show("Admin informaton updated successfully.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminInfo obj = new AdminInfo(selectedItem, loginUserName);
            obj.Show();
        }
    }
}
