using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor
{
    class Monitor
    {
        public string Marka { get; set; }
        public string Tipus { get; set; }
        public double Meret { get; set; }
        public int Ar { get; set; }
        public bool Gamer { get; set; }

        public Monitor(string beolvasottS)
        {
            var darabok = beolvasottS.Split(';');
            this.Marka = darabok[0];
            this.Tipus = darabok[1];
            this.Meret = double.Parse(darabok[2]);
            this.Ar = int.Parse(darabok[3]);
            
        }
    }
}
