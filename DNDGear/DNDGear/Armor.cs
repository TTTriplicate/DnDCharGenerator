using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNDGear
{
    public class Armor : Gear
    {
        public int armorClass, dexMod, maxMod;
        public bool disadvantage;
        //Constructor in the case of a maximum dex mod
        public Armor(string name, int armorClass, int dexMod, int maxMod, bool disadvantage = false)
        {
            this.name = name;
            this.armorClass = armorClass;
            this.dexMod = dexMod;
            this.maxMod = maxMod;
            this.disadvantage = disadvantage;
        }

        //Constructor in the case on no max dex mod
        public Armor(string name, int armorClass, int dexMod = 0, bool disadvantage = false)
        {
            this.name = name;
            this.armorClass = armorClass;
            this.dexMod = dexMod;
            maxMod = 2;
            this.disadvantage = disadvantage;
        }


        /**
         * Mutator method to calculate the armor class based on dexMod
         * @return the calculated armor class
         */
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

        /**
         * Getter method to return the name of the armor (overrides abstract method getName() in Gear
         * @return name the name of the armor
         */
        public override string getName()
        {
            return name;
        }

        /**
         * Method to override the abstract method toString() in Gear
         * @return temp a string representation of the object
         */ 
        public override string toString()
        {
            string temp = name + "    " + calcAC();
            if (disadvantage)
            {
                temp += "    disadvantage";
            }
            return temp;
        }
    }
}
