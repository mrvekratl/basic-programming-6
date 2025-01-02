using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeri_Otomasyon
{
    internal class Araba
    {
        public string Plaka { get; set; }

        public string Marka { get; set; }

        public float KiralamaBedeli { get; set; }

        public string AracTipi { get; set; }

        public string Durum { get; set; }

        public List<int> KiralamaSureleri = new List<int>();

        public Araba(string plaka, string marka, float kiralamaBedeli, string aractipi)
        {
            this.Plaka = plaka;
            this.Marka = marka;
            this.KiralamaBedeli = kiralamaBedeli;
            this.AracTipi = aractipi;
            this.Durum = "Galeride";
        }
        public int KiralanmaSayisi
        {
            get
            {
                return this.KiralamaSureleri.Count;
            }
        }
        public int ToplamKiralamaSuresi
        {
            get
            {                
                return this.KiralamaSureleri.Sum();
            }
        }

        

    }
}
