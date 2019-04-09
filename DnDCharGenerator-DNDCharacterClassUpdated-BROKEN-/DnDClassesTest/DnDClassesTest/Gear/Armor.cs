using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNDGear
{
    class Armor : Gear
    {
        public int armorClass, dexMod, maxMod;
        public bool disadvantage;
        public Armor(string name, int armorClass, int dexMod, int maxMod, bool disadvantage = false)
        {
            this.name = name;
            this.armorClass = armorClass;
            this.dexMod = dexMod;
            this.maxMod = maxMod;
            this.disadvantage = disadvantage;
        }

        public Armor(string name, int armorClass, int dexMod = 0, bool disadvantage = false)
        {
            this.name = name;
            this.armorClass = armorClass;
            this.dexMod = dexMod;
            maxMod = 100;
            this.disadvantage = disadvantage;
        }

        public int calcAC()
        {
            if (dexMod >=2 && maxMod == 2)
            {
                return armorClass + 2;
            }
            else
            {
                return armorClass + dexMod;
            }
        }

        public override string getName()
        {
            return name;
        }

        public override string toString()
        {
            return name + " " + armorClass + " " + dexMod + " " + maxMod + " " + disadvantage;
        }
    }
}
