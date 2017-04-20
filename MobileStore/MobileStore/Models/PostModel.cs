using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileStore.Models
{
    public class PostModel
    {
        [Required, MaxLength(200)]
        public string Subject { get; set; }
        [Required, MinLength(500)]
        public string Content { get; set; }
        [ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; }

        [ScaffoldColumn(false)]
        public string Author { get; set; }
    }
}