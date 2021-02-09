﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3InlamningFinal
{
    class Monster : Entity
    {
        public int xpReward;
        public int goldReward;
        private Player player;
        

   
        public Monster(Player mPlayer) : base(0, 0, 0)
        {
            this.player = mPlayer;
            this.hp = SetHp();
            this.damage = SetDp();
            this.goldReward = SetGoldReward();
            this.xpReward = SetXpReward();
            this.armor = SetArmor();
        }

        //Setting up enemy Values based on  level  ,

        //Adjusting enemy difficulty/stats according to Player level
        //Lowering enemy health so we can easily win in the beggining of the game
        
   
        private int SetHp()
       
        {
            double tempHp = 50 * RandomEvents.NextDouble(0.70, 0.70) * player.level;

            return Convert.ToInt32(tempHp);
        }

        //Lowering enemy damage so we can easily win
        private int SetDp()
        {
            double tempDp = 50 * RandomEvents.NextDouble(0.12, 0.12) * player.level;

            return Convert.ToInt32(tempDp);
        }

        private int SetGoldReward()
        {
            double tempReward = 20 * RandomEvents.NextDouble(0.60, 0.70) * player.level;

            return Convert.ToInt32(tempReward);
        }

        private int SetXpReward()
        {
            double tempXp = 100 * RandomEvents.NextDouble(0.42, 0.42) * player.level / 2;

            return Convert.ToInt32(tempXp);
        }

        private int SetArmor()
        {
            double tempArmor = 10 + (5 * RandomEvents.NextDouble(6.00, 6.00));

            return Convert.ToInt32(tempArmor);
        }

        public string GetHp()
        {
            return hp.ToString();
        }

        public string GetDp()
        {
            return damage.ToString();
        }

        public string GetArmor()
        {
            return armor.ToString();
        }
    }
}
 
