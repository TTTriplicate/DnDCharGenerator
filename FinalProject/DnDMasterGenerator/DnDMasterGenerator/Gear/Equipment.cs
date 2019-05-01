using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDClassesTest
{
    public class Equipment : Gear
    {
        
        public Equipment(string name)
        {
            this.name = name;
        }

        /**
         * Method to override the abstract method toString() in Gear
         * @return temp a string representation of the object
         */
        public override string toString()
        {
            return name;
        }

        /**
         * Getter method to return the name of the armor (overrides abstract method getName() in Gear
         * @return name the name of the armor
         */
        public override string getName()
        {
            return name;
        }

        public override int calcAC()
        {
            return 0;
        }
    }
}
