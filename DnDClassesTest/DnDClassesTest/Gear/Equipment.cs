using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNDGear
{
    class Equipment : Gear
    {
        public Equipment(string name)
        {
            this.name = name;
        }

        public override string toString()
        {
            return this.ToString();
        }

        public override string getName()
        {
            return name;

        }
    }
}
