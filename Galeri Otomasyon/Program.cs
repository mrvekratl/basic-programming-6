using System;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics.X86;

namespace Galeri_Otomasyon
{
    internal class Program
    {
        
        static Galeri OtoGaleri = new Galeri();
        static void Main(string[] args)
        {
            Uygulama();

        }

        static string secim = null; //Klavyeden sürekli alınacak olan seçim verisini ortak değişken olarak tanımladık
        static void Uygulama()
        {
            SahteVeri();
            Menu();
            SecimYönlendir();
        }//Menü ve uygulama
        static void SecimYönlendir()
        {
            while (true)
            {
                secim = SecimAl(); //Seçimi kontrol metoduna gönderdik

                switch (secim)
                {
                    case "1":
                    case "K":
                        ArabaKirala();
                        break;
                    case "2":
                    case "T":
                        ArabaTeslimAl();
                        break;
                    case "3":
                    case "R":
                        KiradakiArabalarıListele();
                        break;
                    case "4":
                    case "M":
                        GaleridekiArabalarıListe();
                        break;
                    case "5":
                    case "A":
                        TümArabalarıListe();
                        break;
                    case "6":
                    case "I":
                        Kiralamaİptali();
                        break;
                    case "7":
                    case "Y":
                        ArabaEkle();
                        break;
                    case "8":
                    case "S":
                        ArabaSil();
                        break;
                    case "9":
                    case "G":
                        GaleriBilgileri();
                        break;
                    default:
                        break;


                }

            }
        }
        static void Menu()
        {
            Console.WriteLine("Galeri Otomasyon");
            Console.WriteLine("1- Araba Kirala (K)");
            Console.WriteLine("2- Araba Teslim Al (T)");
            Console.WriteLine("3- Kiradaki Arabaları Listele (R)");
            Console.WriteLine("4- Galerideki Arabaları Listele (M)");
            Console.WriteLine("5- Tüm Arabaları Listele (A)");
            Console.WriteLine("6- Kiralama İptali (I)");
            Console.WriteLine("7- Araba Ekle (Y)");
            Console.WriteLine("8- Araba Sil (S)");
            Console.WriteLine("9- Bilgileri Göster (G)");
            Console.WriteLine();


        } //Menüdeki gereksiz yazı yığını
        static string SecimAl()
        {
            string karakter = "123456789KTRMAIYSGX"; //harflerden oluşan dizi
            int sayac = 0; //10 adet arka arkaya yanlış girişi saymak için

            while (true)
            {
                sayac++;
                Console.Write("Seçiminiz: ");
                secim = Console.ReadLine().ToUpper(); //klavyeden gelen kullanıcı girişi
                Console.WriteLine();

                int indeks = karakter.IndexOf(secim); //klavyeden gelen giriş, karakter dizisi içindeki harf ve sayılar içerisinde yoksa
                //indeks değişkenine -1 değeri veriyor. Bu da bizim girişin hatlı olup olmadığını kontrol etmemizi sağlıyor.

                if (indeks >= 0) //seçim doğru ise
                {
                    return secim;
                }
                if (secim == "X")
                {
                    SecimYönlendir();
                }
                else //seçim yanlış ise
                {
                    if (sayac == 10)//toplam 10 adet yanlış giriş oldu ise
                    {
                        Environment.Exit(0);
                    }
                    Console.WriteLine("Hatalı işlem gerçekleştirildi. Tekrar deneyin.");
                    Console.WriteLine();
                }
            }

        } //Seçimin doğru olup olmadığının konrolü

        //static bool PlakaKontrolYanlisİslem(string plaka) //Plaka girişini doğru olup olmadığını kontrol eden metot(çalışmadı)
        //{
        //    bool kontrol = true; //bir tane bool değişken atadık, true dedik. Eğer kontrol esnasında bir hata olursa false olarak değişecek

        //    if (plaka.Length == 8 || plaka.Length == 9) //Plakanın uzununluğu 8 olmalı
        //    {
        //        foreach (char c in plaka) //Plakanın her bir harfine bakıp konrol et.
        //        {

