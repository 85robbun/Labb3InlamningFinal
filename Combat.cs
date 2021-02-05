using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace Labb3InlamningFinal
{
    class Combat
    {
        private Player player;
        private Monster monster;
        private int totalPlayerHp;
        private int totalMonsterHp;

        public Combat(Player player)
        {
            Console.Clear();
            this.player = player;
            monster = new Monster(player);
            this.totalPlayerHp = player.totalHp;
            this.totalMonsterHp = monster.hp;

            runCombat();
        }

        //Creating a visual bar to show player and enemy health
        private string visualHp(int hp, int totalHp)
        {
            int barLength = 40;
            double percentHp = (double)hp / totalHp * barLength;
            int playerHp = Convert.ToInt32(percentHp);
            string bar = "";

            for (int i = 0; i < playerHp; i++)
            {
                bar += '#';
            }

            int currlen = bar.Length;
            int needed = barLength == currlen ? 0 : (barLength - currlen);

            return needed == 0 ? bar :
                (needed > 0 ? bar + new string(' ', needed) :
                    new string(new string(bar.ToCharArray().Reverse().ToArray()).
                        Substring(needed * -1, bar.Length - (needed * -1)).ToCharArray().Reverse().ToArray()));
        }

        private void showCombat()
        {
            Console.Clear();
            Program.WriteFormattedLine("{0}", Program.colors[12], "You are encounterd an enemy ! \n");
            Program.WriteFormattedLine("{0}", Program.colors[12], "Remember that for each new battle enemy get stronger! \n");
            Program.WriteFormattedLine("[{0}] ({1}/{2}) HP // Armor : {3}", Program.colors[10], visualHp(player.hp, totalPlayerHp), player.getHp(), player.getTotalHp(), player.getArmor());
            Program.WriteFormattedLine("[{0}] {1} HP // Armor : {2}", Program.colors[12], visualHp(monster.hp, totalMonsterHp), monster.getHp(), monster.getArmor());
            Console.WriteLine("");
        }

        //Method for combat when press key A
        private void runCombat()
        {
            while (player.hp > 0 && monster.hp > 0)
            {
                showCombat();

                Program.WriteFormattedLine("Press {0} to attack!", Program.colors[4], "a");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.A:
                        player.receiveAttack(monster);
                        monster.receiveAttack(player);
                        break;

                    default:
                        break;
                }
            }
            if (monster.hp <= 0)
                endCombat(true);
            else
                endCombat(false);
        }

        private void wonTheWar()
        {
            Program.WriteFormattedLine("{0}", Program.colors[2], "======== You have reached level 10 and Won the Game! ========");
            Program.WriteFormattedLine("{0}", Program.colors[2], "======== Game  exiting! ========");
            Thread.Sleep(3000);
            Environment.Exit(-1);
        }

        private void endCombat(bool won, bool loop = false)
        {
            if (won)
            {
                showCombat();
                Console.WriteLine("\n");
                Program.WriteFormattedLine("{0}", Program.colors[2], "======== You have won this battle! ========");

                Program.WriteFormattedLine("{0}", Program.colors[14], "+ " + monster.goldReward + " G");
                if (!loop) player.golds += monster.goldReward;

                Program.WriteFormattedLine("{0}", Program.colors[11], "+ " + monster.xpReward + " XP");
                if (!loop) player.xp += monster.xpReward;

                player.checkLevelUp();

                if (player.level == 10)
                {
                    wonTheWar();
                }
                Console.WriteLine();
                Program.WriteFormattedLine("Press{0} to return to Home an check to shop ", Program.colors[4], "b");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.B: goHome(); break;
                    default: endCombat(won, true); break;
                }
            }
            else
            {
                Program.gameOver();
                return;
            }
        }

        public void goHome()
        {
            new Game(player);
        }
    }
}
    

