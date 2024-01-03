using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg
{
    internal class Item
    {
        public int index = -1;
        public bool isGotten = false;
        public bool isEquiped = false;
        public  string name;
        public string status;
        public int addStat;
        public string description;
        public int cost;
    }
}
