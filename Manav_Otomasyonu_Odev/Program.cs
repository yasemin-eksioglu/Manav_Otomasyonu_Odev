using System.Collections;

namespace Manav_Otomasyonu_Odev
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1-Hal\n2-Manav");
                string secim = Console.ReadLine();
                if (secim == "1")
                { HosGeldinizHal(); }
                else if (secim == "2")
                {
                    HosGeldinizManav();
                }
                else { Console.WriteLine("Hatalı Tuşlama Yaptınız!"); }
            }
            static void HosGeldinizHal()
            {
                Console.WriteLine("Sebze/Meyve Haline Hoş Geldiniz");
                while (true)
                {
                    Console.WriteLine("Sebze Mi Almak İstersiniz Meyve Mi? S/M ?");
                    string manavSecim = Console.ReadLine();
                    if (manavSecim.ToUpper() == "S")
                    {
                        SebzeListele();
                        try
                        {
                            int sebzeSecim = Convert.ToInt32(Console.ReadLine());
                            if (sebzeSecim > 0 && sebzeSecim <= SebzeListeHal.sebzeListeHal.Count)
                            {
                                Console.WriteLine("Kaç Kilo Almak İstersiniz?");
                                double kiloSecimSebze = Convert.ToDouble(Console.ReadLine());
                                string secilenSebze = SebzeListeHal.sebzeListeHal[sebzeSecim - 1].ToString();
                                string alinanSebze = $"{secilenSebze}-";
                                bool urunBulundu = false;
                                foreach (string sebze in ManavUrunlerListe.manavAlinanlarSebze)
                                {
                                    if (sebze.StartsWith(alinanSebze))
                                    {
                                        var urunBilgileri = sebze.Split("-");
                                        double mevcutKilo = Convert.ToDouble(urunBilgileri[1].Replace(" kg", "").Trim());// Trim metodu istenmeyen boşlukları siler
                                        mevcutKilo += kiloSecimSebze;
                                        ManavUrunlerListe.manavAlinanlarSebze[ManavUrunlerListe.manavAlinanlarSebze.IndexOf(sebze)] = $"{secilenSebze}-{mevcutKilo} kg"; // Güncelle
                                        urunBulundu = true;
                                        break;
                                    }
                                }
                                if (!urunBulundu)
                                {
                                    ManavUrunlerListe.manavAlinanlarSebze.Add($"{secilenSebze}-{kiloSecimSebze} kg");
                                }

                                Console.WriteLine("Seçilen Ürün Listeye Başarıyla Eklendi");
                                Console.WriteLine("Başka Ürün Eklemek İçin 1'e Çıkış Yapmak İçin 9'a Basınız.");
                                int urunEkleme = Convert.ToInt32(Console.ReadLine());
                                if (urunEkleme == 1)
                                { continue; }

                                else if (urunEkleme == 9)
                                {
                                    Console.WriteLine("Aldığınız Ürünlerin Ödemesini Kasada Yapabilirsiniz.Manav Bölümüne Geçiliyor...");
                                    Thread.Sleep(2000);
                                    HosGeldinizManav();
                                }
                                else
                                { Console.WriteLine("Hatalı Tuşlama Yaptınız."); }

                            }
                            else
                            {
                                Console.WriteLine("Hatalı Seçim Yaptınız!");
                            }

                        }
                        catch (FormatException)
                        { Console.WriteLine("Lütfen Rakam Tuşlayınız"); }
                    }
                    else if (manavSecim.ToUpper() == "M")
                    {
                        MeyveListele();
                        try
                        {
                            int meyveSecim = Convert.ToInt32(Console.ReadLine());
                            if (meyveSecim > 0 && meyveSecim <= MeyveListeHal.meyveListeHal.Count)
                            {
                                Console.WriteLine("Kaç Kilo Almak İstersiniz?");
                                double kiloSecimMeyve = Convert.ToDouble(Console.ReadLine());
                                string secilenMeyve = MeyveListeHal.meyveListeHal[meyveSecim - 1].ToString();
                                string alinanMeyve = $"{secilenMeyve}-";
                                bool urunBulundu = false;
                                foreach (string meyve in ManavUrunlerListe.manavAlinanlarMeyve)
                                {
                                    if (meyve.StartsWith(alinanMeyve))
                                    {
                                        var urunBilgileri = meyve.Split("-");
                                        double mevcutKilo = Convert.ToDouble(urunBilgileri[1].Replace(" kg", "").Trim());// Trim metodu istenmeyen boşlukları siler
                                        mevcutKilo += kiloSecimMeyve;
                                        ManavUrunlerListe.manavAlinanlarMeyve[ManavUrunlerListe.manavAlinanlarMeyve.IndexOf(meyve)] = $"{secilenMeyve}-{mevcutKilo} kg"; // Güncelle
                                        urunBulundu = true;
                                        break;
                                    }
                                }
                                if (!urunBulundu)
                                {
                                    ManavUrunlerListe.manavAlinanlarMeyve.Add($"{secilenMeyve}-{kiloSecimMeyve} kg");
                                }

                                Console.WriteLine("Seçilen Ürün Listeye Başarıyla Eklendi");
                                Console.WriteLine("Başka Ürün Eklemek İçin 1'e Çıkış Yapmak İçin 9'a Basınız.");
                                int urunEkleme = Convert.ToInt32(Console.ReadLine());
                                if (urunEkleme == 1)
                                { continue; }

                                else if (urunEkleme == 9)
                                {
                                    Console.WriteLine("Aldığınız Ürünlerin Ödemesini Kasada Yapabilirsiniz.Manav Bölümüne Geçiliyor...");
                                    Thread.Sleep(2000);
                                    HosGeldinizManav();
                                }
                                else
                                { Console.WriteLine("Hatalı Tuşlama Yaptınız."); }

                            }
                            else
                            {
                                Console.WriteLine("Hatalı Seçim Yaptınız!");
                            }
                         
                        }
                        catch (FormatException)
                        { Console.WriteLine("Lütfen Rakam Tuşlayınız"); }
                    }
                    else
                    {
                        Console.WriteLine("Hatalı Tuşlama Yaptınız. S veya M Seçimi Yapınız.");
                    }
                }
            }
            static void SebzeListele()
            {

                Console.WriteLine("Almak İstediğiniz Sebzeyi Seçin");
                for (int i = 0; i < SebzeListeHal.sebzeListeHal.Count; i++)
                {
                    Console.WriteLine($"{i + 1}-{SebzeListeHal.sebzeListeHal[i]}");
                }

            }
            static void MeyveListele()
            {

                Console.WriteLine("Almak İstediğiniz Meyveyi Seçin");
                for (int i = 0; i < MeyveListeHal.meyveListeHal.Count; i++)
                {
                    Console.WriteLine($"{i + 1}-{MeyveListeHal.meyveListeHal[i]}");
                }
            }
            static void HosGeldinizManav()
            {
                Console.WriteLine("Hoş Geldiniz");
                while (true)
                {
                    Console.WriteLine("Sebze Mi Almak İstersiniz Meyve Mi? S/M ?");
                    string manavSecim = Console.ReadLine();
                    if (manavSecim.ToUpper() == "S")
                    {
                        ManavUrunleriSebzeListele();
                        try
                        {
                            int sebzeSecim = Convert.ToInt32(Console.ReadLine());
                            if (sebzeSecim > 0 && sebzeSecim <= ManavUrunlerListe.manavAlinanlarSebze.Count)
                            {
                                Console.WriteLine("Kaç Kilo Almak İstersiniz?");
                                double kiloSecimSebze = Convert.ToDouble(Console.ReadLine());
                                var secilenUrun = ManavUrunlerListe.manavAlinanlarSebze[sebzeSecim - 1].ToString();
                                var urunBilgileri = secilenUrun.Split('-');
                                string urunAdi = urunBilgileri[0];
                                double mevcutKiloSebze = Convert.ToDouble(urunBilgileri[1].Replace(" kg", ""));
                                if (kiloSecimSebze <= mevcutKiloSebze)
                                {
                                    mevcutKiloSebze -= kiloSecimSebze;
                                    if (mevcutKiloSebze > 0)
                                    {
                                        ManavUrunlerListe.manavAlinanlarSebze[sebzeSecim - 1] = $"{urunAdi}-{mevcutKiloSebze} kg"; // satılmasına rağmen hala kalan ürün varsa ürünü güncelle
                                    }
                                    else
                                    {
                                        ManavUrunlerListe.manavAlinanlarSebze.RemoveAt(sebzeSecim - 1); //Stok yoksa ürünü kaldır    
                                    }
                                    Console.WriteLine($"{kiloSecimSebze} kg {urunAdi} alındı.");
                                }
                                else
                                {
                                    Console.WriteLine($"Şuan Elimizde Ürün {mevcutKiloSebze} Kilo Var. Lütfen İstediğiniz Kiloyu Düşürünüz.");

                                }
                            }
                            else
                            { Console.WriteLine("Hatalı Tuşlama Yaptınız"); }
                        }
                        catch (FormatException) { Console.WriteLine("Lütfen Rakam Tuşlayınız!"); }
                    }

                    else if (manavSecim.ToUpper() == "M")
                    {
                        ManavUrunleriMeyveListele();
                        try
                        {
                            int meyveSecim = Convert.ToInt32(Console.ReadLine());
                            if (meyveSecim > 0 && meyveSecim <= ManavUrunlerListe.manavAlinanlarMeyve.Count)
                            {
                                Console.WriteLine("Kaç Kilo Almak İstersiniz?");
                                double kiloSecimMeyve = Convert.ToDouble(Console.ReadLine());
                                var secilenUrun = ManavUrunlerListe.manavAlinanlarMeyve[meyveSecim - 1].ToString();
                                var urunBilgileri = secilenUrun.Split('-');
                                string urunAdi = urunBilgileri[0];
                                double mevcutKiloMeyve = Convert.ToDouble(urunBilgileri[1].Replace(" kg", ""));
                                if (kiloSecimMeyve <= mevcutKiloMeyve)
                                {
                                    mevcutKiloMeyve -= kiloSecimMeyve;
                                    if (mevcutKiloMeyve > 0)
                                    {
                                        ManavUrunlerListe.manavAlinanlarSebze[meyveSecim - 1] = $"{urunAdi}-{mevcutKiloMeyve} kg"; // satılmasına rağmen hala kalan ürün varsa ürünü güncelle
                                    }
                                    else
                                    {
                                        ManavUrunlerListe.manavAlinanlarMeyve.RemoveAt(meyveSecim - 1); //Stok yoksa ürünü kaldır    
                                    }
                                    Console.WriteLine($"{kiloSecimMeyve} kg {urunAdi} alındı.");
                                }
                                else
                                {
                                    Console.WriteLine($"Şuan Elimizde Ürün {mevcutKiloMeyve} Kilo Var. Lütfen İstediğiniz Kiloyu Düşürünüz.");

                                }
                            }
                            else
                            { Console.WriteLine("Hatalı Tuşlama Yaptınız"); }
                        }
                        catch (FormatException) { Console.WriteLine("Lütfen Rakam Tuşlayınız!"); }
                    }

                    else
                    {
                        Console.WriteLine("Hatalı Tuşlama Yaptınız. S veya M Seçimi Yapınız.");
                    }

                }
            }

            static void ManavUrunleriSebzeListele()
            {

                Console.WriteLine("Almak İstediğiniz Sebzeyi Seçin");
                for (int i = 0; i < ManavUrunlerListe.manavAlinanlarSebze.Count; i++)
                {
                    Console.WriteLine($"{i + 1}-{ManavUrunlerListe.manavAlinanlarSebze[i]}");

                }

            }
            static void ManavUrunleriMeyveListele()
            {
                Console.WriteLine("Almak İstediğiniz Meyveyi Seçin");
                for (int i = 0; i < ManavUrunlerListe.manavAlinanlarMeyve.Count; i++)
                {
                    Console.WriteLine($"{i + 1}-{ManavUrunlerListe.manavAlinanlarMeyve[i]}");

                }
            }

        }
    }
}
