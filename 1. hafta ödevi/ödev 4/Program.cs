using System;
using System.Collections.Generic;

class Program
{
    static int[,] directions = new int[,]
    {
#region
        { 0, 1 }, // sağ
        { 1, 0 }, // aşağı
        { 0, -1 }, // sol
        { -1, 0 }  // yukarı
    };

    static void Main()
    {
        int[,] grid = {
            { 1, 1, 0, 1 },
            { 0, 1, 0, 0 },
            { 1, 1, 1, 0 },
            { 0, 0, 1, 1 }
        };

        List<Tuple<int, int>> startingPositions = new List<Tuple<int, int>>()
        {
            Tuple.Create(0, 0), // Robot 1 başlangıç
            Tuple.Create(2, 2), // Robot 2 başlangıç
            Tuple.Create(3, 3)  // Robot 3 başlangıç
        };

        int result = MaxSavedNodes(grid, startingPositions);
        Console.WriteLine("Kurtarılan toplam düğüm sayısı: " + result);
    }

    static int MaxSavedNodes(int[,] grid, List<Tuple<int, int>> robots)
    {
        int n = grid.GetLength(0);
        bool[,] visited = new bool[n, n]; // Ziyaret edilen düğümleri işaretlemek için.

        int totalSavedNodes = 0; // Kurtarılan düğümlerin toplam sayısı.

        // Her robot için BFS ile kurtarılan düğümleri bulalım.
        foreach (var robot in robots)
        {
            totalSavedNodes += Bfs(grid, visited, robot.Item1, robot.Item2);
        }

        return totalSavedNodes;
    }

    static int Bfs(int[,] grid, bool[,] visited, int startX, int startY)
    {
        int n = grid.GetLength(0);

        // Eğer başlangıç noktası zaten ziyaret edilmişse veya zarar görmüşse (0), kurtarılamaz.
        if (visited[startX, startY] || grid[startX, startY] == 0)
            return 0;

        int savedNodes = 0;
        Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
        queue.Enqueue(Tuple.Create(startX, startY));
        visited[startX, startY] = true; // Başlangıç noktası ziyaret edildi.
        savedNodes++;

        // BFS ile komşu düğümleri dolaşalım.
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            int x = current.Item1;
            int y = current.Item2;

            for (int i = 0; i < 4; i++) // Dört farklı yöndeki komşuları kontrol et.
            {
                int newX = x + directions[i, 0];
                int newY = y + directions[i, 1];

                // Yeni koordinatlar gridin dışına çıkmamalı ve düğüm zarar görmemiş olmalı.
                if (IsValid(newX, newY, n) && !visited[newX, newY] && grid[newX, newY] == 1)
                {
                    queue.Enqueue(Tuple.Create(newX, newY));
                    visited[newX, newY] = true; // Ziyaret edildi olarak işaretle.
                    savedNodes++; // Bu düğüm kurtarıldı.
                }
            }
        }

        return savedNodes; // Bu robotun kurtardığı düğüm sayısı.
    }

    static bool IsValid(int x, int y, int n)
    {
        // Koordinatlar gridin sınırları içinde mi kontrol eder.
        return x >= 0 && x < n && y >= 0 && y < n;
        #endregion
    }
}