        //            if (plaka[0] < '0' || plaka[0] > '9' && plaka[1] < '0' || plaka[1] > '9')
        //            {
        //                kontrol = true; //Eğer ilk iki elemanı sayı ise doğrudur.
        //            }
        //            else
        //            {
        //                kontrol = false; //değil ise yanlıştır.
        //            }
        //            if (plaka[2] < 'A' || plaka[2] > 'Z' && plaka[3] < 'A' || plaka[3] > 'Z')
        //            {
        //                kontrol = true;//Eğer üçüncü ve dördüncü elemanı harf ise doğrudur. (Beşinci eleman hem harf hem sayı olabilir onu kontrol etmeye gerek yok)

        //            }
        //            else
        //            {
        //                kontrol = false;//değil ise yanlıştır.
        //            }
        //            if (plaka[5] < '0' || plaka[5] > '9' && plaka[6] < '1' || plaka[6] > '9' && plaka[7] < '1' || plaka[7] > '9' )
        //            {
        //                kontrol = true; //Son üç elemanı sayı ise doğrudur.

        //            }
        //            else
        //            {
        //                kontrol = false;//değil ise yanlıştır.
        //            }
        //            if(plaka.Length == 9)
        //            {
        //                if(plaka[8] < '1' || plaka[8] > '9')
        //                {
        //                    kontrol = true;
        //                }
        //                else
        //                {
        //                    kontrol = false;//değil ise yanlıştır.
        //                }
        //            }

        //        }
        //    }
        //    else if (plaka.Length != 8 || plaka.Length != 9)
        //    {
        //        kontrol = false; //değil ise yanlıştır.
        //    }

        //    return kontrol; //En son kontrol değişkeni ne ise onu döndür

        //}
        static bool PlakaKontrol(string plaka) //Plaka girişini doğru olup olmadığını kontrol eden metot
        {

            if (plaka.Length != 7 && plaka.Length != 8 && plaka.Length != 9)
            {
                return false; // Geçersiz plaka uzunluğu
            }

            // İlk iki karakterin rakam olması gerekir
            for (int i = 0; i < 2; i++)
            {
                if (!char.IsDigit(plaka[i]))
                {
                    return false; // İlk iki karakter rakam değil
                }
            }

            // Üçüncü ve dördüncü karakterlerin harf olması gerekir
            for (int i = 2; i < 4; i++)
            {
                if (!char.IsLetter(plaka[i]))
                {
                    return false; // Üçüncü ve dördüncü karakterler harf değil
                }
            }

            // Son üç karakterin rakam olması gerekir
            for (int i = plaka.Length - 3; i < plaka.Length; i++)
            {
                if (!char.IsDigit(plaka[i]))
                {
                    return false; // Son üç karakter rakam değil
                }
            }

            // Geçerli plaka formatı ise true döndür
            return true;
        }
        static void ArabaKirala()
        {
            Console.WriteLine("-Araba Kirala-");
            Console.WriteLine();
            Console.Write("Kiralanacak arabanın plakası: ");
            string plaka = Console.ReadLine().ToUpper();
            if (plaka == "X")
            {
                Console.WriteLine();
                SecimYönlendir();
            }

            while (true)
            {
                if (PlakaKontrol(plaka))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                    Console.Write("Kiralanacak arabanın plakası: ");
                    plaka = Console.ReadLine().ToUpper();
                    if (plaka == "X")
                    {
                        Console.WriteLine();
                        SecimYönlendir();

                    }
                }
            }

            while (true)
            {
                if (OtoGaleri.PlakaVarMi(plaka))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                    Console.Write("Kiralanacak arabanın plakası: ");
                    plaka = Console.ReadLine().ToUpper();
                    if (plaka == "X")
                    {
                        Console.WriteLine();
                        SecimYönlendir();
                    }
                }
            }
            while (true)
            {
                if (OtoGaleri.KiradaMi(plaka))
                {
                    Console.WriteLine("Araba şu anda kirada. Farklı araba seçiniz.");
                    Console.Write("Kiralanacak arabanın plakası: ");
                    plaka = Console.ReadLine().ToUpper();
                    if (plaka == "X")
                    {
                        Console.WriteLine();
                        SecimYönlendir();
                    }
                }
                else
                {
                    break;
                }
            }

