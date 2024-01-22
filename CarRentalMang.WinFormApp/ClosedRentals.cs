using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalMang.WinFormApp
{
    public partial class ClosedRentals : Form
    {
        public ClosedRentals()
        {
            InitializeComponent();
        }

        private void ClosedRentals_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateGrid();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private async void PopulateGrid()
        {

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5006/api/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("Rentals/Closed");
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        List<Rental> rentals = JsonConvert.DeserializeObject<List<Rental>>(json);

                        gvRentals.DataSource = rentals;

                        gvRentals.Columns[5].DefaultCellStyle.Format = "dd-MM-yyyy HH:mm:ss";
                        gvRentals.Columns[6].DefaultCellStyle.Format = "dd-MM-yyyy HH:mm:ss";

                        TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                        foreach (DataGridViewRow row in gvRentals.Rows)
                        {
                            DateTime pickUpDate = (DateTime)row.Cells[5].Value;
                            DateTime convertedPickUpDate = TimeZoneInfo.ConvertTimeFromUtc(pickUpDate, timeZoneInfo);
                            row.Cells[5].Value = convertedPickUpDate.ToString("dd-MM-yyyy HH:mm:ss");

                            DateTime dropDate = (DateTime)row.Cells[6].Value;
                            DateTime convertedDropDate = TimeZoneInfo.ConvertTimeFromUtc(dropDate, timeZoneInfo);
                            row.Cells[6].Value = convertedDropDate.ToString("dd-MM-yyyy HH:mm:ss");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
           
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5006/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (gvRentals.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please Select A Rental");
                }
                else
                {
                    var id = (int)gvRentals.SelectedRows[0].Cells[0].Value;

                    DialogResult dr = MessageBox.Show("Are You Sure Want To Delete This Record?",
                            "Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                    if (dr == DialogResult.Yes)
                    {
                        HttpResponseMessage response = await client.DeleteAsync($"Rentals/{id}");
                        if (response.IsSuccessStatusCode)
                        {
                            //string result = await response.Content.ReadAsStringAsync();
                            //MessageBox.Show(result);
                            MessageBox.Show("Deleted Successfully!");
                            PopulateGrid();
                        }
                        else
                            MessageBox.Show("Server is not responding");
                    }                  
                }

            }

        }

        private void btnOpenRentals_Click(object sender, EventArgs e)
        {
            var rentals = new OpenRentals();
            rentals.ShowDialog();
            rentals.MdiParent = this.MdiParent;
        }

        
    }
}
