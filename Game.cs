﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3InlamningFinal
{
    class Game
    {
        private Player player;
        public Game(Player player)

        {
            this.player = player;
            Console.Clear();
            Console.WriteLine("Reach level 10 to win  the game: " + player.name + "\n");
            Console.WriteLine();
            Program.WriteFormattedLine("[{0}] ({1}/{2})", Program.colors[9], player.showXp(player.xp, player.xpNeeded), player.getXp(), player.XpToLevel());
            Program.WriteFormattedLine("You have ({0}/{1}) HP", Program.colors[8], player.getHp(), player.getTotalHp());
            Program.WriteFormattedLine("Your damage is {0} ", Program.colors[7], player.getDp());
            Program.WriteFormattedLine("You are Level {0}", Program.colors[6], player.getLevel());
            Program.WriteFormattedLine("You have {0} Gold", Program.colors[5], player.getGolds());
            Console.WriteLine("\n \n");

            Program.WriteFormattedLine("Press {0} to fight", Program.colors[4], "f");
            Program.WriteFormattedLine("Press {0} to go to shop", Program.colors[4], "s");
            Program.WriteFormattedLine("Press {0} to quit the game", Program.colors[4], "q");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.F: new Combat(player); break;
                case ConsoleKey.S: new Shop(player); break;
                case ConsoleKey.Q: new Exit(); break;
                default: new Game(player); break;
            }
        }
    }
}

