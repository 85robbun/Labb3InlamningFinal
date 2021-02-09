using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3InlamningFinal
{
    class ItemsList
    {
        //Creating simple list for items we can adjust
     
            private static List<Item> items = new List<Item> {
            new Item(0, 1, 30, 1, "Small Healing Potion","", 10),
            new Item(1, 3, 3, 1, "Basic Sword", "",15),
            new Item(2, 2, 10, 1, "Basic Armor", "",20),

            new Item(3, 1, 75, 2, "Medium Healing Potion","", 15),
            new Item(4, 3, 8, 2, "Long Sword", "",25),
            new Item(5, 2, 25, 2, "Medium Armor", "",40),

            new Item(6, 4, 150, 3, "HP-boost", "",30),
            new Item(7, 3, 25, 3, "Heavy Sword", "",50),
            new Item(8, 2, 45, 3, "Heavy Armor","", 60),
           
            new Item(9, 4, 300, 4, "Huge HP-boost", "",60),
            new Item(10, 3, 50, 4, "Heavest Sword", "",70),
            new Item(11, 2, 70, 4, "Heaviest Armor","", 80),
        };

            public ItemsList()
            {
            }

            //Sorting the tiems according id and creating sorted pages in order to navigate troghuh shop

            public static List<Item> GetItems(int level)
            {
                List<Item> sortedItems = items.FindAll(x => x.level <= level);

                return sortedItems;
            }

            public static List<Item> GetItemsPage(int level, List<Item> list)
            {
                List<Item> sortedPage = list.FindAll(x => x.level == level);

                return sortedPage;
            }
        
    }
}

