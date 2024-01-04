using System.Numerics;

namespace TextRpg
{
    internal class Program
    {
        enum SceneNum
        {
            StartScene = 0,
            StatusScene,
            InventoryScene,
        };
        static Bank bank;
        static List<Item> itemList;
        static List<Item> gottenItemList;
        static List<Item> equipedItemList;
        static char cusor = '>';
        static int cursonNum = 1;
        static void Main(string[] args)
        {
            
            Player player = new Player();
            bank = new Bank();
            itemList = new List<Item>();
            gottenItemList = new List<Item>();
            equipedItemList = new List<Item>();
            CreateItem();
            SceneNum sceneNum;
            StartScene(player);
            //GameStart(player);
        }
        static void StartScene(Player player)
        {
            Console.Clear();
            ConsoleKeyInfo c;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("           /\\                                                 /\\");
            Console.WriteLine(" _         )( ______________________   ______________________ )(         _");
            Console.WriteLine("(_)///////(**)______________________> <______________________(**)\\\\\\\\\\\\\\(_)");
            Console.WriteLine("           )(                                                 )(");
            Console.WriteLine("           \\/                                                 \\/");
            Console.WriteLine();
            Console.WriteLine("__________________________  ______________ ____________________  ________");
            Console.WriteLine("\\__    ___/\\_   _____/\\   \\/  /\\__    ___/ \\______   \\______   \\/  _____/");
            Console.WriteLine("  |    |    |    __)_  \\     /   |    |     |       _/|     ___/   \\  ___ ");
            Console.WriteLine("  |    |    |        \\ /     \\   |    |     |    |   \\|    |   \\    \\_\\  \\");
            Console.WriteLine("  |____|   /_______  //___/\\  \\  |____|     |____|_  /|____|    \\______  /");
            Console.WriteLine("                   \\/       \\_/                    \\/                  \\/ ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("=========================================================================");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            if(cursonNum == 1)
            {
                Console.WriteLine("                                {0} 게임 시작", cusor);
                Console.WriteLine("                                새 게임");
            }
            else
            {
                Console.WriteLine("                                게임 시작");
                Console.WriteLine("                                {0}새 게임", cusor);
            }
            do
            {
                c = Console.ReadKey();
                switch(c.Key)
                {
                    case ConsoleKey.UpArrow:
                        Console.WriteLine("위");
                        cursonNum--;
                        if (cursonNum > 2) cursonNum = 2;
                        break;
                       case ConsoleKey.DownArrow:
                        Console.WriteLine("아래");
                        cursonNum++;
                        if (cursonNum < 1) cursonNum = 1;
                        break;
                    case ConsoleKey.Enter:
                        if(cursonNum == 1)
                        {
                            GameStart(player);
                        }
                        break;
                }
                StartScene(player);
            } while(c.Key != ConsoleKey.Enter);

            GameStart(player);
        }
        static void GameStart(Player player)
        {
            Console.Clear();
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다. ");
            Console.WriteLine();
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine();
            Console.WriteLine("원하시는  행동을 입력해 주세요");
            Console.Write(">>");
            int nextAct = int.Parse(Console.ReadLine());
            switch (nextAct)
            {
                case 1:
                    StatusScene(player);
                    break;
                case 2:
                    InventoryScene(player);
                    break;
                case 3:
                    ShopScene(player);
                    break;
                case 4:
                    bank.BuyItem(100);
                    GameStart(player);
                    break;
                default:
                    Console.WriteLine("올바른 입력을 해주세요");
                    GameStart(player);
                    break;
            }
        }
        static void StatusScene(Player player)
        {
            CehckAddStatus(player);
            Console.Clear();
            Console.WriteLine("Lv.  {0}", player.level);
            Console.WriteLine("{0} ({1})", player.name, player.job);
            if (player.atkAfter > 0)
            {
                Console.WriteLine("공격력 : {0} (+{1})", player.atk, player.atkAfter);
            }
            else
            {
                Console.WriteLine("공격력 : {0} ", player.atk);
            }

            if (player.defAfter > 0)
            {
                Console.WriteLine("방어력 : {0} (+{1})", player.def, player.defAfter);
            }
            else
            {
                Console.WriteLine("방여력 : {0}", player.def);
            }
            Console.WriteLine("체력 : {0}", player.health);
            Console.WriteLine("Gold : {0} G", bank.Gold);
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">>");

            int nextAct = int.Parse(Console.ReadLine());
            switch (nextAct)
            {
                case 0:
                    GameStart(player);
                    break;
                default:
                    StatusScene(player);
                    Console.WriteLine("올바른 값을 입력해 주세요");
                    break;
            }
        }

