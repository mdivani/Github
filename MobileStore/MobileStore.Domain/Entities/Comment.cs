using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Domain.Entities
{
    public class Comment {
        [Key, Required]
        public int ID { get; set; }
        [Required]
        public string text { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public virtual User User { get; set; }
        public virtual Article Article { get; set; }
    }
}
