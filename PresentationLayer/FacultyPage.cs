﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class FacultyPage : Form
    {
        string loginUserName, department;

        public FacultyPage()
        {
            InitializeComponent();
        }

        public FacultyPage(string loginUserName, string department)
        {
            this.loginUserName = loginUserName;
            this.department = department;
            InitializeComponent();
            button1.BackColor = Color.LightSeaGreen;
            button2.BackColor = Color.LightSeaGreen;
            button4.BackColor = Color.LightSeaGreen;
        }

        private void ExitApp(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start obj = new Start();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangePassword cp = new ChangePassword(loginUserName, department);
            cp.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FacultyInfo fi = new FacultyInfo(loginUserName, department);
            fi.Show();
        }
    }
}
