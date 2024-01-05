﻿using System.ComponentModel.DataAnnotations;

namespace CarRentalManagement.Api.Models.Domain
{
    public class CarRentalRecord
    {
        [Key]
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string DrivingLicenceNo { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropDate { get; set; }
        public decimal Cost { get; set; }
        public bool CompletionStatus { get; set; } = false;
        public int VehicleId { get; set; }

        //Navigation properties
        public Car Vehicle { get; set; }
    }
}
