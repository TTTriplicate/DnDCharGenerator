using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNDGear
{
    public class Weapon : Gear
    {
        public int damageFactor, numDice;
        public bool finesse, twoHanded, versatile, loading, heavy, special;
        public Weapon(string name, int damageFactor, int numDice = 1)
        {
            this.name = name;
            this.damageFactor = damageFactor;
            this.numDice = numDice;
        }
        public Weapon(string name, int damageFactor, bool finesse = false, bool twoHanded = false, bool versatile = false, bool loading = false, bool heavy = false, bool special = false, int numDice = 1)
        {
            this.name = name;
            this.damageFactor = damageFactor;
            this.finesse = finesse;
            this.twoHanded = twoHanded;
            this.versatile = versatile;
            this.loading = loading;
            this.heavy = heavy;
            this.special = special;
            this.numDice = numDice;
        }

        /**
         * Method to override the abstract method toString() in Gear
         * @return temp a string representation of the object
         */
        public override string toString()
        {
            string temp =  name + "    " + damageFactor + "d" + numDice;
            if (finesse)
            {
                temp += "    Finesse";
            }

            if (twoHanded)
            {
                temp += "    Two Handed";
            }

            if (versatile)
            {
                temp += "    Versatile";
            }

            if(loading)
            {
                temp += "    Loading";
            }

            if(heavy)
            {
                temp += "    Heavy";
            }

            if (special)
            {
                temp += "    Special";
            }

            return temp;
        }

        /**
         * Getter method to return the name of the armor (overrides abstract method getName() in Gear
         * @return name the name of the armor
         */
        public override string getName()
        {
            return name;
        }

    }
}
