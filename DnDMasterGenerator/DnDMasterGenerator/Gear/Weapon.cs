using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDClassesTest
{
    public class Weapon : Gear
    {
        public int damageFactor, numDice;
        public bool finesse, twoHanded, versatile, loading, heavy, special;
        public string type;
        public Weapon(string name, int damageFactor, string type, int numDice = 1)
        {
            this.name = name;
            this.damageFactor = damageFactor;
            this.numDice = numDice;
            this.type = type;
        }
        public Weapon(string name, int damageFactor, string type, bool finesse = false, bool twoHanded = false, bool versatile = false, bool loading = false, bool heavy = false, bool special = false, int numDice = 1)
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
            this.type = type;
        }

        /**
         * Method to override the abstract method toString() in Gear
         * @return temp a string representation of the object
         */
        public override string toString()
        {
            string temp =  name + "    " + numDice + "d" + damageFactor;
            //if (finesse)
            //{
            //    temp += "    Finesse";
            //}

            //if (twoHanded)
            //{
            //    temp += "    Two Handed";
            //}

            //if (versatile)
            //{
            //    temp += "    Versatile";
            //}

            //if(loading)
            //{
            //    temp += "    Loading";
            //}

            //if(heavy)
            //{
            //    temp += "    Heavy";
            //}

            //if (special)
            //{
            //    temp += "    Special";
            //}

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

        public int getDamage()
        {
            return damageFactor;
        }
        public override int calcAC()
        {
            return 0;
        }

        public int calcATKBonus(DnDCharacter b)
        {
            if (type == "ranged thrown" || type == "ranged fired")
            {
                return b.ProficiencyBonus() + b.AbilityModifiers()[1];
            }
            else
            {
                return (b.ProficiencyBonus() + b.AbilityModifiers()[0]);
            }
        }

        public string calcDamage(DnDCharacter b)
        {
            if (type == "melee")
            {
                if (b.AbilityModifiers()[0] > -1)
                {
                    return numDice + "d" + damageFactor + " +" + b.AbilityModifiers()[0];
                }
                else
                {
                    return numDice + "d" + damageFactor + " " + b.AbilityModifiers()[0];
                }
            }
            else
            {
                if (b.AbilityModifiers()[1] > -1)
                {
                    return numDice + "d" + damageFactor + " +" + b.AbilityModifiers()[1];
                }
                else
                {
                    return numDice + "d" + damageFactor + " " + b.AbilityModifiers()[1];
                }
            }
        }
    }
}