        static void CehckAddStatus(Player player)
        {
            player.atkAfter = 0;
            player.defAfter = 0;
            foreach (Item item in equipedItemList)
            {
                if (item.status == "공격력")
                {
                    player.atkAfter += item.addStat;
                }
                else if (item.status == "방어력")
                {
                    player.defAfter += item.addStat;
                }
            }
        }
        static void InventoryScene(Player player)
        {
            int index = 1;
            gottenItemList.Clear();
            Console.Clear();
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다,");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            foreach (var item in itemList)
            {
                if (item.isGotten)
                {
                    item.index = index;
                    index++;
                    gottenItemList.Add(item);
                }
            }
            for (int i = 0; i < gottenItemList.Count; i++)
            {
                if (gottenItemList[i].isEquiped)
                {
                    Console.Write("-  [E]");
                }
                Console.WriteLine("{0}    |{1} +{2} |{3}        | ", gottenItemList[i].name, gottenItemList[i].status, gottenItemList[i].addStat, gottenItemList[i].description);
            }
            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            int nextAct = int.Parse(Console.ReadLine());
            switch (nextAct)
            {
                case 1:
                    EquipItem(player);
                    break;
                case 0:
                    GameStart(player);
                    break;
                default:
                    Console.WriteLine("올바른 값을 입력해 주세요");
                    InventoryScene(player);
                    break;
            }
        }

