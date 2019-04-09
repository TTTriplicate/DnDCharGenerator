using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DnDClassesTest
{
 /*   class Program
    {
        static void Main(string[] args)
        {
            DnDCharacter NewChar = new DnDCharacter();
        }
    }*/
    public class DnDCharacter
    {
        /*most of this will probably get set in a parameterized constructor
         * not sure yet how best to implement that.
         All part of the project later on
        protected int Level;
        public int _level
        {
            get
            {
                return Level;
            }
            set
            {
                Level = value;
            }
        }
        //get and set
        protected int[] Abilities = new int[6] { 8, 8, 8, 8, 8, 8 };
        public int[] _abilities
        {
            get
            {
                return Abilities;
            }
            set
            {
                Abilities = value;
            }
        }*/
        //STR, DEX, CON, INT, WIS, CHA, in that order for all int[6]
        //get and set(RNG and point buy system in user interface)
        //default to all 8s for point buy start
        //protected Profession CharClass { get; set; }
        //public Profession _class
        //{
        //    get
        //    {
        //        return CharClass;
        //    }
        //    set
        //    {
        //        CharClass = value;
        //    }
        //}
        //get and set(Profession library, Chris)
  //      protected Race Race { get; set; }
        //get and set(Race library, Dylan)
 //       protected Background_Class Background { get; set; }
        //get and set(Background libraries, Jack)
 //       protected List<Gear> Inventory;
        //add and remove methods? (Item library, Catherine)
        //equiped vs. carried?
        //        protected List<string> SkillList;
        //bool[]?
        //add methods from class and background, some user interaction to pick from list
        //skills on list get proficiency bonus
        //public bool[] SavingThrows
        //{
        //    get
        //    {
        //        return this.CharClass.SavingThrows();
        //    }
        //}
        ////mark which saves get proficiency bonus, get from CharClass
        //public DnDCharacter()
        //{
        //    int[] a = new int[6];
        //    this.CharClass = Profession.InteractiveChoice(out a);
        //    this._abilities = a;
        //    this._level = this.CharClass._level;
        //    foreach (int i in this._abilities)
        //        Console.WriteLine(i);
        //    //needs the remaining interactive constructor pieces
        //    //and I forgot to set the ability scores off that form....Chris
        //}
     /*   public DnDCharacter(int level, int p, int proPath)
        {
            switch (p)
            {
                case 0:
                    this.CharClass = new Barbarian(level, proPath);
                    break;
                case 1:
                    this.CharClass = new Bard(level, proPath);
                    break;
                case 2:
                    this.CharClass = new Cleric(level, proPath);
                    break;
                case 3:
                    this.CharClass = new Druid(level, proPath);
                    break;
                case 4:
                    this.CharClass = new Fighter(level, proPath);
                    break;
                case 5:
                    this.CharClass = new Monk(level, proPath);
                    break;
                case 6:
                    this.CharClass = new Paladin(level, proPath);
                    break;
                case 7:
                    this.CharClass = new Ranger(level, proPath);
                    break;
                case 8:
                    this.CharClass = new Rogue(level, proPath);
                    break;
                case 9:
                    this.CharClass = new Sorcerer(level, proPath);
                    break;
                case 10:
                    break;
            }*/
           /* this.CharClass = new ;
            this.CharClass._level = level;
            this.CharClass._proPath = proPath;
            this code would break badly*/
            //unnecessary this.SavingThrows = this.CharClass.SavingThrows();
        //}
        //public int ProficiencyBonus()
        //{//passes the proficiency bonus to main function
        //    return 2 + (Level / 5);
        //}
        //public int[] AddAbilities(int[] toadd)
        //{
        //    for(int i = 0; i < 6; ++i)
        //    {
        //        toadd[i] += this.Abilities[i];
        //    }
        //    return toadd;
        //}
        //public int[] AbilityModifiers(int[] Abilities)
        //{//pass ability modifiers to main so they can be accessed there
        //    int[] modifiers = new int[6];
        //    for (int i = 0; i < 6; ++i)
        //    {
        //        if (Abilities[i] >= 10) modifiers[i] = (Abilities[i] - 10) / 2;
        //        else if (Abilities[i] < 10) modifiers[i] = Math.Min(((10 - Abilities[i]) / -2), -1);
        //    }
        //    return modifiers;
        //}
     /*   public bool SetProfession(int c, int s, int level = 1)
        {
            try
            {
                switch (c)
                {
                    case 0:
                        this.CharClass = new Barbarian(level, s);
                        break;
                    case 1:
                        this.CharClass = new Bard(level, s);
                        break;
                    case 2:
                        this.CharClass = new Cleric(level, s);
                        break;
                    case 3:
                        this.CharClass = new Druid(level, s);
                        break;
                    case 4:
                        this.CharClass = new Fighter(level, s);
                        break;
                    case 5:
                        this.CharClass = new Monk(level, s);
                        break;
                    case 6:
                        this.CharClass = new Paladin(level, s);
                        break;
                    case 7:
                        this.CharClass = new Ranger(level, s);
                        break;
                    case 8:
                        this.CharClass = new Rogue(level, s);
                        break;
                    case 9:
                        this.CharClass = new Sorcerer(level, s);
                        break;
                    case 10:
                        break;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }*/
    }
}
