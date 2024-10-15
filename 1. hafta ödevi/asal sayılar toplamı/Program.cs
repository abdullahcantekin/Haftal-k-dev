using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace asal_sayılar_toplamı
{
    class Program
    {
        static void Main(string[] args)
        {

            #region
            Console.Write("Lütfen bir sayı girin: ");
                int n = int.Parse(Console.ReadLine()); // Kullanıcıdan bir sayı alınır ve int'e dönüştürülür.

                int toplam = 0; // Asal sayıların toplamını tutacak değişken.

                for (int sayi = 2; sayi <= n; sayi++) // 2'den başlayarak N sayısına kadar her sayı kontrol edilir.
                {
                    if (AsalMi(sayi)) // Sayının asal olup olmadığını kontrol eden fonksiyon çağrılır.
                    {
                        toplam += sayi; // Eğer sayı asal ise toplam değişkenine eklenir.
                    }
                }

                Console.WriteLine($"1'den {n}'e kadar olan asal sayıların toplamı: {toplam}");
            }

            // Bir sayının asal olup olmadığını kontrol eden fonksiyon.
            static bool AsalMi(int sayi)
            {
                if (sayi < 2) return false; // 2'den küçük sayılar asal değildir.

                for (int i = 2; i <= Math.Sqrt(sayi); i++) // Sayının kareköküne kadar olan sayılarla kontrol edilir.
                {
                    if (sayi % i == 0) // Eğer sayı herhangi bir sayıya tam bölünüyorsa asal değildir.
                    {
                        return false;
                    }
                }
                return true; // Eğer sayı hiçbir sayıya tam bölünmüyorsa asal sayıdır.
            #endregion
        }
    }

    }


