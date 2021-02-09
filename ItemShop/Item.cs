using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3InlamningFinal
{
    class Item
    {
         
        /* Different Types of items in shop  : 1: Potion 2: Armor3: Damage 4: HP */
        public int id = 0;
        public int golds = 0;
        public int itemType = 0;
        public int value = 0;
        public int level = 0;
        public string name = "";
        public string desc = "";
        //public string desc = ""; Can be added do describe healing amount, attack damage,defence

        public Item(int id, int type, int value, int level, string name, string description, int golds)
        {
            this.id = id;
            this.itemType = type;
            this.value = value;
            this.level = level;
            this.name = name;
            this.desc = description;
            this.golds = golds;
        }

        private string GetItemType()
        {
            switch (itemType)
            {
                case 1: return "Health";
                case 2: return "Armour";
                case 3: return "Damage";
                case 4: return "HP Max";
                default: return "WrongItem";
            }
        }

        public void ShowItem()
        {
            Console.WriteLine("\n");
            Program.WriteFormattedLine("          " + name + " ({0} G)", Program.colors[14], golds.ToString());
            Console.WriteLine("          " + desc);
            Program.WriteFormattedLine("          {0}", Program.colors[5], NegOrPos(value) + value + " " + GetItemType());
            Console.WriteLine("          ID: " + id);
            Console.WriteLine("\n");
        }

        //Adding navigation buttons to the list
        private string NegOrPos(int value)
        {
            if (value < 0)
            {
                return "-";
            }
            else
            {
                return "+";
            }
        }
    }
}

