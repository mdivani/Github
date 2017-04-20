using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Domain.Entities
{
   public class Article
    {
        public Article() {
            Comment = new List<Comment>();
        }

        [Key, Required]
        public int ID { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [Required]
        public int? Views { get; set; }
        [MaxLength]
        public string[] ImageUrl { get; set; }

        public virtual List<Comment> Comment { get; set; }
    }
}