        static void EquipItem(Player player)
        {
            Console.Clear();
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < gottenItemList.Count; i++)
            {
                Console.Write("- {0}", i + 1);
                if (gottenItemList[i].isEquiped)
                {
                    Console.Write(" [E]");
                }
                Console.WriteLine(" {0}    |{1} +{2} |{3}        | ", gottenItemList[i].name, gottenItemList[i].status, gottenItemList[i].addStat, gottenItemList[i].description);
            }
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            int nextAct = int.Parse(Console.ReadLine());
            if (nextAct == 0)
            {
                InventoryScene(player);
            }
            foreach (Item item in gottenItemList)
            {
                if (item.index == nextAct)
                {
                    if (item.isEquiped)
                    {
                        break;
                    }
                    equipedItemList.Add(item);
                    item.isEquiped = true;
                }
            }
            EquipItem(player);
        }
        static void ShopScene(Player player)
        {
            Console.Clear();
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상접입니다. ");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine("{0} G", bank.Gold);
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < itemList.Count; i++)
            {
                Console.Write("- {0}    |{1} +{2} |{3}        | ", itemList[i].name, itemList[i].status, itemList[i].addStat, itemList[i].description);
                if (itemList[i].isGotten)
                {
                    Console.WriteLine("구매완료");
                }
                else
                {
                    Console.WriteLine("{0}G", itemList[i].cost);
                }
            }
            Console.WriteLine();
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">>");
            int nextAct = int.Parse(Console.ReadLine());
            switch (nextAct)
            {
                case 1:
                    ItemBuy(player);
                    break;
                case 2:
                    ItemSell(player);
                    break;
                case 0:
                    GameStart(player);
                    break;
                default:
                    Console.WriteLine("올바른 값을 입력해 주세요");
                    ShopScene(player);
                    break;
            }
        }

        static void ItemBuy(Player player)
        {
            Console.Clear();
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상접입니다. ");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine("{0} G", bank.Gold);
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < itemList.Count; i++)
            {
                Console.Write("-{0} {1}    |{2} +{3} |{4}        | ", i + 1, itemList[i].name, itemList[i].status, itemList[i].addStat, itemList[i].description);
                if (itemList[i].isGotten)
                {
                    Console.WriteLine("구매완료");
                }
                else
                {
                    Console.WriteLine("{0}G", itemList[i].cost);
                }
            }
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">>");
            int nextAct = int.Parse(Console.ReadLine());
            if (nextAct > 0 && itemList[nextAct - 1].isGotten)
            {
                ItemBuy(player);
            }
            else
            {
                switch (nextAct)
                {
                    case 0:
                        ShopScene(player);
                        break;
                    case 1:
                        bank.BuyItem(itemList[0].cost);
                        itemList[0].isGotten = true;
                        ShopScene(player);
                        break;
                    case 2:
                        bank.BuyItem(itemList[1].cost);
                        itemList[1].isGotten = true;
                        ShopScene(player);
                        break;
                    case 3:
                        bank.BuyItem(itemList[2].cost);
                        itemList[2].isGotten = true;
                        ShopScene(player);
                        break;
                    case 4:
                        bank.BuyItem(itemList[3].cost);
                        itemList[3].isGotten = true;
                        ShopScene(player);
                        break;
                    case 5:
                        bank.BuyItem(itemList[4].cost);
                        itemList[4].isGotten = true;
                        ShopScene(player);
                        break;
                    case 6:
                        bank.BuyItem(itemList[5].cost);
                        itemList[5].isGotten = true;
                        ShopScene(player);
                        break;
                    default:
                        ItemBuy(player);
                        break;
                }
            }
        }
        static void ItemSell(Player player)
        {
            Console.Clear();
            Console.WriteLine("판매하고 싶은 아이템을 선택해 주세요. ");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine("{0} G", bank.Gold);
            Console.WriteLine();
            Console.WriteLine("[보유한 아이템 목록]");
            for (int i = 0; i < gottenItemList.Count; i++)
            {
                Console.Write("{0}", i+1);
                Console.WriteLine(" {0}    |{1} +{2} |{3}        |{4} ", gottenItemList[i].name, gottenItemList[i].status, gottenItemList[i].addStat, gottenItemList[i].description, gottenItemList[i].cost);
            }
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">>");
            int nextAct = int.Parse(Console.ReadLine());
            if (nextAct == 0)
            {
                ShopScene(player);
            }
            foreach (Item item in gottenItemList)
            {
                if (item.index == nextAct)
                {
                    bank.sellItem(item.cost);
                    item.isGotten = false;
                    item.isEquiped = false;
                    gottenItemList.Remove(item);
                    equipedItemList.Remove(item);
                }
            }
            ItemSell(player);
        }

        static void CreateItem()
        {
            Item trainerArmor = new Item();
            trainerArmor.name = "수련자 갑옷";
            trainerArmor.status = "방어력";
            trainerArmor.addStat = 5;
            trainerArmor.description = "수련에 도움을 주는 갑옷입니다.";
            trainerArmor.cost = 1000;
            itemList.Add(trainerArmor);
            Item ironArmor = new Item();
            ironArmor.name = "무쇠갑옷";
            ironArmor.status = "방어력";
            ironArmor.addStat = 9;
            ironArmor.description = "무쇠로 만들어져 튼튼한 갑옷입니다.";
            ironArmor.cost = 2000;
            itemList.Add(ironArmor);
            Item spartanArmor = new Item();
            spartanArmor.name = "스파르타의 갑옷";
            spartanArmor.status = "방어력";
            spartanArmor.addStat = 15;
            spartanArmor.description = "스파르타의 전사들이 사용했다는 전설의 갑옷입니다..";
            spartanArmor.cost = 3500;
            itemList.Add(spartanArmor);
            Item oldSword = new Item();
            oldSword.name = "낡은 검";
            oldSword.status = "공격력";
            oldSword.addStat = 2;
            oldSword.description = "쉽게 볼 수 있는 낡은 검 입니다.";
            oldSword.cost = 600;
            itemList.Add(oldSword);
            Item bronzeAxe = new Item();
            bronzeAxe.name = "청동 도끼";
            bronzeAxe.status = "공격력";
            bronzeAxe.addStat = 5;
            bronzeAxe.description = "어디선가 사용했던거 같은 도끼입니다.";
            bronzeAxe.cost = 1500;
            itemList.Add(bronzeAxe);
            Item spratanSpear = new Item();
            spratanSpear.name = "스파르타의 창";
            spratanSpear.status = "공격력";
            spratanSpear.addStat = 7;
            spratanSpear.description = "스파르타의 전사들이 사용했다는 전설의 창입니다.";
            spratanSpear.cost = 4000;
            itemList.Add(spratanSpear);
        }
    }
}