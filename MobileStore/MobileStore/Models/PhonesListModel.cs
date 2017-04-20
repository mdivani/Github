using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileStore.Models
{
    public class PhonesListModel {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public int Views { get; set; }
        public int? Rating { get; set; }
        [ScaffoldColumn(false)]
        public int ID { get; set; }

    }
}