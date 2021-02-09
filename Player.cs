using System;
using System.Linq;

namespace Labb3InlamningFinal
{
    internal class Player : Entity
    {
        public string name;
        public int level = 0;
        public int golds = 0;
        public int totalHp = 0;
        public int xp = 0;
        public int xpNeeded = 0;
        private Player player;

        public Player(string Name) : base(120, 15, 25)  //health , damage and armor
        {
            this.name = Name;
            this.level = 1;
            this.totalHp = hp;
            this.xpNeeded = setNeededXp();
        }

        // Setting the  getters upp

        public string getHp()
        {
            return hp.ToString();
        }

        public string getTotalHp()
        {
            return totalHp.ToString();
        }

        public string getGolds()
        {
            return golds.ToString();
        }

        public string getDp()
        {
            return damage.ToString();
        }

        public string getLevel()
        {
            return level.ToString();
        }

        public string getXp()
        {
            return xp.ToString();
        }

        public string XpToLevel()
        {
            return xpNeeded.ToString();
        }

        public string getArmor()
        {
            return armor.ToString();
        }

        // Visual Expiriance bar

        public string showXp(int xp, int totalXp)
        {
            Console.WriteLine("Expirience bar");
            int barLength = 100;
            double percentXp = (double)xp / totalXp * barLength;
            int playerXp = Convert.ToInt32(percentXp);
            string bar = "";

            for (int i = 0; i < playerXp; i++)
            {
                bar += '#';
            }

            int currlength = bar.Length;
            int needed = barLength == currlength ? 0 : (barLength - currlength);

            return needed == 0 ? bar :
                (needed > 0 ? bar + new string('#', needed) :
                    new string(new string(bar.ToCharArray().Reverse().ToArray()).
                        Substring(needed * -1, bar.Length - (needed * -1)).ToCharArray().Reverse().ToArray()));
        }

        // Simple level upp formula
        public void checkLevelUp()
        {
            if (xp > xpNeeded)
            {
                level++;
                Program.WriteFormattedLine("{0}", Program.colors[9], "/You have leveld upp >>> " + getLevel() + "-You need to get to level 10");
                xp -= xpNeeded;
                xpNeeded = setNeededXp();
                //hp += Convert.ToInt32(totalHp / 3);
                //totalHp = Convert.ToInt32(totalHp * 1.25);
                hp = setHp();
                damage = setDp();
                armor = setArmor();
                totalHp = hp;
            }
        }

        //Making it pretty easy to level formula
        public int setNeededXp()
        {
            double tempXp = 10 + RandomEvents.NextDouble(20, 30);

            return Convert.ToInt32(tempXp);
        }

        private int setHp()
        {
            double tempHp = 120 + RandomEvents.NextDouble(50, 100);

            return Convert.ToInt32(tempHp);
        }

        //Lowering enemy damage so we can easily win
        private int setDp()
        {
            double tempDp = 15 + RandomEvents.NextDouble(10, 20);

            return Convert.ToInt32(tempDp);
        }

        private int setArmor()
        {
            double tempArmor = 10 + RandomEvents.NextDouble(10, 30);

            return Convert.ToInt32(tempArmor);
        }
    }
}