using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace masivyi
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int n=10; // количество недель
            int d=7; // количество дней в неделе
            int p=2; // 2 варианта оплаты: наличный и безналичный
            int[, ,] m = new int[n, d, p]; //массив оплаты наличными и безналичными по дням недели

            for (int x = 0; x < n; x++)
            {
                Console.WriteLine("{0} неделя",x+1);
                for (int y = 0; y < d; y++)
                {
                    Console.WriteLine("   день {0}",y+1);
                    for (int z = 0; z < p; z++)
                    {
                        m[x, y, z] = rnd.Next(0, 1000)/50;
                        if (z == 0) Console.WriteLine("      Наличный расчет - {0}", m[x, y, z]);
                        else Console.WriteLine("      Безналичный расчет - {0}", m[x, y, z]);
                    }
                    Console.WriteLine("");
                }
            }
            
            // Общее число покупателей
            int kp = 0;
            for (int x = 0; x < n; x++)
            {
                for (int y = 0; y < d; y++)
                {
                    for (int z = 0; z < p; z++)
                    {
                        kp = kp + m[x, y, z];
                    }
                }
            }
            Console.WriteLine("Общее число покупателей: {0}", kp);

            // Число покупателей расплатившихся наличными
            int kpn = 0;
            for (int x = 0; x < n; x++)
            {
                for (int y = 0; y < d; y++)
                {
                    kpn = kpn + m[x, y, 0];
                }
            }
            Console.WriteLine("Число покупателей расплатившихся наличными: {0}", kpn);

            // Число покупателей расплатившихся картами
            int kpb = 0;
            for (int x = 0; x < n; x++)
            {
                for (int y = 0; y < d; y++)
                {
                    kpb = kpb + m[x, y, 1];
                }
            }
            Console.WriteLine("Число покупателей расплатившихся картами: {0}", kpb);

            //в какие недели была ситуация, когда наличными платили больше, чем картой
            int nr = 0, br = 0;
            for (int x = 0; x < n; x++)
            {
                for (int y = 0; y < d; y++)
                {
                    nr = nr + m[x, y, 0];
                    br = br + m[x, y, 1];
                }
                if (nr > br) Console.WriteLine("На {0} недели наличными платили больше чем картой. Наличными - {1}, картой- {2}", x+1,nr,br);
            }

        }
    }
}
