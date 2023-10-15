using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeyazEsyaProje.Models
{
    public class Kategori
    {
        [Key]
        public int Id{ get; set; }

        [Required]
        [MaxLength(50)]
        public string KategoriAdi{ get; set; }

        public virtual List<BeyazEsya> Urunler{ get; set; }


    }
}