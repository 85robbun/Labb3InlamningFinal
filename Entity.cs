using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3InlamningFinal
{
    class Entity
    {
        //public string name { get; set; } TO DO adding random monsters
        public int hp { get; set; }

        public int damage { get; set; }
        public int armor { get; set; }

        public Entity(int hp, int dp, int armor)
        {
            this.hp = hp;
            this.damage = dp;
            this.armor = armor;
        }

        public void receiveAttack(Entity attacker)
        {
            double multiplier = (double)50 / (50 + armor);
            int input = Convert.ToInt32((double)attacker.damage * multiplier);
            hp -= Convert.ToInt32((double)attacker.damage * multiplier);
            if (this.hp < 0)
                this.hp = 0;
        }

        public void showDamage(Entity attacker)
        {
            Console.WriteLine();
        }
    }
}
 

