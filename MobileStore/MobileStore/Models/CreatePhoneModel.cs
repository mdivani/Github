using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileStore.Models
{
    public class CreatePhoneModel
    {
       public  CreatePhoneModel() {
            ImageUrl = new string[3];
        }
        public string PhoneName { get; set; }
        public string Model { get; set; }
        public string Resolution { get; set; }
        public string GPU { get; set; }
        public string CPU { get; set; }
        public string MainCamera { get; set; }
        public string OS { get; set; }
        public string SecondaryCamera { get; set; }
        public string BatteryCapacity { get; set; }
        public DateTime? RealseDate { get; set; }
        public decimal? Price { get; set; }
        public int? OEMID { get; set; }
        public string[] ImageUrl { get; set; }
    }
}