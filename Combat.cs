using System;
using System.Linq;
using System.Threading;

namespace Labb3InlamningFinal
{
    internal class Combat
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

            RunCombat();
        }

        //Creating a visual bar to show player and enemy health
        private string VisualHp(int hp, int totalHp)
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

        

        //Method for combat when press key A attack
        private void RunCombat()
        {
            while (player.hp > 0 && monster.hp > 0)
            {
                ShowCombat();

                Program.WriteFormattedLine("Press {0} to attack!", Program.colors[4], "a");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.A:
                        player.ReceiveAttack(monster);
                        monster.ReceiveAttack(player);
                        break;
                       
                    default:
                        break;
                }
            }

            if (monster.hp <= 0)
                EndCombat(true);
            else
                EndCombat(false);
        }
        
        private void WonTheWar()
        {
            Program.WriteFormattedLine("{0}", Program.colors[2], "======== You have reached level 10 and Won the Game! ========");
            Program.WriteFormattedLine("{0}", Program.colors[2], "======== Game  exiting! ========");
            Thread.Sleep(3000);
            Environment.Exit(-1);
        }

        private void EndCombat(bool won, bool loop = false)
        {
            if (won)
            {
                ShowCombat();
                Console.WriteLine("\n");
                Program.WriteFormattedLine("{0}", Program.colors[2], "======== You have won this battle! ========");

                Program.WriteFormattedLine("{0}", Program.colors[14], "+ " + monster.goldReward + " G");
                if (!loop) player.golds += monster.goldReward;

                Program.WriteFormattedLine("{0}", Program.colors[11], "+ " + monster.xpReward + " XP");
                if (!loop) player.xp += monster.xpReward;

                player.CheckLevelUp();
        

                if (player.level == 10)
                {
                    WonTheWar();
                }
                Console.WriteLine();
                Program.WriteFormattedLine("Press{0} to return to Home an check to shop ", Program.colors[4], "b");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.B: GoHome(); break;
                    default: EndCombat(won, true); break;
                }
            }
            else
            {
                Program.gameOver();
                return;
            }
        }
        private void ShowCombat()
        {
            Console.Clear();
            Program.WriteFormattedLine("{0}", Program.colors[12], "You are encounterd an enemy:");
            Program.WriteFormattedLine("{0}", Program.colors[12], "Remember that for each new battle enemy gets stronger! \n");
            Program.WriteFormattedLine("[{0}] ({1}/{2}) HP // Armor : {3} //Damage: {4}", Program.colors[10], VisualHp(player.hp, totalPlayerHp), player.GetHp(), player.GetTotalHp(), player.GetArmor(), player.GetDp());
            Program.WriteFormattedLine("[{0}] {1} HP // Armor : {2} //Damage : {3}", Program.colors[12], VisualHp(monster.hp, totalMonsterHp), monster.GetHp(), monster.GetArmor(), monster.GetDp());
            Console.WriteLine("");
        }

        public void GoHome()
        {
            new Game(player);
        }
 
    }
}