using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using System.Linq;


namespace CarRentalMang.WinFormApp
{
    public partial class ManageCars : Form
    {
        public ManageCars()
        {
            InitializeComponent();
        }

        private async void ManageCars_Load(object sender, EventArgs e)
        {
            cbCarColor.SelectedIndex = 0;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5006/api/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("CarMakes");
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        List<CarMake> carMakes = JsonConvert.DeserializeObject<List<CarMake>>(json);
                       
                        cbCarMake.DisplayMember = "Name";
                        cbCarMake.ValueMember = "MakeId";
                        cbCarMake.DataSource = carMakes;
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

                    HttpResponseMessage response = await client.GetAsync("Cars");
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        List<Car> cars = JsonConvert.DeserializeObject<List<Car>>(json);
                        gvCars.DataSource = cars;
                        gvCars.Columns[0].Visible = false;
                        gvCars.Columns[4].HeaderText = "License Plate Number";

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

                    var makeId = (int)cbCarMake.SelectedValue;
                    var modelId = (int)cbCarModel.SelectedValue;

                    var newCar = new CarPost
                    {                     
                        Color = cbCarColor.Text,
                        LicensePlateNumber = tbCarNo.Text,
                        Availability = true
                    };
                    var errorMsg = ValidateUserInput(newCar);
                    if (errorMsg.Length == 0)
                    {
                        var json = JsonConvert.SerializeObject(newCar);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");

                        HttpResponseMessage response = await client.PostAsync($"Cars/{makeId}/{modelId}", content);
                        if (response.IsSuccessStatusCode)
                        {
                            //string result = await response.Content.ReadAsStringAsync();
                            //MessageBox.Show(result);
                            MessageBox.Show(
                               $"YOU HAVE ADDED : \n\r" +
                               $"Make : {cbCarMake.Text}\n\r" +
                               $"Model : {cbCarModel.Text}\n\r" +
                               $"Color : {cbCarColor.Text}\n\r" +
                               $"LplateNo.: {tbCarNo.Text}\n\r"

                              );
                        }
                        else
                        {
                            string result = await response.Content.ReadAsStringAsync();
                            if (result.Contains("Already Exist"))
                                MessageBox.Show($"Car With License Plate No. : {tbCarNo.Text}  Already Exist");
                            else if (result.Contains("Model Limit exceeded"))
                                MessageBox.Show("Model Limit exceeded : For a model, maximum 3 car of same color is allowed");
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

                        var carToBeUpdate = new CarPost
                        { 
                            Color = cbCarColor.Text,
                            LicensePlateNumber = tbCarNo.Text,
                            Availability = bool.Parse(gvCars.SelectedRows[0].Cells[5].Value.ToString())  
                        };

                        var json = JsonConvert.SerializeObject(carToBeUpdate);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");

                        HttpResponseMessage response = await client.PutAsync($"Cars/Update/{id}", content);
                        if (response.IsSuccessStatusCode)
                        {
                            //string result = await response.Content.ReadAsStringAsync();
                            //MessageBox.Show(result);
                            MessageBox.Show(
                               $"YOU HAVE UPDATED : \n\r" +
                               $"Make : {cbCarMake.Text}\n\r" +
                               $"Model : {cbCarModel.Text}\n\r" +
                               $"Color : {cbCarColor.Text}\n\r" +
                               $"LplateNo.: {tbCarNo.Text}\n\r"

                              );
                            PopulateGrid();
                        }
                        else
                            MessageBox.Show(await response.Content.ReadAsStringAsync());
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

        private  void cbCarMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCarMake.SelectedValue.ToString() != null)
            {
                var makeId = Convert.ToInt32(cbCarMake.SelectedValue.ToString());
                LoadMakeModels(makeId);
            }
                
        }

        private async void LoadMakeModels(int makeId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5006/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync($"CarMakes/{makeId}/models");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<CarModel> carModels = JsonConvert.DeserializeObject<List<CarModel>>(json);

                    var cbCarModels = carModels.Select(m => new
                    {
                        ModelId = m.ModelId,
                        m.Name,
                        m.IsAvailable
                    }).ToList();

                    var availModles = cbCarModels.Where(m => m.IsAvailable == true).ToList();

                    cbCarModel.DisplayMember = "Name";
                    cbCarModel.ValueMember = "ModelId";
                    cbCarModel.DataSource = availModles;
                    
                }
            }
        }
        private void gvCars_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //tbCarId.Text = gvCars.SelectedRows[0].Cells[0].Value.ToString();
            cbCarMake.Text = gvCars.SelectedRows[0].Cells[1].Value.ToString();
            cbCarModel.Text = gvCars.SelectedRows[0].Cells[2].Value.ToString();
            cbCarColor.Text = gvCars.SelectedRows[0].Cells[3].Value.ToString();
            tbCarNo.Text = gvCars.SelectedRows[0].Cells[4].Value.ToString();
        }

        private string ValidateUserInput(CarPost car)
        {

            var errorMessage = "";

            if (string.IsNullOrWhiteSpace(car.Color))
                errorMessage += "Error : Please Enter Color.\n\r";

            if (string.IsNullOrWhiteSpace(car.LicensePlateNumber))
                errorMessage += "Error : Please Enter License Plate Number.\n\r";

            if ((car.LicensePlateNumber).Length != 10)
                errorMessage += "Error : License Plate Number Should Be 10-Characters Long.\n\r";

            return errorMessage;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cbCarMake.SelectedIndex = 0;
            cbCarModel.SelectedIndex = 0;
            cbCarColor.SelectedIndex = 0;
            tbCarNo.Clear();

            PopulateGrid();
        }

       
    }
}
