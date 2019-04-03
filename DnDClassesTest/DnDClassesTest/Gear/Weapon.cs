using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNDGear
{
    class Weapon : Gear
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

        public bool validateProficiency()
        {
            return false;
        }

        public override string toString()
        {
            return name + " " + damageFactor + " " + finesse + " " + twoHanded + " " + versatile + " " + loading + " " + heavy + " " + special + " " + numDice;
        }

        public override string getName()
        {
            return name;
        }

    }
}
