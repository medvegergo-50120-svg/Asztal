using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idk_anymore
{
    public class Player
    {
        public enum Teruletek
        {
            Erdo,
            Otthon,
            Ret,
            Sivatag,
            To,
        }
        public enum Item
        {
            Fa,
            Etel,
            Ital,
            Gyogynoveny,
            Alkohol
        }
        public string Nev { get; set; }
        public bool Ittas { get; set; }
        public int HP { get; set; }
        public int MaxHP { get; set; }
        public int MaxÉtel { get; set; }
        public int Étel { get; set; }
        public int Víz { get; set; }
        public int Fa { get; set; }
        public int Sebzes { get; set; }
        public Teruletek Helység { get; set; }
        public List<Item> Inventory = new List<Item>();
        bool tamadas = false;
        public Player(string nev, int maxhp, int maxEtel, int sebzes)
        {
            Nev = nev;
            MaxHP = maxhp;
            HP = maxhp;
            Étel = maxEtel;
            MaxÉtel = maxEtel;
            Sebzes = sebzes;
            Helység = Teruletek.Otthon;
        }
        public void Ehezes()
        {
            Étel -= 1;
        }
        public void Pia()
        {
            if (Inventory.Contains(Item.Alkohol))
            {
                Console.WriteLine("Elhasználtál egy alkoholt, a karakter részeg lett!");
                Ittas = true;
                Inventory.Remove(Item.Alkohol);
                return;
            }
            Console.WriteLine("Nincs rendelkezésre álló hangulatmódosító szer!");
        }
        public void Heal()
        {
            if (Inventory.Contains(Item.Gyogynoveny) && HP <= MaxHP - 2)
            {
                HP += 2;
                Console.WriteLine("Elhasználtál egy gyógynövényt + 2HP");
                Inventory.Remove(Item.Gyogynoveny);
            }
            else if (HP == MaxHP && Inventory.Contains(Item.Gyogynoveny))
            {
                Console.WriteLine("Már tele vagy, nem használhatsz gyógynövényt");
                return;
            }
            else if (HP == (MaxHP - 1) && Inventory.Contains(Item.Gyogynoveny))
            {
                HP += 1;
                Console.WriteLine("Már majdnem tele vagy, csak 1 HPt adott a gyógynövény dumbass");
                Inventory.Remove(Item.Gyogynoveny);
            }
            else
            {
                Console.WriteLine("Nincs gyógynövényed");
                return;
            }
        }
        public void Harc(Ellenség ellenség, int ut)
        {
            if (tamadas == true)
            {
                return;
            }
            if (ut == 1)
            {
                Tamadas(ellenség);
                ut++;
            }
            if (ut == 2)
            {
                ellenség.Tamadas(this);
                ut--;
            }
        }
        public void Tamadas(Ellenség ellenség)
        {
            if (HP == 0)
            {
                return;
            }
            tamadas = true;
            if (Ittas)
            {
                Console.WriteLine("A karakter táncolni kezdett és a levegőt ütötte");
                tamadas = false;
                return;
            }
            ellenség.Sebzodes(Sebzes, this);
            tamadas = false;
        }
        public void Halal()
        {
            if (HP <= 0)
            {
                Console.WriteLine("Meghaltál");
            }
        }
        public void Étkezés()
        {
            bool food = false;
            if (Étel == MaxÉtel)
            {
                Console.WriteLine("Tele vagy");
                return;
            }
            foreach (var item in Inventory)
            {
                if (item == Item.Etel)
                {
                    Étel += 1;
                    Inventory.Remove(item);
                    food = true;
                    Console.WriteLine("Élelem elfogyasztva");
                }
            }
            if (food == false)
            {
                Console.WriteLine("Nincs Étel");
            }
        }
        public void Ivás()
        {
            bool víz = false;
            foreach (var item in Inventory)
            {
                if (item == Item.Ital)
                {
                    Víz += 1;
                    Inventory.Remove(item);
                    víz = true;
                }
            }
            if (víz == false)
            {
                Console.WriteLine("Nincs víz");
            }
        }
        public void Favágás()
        {
            Inventory.Add(Item.Fa);
            Console.WriteLine("Kivágta a fát");
        }
        public void ShowInventory()
        {
            Console.WriteLine("Inventory:");
            foreach (var item in Inventory)
            {
                Console.WriteLine($"\t{item}");
            }
        }
        public void Mozgas(int opcio)
        {
            if (opcio == 1)
            {
                Helység = Teruletek.Erdo;
                Console.WriteLine("Az erdőben vagyunk");
            }
            if (opcio == 2)
            {
                Helység = Teruletek.Otthon;
                Console.WriteLine("Otthon vagyunk");
            }
            if (opcio == 3)
            {
                Helység = Teruletek.Ret;
                Console.WriteLine("A réten vagyunk");
            }
            if (opcio == 4)
            {
                Helység = Teruletek.Sivatag;
                Console.WriteLine("Sivatagban vagyunk");
            }
            if (opcio == 5)
            {
                Helység = Teruletek.To;
                Console.WriteLine("A tónál vagyunk");
            }
        }
        public void Sebződés()
        {
            HP -= 1;
        }
        public void Alvas()
        {
            if (Ittas)
            {
                Console.WriteLine("A karakter alszik, +1HP és a karakter kijózanodott");
                HP += 1;
            }
            else if(Ittas && HP == MaxHP)
            {
                Console.WriteLine("A karakter alszik, a karakter kijózanodott");
                return;
            }
            else if (HP == MaxHP)
            {
                Console.WriteLine("A karakter alszik, de már a HP maxon van");
                return;
            }
            else
            {
                Console.WriteLine("A karakter alszik, +1HP");
                HP += 1;
            }
            Ittas = false;
        }
        public void getÉtel()
        {
            Inventory.Add(Item.Etel);
            Console.WriteLine($"Szereztél kaját");
        }
        public void getGyogynoveny()
        {
            Inventory.Add(Item.Gyogynoveny);
            Console.WriteLine("Nice, kaptál egy gyógynövényt");
        }
    }
}
