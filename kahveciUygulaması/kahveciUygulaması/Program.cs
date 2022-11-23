using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kahveciUygulaması
{
    class Program
    {

        public static bool calis = true;
        public static string isim;
        public static string[] masa = { "", "", "", "", "", "", "", "", "", "" };
        public static List<Icecek> siparisIcecek = new List<Icecek>();
        public static List<Yiyecek> siparisYiyecek = new List<Yiyecek>();
        public static int secim;
        public static int icecekSecim;
        public static int yiyecekSecim;
        public static List<Siparis> siparisList = new List<Siparis>();
        public static int siparisSayac = 0;
        public static double toplam = 0;


        static void Main(string[] args)
        {
           
            while (calis)
            {
                toplam = 0;
                Console.WriteLine("ÇETİN KAFEYE HOŞGELDİNİZ..");          
                masaKontrol();
                isimKontrol();
                masaSec();
                menu();
                Console.ReadLine();
                Console.Clear();
            }
          
          
        }
        public static void isimKontrol()
        {
            Console.WriteLine("Lütfen isminizi giriniz.");

            isim = Console.ReadLine();

            for (int i = 0; i < isim.Length; i++)
            {
                if (char.IsDigit(isim[i]))
                {
                    Console.WriteLine("İsmi hatalı girdiniz.");
                    isimKontrol();
                }
                if (char.IsPunctuation(isim[i]))
                {
                    Console.WriteLine("İsmi hatalı girdiniz.");
                    isimKontrol();
                }
                if (char.IsSymbol(isim[i]))
                {
                    Console.WriteLine("İsmi hatalı girdiniz.");
                    isimKontrol();
                }
            }

        }
        public static void masaKontrol()
        {
            int sayac = 0;
            for (int i = 0; i < masa.Length; i++)
            {
                if (masa[i] == "")
                {
                    Console.WriteLine($"{i + 1}. masa boştur.");
                    sayac++;
                }
                else
                {
                    Console.WriteLine($"{i + 1}. masa {masa[i]} tarafından rezerve edilmiştir.");
                }
            }
            if (sayac > 0)
            {
                //Console.WriteLine("Boş masamız vardır.");
               
            }
            else
            { 
                Console.WriteLine("Kafemizde boş masa kalmamıştır. Çıkış için ESC tuşuna basınız.");
                k:
                ConsoleKeyInfo cikis = new ConsoleKeyInfo();
                cikis = Console.ReadKey(true);
                if (cikis.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Yanlış tuşa bastınız. Tekrar deneyiniz.");
                    goto k;
                }

            }

        }

        public static void masaSec()
        {
            
            Console.WriteLine("Lütfen seçmek istediğiniz masa numarasını giriniz. ");

            try
            {
                int basilan = int.Parse(Console.ReadLine());
                if (masa[basilan - 1] == "")
                {
                    masa[basilan - 1] = isim;
                    Console.WriteLine($"{basilan} nolu masa {isim} tarafından rezerve edilmiştir.");
                    //masaKontrol();
                }
                else
                {
                    Console.WriteLine($"Seçmek istediğiniz masa daha önceden {masa[basilan - 1]} tarafından rezerve edilmiştir.");
                    masaSec();
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Hatalı giriş yaptınız. Tekrar deneyiniz.");
                masaSec();
            }


        }
        public static void menu()
        {

            m:
            Console.WriteLine("Ne arzu edersiniz? İçecek seçimi için 1'e , Yiyecek seçimi için 2'ye basınız.");
            try
            {
                secim = Convert.ToInt32(Console.ReadLine());
                if (secim != 1 && secim != 2)
                {
                    Console.WriteLine("Yanlış tuşa bastınız. Tekrar deneyiniz.");
                    goto m;
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Hatalı giriş yaptınız. Tekrar deneyiniz. ");
                goto m;
            }

            if (secim == 1)
            {
                icecekSecimi();
            }
            else if (secim == 2)
            {
                yiyecekSecimi();

            }

        }

        public static void icecekSecimi()
        {
            siparisSayac = 0;
            List<string> icecekList = new List<string>();
            icecekList.Add("1- Siyah Çay (10 TL)");
            icecekList.Add("2- Yeşil Çay (15 TL)");
            icecekList.Add("3- Filtre Kahve (25 TL)");
            icecekList.Add("4- Türk Kahvesi (20 TL)");
            icecekList.Add("5- Limonata (15 TL)");
            Console.WriteLine();
            f:
            foreach (var item in icecekList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("İçeceklerden neyi tercih edersiniz? İstediğiniz içeceğin numarasını giriniz: ");
            try
            {
                icecekSecim = Convert.ToInt32(Console.ReadLine());
                if (icecekSecim != 1 && icecekSecim != 2 && icecekSecim != 3 && icecekSecim != 4 && icecekSecim != 5)
                {
                    Console.WriteLine("Yanlış tuşa bastınız. Tekrar deneyiniz. ");
                    goto f;
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Hatalı tuşa bastınız. Tekrar deneyiniz. ");
                goto f;
            }
            Icecek i = new Icecek();
            Siparis s = new Siparis();
            siparisSayac++;
            switch (icecekSecim)
            {
                case 1:
                    i.Ad = "Siyah Çay (10 TL)";
                    s.Tutar = 10.0;
                    break;
                case 2:
                    i.Ad = "Yeşil Çay (15 TL)";
                    s.Tutar = 15.0;
                    break;
                case 3:
                    i.Ad = "Filtre Kahve (25 TL)";
                    s.Tutar = 25.0;
                    break;
                case 4:
                    i.Ad = "Türk Kahvesi (20 TL)";
                    s.Tutar = 20.0;
                    break;
                case 5:
                    i.Ad = "Limonata (15 TL)";
                    s.Tutar = 15.0;
                    break;
            }
            s.SiparisID = siparisSayac;
            siparisList.Add(s);
            secimYapma();
            

        }

        public static void yiyecekSecimi()
        {
            siparisSayac = 0;
            List<string> yiyecekList = new List<string>();
            yiyecekList.Add("1- Sandviç (10 TL)");
            yiyecekList.Add("2- Kaşarlı Tost (15 TL)");
            yiyecekList.Add("3- Çikolatalı Pasta (35 TL)");
            yiyecekList.Add("4- Tuzlu & Tatlı Kuru Pasta (25 TL)");
            yiyecekList.Add("5- Cheesecake (20 TL)");
            Console.WriteLine();
            t:
            foreach (var item in yiyecekList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Yiyeceklerden neyi tercih edersiniz? İstediğiniz yiyeceğin numarasını giriniz: ");
            try
            {
                yiyecekSecim = Convert.ToInt32(Console.ReadLine());
                if (yiyecekSecim != 1 && yiyecekSecim != 2 && yiyecekSecim != 3 && yiyecekSecim != 4 && yiyecekSecim != 5)
                {
                    Console.WriteLine("Yanlış tuşa bastınız. Tekrar deneyiniz. ");
                    goto t;
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Hatalı tuşa bastınız. Tekrar deneyiniz. ");
                goto t;
            }
            Yiyecek y = new Yiyecek();
            Siparis s2 = new Siparis();
            siparisSayac++;
            switch (yiyecekSecim)
            {
                case 1:
                    y.Ad = "Sandviç (10 TL)";
                    s2.Tutar = 10.0;
                    break;
                case 2:
                    y.Ad = "Kaşarlı Tost (15 TL)";
                    s2.Tutar = 15.0;
                    break;
                case 3:
                    y.Ad = "Çikolatalı Pasta (35 TL)";
                    s2.Tutar = 35.0;
                    break;
                case 4:
                    y.Ad = "Tuzlu & Tatlı Pasta (25 TL)";
                    s2.Tutar = 25.0;
                    break;
                case 5:
                    y.Ad = "Cheesecake (20 TL)";
                    s2.Tutar = 20.0;
                    break;
            }
            s2.SiparisID = siparisSayac;
            siparisList.Add(s2);
            secimYapma();

        }

        public static void hesap()
        {
          
            Console.WriteLine("Siparişiniz tamamlandı. Bizi tercih ettiğiniz için teşekkür ederiz.");
                   
            for (int j = 0; j < siparisList.Count; j++)
            {
                toplam += siparisList[j].Tutar;

            }
            Console.WriteLine($"Toplam sipariş tutarınız: {toplam} TL");

            for (int z = 0; z < siparisList.Count; z++)
            {
                siparisList[z].Tutar = 0;
            }


        }

        public static void secimYapma()
        {
            g:
            Console.WriteLine("İlave bir seçim yapmak ister misiniz? İçecek seçimi için 1'e , yiyecek seçimi için 2'ye basınız. Herhangi bir seçim yapmak istemiyorsanız 3'e basınız. ");
            try
            {
                secim = Convert.ToInt32(Console.ReadLine());
                if (secim != 1 && secim != 2 && secim != 3)
                {
                    Console.WriteLine("Yanlış tuşa bastınız. Tekrar deneyiniz.");
                    goto g;
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Hatalı giriş yaptınız. Tekrar deneyiniz. ");
                goto g;
            }

            if (secim == 1)
            {
                icecekSecimi();
            }
            else if (secim == 2)
            {
                yiyecekSecimi();

            }
            else if (secim == 3)
            {
                hesap();
            }

        }
    }
}
