using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryConsoleAppOrnek
{
    class Program
    {
        static void Main(string[] args)
        {
            //C klasoru içinde kendi adımızla bir klasor oluşturmamız isteniyor.
            //Kullanıcıya klasoru sil -->1 klasoru taşı-->2 gibi menu sunmamız isteniyor.
            //Kullanıcı hangi işlemi seçerse o işlem yapılacaktır.
            //Silme işlemini seçerse emin misiniz? E/H sorusu sormamız ve verilecek cevaba göre silme işlemi yapmamız isteniyor.
            try
            {
                string myPath = "C:\\Beyza";
                if (KlasordenVarMi(myPath))
                {
                    Console.WriteLine("Klasorunuz sistemde mevcuttur!");
                }
                else
                {
                    KlasorOlustur(myPath);
                }
            Baslangic:
                Console.WriteLine("Klasor silmek için --> 1");
                Console.WriteLine("Klasor taşımak için --> 2 ");
                int islem = 0;
                ConsoleKeyInfo secim;
                islem = Convert.ToInt32(Console.ReadLine());
                if (islem==1)
                {
                    SilSorusu:
                    Console.WriteLine($"{myPath} directory'yi silmek istediğinize emin misiniz? E/H");
                    secim = Console.ReadKey();
                    switch(secim.Key)
                    {
                        case ConsoleKey.E:
                            KlasoruSil(myPath);
                            Console.WriteLine("Silindi!");
                            break;
                        case ConsoleKey.H:
                            Console.WriteLine("\n Silinmedi!");
                            goto Baslangic;
                        default:
                            Console.WriteLine("Lütfen size sorulan soruya uygun cevap veriniz!");
                            goto SilSorusu;
                    }
                }
                else if (islem==2)
                {
                    string yeniHedef;
                    Console.WriteLine("Hedef klasor isim veriniz:");
                    yeniHedef = Console.ReadLine();
                    string yeniYol = @"C:\" + yeniHedef;
                    KlasoruTasi(myPath, yeniYol);
                }
                else
                {
                    Console.WriteLine("Geçerli bir işlem tercihi yapmadınız!");
                    Console.Clear();
                    goto Baslangic;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("HATA: Beklenmedik bir hata oluştu!" + ex.Message);

            }
            Console.ReadKey();
        }
        private static void KlasorOlustur(string dosyaYolu)
        {
            DirectoryInfo di = Directory.CreateDirectory(dosyaYolu);
        }
        private static bool KlasordenVarMi(string dosyaYolu)
        {
            bool sonuc = false;
            sonuc = Directory.Exists(dosyaYolu);
            return sonuc;
        }
        private static void KlasoruSil(string dosyaYolu)
        {
            Directory.Delete(dosyaYolu);
        }
        private static void KlasoruTasi(string kaynakYol, string hedefYol)
        {
            Directory.Move(kaynakYol, hedefYol);
            Console.WriteLine($"Kaynak: {kaynakYol}, {hedefYol} hedefine taşındı");
        }
    }
}
