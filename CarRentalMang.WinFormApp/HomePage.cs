using System;
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

        private void openRentalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rentals = new OpenRentals();
            rentals.ShowDialog();
            rentals.MdiParent = this;
        }

        private void closedRentalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rentals = new ClosedRentals();
            rentals.ShowDialog();
            rentals.MdiParent = this;
        }
    }
}
