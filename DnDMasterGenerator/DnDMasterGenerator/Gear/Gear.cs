using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDClassesTest
{
    public abstract class Gear 
    {
        public string name;
        public List<String> items = new List<String>();
        public Gear()
        {

        }

        public void setGear(Gear a)
        {

        }

        public abstract string getName();
        public abstract string toString();
        public abstract int calcAC();
    }
}


