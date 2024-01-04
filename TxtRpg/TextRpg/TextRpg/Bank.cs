using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg
{
    public class Bank
    {
        int gold = 100000;
        public int Gold { get { return gold; } }

        public void Deposit(int mout)
        {
            gold += mout;
        }
        public bool BuyItem(int mout)
        {
            if (gold < mout)
            {
                Console.WriteLine("Gold가 부족합니다.");
                return false;
            }
            gold -= mout;
            Console.WriteLine("구매를 완료했습니다.");
            return true;
        }
        public void sellItem(int mount)
        {
            gold += (int)(mount * 0.8);
        }
    }
}
