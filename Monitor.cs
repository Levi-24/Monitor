using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor
{
    class Monitor
    {
        public string Gyarto { get; set; }
        public string Tipus { get; set; }
        public double Meret { get; set; }
        public int Ar { get; set; }
        public bool Gamer { get; set; }
        public int Brutto { get; set; }
        public int Darab { get; set; }

        public Monitor(string beolvasottS)
        {
            var darabok = new List<string>(beolvasottS.Split(';'));
            this.Gyarto = darabok[0];
            this.Tipus = darabok[1];
            this.Meret = double.Parse(darabok[2]);
            this.Ar = int.Parse(darabok[3]);
            if (darabok.Count == 5) {this.Gamer = true;}
            else {this.Gamer = false;}
            int ar = int.Parse(darabok[3]);
            this.Brutto = Convert.ToInt32(ar += (ar / 100) * 27);
            this.Darab = 15;

        }
    }
}
