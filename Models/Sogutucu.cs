using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeyazEsyaProje.Models
{

    public enum SogutucuTip
    {
        Buzdolabi,
        DerinDondurucu,
        MiniBuzdolabi
    }
    public class Sogutucu:BeyazEsya
    {
            public SogutucuTip SogutucuTip {  get; set; }

        
        public int Hacim{ get; set; }
    }
}