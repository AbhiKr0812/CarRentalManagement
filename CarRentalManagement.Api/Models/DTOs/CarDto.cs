﻿using System.ComponentModel.DataAnnotations;

namespace CarRentalManagement.Api.Models.DTOs
{
    public class CarDto
    {
        
        public int Id { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public string LicensePlateNumber { get; set; }

        public string Make { get; set; }

        public bool Availability { get; set; }
    }
}
