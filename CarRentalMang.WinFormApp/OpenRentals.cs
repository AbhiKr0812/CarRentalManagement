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
using System.Globalization;

namespace CarRentalMang.WinFormApp
{
    public partial class OpenRentals : Form
    {
        public OpenRentals()
        {
            InitializeComponent();
        }

        private async void OpenRentals_Load(object sender, EventArgs e)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5006/api/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("Cars");
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        List<Car> cars = JsonConvert.DeserializeObject<List<Car>>(json);
                        var cbCars = cars.Select(q => new
                        {
                            Id = q.Id,
                            Name = q.Name + " " + q.Color,
                            Availability = q.Availability
                        }).ToList();

                        var availCars = cbCars.Where(c => c.Availability == true).ToList();
                        cbAvailCars.DisplayMember = "Name";
                        cbAvailCars.ValueMember = "Id";
                        cbAvailCars.DataSource = availCars;
                        lbAvailableCars.Text = "Available Cars";
                    }
                }
                
                PopulateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        public async void PopulateGrid()
        {

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5006/api/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("Rentals/Open");
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
                    else
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        if (result.Contains("no record available"))
                            MessageBox.Show("There Is No Open Rentals Available At This Moment");
                          
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5006/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var textBoxError = CheckRequiredTextBoxes();

                if (textBoxError.Length == 0)
                {
                    var newRental = new Rental
                    {
                        CustomerName = tbCustName.Text,
                        DrivingLicenceNo = tbDLNo.Text,
                        VehicleId = (int)cbAvailCars.SelectedValue,
                        PickUpDate = ConvertIntoUTC(dtPickUp.Value.ToString()),
                        DropDate = ConvertIntoUTC(dtDrop.Value.ToString()),
                        Cost = Convert.ToDecimal(tbCost.Text),
                        CompletionStatus = false
                        //CompletionStatus = bool.Parse(tbCompletion.Text)

                    };

                    var json = JsonConvert.SerializeObject(newRental);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("Rentals/Add", content);
                    if (response.IsSuccessStatusCode)
                    {
                        //string result = await response.Content.ReadAsStringAsync();
                        //MessageBox.Show(result);
                        MessageBox.Show(
                        $"YOU HAVE ADDED: \n\r" +
                        $"Customer Name: {tbCustName.Text}\n\r" +
                        $"Customer DL NO.: {tbDLNo.Text}\n\r" +
                        $"Rented Car Type: {cbAvailCars.Text}\n\r" +
                        $"Rented Car Cost: {tbCost.Text}\n\r" +
                        $"Rented Date: {dtPickUp.Value}\n\r" +
                        $"Returned Date: {dtDrop.Value}\n\r"
                        );

                        PopulateGrid();
                    }
                    else
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        if (result.Contains("Should Be False"))
                            MessageBox.Show("Error : Completion Status Should Be False, While Adding");
                        else if (result.Contains("already occupied"))
                            MessageBox.Show($"Error : Driving License {tbDLNo.Text} Is Already Occupied With Active Rental.");
                        else
                        MessageBox.Show("Error : Server is not responding");
                    }

                }
                else
                    MessageBox.Show(textBoxError);
              
            }
            
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5006/api/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    if (tbRentalId.Text.Length == 0)
                    {
                        MessageBox.Show("Please Select A Rental");
                    }
                    else
                    {
                        var textBoxError = CheckRequiredTextBoxes();

                        if (textBoxError.Length == 0)
                        {
                            //var id = (int)gvRentals.SelectedRows[0].Cells[0].Value;
                            var id = int.Parse(tbRentalId.Text);

                            var rentalToBeUpdate = new Rental
                            {
                                CustomerName = tbCustName.Text,
                                DrivingLicenceNo = tbDLNo.Text,
                                VehicleId = int.Parse(tbCarId.Text),
                                PickUpDate = ConvertIntoUTC(dtPickUp.Value.ToString()),
                                DropDate = ConvertIntoUTC(dtDrop.Value.ToString()),
                                Cost = Convert.ToDecimal(tbCost.Text),
                            };

                            var json = JsonConvert.SerializeObject(rentalToBeUpdate);
                            var content = new StringContent(json, Encoding.UTF8, "application/json");

                            HttpResponseMessage response = await client.PutAsync($"Rentals/Update/{id}", content);
                            if (response.IsSuccessStatusCode)
                            {
                                //string result = await response.Content.ReadAsStringAsync();
                                //MessageBox.Show(result);
                                MessageBox.Show(
                                    $"YOU HAVE UPDATED: \n\r" +
                                    $"Customer Name: {tbCustName.Text}\n\r" +
                                    $"Customer DL NO.: {tbDLNo.Text}\n\r" +
                                    $"Rented Car Type: {cbAvailCars.Text}\n\r" +
                                    $"Rented Car Cost: {tbCost.Text}\n\r" +
                                    $"Rented Date: {dtPickUp.Value}\n\r" +
                                    $"Returned Date: {dtDrop.Value}\n\r"
                                    );

                                PopulateGrid();
                            }
                            else
                                MessageBox.Show("Server is not responding");
                            
                        }
                        else
                            MessageBox.Show(textBoxError);
                    }

                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        private async void gvRentals_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvRentals.Columns[e.ColumnIndex].HeaderText == "Completed")
            {
                var id = gvRentals.Rows[e.RowIndex].Cells[0].Value;
                var vehicleId = gvRentals.Rows[e.RowIndex].Cells[1].Value;
                var name = gvRentals.Rows[e.RowIndex].Cells[2].Value;
                var dlNo = gvRentals.Rows[e.RowIndex].Cells[3].Value;
                var rentedCar = gvRentals.Rows[e.RowIndex].Cells[4].Value;
                var pickUp = gvRentals.Rows[e.RowIndex].Cells[5].Value;
                var drop = gvRentals.Rows[e.RowIndex].Cells[6].Value;
                var cost = gvRentals.Rows[e.RowIndex].Cells[7].Value;


                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5006/api/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var rentalToBeApproved = new Rental
                    {

                        CustomerName = name.ToString(),
                        DrivingLicenceNo = dlNo.ToString(),
                        VehicleId = (int)vehicleId,
                        PickUpDate = ConvertIntoUTC(pickUp.ToString()),
                        DropDate = ConvertIntoUTC(drop.ToString()),
                        Cost = decimal.Parse(cost.ToString()),
                        CompletionStatus = true

                    };

                    var json = JsonConvert.SerializeObject(rentalToBeApproved);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync($"Rentals/Update/{id}", content);
                    if (response.IsSuccessStatusCode)
                    {
                        //string result = await response.Content.ReadAsStringAsync();
                        //MessageBox.Show(result);
                        MessageBox.Show("Completed Marked!!");
                        PopulateGrid();
                    }
                    else
                        MessageBox.Show("Server is not responding");
                    
                }
            }

            if (gvRentals.Columns[e.ColumnIndex].HeaderText == "Customer Name")
            {
                
                tbRentalId.Text = gvRentals.Rows[e.RowIndex].Cells[0].Value.ToString();
                tbCarId.Text = gvRentals.Rows[e.RowIndex].Cells[1].Value.ToString();
                tbCustName.Text = gvRentals.Rows[e.RowIndex].Cells[2].Value.ToString();
                tbDLNo.Text = gvRentals.Rows[e.RowIndex].Cells[3].Value.ToString();
                dtPickUp.Text = gvRentals.Rows[e.RowIndex].Cells[5].Value.ToString();
                dtDrop.Text = gvRentals.Rows[e.RowIndex].Cells[6].Value.ToString();
                tbCost.Text = gvRentals.Rows[e.RowIndex].Cells[7].Value.ToString();
                //tbCompletion.Text = gvRentals.Rows[e.RowIndex].Cells[8].Value.ToString();

                tbCustName.ReadOnly = true; tbDLNo.ReadOnly = true;
                lbAvailableCars.Text = "Rented Car";
                cbAvailCars.Enabled = false;
            }
        }

        private DateTime ConvertIntoUTC(string date)
        {
            string istDateString = date;
            DateTime istDateTime = DateTime.ParseExact(istDateString, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime utcDateTime = istDateTime.ToUniversalTime();
            return utcDateTime;
        }

        private string CheckRequiredTextBoxes()
        {
            var errorMessage = "";

            if (string.IsNullOrWhiteSpace(tbCustName.Text))
                errorMessage += "Error : Please Enter Customer Name.\n\r";
            else if (tbCustName.Text.Length < 4 || tbCustName.Text.Length > 50)
                errorMessage += "Error : Customer Name Sould Be In The Range Of 4-50 Chars.\n\r";
            if (string.IsNullOrEmpty(tbDLNo.Text))
                errorMessage += "Error : Please Enter Driving License Number.\n\r";
            else if (tbDLNo.Text.Length != 11)
                errorMessage += "Error : License Plate Number Should Be 11-Characters Long.\n\r";

            if (dtPickUp.Value >= dtDrop.Value)
                errorMessage += "Error : Drop Date/Time Should Be Greater Than PickUp Date/Time.\n\r";
            else if (dtDrop.Value - dtPickUp.Value < TimeSpan.FromHours(2))
                errorMessage += "Error : Minimum Duration of a car to be rented is 2 hours.\n\r";
            else if (dtDrop.Value - dtPickUp.Value > TimeSpan.FromHours(72))
                errorMessage += "Error : A Car can not be rented for more than 72 hours.\n\r";

            if (string.IsNullOrEmpty(tbCost.Text))
                errorMessage += "Error : Please Enter Cost";
            return errorMessage;
        }
    
        private async void bynReset_Click(object sender, EventArgs e)
        {
            if(tbCustName.ReadOnly == true)
                tbCustName.ReadOnly = false;
            if (tbDLNo.ReadOnly == true)
                tbDLNo.ReadOnly = false;
            lbAvailableCars.Text = "Available Cars";
            cbAvailCars.Enabled = true;

            tbRentalId.Clear();
            tbCustName.Clear();
            tbDLNo.Clear();
            dtPickUp.Text = DateTime.Now.ToString();
            dtDrop.Text = DateTime.Now.ToString();
            tbCost.Clear();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5006/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("Cars");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Car> cars = JsonConvert.DeserializeObject<List<Car>>(json);
                    var cbCars = cars.Select(q => new
                    {
                        Id = q.Id,
                        Name = q.Name + " " + q.Color,
                        Availability = q.Availability
                    }).ToList();

                    var availCars = cbCars.Where(c => c.Availability == true).ToList();
                    cbAvailCars.DisplayMember = "Name";
                    cbAvailCars.ValueMember = "Id";
                    cbAvailCars.DataSource = availCars;
                }
            }

            PopulateGrid();

        }

        private void btnClosedRentals_Click(object sender, EventArgs e)
        {
            var rentals = new ClosedRentals();
            rentals.ShowDialog();
            rentals.MdiParent = this.MdiParent;
        }

        private void tbCustName_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (Char.IsLetter(ch))
                e.Handled = false;

            else if (ch == 32)        // Spacebar
                e.Handled = false;

            else if (ch == 8)        // Backspace
                e.Handled = false;
 
            else if(ch == 46)       // Delete
                e.Handled = false;

            else if (ch == 12)      // Clear
                e.Handled = false;
            else { e.Handled = true; }
        }

        private void tbDLNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (Char.IsLetterOrDigit(ch))
                e.Handled = false;

            else if (ch == 8)        // Backspace
                e.Handled = false;

            else if (ch == 46)       // Delete
                e.Handled = false;

            else if (ch == 12)      // Clear
                e.Handled = false;
            else { e.Handled = true; }
        }

        private void tbCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (Char.IsDigit(ch))
                e.Handled = false;

            else if (ch == 110)        // Decimal
                e.Handled = false;

            else if (ch == 8)        // Backspace
                e.Handled = false;

            else if (ch == 46)       // Delete
                e.Handled = false;

            else if (ch == 12)      // Clear
                e.Handled = false;
            else { e.Handled = true; }
        }


        //private void gvRentals_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    tbCustName.Text = gvRentals.SelectedRows[0].Cells[1].Value.ToString();
        //    tbDLNo.Text = gvRentals.SelectedRows[0].Cells[2].Value.ToString();
        //    cbAvailCars.Text = gvRentals.SelectedRows[0].Cells[3].Value.ToString();
        //    dtPickUp.Text = gvRentals.SelectedRows[0].Cells[4].Value.ToString();
        //    dtDrop.Text = gvRentals.SelectedRows[0].Cells[5].Value.ToString();
        //    tbCost.Text = gvRentals.SelectedRows[0].Cells[6].Value.ToString();
        //    tbCompletion.Text = gvRentals.SelectedRows[0].Cells[7].Value.ToString();

        //}
    }
}
