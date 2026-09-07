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
        public bool Ittas { get; set; }
        public int HP { get; set; }
        public int MaxHP { get; set; }
        public int Étel { get; set; }
        public int Víz { get; set; }
        public int Fa { get; set; }
        public int Sebzes { get; set; }
        public Teruletek Helység { get; set; }
        public List<Item> Inventory = new List<Item>();
        bool tamadas = false;
        public Player(int maxhp, int maxEtel, int sebzes)
        {
            MaxHP = maxhp;
            HP = maxhp;
            maxEtel = maxEtel;
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
                Ittas = true;
                Inventory.Remove(Item.Alkohol);
            }
        }
        public void Heal()
        {
            if (Inventory.Contains(Item.Gyogynoveny))
            {
                HP += 2;
            }
        }
        public void Harc(Ellenség ellenség)
        {
            if (tamadas == true)
            {
                return;
            }
            Tamadas(ellenség);
            ellenség.Tamadas(this);
        }
        public void Tamadas(Ellenség ellenség)
        {
            tamadas = true;
            if (Ittas)
            {
                Console.WriteLine("A karakter táncolni kezdett és a levegőt ütöti");
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
            foreach (var item in Inventory)
            {
                if (item == Item.Etel)
                {
                    Étel += 1;
                    Inventory.Remove(item);
                    food = true;
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
            HP += 1;
            Ittas = false;
        }
    }
}
