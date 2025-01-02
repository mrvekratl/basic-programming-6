using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Galeri_Otomasyon
{   
    internal class Galeri
    {
        public List<Araba> Arabalar = new List<Araba>(); //Galeride işlem yapabilmek için arabalar classından oluşan bir liste oluşturuluyor

        public int ToplamAracSayisi  //Toplam araç sayısı için bu listenin eleman sayısına eşit
        {
            get 
            {
                return this.Arabalar.Count; //Liste uzunluğunu okuttuk
            }
        }

        public int KiradakiAracSayisi 
        {
            get
            {
                int adet = 0; //Sayaç oluştur

                foreach (Araba item in Arabalar) //Araba listesindeki her elemanı kontrol et ve "Kirada" olanları ayıkla
                {
                    if (item.Durum == "Kirada")
                    {
                        adet++; //sayaca "Kirada" olanları ekle
                    }


                }
                return adet;//KiradakiAracSayisi na sayaçtaki eklenen miktarı okut
            }

        }

        public int GaleridekiAracSayisi //Sayaç oluştur
        {
            get
            {
                int adet = 0; 

                foreach (Araba item in Arabalar) //Araba listesindeki her elemanı kontrol et ve "Galeride" olanları ayıkla
                {
                    if (item.Durum == "Galeride")
                    {
                        adet++; //sayaca "Galeride" olanları ekle 
                    }


                }
                return adet; //GaleridekiAracSayisi na sayaçtaki eklenen miktarı okut
            } 
        }

        public int ToplamAracKiralamaSuresi
        {
            get
            {
                int toplam = 0; //Toplam indeksi oluşturup içerisine her aracın toplam kiralanma süresi eklenecek
                foreach(Araba item in Arabalar) //Listedeki her aracı kontrol et
                {
                    toplam += item.ToplamKiralamaSuresi; //Her elemanın/aracın toplam kiralama süresini "toplam" indeksine ekle
                }
                return toplam; //Bütün araçların toplamlarını bulup ekledikten sonra okut
            }
        }

        public int ToplamAracKiralamaAdeti  //A aracı 5 kez kiralanmış, B aracı 4 kez kiralanmış. Bu durumda toplam araç kiralama adedi = 9 olur       
        { 
            get
            {
                int toplam = 0; //Toplam indeksi oluşturup içerisine her aracın kiralanma sayısı eklenecek
                foreach (Araba item in Arabalar) //Listedeki her aracı kontrol et
                {
                    toplam += item.KiralanmaSayisi; //Her elemanın/aracın toplam kiralama sayısını "toplam" indeksine ekle
                }
                return toplam; //bütün araçların kirlanma sayılarını topla ve okut


            }
        }

        public float Ciro //Kiralama sayısı * kiralama bedeli ile hesaplanmalı
        { 
            get
            {
                float toplam = 0; //Toplam indeksi oluşturup içerisine her araçtan elde edilecek kar eklenecek
                foreach (Araba item in Arabalar) //Listedeki her aracı kontrol et
                {
                    toplam += (item.ToplamKiralamaSuresi * item.KiralamaBedeli); //Her aracın kiralanma sayısı ile kiralama bedelini çarpıp toplama ekle
                }
                return toplam; //Her araçtan elde edilen karı toplama ekle ve okut

            }
        }

        public void ArabaKirala (string plaka, int sure) //Kullanıcı araba kiralamak için istediği aracın plakasını giriyor ve kiralamak istediği süreyi giriyor
        {
            Araba a = null; //Boş bir değişken oluşturup istenilen aracı bulunca içerisine atayacağız

            foreach (Araba item in Arabalar) //Listedeki her aracı kontrol ediyoruz
            {
                if(item.Plaka == plaka) //İstenilen plaka listede var ise;
                {
                    a = item; //Bu aracı boş değişkene ata
                }
                
            }

            if(a != null) //Eğer değişkenin içerisi dolduysa ve bir araç bulabildiysek;
            {
                a.Durum = "Kirada"; //Bu aracın durumunu "Kirada" olarak değiştir.
                a.KiralamaSureleri.Add(sure);//Bu aracın kiralama süresine de kullanıcının kiralamak için girdiği süreyi ekle
            }
        }
        public void ArabaTeslimEt (string plaka) //Kullanıcı arabayı teslim etmek için istediği aracın plakasını giriyor
        {
            Araba a = null; //Boş bir değişken oluşturup teslim edilecek aracı bulunca içerisine atayacağız

            foreach (Araba item in Arabalar) //Listedeki her aracı kontrol ediyoruz
            {
                if (item.Plaka == plaka) //İstenilen plaka listede var ise;
                {
                    a = item; //Bu aracı boş değişkene ata
                }
            }
            if( a != null) //Eğer değişkenin içerisi dolduysa ve bir araç bulabildiysek;
            {
                a.Durum = "Galeride"; //Bu aracın durumunu "Galeride" olarak değiştir
            }


        }
        public void KiralamaIptali (string plaka) //Kullanıcı araba kiralamayı iptal etmek için iptal etmek istediği aracın plakasını giriyor
        {
            Araba a = null; //Boş bir değişken oluşturup kiralaması iptal edilecek aracı bulunca içerisine atayacağız

            foreach (Araba item in Arabalar) //Listedeki her aracı kontrol ediyoruz
            {
                if (item.Plaka == plaka) //İstenilen plaka listede var ise;
                {
                    a = item; //Bu aracı boş değişkene ata
                }
            }
            if (a != null)
            {
                a.Durum = "Galeride"; //Bu aracın durumunu "Galeride" olarak değiştir

                //Bu aracın kiralanma sürelerinden son iptal edilecek kiralanma süresini silmek için listedeki son elemanı bul ve sil:

                int i = 0; //Boş bir değişken atadık ve içerisine son kiralama süresini bulup atayacağız
                while(i < a.KiralamaSureleri.Count) //i değişkeni kiralama süresi listesi uzunluğundan bir küçük olacak şekilde artacaktır. 
                {
                    i++; //üzerine 1 ekleye ekleye liste uzunluğunluğundan 1 eksik yani son indeks numarası kadar arttı
                }
                
                a.KiralamaSureleri.RemoveAt(i); //i değişkeni ile son indeks sayısını bulduk ve listeden o indeksi çıkarttık
            }
        }
        public void ArabaEkle(string plaka, string marka, float kiralamaBedeli, string aractipi)
        {
            Araba a = new Araba (plaka, marka, kiralamaBedeli, aractipi);
            this.Arabalar.Add(a);   
        }
        public bool PlakaVarMi(string plaka)
        {
            bool kontrol= false;
            foreach (Araba item in Arabalar)
            {
                if (item.Plaka == plaka)
                {
                    kontrol =  true;
                }
            }
            return kontrol;
            
        }
        public bool KiradaMi (string plaka)
        {
            bool kontrol = false;
            foreach (Araba item in Arabalar)
            {
                if (item.Plaka == plaka)
                {
                    if (item.Durum == "Kirada")
                    {
                        kontrol = true;
                    }
                   
                }
                              
            }
            return kontrol;
        }
        public bool GalerideMi(string plaka) 
        {
            bool kontrol = false;
            foreach (Araba item in Arabalar)
            {
                if (item.Plaka == plaka)
                {
                    if (item.Durum == "Galeride")
                    {
                        kontrol = true;
                    }

                }

            }
            return kontrol;
        }
        public void ArabaSil(string plaka)
        {
            for (int i = Arabalar.Count - 1; i >= 0; i--)
            {
                if (Arabalar[i].Plaka == plaka)
                {
                    Arabalar.RemoveAt(i);
                }
            }
        }

    }
}
