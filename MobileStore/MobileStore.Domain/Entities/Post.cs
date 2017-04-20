using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Domain.Entities
{
   public class Post : Article {

        public Post()
        {
            ImageUrl = new string[1];
        }

        [Required, MaxLength(500)]
        public string Subject { get; set; }
        [Required, MinLength(500)]
        public string Content { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime? PinDate { get; set; }

        [Required]
        public virtual User User { get; set; }
    }
}
