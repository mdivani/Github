using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Domain.Entities
{
   public class Manufacturer
    {
        public Manufacturer() {
            Phones = new List<Phone>();
        }
        [Key, Required]
        public int ID { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Country { get; set; }

        public ICollection<Phone> Phones { get; set; }
    }
}
