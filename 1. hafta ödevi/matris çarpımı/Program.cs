using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace matris_çarpımı
{
    class Program
    {
        static void Main(string[] args)
        {
            #region
            Console.Write("Matris boyutunu girin (N): ");
            int n = Convert.ToInt32(Console.ReadLine()); // Kullanıcıdan matrisin boyutunu alıyoruz.

            // NxN boyutunda iki matris oluşturuyoruz.
            int[,] matris1 = new int[n, n];
            int[,] matris2 = new int[n, n];
            int[,] carpimSonucu = new int[n, n]; // Çarpım sonucu için matris.

            // İlk matrisin elemanlarını kullanıcıdan alıyoruz.
            Console.WriteLine("1. Matrisin elemanlarını girin:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"matris1[{i}, {j}]: ");
                    matris1[i, j] = Convert.ToInt32(Console.ReadLine()); // Elemanları alıyoruz.
                }
            }

            // İkinci matrisin elemanlarını kullanıcıdan alıyoruz.
            Console.WriteLine("2. Matrisin elemanlarını girin:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"matris2[{i}, {j}]: ");
                    matris2[i, j] = Convert.ToInt32(Console.ReadLine()); // Elemanları alıyoruz.
                }
            }

            // Matris çarpım işlemi
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    carpimSonucu[i, j] = 0; // Çarpım sonucu matrisini sıfırlıyoruz.
                    for (int k = 0; k < n; k++)
                    {
                        carpimSonucu[i, j] += matris1[i, k] * matris2[k, j]; // Çarpım formülü
                    }
                }
            }

            // Çarpım sonucunu ekrana yazdırıyoruz.
            Console.WriteLine("Çarpım Sonucu:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(carpimSonucu[i, j] + "\t"); // Her elemanı tab ile ayırarak yazdırıyoruz.
                }
                Console.WriteLine(); // Satır sonu
                Console.ReadKey();
                #endregion
            }
        }
    }
}
