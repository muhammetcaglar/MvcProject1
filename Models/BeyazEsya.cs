using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeyazEsyaProje.Models
{
    [ComplexType] 
    public class Boyutlar
    {
        public int En { get; set; }

        public int Boy { get; set; }

        public int Derinlik { get; set; }
    }
    public abstract class BeyazEsya
    {
        [Key]

        public int Id { get; set; }

        public string Model{ get; set; }

        public string Renk { get; set; }

        public Boyutlar Boyutlar { get; set; }

        [ForeignKey("Kategori")]
        public int KategoriId { get; set; }

        public virtual Kategori Kategori{ get; set; }

    }
}