using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Domain.Entities
{
   public class Phone : Article {

        public Phone()
        {
            ImageUrl = new string[3];
        }

        [Required, MaxLength(20)]
        public string PhoneName { get; set; }
        [MaxLength(10)]
        public string Model { get; set; }
        [MaxLength(100)]
        public string Resolution { get; set; }
        [MaxLength(230)]
        public string OS { get; set; }
        [MaxLength(200)]
        public string CPU { get; set; }
        [MaxLength(200)]
        public string GPU { get; set; }
        [MaxLength(250)]
        public string MainCamera { get; set; }
        [MaxLength(250)]
        public string SecondaryCamera { get; set; }
        [MaxLength(200)]
        public string BatteryCapacity { get; set; }
        [Column("ReleaseDate", TypeName = "date")]
        public DateTime? ReleaseDate { get; set; }
        public decimal? Price { get; set; }
        public int? RatingTotal { get; set; }
        public int? VotesTotal { get; set; }
        public int? OEMID { get; set; }

        [Required]
        public virtual Manufacturer Manufacturer { get; set; }
    }
}
