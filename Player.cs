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
        public Player(string Name) : base(120, 15, 25)  //health , damage and armor
        {
            this.name = Name;
            this.level = 1;
            this.totalHp = hp;
            this.xpNeeded = SetNeededXp();
        }

        // Setting the  getters upp

        public string GetHp()
        { 
            return hp.ToString();
        }

        public string GetTotalHp()
        {
            return totalHp.ToString();
        }

        public string GetGolds()
        {
            return golds.ToString();
        }

        public string GetDp()
        {
            return damage.ToString();
        }

        public string GetLevel()
        {
            return level.ToString();
        }

        public string GetXp()
        {
            return xp.ToString();
        }

        public string XpToLevel()
        {
            return xpNeeded.ToString();
        }

        public string GetArmor()
        {
            return armor.ToString();
        }
   

        // Visual Expiriance bar

        public string ShowXp(int xp, int totalXp)
        {
            Console.WriteLine("Experience bar");
            int barLength = 100;
            double percentXp = SetNeededXp() * barLength;
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


        // Simple level up formula
        public void CheckLevelUp()
        {
            if (xp > xpNeeded)
            {
                level++;
                Program.WriteFormattedLine("{0}", Program.colors[9], "/You have leveld upp >>> " + GetLevel() + "-You need to get to level 10");
                xp -= xpNeeded;
                xpNeeded = SetNeededXp();
                //hp += Convert.ToInt32(totalHp / 3);
                //totalHp = Convert.ToInt32(totalHp * 1.25);
                hp = SetHp();
                damage = SetDp();
                armor = SetArmor();
                totalHp = hp;
            }
        }

        //This section is for setting players the  XP, health ,damage and armor
        //
        public int SetNeededXp()
        {
            double tempXp = 10 * RandomEvents.NextDouble(2, 3);

            return Convert.ToInt32(tempXp);
        }

        private int SetHp()
        {
            double tempHp = 120 + RandomEvents.NextDouble(50, 100);

            return Convert.ToInt32(tempHp);
        }

        //
        private int SetDp()
        {
            double tempDp = 2 * RandomEvents.NextDouble(5, 10);

            return Convert.ToInt32(tempDp);
        }

        private int SetArmor()
        {
            double tempArmor = 10 + RandomEvents.NextDouble(10, 30);

            return Convert.ToInt32(tempArmor);
        }


}
}