            Console.Write("Kiralama süresi: ");
            int sure = int.Parse(Console.ReadLine());

            OtoGaleri.ArabaKirala(plaka, sure);
            Console.WriteLine();
            Console.WriteLine(plaka + " plakalı araba " + sure + " saatliğine kiralandı.");
            Console.WriteLine();
            SecimAl();


        }
        static void ArabaTeslimAl()
        {
            Console.WriteLine("-Araba Teslim Al-");
            Console.WriteLine();
            Console.Write("Teslim edilecek arabanın plakası: ");
            string plaka = Console.ReadLine().ToUpper();
            if (plaka == "X")
            {
                Console.WriteLine();
                SecimYönlendir();
            }

            while (true)
            {
                if (PlakaKontrol(plaka))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                    Console.Write("Teslim edilecek arabanın plakası: ");
                    plaka = Console.ReadLine().ToUpper();
                    if (plaka == "X")
                    {
                        SecimYönlendir();
                    }
                    SecimAl();

                }
            }
            while (true)
            {
                if (OtoGaleri.PlakaVarMi(plaka))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                    Console.Write("Teslim edilecek arabanın plakası: ");
                    plaka = Console.ReadLine().ToUpper();
                    SecimAl();

                }
            }
            while (true)
            {
                if (OtoGaleri.GalerideMi(plaka))
                {
                    Console.WriteLine("Hatalı giriş yapıldı. Araba zaten galeride.");
                    Console.Write("Teslim edilecek arabanın plakası: ");
                    plaka = Console.ReadLine().ToUpper();

                    SecimAl();

                }
                else
                {
                    break;
                }
            }


            OtoGaleri.ArabaTeslimEt(plaka);
            Console.WriteLine();
            Console.WriteLine("Araba galeride beklemeye alındı.");
            Console.WriteLine();
            SecimAl();
        }
        static void KiradakiArabalarıListele()
        {
            Console.WriteLine("-Kiradaki Arabalar-");
            Console.WriteLine();

            while (true)
            {
                if (OtoGaleri.KiradakiAracSayisi == 0)
                {
                    Console.WriteLine("Listelenecek araç yok.");
                    Console.WriteLine();
                    SecimYönlendir();
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("Plaka".PadRight(14) + "Marka".PadRight(11) + "K. Bedeli".PadRight(12) + "Araba Tipi".PadRight(12) + "K. Sayısı".PadRight(12) + "Durum".PadRight(7));
            Console.WriteLine("----------------------------------------------------------------------");

            foreach (var araba in OtoGaleri.Arabalar)
            {
                if (araba.Durum == "Kirada")
                {
                    Console.WriteLine(araba.Plaka.PadRight(14) + araba.Marka.PadRight(11) + araba.KiralamaBedeli.ToString().PadRight(12) + araba.AracTipi.PadRight(12) + araba.KiralanmaSayisi.ToString().PadRight(12) + araba.Durum.PadRight(10));
                }
            }
            Console.WriteLine();

        }
        static void GaleridekiArabalarıListe()
        {
            Console.WriteLine("-Galerideki Arabalar-");
            Console.WriteLine();

            while (true)
            {
                if (OtoGaleri.GaleridekiAracSayisi == 0)
                {
                    Console.WriteLine("Listelenecek araç yok.");
                    Console.WriteLine();
                    SecimYönlendir();
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("Plaka".PadRight(13) + "Marka".PadRight(12) + "K. Bedeli".PadRight(12) + "Araba Tipi".PadRight(12) + "K. Sayısı".PadRight(10) + "Durum".PadLeft(7));
            Console.WriteLine("----------------------------------------------------------------------");
            foreach (var araba in OtoGaleri.Arabalar)
            {
                if (araba.Durum == "Galeride")
                {
                    Console.WriteLine(araba.Plaka.PadRight(13) + araba.Marka.PadRight(12) + araba.KiralamaBedeli.ToString().PadRight(12) + araba.AracTipi.PadRight(12) + araba.KiralanmaSayisi.ToString().PadRight(10) + araba.Durum.PadLeft(10));

                }
            }
            Console.WriteLine();

        }
        static void TümArabalarıListe()
        {
            Console.WriteLine("-Tüm Arabalar-");
            Console.WriteLine();
            while (true)
            {
                if (OtoGaleri.ToplamAracSayisi == 0)
                {
                    Console.WriteLine("Listelenecek araç yok.");
                    Console.WriteLine();
                    SecimYönlendir();
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("Plaka".PadRight(13) + "Marka".PadRight(12) + "K. Bedeli".PadRight(12) + "Araba Tipi".PadRight(12) + "K. Sayısı".PadRight(12) + "Durum".PadRight(7));
            Console.WriteLine("----------------------------------------------------------------------");
            foreach (var araba in OtoGaleri.Arabalar)
            {
                Console.WriteLine(araba.Plaka.PadRight(13) + araba.Marka.PadRight(12) + araba.KiralamaBedeli.ToString().PadRight(12) + araba.AracTipi.PadRight(12) + araba.KiralanmaSayisi.ToString().PadRight(12) + araba.Durum.PadRight(10));

            }
            Console.WriteLine();

        }
        static void Kiralamaİptali()
        {
            Console.WriteLine("Kiralaması iptal edilecek arabanın plakası: ");
            string plaka = Console.ReadLine().ToUpper();
            if (plaka == "X")
            {
                Console.WriteLine();
                SecimYönlendir();
            }

            SecimAl();

            while (true)
            {
                if (PlakaKontrol(plaka))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                    Console.Write("Kiralaması iptal edilecek arabanın plakası: ");
                    plaka = Console.ReadLine().ToUpper();

                    SecimAl();

                }
            }
            while (true)
            {
                if (OtoGaleri.GalerideMi(plaka))
                {
                    Console.WriteLine("Hatalı giriş yapıldı. Araba zaten galeride.");
                    Console.Write("Kiralaması iptal edilecek arabanın plakası: ");
                    plaka = Console.ReadLine().ToUpper();

                    SecimAl();

                }
                else
                {
                    break;
                }
            }
            while (true)
            {
                if (OtoGaleri.PlakaVarMi(plaka))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                    Console.Write("Kiralaması iptal edilecek arabanın plakası: ");
                    plaka = Console.ReadLine().ToUpper();

                    SecimAl();

                }
            }
            OtoGaleri.KiralamaIptali(plaka);
            Console.WriteLine();
            Console.WriteLine("İptal gerçekleştirildi.");
            Console.WriteLine();
            SecimAl();

        }
        static void ArabaEkle()
        {
            string plaka;
            string marka;
            float kiralamaBedeli;
            string aTipi;

            Console.WriteLine("-Araba Ekle-");
            Console.WriteLine();
            Console.Write("Plaka: ");
            plaka = Console.ReadLine().ToUpper();
            if (plaka == "X")
            {
                Console.WriteLine();
                SecimYönlendir();
            }


            while (true)
            {
                if (PlakaKontrol(plaka))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                    Console.Write("Plaka: ");
                    plaka = Console.ReadLine().ToUpper();

                    SecimAl();

                }
            }
            while (true)
            {
                if (OtoGaleri.PlakaVarMi(plaka))
                {
                    Console.WriteLine("Aynı plakada araba mevcut. Girdiğiniz plakayı kontrol edin");
                    Console.Write("Plaka: ");
                    plaka = Console.ReadLine().ToUpper();

                    SecimAl();

                }
                else
                {
                    break;
                }
            }


            Console.Write("Marka: ");
            marka = Console.ReadLine().ToUpper();

            int sayi;

            while (int.TryParse(marka, out sayi))
            {
                Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                Console.Write("Marka: ");
                if (marka.All(char.IsDigit))
                {
                    marka = Console.ReadLine().ToUpper();
                    continue;

                }

            }

            Console.Write("Kiralama Bedeli: ");

            while (true)
            {
                string giris = Console.ReadLine().ToUpper();

                if (!float.TryParse(giris, out kiralamaBedeli))
                {
                    Console.WriteLine("Geçersiz giriş. Tekrar deneyin.");
                    Console.Write("Kiralama Bedeli: ");
                }
                else
                {
                    // Geçerli bir kiralama bedeli girildi, işlemi devam ettir
                    break; // Döngüyü sonlandır
                }
            }

            Console.WriteLine("Araba Tipi: ");
            Console.WriteLine("SUV için 1");
            Console.WriteLine("Hatchback için 2");
            Console.WriteLine("Sedan için 3");
            Console.Write("Araba Tipi: ");
            int aTipiSecim = int.Parse(Console.ReadLine());


            SecimAl();


            switch (aTipiSecim)
            {
                case 1: aTipi = "SUV"; break;
                case 2: aTipi = "Hatchback"; break;
                case 3: aTipi = "Sedan"; break;
                default: Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin."); break;

            }
            Console.WriteLine();
            Console.WriteLine("Araba başarılı bir şekilde eklendi.");
            Console.WriteLine();
            SecimAl();


        }
        static void ArabaSil()
        {
            Console.WriteLine("-Araba Sil-");
            Console.WriteLine();
            Console.Write("Silmek istediğiniz arabanın plakasını giriniz:");
            string plaka = Console.ReadLine().ToUpper();
            if (plaka == "X")
            {
                Console.WriteLine();
                SecimYönlendir();

            }

            while (true)
            {
                if (PlakaKontrol(plaka))
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                    Console.Write("Silinmek istenen araba plakasını girin: ");
                    plaka = Console.ReadLine().ToUpper();
                    SecimAl();
                }

            }
            while (true)
            {
                if (OtoGaleri.KiradaMi(plaka))
                {
                    Console.WriteLine("Araba kirada olduğu için silme işlemi gerçekleştirilemedi.");
                    Console.Write("Silinmek istenen araba plakasını girin: ");
                    plaka = Console.ReadLine().ToUpper();
                    SecimYönlendir();

                }
                else
                {
                    break;
                }
            }
            while (true)
            {
                if (OtoGaleri.PlakaVarMi(plaka))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                    Console.Write("Silinmek istenen araba plakasını girin: ");
                    plaka = Console.ReadLine().ToUpper();


                }
            }
            OtoGaleri.ArabaSil(plaka);
            Console.WriteLine();
            Console.WriteLine("Araba silindi.");
            Console.WriteLine();
            SecimYönlendir();
            SecimAl();

        }
        static void GaleriBilgileri()
        {
            Console.WriteLine("-Galeri Bilgileri-");
            Console.WriteLine("Toplam araba sayısı: " + OtoGaleri.ToplamAracSayisi);
            Console.WriteLine("Kiradaki araba sayısı: " + OtoGaleri.KiradakiAracSayisi);
            Console.WriteLine("Bekleyen araba sayısı: " + OtoGaleri.GaleridekiAracSayisi);
            Console.WriteLine("Toplam araba kiralama süresi: " + OtoGaleri.ToplamAracKiralamaSuresi);
            Console.WriteLine("Toplam araba kiralama adedi: " + OtoGaleri.ToplamAracKiralamaAdeti);
            Console.WriteLine("Ciro: " + OtoGaleri.Ciro);
            Console.WriteLine();
            SecimYönlendir();
        }
        static void SahteVeri() //Açtığımızda içerisi boş olmasın diye sahte veri ekledik
        {
            Araba a1 = new Araba("34ARB3434", "FIAT", 70, "Sedan");
            a1.Durum = "Galeride";
            Araba a2 = new Araba("35ARB3535", "KIA", 60, "SUV");
            a2.Durum = "Galeride";
            Araba a3 = new Araba("34US2342", "OPEL", 50, "Hatchback");
            a3.Durum = "Galeride";

            OtoGaleri.Arabalar.Add(a1);
            OtoGaleri.Arabalar.Add(a2);
            OtoGaleri.Arabalar.Add(a3);
        }

    }
}
