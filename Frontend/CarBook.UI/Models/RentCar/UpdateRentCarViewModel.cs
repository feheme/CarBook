﻿namespace CarBook.UI.Models.RentCar
{
    public class UpdateRentCarViewModel
    {
        public int RentCarID { get; set; }
        public string? Name { get; set; }    
        public string? Mail { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Car { get; set; }
        public string? PickUpLocation { get; set; }
        public string? DropOffLocation { get; set; }
        public DateTime? PickUpDate { get; set; }
        public DateTime? DropOffDate { get; set; }
     
      
    }
}
