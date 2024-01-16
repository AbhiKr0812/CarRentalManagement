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

                        try
                        {
                            gvRentals.Columns[4].DefaultCellStyle.Format = "dd-MM-yyyy HH:mm:ss";
                            gvRentals.Columns[5].DefaultCellStyle.Format = "dd-MM-yyyy HH:mm:ss";

                            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                            foreach (DataGridViewRow row in gvRentals.Rows)
                            {
                                DateTime pickUpDate = (DateTime)row.Cells[4].Value;
                                DateTime convertedPickUpDate = TimeZoneInfo.ConvertTimeFromUtc(pickUpDate, timeZoneInfo);
                                row.Cells[4].Value = convertedPickUpDate.ToString("dd-MM-yyyy HH:mm:ss");

                                DateTime dropDate = (DateTime)row.Cells[5].Value;
                                DateTime convertedDropDate = TimeZoneInfo.ConvertTimeFromUtc(dropDate, timeZoneInfo);
                                row.Cells[5].Value = convertedDropDate.ToString("dd-MM-yyyy HH:mm:ss");
                            }
                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }

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

                var newRental = new Rental
                {
                    CustomerName = tbCustName.Text,
                    DrivingLicenceNo = tbDLNo.Text,
                    VehicleId = (int)cbAvailCars.SelectedValue,
                    PickUpDate = ConvertIntoUTC(dtPickUp.Value.ToString()),
                    DropDate = ConvertIntoUTC(dtDrop.Value.ToString()),
                    Cost = Convert.ToDecimal(tbCost.Text),
                    CompletionStatus = false

                };

                var errorMsg = ValidateUserInput(newRental);

                if (errorMsg.Length == 0)
                {
                    var json = JsonConvert.SerializeObject(newRental);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("Rentals", content);
                    if (response.IsSuccessStatusCode)
                    {
                        //string result = await response.Content.ReadAsStringAsync();
                        //MessageBox.Show(result);
                        MessageBox.Show(
                        $"YOU HAVE ADDED: \n\r"+
                        $"Customer Name: {tbCustName.Text}\n\r" +
                        $"Customer DL NO.: {tbDLNo.Text}\n\r" +
                        $"Rented Car Type: {cbAvailCars.Text}\n\r" +
                        $"Rented Car Cost: {tbCost.Text}\n\r" +
                        $"Rented Date: {dtPickUp.Value}\n\r" +
                        $"Returned Date: {dtDrop.Value}\n\r"
                        );
                    } 
                }
                else 
                    MessageBox.Show($"Error: {errorMsg}");
            }
            PopulateGrid();
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

                    //var id = (int)gvRentals.SelectedRows[0].Cells[0].Value;
                    var id = int.Parse(tbRentalId.Text);

                    var rentalToBeUpdate = new Rental
                    {
                        CustomerName = tbCustName.Text,
                        DrivingLicenceNo = tbDLNo.Text,
                        VehicleId = int.Parse(cbAvailCars.Text),
                        PickUpDate = ConvertIntoUTC(dtPickUp.Value.ToString()),
                        DropDate = ConvertIntoUTC(dtDrop.Value.ToString()),
                        Cost = Convert.ToDecimal(tbCost.Text),
                        CompletionStatus = bool.Parse(tbCompletion.Text)
                    };

                    var errorMsg = ValidateUserInput(rentalToBeUpdate);

                    if (errorMsg.Length == 0)
                    {
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

                        } 
                    }
                    else
                        MessageBox.Show($"Error: {errorMsg}");

                }
                PopulateGrid();
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
                var name = gvRentals.Rows[e.RowIndex].Cells[1].Value;
                var dlNo = gvRentals.Rows[e.RowIndex].Cells[2].Value;
                var rentedCar = gvRentals.Rows[e.RowIndex].Cells[3].Value;
                var pickUp = gvRentals.Rows[e.RowIndex].Cells[4].Value;
                var drop = gvRentals.Rows[e.RowIndex].Cells[5].Value;
                var cost = gvRentals.Rows[e.RowIndex].Cells[6].Value;


                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5006/api/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var rentalToBeApproved = new Rental
                    {

                        CustomerName = name.ToString(),
                        DrivingLicenceNo = dlNo.ToString(),
                        VehicleId = (int)rentedCar,
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
                        string result = await response.Content.ReadAsStringAsync();
                        MessageBox.Show(result);
                    }
                    else
                        MessageBox.Show(await response.Content.ReadAsStringAsync());
                    PopulateGrid();
                }
            }

            if (gvRentals.Columns[e.ColumnIndex].HeaderText == "Customer Name")
            {
                tbRentalId.Text = gvRentals.Rows[e.RowIndex].Cells[0].Value.ToString();
                tbCustName.Text = gvRentals.Rows[e.RowIndex].Cells[1].Value.ToString();
                tbDLNo.Text = gvRentals.Rows[e.RowIndex].Cells[2].Value.ToString();
                cbAvailCars.Text = gvRentals.Rows[e.RowIndex].Cells[3].Value.ToString();
                dtPickUp.Text = gvRentals.Rows[e.RowIndex].Cells[4].Value.ToString();
                dtDrop.Text = gvRentals.Rows[e.RowIndex].Cells[5].Value.ToString();
                tbCost.Text = gvRentals.Rows[e.RowIndex].Cells[6].Value.ToString();
                tbCompletion.Text = gvRentals.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
        }

        private DateTime ConvertIntoUTC(string date)
        {
            string istDateString = date;
            DateTime istDateTime = DateTime.ParseExact(istDateString, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime utcDateTime = istDateTime.ToUniversalTime();
            return utcDateTime;
        }

        private string ValidateUserInput(Rental rental)
        {

            var errorMessage = "";

            if (string.IsNullOrWhiteSpace(rental.CustomerName))
                errorMessage += "Error : Please Enter Customer Name.\n\r";

            if (string.IsNullOrWhiteSpace(rental.DrivingLicenceNo))
                errorMessage += "Error : Please Enter Driving License Number.\n\r";

            if ((rental.DrivingLicenceNo).Length != 11)
                errorMessage += "Error : License Plate Number Should Be 11-Characters Long.\n\r";

            if ((rental.VehicleId) == 0)
                errorMessage += "Error : Please Select A Available Car";

            if (rental.PickUpDate >= rental.DropDate)           
                errorMessage += "Error : Drop Date/Time Should Be Greater Than PickUp Date/Time.\n\r";
            //else if (rental.DropDate - rental.PickUpDate < TimeSpan.FromHours(8))
            //    errorMessage += "Error : Minimum Duration of a car to be rented is 8 hours.\n\r";

            if (rental.Cost == 0)
                errorMessage += "Error : Please Enter Cost";

            //if (!rental.CompletionStatus)
            //    errorMessage += "Error : Do Not Mark Completion While Adding.\n\r";

            return errorMessage;
        }

        private async void bynReset_Click(object sender, EventArgs e)
        {
            tbRentalId.Clear();
            tbCustName.Clear();
            tbDLNo.Clear();
            tbCompletion.Text = false.ToString();
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
                        q.Id,
                        q.Name,
                        q.Availability
                    }).ToList();

                    var availCars = cars.Where(c => c.Availability == true).ToList();
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
