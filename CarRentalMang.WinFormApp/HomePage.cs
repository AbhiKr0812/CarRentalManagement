﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalMang.WinFormApp
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void manageCarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cars = new ManageCars();
            cars.ShowDialog();
            cars.MdiParent = this;
        }
    }
}
