using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalMang.WinFormApp
{
    internal class Rental
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public string CustomerName { get; set; }
        public string DrivingLicenceNo { get; set; }
        public string CarName { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropDate { get; set; }
        public decimal Cost { get; set; }
        public bool CompletionStatus { get; set; }
        
    }
}
