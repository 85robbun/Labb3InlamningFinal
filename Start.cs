using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3InlamningFinal
{
    class Start
    {
        private Player player;

        public Start()
        {
            Console.WriteLine("Welcome Fighter!");
            Console.WriteLine("Please choose your name : ");
            Console.WriteLine("if name = Robin ,god mod unlocked");
            string name = Console.ReadLine();
            player = new Player(name);
            if (name == "Robin")
            {
                player.damage = 10000;
                player.hp = 10000;
                player.armor = 10000;
                player.totalHp = player.hp;
                player.level = 9;
                player.xpNeeded = 1;
                player.golds = 1000;
            }
        }

        public void goHome()
        {
            new Game(player);
        }
    }
}
    

