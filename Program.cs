using System;
using System.Collections.Generic;

namespace VotingUygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Pre-defined kategorileri oluşturun
            List<string> kategoriler = new List<string> { "Film Kategorileri", "Tech Stack Kategorileri", "Spor Kategorileri" };

            Dictionary<string, int> oySonuclari = new Dictionary<string, int>();

            Console.WriteLine("Voting Uygulamasına Hoş Geldiniz!");

            while (true)
            {
                Console.Write("Kullanıcı adınızı girin: ");
                string kullaniciAdi = Console.ReadLine();

                // Kullanıcı kayıtlı değilse kayıt işlemi yapın
                if (!oySonuclari.ContainsKey(kullaniciAdi))
                {
                    Console.WriteLine("Kayıtlı değilsiniz. Kayıt olmak istiyor musunuz? (E/H)");
                    string cevap = Console.ReadLine();
                    if (cevap.ToLower() == "e")
                    {
                        oySonuclari[kullaniciAdi] = 0;
                    }
                    else
                    {
                        Console.WriteLine("Oy verme işlemine devam edin...");
                        continue;
                    }
                }

                Console.WriteLine("Kategoriler:");
                for (int i = 0; i < kategoriler.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {kategoriler[i]}");
                }

                Console.Write("Oy vermek istediğiniz kategoriyi seçin (1-3): ");
                int secim = Convert.ToInt32(Console.ReadLine());

                if (secim >= 1 && secim <= kategoriler.Count)
                {
                    oySonuclari[kullaniciAdi]++;
                    Console.WriteLine("Oyunuz alındı!");
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim!");
                }

                Console.Write("Başka oy vermek istiyor musunuz? (E/H): ");
                string devam = Console.ReadLine();
                if (devam.ToLower() != "e")
                {
                    Console.WriteLine("Voting sonuçları:");
                    foreach (var kvp in oySonuclari)
                    {
                        double yuzde = (double)kvp.Value / oySonuclari.Count * 100;
                        Console.WriteLine($"{kvp.Key}: {kvp.Value} oy, %{yuzde:F2}");
                    }
                    break;
                }
            }
        }
    }
}
