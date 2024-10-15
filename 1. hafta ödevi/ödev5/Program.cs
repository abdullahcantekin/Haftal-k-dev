using System;
using System.Collections.Generic;

class Program
{
    // Dört ana yön: yukarı, aşağı, sağ, sol
    static int[,] directions = new int[,]
    {
        { 0, 1 }, // sağ
        { 1, 0 }, // aşağı
        { 0, -1 }, // sol
        { -1, 0 }  // yukarı
    };

    static void Main()
    {
        #region
        int[,] labirent = {
            { 1, 0, 0, 0 },
            { 1, 1, 0, 1 },
            { 0, 1, 1, 1 },
            { 0, 0, 0, 1 }
        };

        int result = EnKisaYoluBul(labirent);

        if (result != -1)
            Console.WriteLine("En Kısa Yol: " + result + " adım");
        else
            Console.WriteLine("Yol Yok");
    }

    static int EnKisaYoluBul(int[,] labirent)
    {
        int n = labirent.GetLength(0);

        // Eğer başlangıç ya da bitiş noktasında bir engel varsa, doğrudan "Yol Yok" diyelim.
        if (labirent[0, 0] == 0 || labirent[n - 1, n - 1] == 0)
            return -1;

        bool[,] ziyaretEdildi = new bool[n, n]; // Ziyaret edilen hücreleri tutan dizi.
        Queue<Tuple<int, int, int>> queue = new Queue<Tuple<int, int, int>>();

        // Başlangıç noktası (0, 0) ve adım sayısı 1 olarak kuyruğa ekleniyor.
        queue.Enqueue(Tuple.Create(0, 0, 1));
        ziyaretEdildi[0, 0] = true;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            int x = current.Item1;
            int y = current.Item2;
            int steps = current.Item3;

            // Eğer hazineye (N-1, N-1) ulaşıldıysa adım sayısını döndür.
            if (x == n - 1 && y == n - 1)
                return steps;

            // Dört farklı yönde komşuları kontrol et.
            for (int i = 0; i < 4; i++)
            {
                int newX = x + directions[i, 0];
                int newY = y + directions[i, 1];

                // Eğer yeni koordinatlar geçerli ve henüz ziyaret edilmediyse ve 1 ise, kuyruğa ekle.
                if (IsValid(newX, newY, n) && labirent[newX, newY] == 1 && !ziyaretEdildi[newX, newY])
                {
                    queue.Enqueue(Tuple.Create(newX, newY, steps + 1));
                    ziyaretEdildi[newX, newY] = true; // Ziyaret edildi olarak işaretle.
                }
            }
        }

        // Kuyruk boşaldı ve hazineye ulaşılamadıysa "Yol Yok".
        return -1;
    }

    // Yeni koordinatların gridin içinde olup olmadığını kontrol eden fonksiyon.
    static bool IsValid(int x, int y, int n)
    {
        return x >= 0 && x < n && y >= 0 && y < n;
        #endregion
    }
}

