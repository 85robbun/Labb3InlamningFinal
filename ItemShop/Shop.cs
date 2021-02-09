using System;

namespace Labb3InlamningFinal
{
    class Shop
    {
        private Player player;

        public Shop(Player player, Item boughtItem = null, int error = 0, int page = 1)
        {
            this.player = player;

            // This is a good way to add the page according to Player Level , if player level 9 , shop page level 9 with items lvl 9 items.

            //int page = (p != 0 ? p : player.level);

            //Item shop with navigation right left arrow
            if (boughtItem is Item)
            {
                Console.WriteLine("You bought : " + boughtItem.name);
            }
            else
            {
                foreach (Item item in ItemsList.GetItemsPage(page, ItemsList.GetItems(player.level)))
                {
                    item.ShowItem();
                }
            }
            Console.WriteLine("\n ===================Page " + page + "====================");
            if (boughtItem is Item)
            {
                Program.WriteFormattedLine("Press any key to return back to the store", Program.colors[4], "");
                Console.ReadKey();
            }

            if (error == 1)
            {
                Program.WriteFormattedLine("{0}", Program.colors[4], "Not enough gold!,You have--> " + player.golds + "  gold on you");
            }

            if (error == 2)
            {
                Program.WriteFormattedLine("{0}", Program.colors[4], "Your health is full");
            }

            ShowShopInfo();
            string itemInput = "";
            if (!(boughtItem is Item))
            {
                ConsoleKey shopInput = Console.ReadKey().Key;
                switch (shopInput)
                {
                       case ConsoleKey.Enter:
                        Program.WriteFormattedLine("Enter{0} of item you want to buy", Program.colors[4], " ID number ");
                         itemInput = Console.ReadLine();
                       break;

                    case ConsoleKey.B: new Game(player); break;
                    case ConsoleKey.LeftArrow:
                        page--;
                        new Shop(player, null, 0, page);
                        break;

                    case ConsoleKey.RightArrow:
                        page++;
                        new Shop(player, null, 0, page);
                        break;

                    default: new Shop(player); break;
                }
            }
            if (Int32.TryParse(itemInput, out int res))
            {
                Item item = ItemsList.GetItems(player.level).Find(x => x.id == res);

                if (item == null || boughtItem is Item)
                {
                    new Shop(player);
                }
                else
                {
                    buyItem(item);
                }
            }
            else if (itemInput == "b")
            {
                new Game(player);
            }
            else
            {
                new Shop(player);
            }
        }
        public void ShowShopInfo()
        {
            if (player.level > 2 || player.golds >15)
            {
                Program.WriteFormattedLine("Navigate {0} with right and left key", Program.colors[4], "to scroll the page");
                Program.WriteFormattedLine("Press {0} to activate shop", Program.colors[4], "Enter");
                Program.WriteFormattedLine("Press {0} to return back to menu", Program.colors[4], "b");
                Program.WriteFormattedLine("{0}", Program.colors[6], "You have--> " + player.golds + "  gold on you");
            }
            else
            {
                Program.WriteFormattedLine("Press {0} to activate shop", Program.colors[4], "Enter");
                Program.WriteFormattedLine("Press {0} to return back to menu", Program.colors[4], "b");
                Program.WriteFormattedLine("{0}", Program.colors[6], "You have--> " + player.golds + "  gold on you");

            }
        }

        private void buyItem(Item item)
        {
            if (player.golds < item.golds)
            {
                new Shop(player, null, 1);
            }

            switch (item.itemType)
            {
                case 1:
                    if (player.hp == player.totalHp) new Shop(player, null, 2);
                    player.golds -= item.golds;
                    if (player.hp + item.value > player.totalHp) player.hp = player.totalHp;
                    else player.hp += item.value;
                    break;

                case 2: player.golds -= item.golds; player.armor += item.value; break;
                case 3: player.golds -= item.golds; player.damage += item.value; break;
                case 4: player.golds -= item.golds; player.totalHp += item.value; break;
            }

            new Shop(player, item, 0);
        }
    }
}

