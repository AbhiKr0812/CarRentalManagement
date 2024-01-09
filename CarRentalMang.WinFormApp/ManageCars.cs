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
using System.Xml.Linq;

namespace CarRentalMang.WinFormApp
{
    public partial class ManageCars : Form
    {
        public ManageCars()
        {
            InitializeComponent();
        }

        private void ManageCars_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        public async void PopulateGrid()
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
                    gvCars.DataSource = cars;
                    gvCars.Columns[0].Visible = false;
                    gvCars.Columns[3].HeaderText = "License Plate Number";
                }
            }

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5006/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var newCar = new Car
                {
                    Name = tbCarName.Text,
                    Color = tbCarColor.Text,
                    Make = tbCarBrand.Text,
                    LicensePlateNumber = tbCarNo.Text,
                    Availability = bool.Parse(tbAvailability.Text)

                };
                var errorMsg = ValidateUserInput(newCar);
                if (errorMsg.Length == 0)
                {
                    var json = JsonConvert.SerializeObject(newCar);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("Cars", content);
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        MessageBox.Show(result);
                    }
                }
                else
                    MessageBox.Show($"Error: {errorMsg}");

            }
            PopulateGrid();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5006/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var id = (int)gvCars.SelectedRows[0].Cells[0].Value;
                

                var carToBeUpdate = new Car
                {
                    Name = tbCarName.Text,
                    Color = tbCarColor.Text,
                    Make = tbCarBrand.Text,
                    LicensePlateNumber = tbCarNo.Text,
                    Availability = bool.Parse(tbAvailability.Text)
                };

                var errorMsg = ValidateUserInput(carToBeUpdate);
                if (errorMsg.Length == 0)
                {
                    var json = JsonConvert.SerializeObject(carToBeUpdate);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync($"Cars/{id}", content);
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        MessageBox.Show(result);
                    }
                }
                else
                    MessageBox.Show($"Error: {errorMsg}");

            }
            PopulateGrid();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5006/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var id = (int)gvCars.SelectedRows[0].Cells[0].Value;

                HttpResponseMessage response = await client.DeleteAsync($"Cars/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(result);

                }
                else
                    MessageBox.Show(await response.Content.ReadAsStringAsync());   

            }
            PopulateGrid();

        }

        private void gvCars_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            tbCarName.Text = gvCars.SelectedRows[0].Cells[1].Value.ToString();
            tbCarColor.Text = gvCars.SelectedRows[0].Cells[2].Value.ToString();
            tbCarNo.Text = gvCars.SelectedRows[0].Cells[3].Value.ToString();
            tbCarBrand.Text = gvCars.SelectedRows[0].Cells[4].Value.ToString();
            tbAvailability.Text = gvCars.SelectedRows[0].Cells[5].Value.ToString();
        }

        private string ValidateUserInput(Car car)
        {

            var errorMessage = "";

            if (string.IsNullOrWhiteSpace(car.Name))
                errorMessage += "Error : Please Enter Name.\n\r";

            if (car.Name.Length < 4)
                errorMessage += "Error : Car Name Sould Be Minimum Of 4-Chars Long";

            if (car.Name.Length > 50)
                errorMessage += "Error : Car Name Sould Be Maximium Of 50-Chars Long";

            if (string.IsNullOrWhiteSpace(car.Color))
                errorMessage += "Error : Please Enter Color.\n\r";

            if (string.IsNullOrWhiteSpace(car.LicensePlateNumber))
                errorMessage += "Error : Please Enter License Plate Number.\n\r";

            if ((car.LicensePlateNumber).Length != 10)
                errorMessage += "Error : License Plate Number Should Be 8-Characters Long.\n\r";

            if (string.IsNullOrWhiteSpace(car.Make))
                errorMessage += "Error : Please Enter Make Name.\n\r";

            //if (!car.Availability )
            //    errorMessage += "Error : Car Should Be Available While Adding.\n\r";

            return errorMessage;
        }

    }
}
