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
    public partial class OfferedCourses : Form
    {
        FacultyBusinessLogic fba = new FacultyBusinessLogic();

        string loginUserName;

        public OfferedCourses()
        {
            InitializeComponent();
        }

        public OfferedCourses(string loginUserName)
        {
            this.loginUserName = loginUserName;
            InitializeComponent();
            FillDataGridview();
            button1.BackColor = Color.LightSeaGreen;
            button4.BackColor = Color.LightSeaGreen;
            AutoScroll = true;
        }

        private void FillDataGridview()
        {
            dataGridView1.DataSource = fba.GetCSCourseTableData();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView2.DataSource = fba.GetEEECourseTableData();
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView3.DataSource = fba.GetBBACourseTableData();
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminSettings ads = new AdminSettings(this.loginUserName);
            ads.Show();
        }

        private void ExitApp(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start st = new Start();
            st.Show();
        }
    }
}
