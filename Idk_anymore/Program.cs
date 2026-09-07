using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idk_anymore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(10, 7, 1);
            Ellenség ellenség = new Ellenség(2, 1, "Erasmus kapitány");
            int tuleltNapok = 0;
            int opcio;
            int akcio;
            while (player.HP > 0)
            {
                Console.Clear();
                Console.WriteLine("Az adott gombok a következő akciókat hajtják végre: \n" + "\t 1: Elmegyünk az erdőbe(tipp: Fa lelőhely!)" + "\n \t 2: Hazavisz (biztonságos zóna)" + "\n \t 3: A rétre visz (élelem szerzési lehetőség)" + "\n \t 4: A sivatagba visz (esély piramist nézni)" + "\n \t 5: A tóhoz visz (tipp: víz)");
                Console.Write("Mit szeretnél csinálni? : ");
                try
                {
                    opcio = Convert.ToInt16(Console.ReadLine());
                    player.Mozgas(opcio);
                    if (opcio == 1)
                    {
                        Console.WriteLine("Az adott gombok a következő akciókat hajtják végre: \n \t" + "1: Favágás");
                        akcio = Convert.ToInt16(Console.ReadLine());
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Csak számot adjon meg!");
                }

                Console.ReadKey();
            }
        }
    }
}
