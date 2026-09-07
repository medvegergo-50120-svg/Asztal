using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idk_anymore
{
    public class Ellenség
    {
        public int HP { get; set; }
        public int Sebzés { get; set; }
        public string Nev { get; set; }
        public Ellenség(int hp, int sebzes, string nev)
        {
            HP = hp;
            Sebzés = sebzes;
            Nev = nev;
        }
        public void Sebzodes(int amount, Player player)
        {
            HP -= amount;
            if (HP <= 0)
            {
                Console.WriteLine($"{Nev} meghalt.");
                player.Inventory.Add(Player.Item.Alkohol);
            }
        }
        public void Tamadas(Player player)
        {
            player.HP -= Sebzés;
        }
    }
}
