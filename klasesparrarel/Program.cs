using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace klasesparrarel
{
    class Program
    {
        public static int Length(string x) // kapec javeido sava, ja ir iebuveta char skaitishanas funkcija? 
                                           // -> "Izveidot funkciju Length(), kas saņem string tipa mainīgo x un atgriež tā garumu (garuma pārbaude ir jārealizē izmantojot ciklu)"
        {
            int l = 0;
            foreach (char i in x)
            {
                l++;
            }

            return l;
        }
        static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();

            //watch.Start();
            //for (long i = 20; i < 50; i++)
            //{
            //    double k = Math.Pow(2, i);
            //    Console.WriteLine(k);
            //}
            //watch.Stop();
            //Console.WriteLine($"Time: {watch.ElapsedMilliseconds} ms");                          ====== > // 23 ms 

            //watch.Start();
            //Parallel.For(20, 50, i =>
            //{
            //    double k = Math.Pow(2, i);
            //  Console.WriteLine(k);
            //});
            //watch.Stop();
            //Console.WriteLine($"Time: {watch.ElapsedMilliseconds} ms");                         =====> //76 ms

            ///////////////////////////////////////////////////////////////////////////////// 2.Uzd

            watch.Start();
            Random r = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string[] lol = new string[10];
            for (int i = 0; i < 10; i++)
            {
                char[] viens = new char[r.Next(99, 10000)];

                for (int j = 0; j < viens.Length; j++)
                {
                    viens[j] = chars[r.Next(chars.Length)];
                }

                string a = new string(viens);
                lol[i] = a;
            }
            
            List<string> k = new List<string>(lol);
            int sk = 0;
            //foreach (string b in k)
            //{      
            //    Console.WriteLine($"{sk} stringa izmers ir {Length(b)}");
            //    sk++;
            //}
           // Console.WriteLine($"Time: {watch.ElapsedMilliseconds} ms");  /// ======================> 18 ms 
            
            Parallel.ForEach(k, i =>
            {
                Console.WriteLine($"string izmers ir {Length(i)}");
                sk++;
            });
            watch.Stop();

            Console.WriteLine($"Time: {watch.ElapsedMilliseconds} ms");  /// ======================> 75 ms 
        }
    }
}
