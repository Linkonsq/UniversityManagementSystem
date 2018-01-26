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
    public partial class AdminInfo : Form
    {
        AdminBusinessLogic blc = new AdminBusinessLogic();

        string selectedItem, loginUserName;

        public AdminInfo()
        {
            InitializeComponent();
        }

        public AdminInfo(string selectedItem, string loginUserName)
        {
            this.selectedItem = selectedItem;
            this.loginUserName = loginUserName;
            InitializeComponent();
            button1.BackColor = Color.LightSeaGreen;
            button2.BackColor = Color.LightSeaGreen;
            button3.BackColor = Color.LightSeaGreen;
            button4.BackColor = Color.LightSeaGreen;
            List<string> adminInfo = blc.GetAdminInfo(selectedItem);
            label27.Text = adminInfo[0];
            label26.Text = adminInfo[1];
            label25.Text = adminInfo[2];
            label20.Text = adminInfo[3];
            label21.Text = adminInfo[4];
            label24.Text = adminInfo[5];
            label23.Text = adminInfo[6];
            label22.Text = adminInfo[7];

            if(selectedItem == "admin123")
            {
                button1.Visible = false;
                button2.Visible = false;
            }
        }

        private void ExitApp(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((label27.Text != loginUserName && loginUserName == "admin123") || (loginUserName == "admin123"))
            {
                this.Hide();
                AdminSettings obj = new AdminSettings("admin123");
                obj.Show();
            }
            else //if(label6.Text != loginUserName)
            {
                this.Hide();
                AdminSettings obj = new AdminSettings(loginUserName);
                obj.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start obj = new Start();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label27.Text == "admin123")
            {
                MessageBox.Show("Can not delete primary admin.");
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure to dlete this admin?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (label27.Text == loginUserName)
                {
                    if (result == DialogResult.Yes)
                    {
                        blc.DeleteAdmin(label27.Text);
                        this.Hide();
                        Start obj = new Start();
                        obj.Show();
                        MessageBox.Show("Admin deleted successfully.");
                    }
                }
                else
                {
                    if (result == DialogResult.Yes)
                    {
                        blc.DeleteAdmin(label27.Text);
                        this.Hide();
                        AdminSettings obj = new AdminSettings("admin123");
                        obj.Show();
                        MessageBox.Show("Admin deleted successfully.");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditAdmin gai = new EditAdmin(selectedItem, loginUserName);
            gai.Show();
        }
    }
}
