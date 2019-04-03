using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNDGear
{
    abstract class Gear 
    {
        public string name;
        public List<String> items = new List<String>();
        public Gear()
        {

        }

        //public static void openForm()
        //{
        //    Form1 gearForm = new Form1();
        //    gearForm.Show();
        //}


        public void setGear(Gear a)
        {

        }

        public abstract string getName();
        public abstract string toString();

        //public List<String> returnItems()
        //{
        //    return items;
        //}
    }
}



////Barbarian: 
//List<Gear>;
//myGear.Add(new Gear("Exporer’s pack"));
//myGear.addGear("Javelines (4)");

////Bard: 
//Gear myGear = new Gear();
//myGear.addGear("Leather armor");
//myGear.addGear("Dagger");

////Cleric: 
//Gear myGear = new Gear();
//myGear.addGear("Shield");
//myGear.addGear("Holy Symbol"); //????

//Druid: 
//Gear myGear = new Gear();
//myGear.addGear("Leather Armor");
//myGear.addGear("Explorer's pack");
//myGear.addGear("Druidic Focus");

//Fighter: 
//Gear myGear = new Gear();

//Monk: 
//Gear myGear = new Gear();
//myGear.addGear("Darts (10)");

//Paladin: 
//Gear myGear = new Gear();
//myGear.addGear("Holy Symbol");

//Ranger: 
//Gear myGear = new Gear();
//myGear.addGear("Longbow");
//myGear.addGear("Arrows (20)");

//Rogue: 
//Gear myGear = new Gear();
//myGear.addGear("Leather armor");
//myGear.addGear("Daggers (2)");
//myGear.addGear("Thieves' tools");

//Sorcerer: 
//Gear myGear = new Gear();
//myGear.addGear("Daggers (2)");

//Warlock: 
//Gear myGear = new Gear();
//myGear.addGear("Leather Armor");
//myGear.addGear("Daggers (2)");

//Wizard: 
//Gear myGear = new Gear();
//myGear.addGear("Spell book");

