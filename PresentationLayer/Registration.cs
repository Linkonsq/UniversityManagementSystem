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
    public partial class Registration : Form
    {
        CourseBusinessLogic cbl = new CourseBusinessLogic();

        string loginUserName, department;

        public Registration()
        {
            InitializeComponent();
            FillDataGridview();
        }

        public Registration(string loginUserName, string department)
        {
            this.loginUserName = loginUserName;
            this.department = department;
            InitializeComponent();
            FillDataGridview();
            button1.BackColor = Color.LightSeaGreen;
            button2.BackColor = Color.LightSeaGreen;
            button4.BackColor = Color.LightSeaGreen;
        }

        private void FillDataGridview()
        {
            DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn();
            check.HeaderText = "Select";
            check.Name = "CheckBox";
            dataGridView1.Columns.Add(check);

            if (this.department == "CS")
            {
                dataGridView1.DataSource = cbl.GetCSTableData();

                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(item.Cells[0].Value))
                    {
                        int n = dataGridView2.Rows.Add();
                        dataGridView2.Rows[n].Cells[0].Value = item.Cells[1].Value.ToString();
                        dataGridView2.Rows[n].Cells[1].Value = item.Cells[2].Value.ToString();
                        dataGridView2.Rows[n].Cells[2].Value = item.Cells[3].Value.ToString();
                        dataGridView2.Rows[n].Cells[3].Value = item.Cells[4].Value.ToString();
                    }
                }
            }
            else if(this.department == "EEE")
            {
                dataGridView1.DataSource = cbl.GetEEETableData();
            }
            else if(this.department == "BBA")
            {
                dataGridView1.DataSource = cbl.GetBBATableData();
            }

            //dataGridView1.AutoResizeColumns();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();

            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(item.Cells[0].Value))
                {
                    int n = dataGridView2.Rows.Add();
                    dataGridView2.Rows[n].Cells[0].Value = item.Cells[1].Value.ToString();
                    dataGridView2.Rows[n].Cells[1].Value = item.Cells[2].Value.ToString();
                    dataGridView2.Rows[n].Cells[2].Value = item.Cells[3].Value.ToString();
                    dataGridView2.Rows[n].Cells[3].Value = item.Cells[4].Value.ToString();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(item.Cells[0].Value))
                {
                    int n = dataGridView2.Rows.Add();
                    dataGridView2.Rows[n].Cells[0].Value = item.Cells[1].Value.ToString();
                    dataGridView2.Rows[n].Cells[1].Value = item.Cells[2].Value.ToString();
                    dataGridView2.Rows[n].Cells[2].Value = item.Cells[3].Value.ToString();
                    dataGridView2.Rows[n].Cells[3].Value = item.Cells[4].Value.ToString();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentPage sp = new StudentPage(this.loginUserName, this.department);
            sp.Show();
        }
    }
}
