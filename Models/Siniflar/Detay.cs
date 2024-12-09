using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTİcariOtomasyon.Models.Siniflar
{
    public class Detay
    {
        [Key]
        public int DetayID { get; set; }
        [Column(TypeName="Varchar")]
        [StringLenght(40)]
        public string UrunAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLenght(2000)]
        public string UrunBilgi { get; set; }
    }
}