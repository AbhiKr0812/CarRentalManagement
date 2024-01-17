using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;


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
                        gvCars.DataSource = cars;
                        //gvCars.Columns[0].Visible = false;
                        gvCars.Columns[3].HeaderText = "License Plate Number";

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
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

                        HttpResponseMessage response = await client.PostAsync("Cars/Add", content);
                        if (response.IsSuccessStatusCode)
                        {
                            //string result = await response.Content.ReadAsStringAsync();
                            //MessageBox.Show(result);
                            MessageBox.Show(
                               $"YOU HAVE ADDED : \n\r" +
                               $"Name : {tbCarName.Text}\n\r" +
                               $"Color : {tbCarColor.Text}\n\r" +
                               $"Make : {tbCarBrand.Text}\n\r" +
                               $"LplateNo.: {tbCarNo.Text}\n\r" +
                               $"Availability : {tbAvailability.Text}\n\r"

                              );
                        }
                        else
                        {
                            string result = await response.Content.ReadAsStringAsync();
                            if (result.Contains("Already Exist"))
                                MessageBox.Show($"Car With License Plate No. : {tbCarNo.Text}  Already Exist");
                            else if (result.Contains("Car Availability Should Be True"))
                                MessageBox.Show("Car Availability Should Be True,While Adding");
                            else 
                            MessageBox.Show("Server Is Not Responding");
                        }

                    }
                    else
                        MessageBox.Show(errorMsg);

                }
                PopulateGrid();
            }
            catch (Exception ex)
            {

                throw ex;
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

                    if (gvCars.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Please Select A Car");
                    }
                    else
                    {
                        //var id = int.Parse(tbCarId.Text);
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

                            HttpResponseMessage response = await client.PutAsync($"Cars/Update/{id}", content);
                            if (response.IsSuccessStatusCode)
                            {
                                //string result = await response.Content.ReadAsStringAsync();
                                //MessageBox.Show(result);
                                MessageBox.Show(
                                   $"YOU HAVE UPDATED : \n\r" +
                                   $"Name : {tbCarName.Text}\n\r" +
                                   $"Color : {tbCarColor.Text}\n\r" +
                                   $"Make : {tbCarBrand.Text}\n\r" +
                                   $"LplateNo.: {tbCarNo.Text}\n\r" +
                                   $"Availability : {tbAvailability.Text}\n\r"

                                  );
                                PopulateGrid();
                            }
                            else
                                MessageBox.Show(await response.Content.ReadAsStringAsync());
                        }
                        else
                            MessageBox.Show($"Error: {errorMsg}");
                    }


                }
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5006/api/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    if (gvCars.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Please Select A Car");
                    }
                    else
                    {
                        var id = (int)gvCars.SelectedRows[0].Cells[0].Value;

                        DialogResult dr = MessageBox.Show("Are You Sure Want To Delete This Record?",
                            "Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                        if (dr == DialogResult.Yes)
                        {
                            HttpResponseMessage response = await client.DeleteAsync($"Cars/Delete/{id}");
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
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void gvCars_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //tbCarId.Text = gvCars.SelectedRows[0].Cells[0].Value.ToString();
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

            if (car.Name.Length < 4 || car.Name.Length > 50)
                errorMessage += "Error : Car Name Sould Be In The Range Of 4-50 Chars.\n\r";

            if (string.IsNullOrWhiteSpace(car.Color))
                errorMessage += "Error : Please Enter Color.\n\r";

            if (car.Color.Length < 3 || car.Color.Length > 50)
                errorMessage += "Error : Car Color Sould Be In The Range Of 3-15 Chars.\n\r";

            if (string.IsNullOrWhiteSpace(car.LicensePlateNumber))
                errorMessage += "Error : Please Enter License Plate Number.\n\r";

            if ((car.LicensePlateNumber).Length != 10)
                errorMessage += "Error : License Plate Number Should Be 10-Characters Long.\n\r";

            if (string.IsNullOrWhiteSpace(car.Make))
                errorMessage += "Error : Please Enter Make Name.\n\r";

            if (car.Make.Length < 4 || car.Make.Length > 24)
                errorMessage += "Error : Car Make Sould Be In The Range Of 4-24 Chars.\n\r";

            return errorMessage;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tbCarName.Clear();
            tbCarColor.Clear();
            tbCarNo.Clear();
            tbCarBrand.Clear();

            PopulateGrid();
        }
    }
}
