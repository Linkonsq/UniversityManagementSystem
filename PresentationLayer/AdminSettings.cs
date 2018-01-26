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
    public partial class AdminSettings : Form
    {
        AdminBusinessLogic blc = new AdminBusinessLogic();

        string loginUserName;

        public AdminSettings()
        {
            InitializeComponent();
            FillListBox();
            button1.BackColor = Color.LightSeaGreen;
            button2.BackColor = Color.LightSeaGreen;
            button3.BackColor = Color.LightSeaGreen;
            button4.BackColor = Color.LightSeaGreen;
            button5.BackColor = Color.LightSeaGreen;
        }

        public AdminSettings(string loginUserName)
        {
            this.loginUserName = loginUserName;
            InitializeComponent();
            FillListBox();
            button1.BackColor = Color.LightSeaGreen;
            button2.BackColor = Color.LightSeaGreen;
            button3.BackColor = Color.LightSeaGreen;
            button4.BackColor = Color.LightSeaGreen;
            button5.BackColor = Color.LightSeaGreen;
        }

        private void FillListBox()
        {
            //listBox1.DataSource = blc.GetAdminList().ToList();

            listBox1.DataSource = blc.GetAdminLst();

            //listBox1.SelectedIndex = -1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPage obj = new AdminPage(loginUserName);
            obj.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start obj = new Start();
            obj.Show();
        }

        private void ExitApp(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddAdmin obj = new AddAdmin(loginUserName);
            obj.Show();
        }

        private void ItemSelected(object sender, MouseEventArgs e)
        {
            string selectedItem = listBox1.SelectedItem.ToString();

            if (loginUserName == "admin123" || selectedItem == loginUserName)
            {
                this.Hide();
                AdminInfo obj = new AdminInfo(selectedItem, loginUserName);
                obj.Show();
            }
            else
            {
                MessageBox.Show("Can't show other admin information");
            }

            //if ((loginUserName != "root" && listBox1.SelectedItem.ToString() == "root") || (loginUserName != "root" && listBox1.SelectedItem.ToString() != loginUserName))
            //{
            //    MessageBox.Show("Can not show other admin information.");
            //}
            //else
            //{
            //    this.Hide();
            //    AdminInfo obj = new AdminInfo(selectedItem, loginUserName);
            //    obj.Show();
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            OfferCourse oc = new OfferCourse(this.loginUserName);
            oc.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            OfferedCourses ocrses = new OfferedCourses(this.loginUserName);
            ocrses.Show();
        }
    }
}
