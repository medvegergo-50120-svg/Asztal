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
            Player player = new Player("János", 10, 7, 1);
            Ellenség ellenség1 = new Ellenség(2, 1, "Erasmus kapitány");
            Ellenség ellenség2 = new Ellenség(6, 1, "Mazda");
            Ellenség ellenség3 = new Ellenség(10, 9, "Medve");
            Ellenség ellenség4 = new Ellenség(1, 2, "Taktaharkányi bajnok");
            Ellenség ellenség5 = new Ellenség(5, 3, "Fárajó");
            Ellenség ellenség6 = new Ellenség(100, 100, "Kiráj");
            Ellenség ellenség7 = new Ellenség(1, 100, "Szabolcs");
            Ellenség ellenség8 = new Ellenség(100, 1, "Hegedűs");
            Ellenség ellenség9 = new Ellenség(2, 2, "Pink Panther");
            List<Ellenség> ellensegek = new List<Ellenség>();
            ellensegek.Add(ellenség1);
            ellensegek.Add(ellenség2);
            ellensegek.Add(ellenség3);
            ellensegek.Add(ellenség4);
            ellensegek.Add(ellenség5);
            ellensegek.Add(ellenség6);
            ellensegek.Add(ellenség7);
            ellensegek.Add(ellenség8);
            ellensegek.Add(ellenség9);
            Random rand = new Random();
            Ellenség ellenség;
            int tuleltNapok = 0;
            int ido = 24;
            int opcio;
            int akcio;
            while (player.HP > 0)
            {
                Console.Clear();
                Console.WriteLine($"HP: {player.HP}/{player.MaxHP} | Étel: {player.Étel}/{player.MaxÉtel} | Víz: {player.Víz} | Fa: {player.Fa}");
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
                        player.Favágás();
                        ellenség = ellensegek[rand.Next(ellensegek.Count)];
                        Console.WriteLine($"Feltűnt egy szörny, a nagy és félelmetes {ellenség.Nev}!!");
                        Console.WriteLine("Az adott gombok a következő akciókat hajtják végre: \n \t" + $"\n \t1: Harc {ellenség.Nev}!" + "\n \t2: Menekülés");
                        Console.Write("Mit szeretnél csinálni? : ");
                        akcio = Convert.ToInt16(Console.ReadLine());
                        if (akcio == 0)
                        {
                            player.Pia();
                        }
                        if (akcio == 1)
                        {
                            Random random = new Random();
                            int ut = random.Next(1, 3);
                            while (player.HP > 0 && ellenség.HP > 0)
                            {
                                player.Harc(ellenség, ut);
                            }
                        }
                        if (akcio == 2)
                        {
                            Console.WriteLine("Coward");
                            player.Mozgas(akcio);
                        }
                        ellenség = ellensegek[rand.Next(ellensegek.Count)];
                    }
                    if (opcio == 2)
                    {
                        Console.WriteLine("Az adott gombok a következő akciókat hajtják végre:" + "\n \t 0: A karakter lerészegedik" + "\n \t 1: Inventory" + "\n \t 2: Alvás" + "\n \t 3: Evés" + "\n \t 4: Gyógynövény használata");
                        akcio = Convert.ToInt16(Console.ReadLine());
                        if (akcio == 0)
                        {
                            player.Pia();
                        }
                        if (akcio == 1)
                        {
                            player.ShowInventory();
                        }
                        if (akcio == 2)
                        {
                            player.Alvas();
                        }
                        if (akcio == 3)
                        {
                            player.Étkezés();
                        }
                        if (akcio == 4)
                        {
                            player.Heal();
                        }
                    }
                    if (opcio == 3)
                    {
                        Console.WriteLine("Az adott gombok a következő akciókat hajtják végre:" + "\n \t 1: Kajaszerzés");
                        akcio = Convert.ToInt16(Console.ReadLine());
                        if (akcio == 1)
                        {
                            player.getÉtel();
                        }
                    }
                    if (opcio == 4)
                    {
                        Console.WriteLine("Az adott gombok a következő akciókat hajtják végre:" + "\n \t 1: Nézzünk piramist");
                        akcio = Convert.ToInt16(Console.ReadLine());
                        if (akcio == 1)
                        {
                            player.getGyogynoveny();
                        }
                        if (akcio == 2)
                        {
                            
                        }
                    }
                    if (opcio == 5)
                    {
                        Console.WriteLine("Az adott gombok a következő akciókat hajtják végre:" + "\n \t 1: ");
                    }
                    tuleltNapok++;
                }
                catch (Exception)
                {
                    Console.WriteLine("Csak számot adjon meg!");
                }

                Console.ReadKey();
            }
            Console.WriteLine("Game Over");
            Console.WriteLine($"Túlélt napok: {tuleltNapok}");
        }
    }
}
