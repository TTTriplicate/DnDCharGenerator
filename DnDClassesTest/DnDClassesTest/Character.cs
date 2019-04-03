using System;
using System.Collections.Generic;

namespace DnDClassesTest
{

    public class DnDCharacter
    {
        /*most of this will probably get set in a parameterized constructor
         * not sure yet how best to implement that.
         All part of the project later on*/
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
        }
        //STR, DEX, CON, INT, WIS, CHA, in that order for all int[6]
        //get and set(RNG and point buy system in user interface)
        //default to all 8s for point buy start
        public Profession CharClass { get; set; }
        //get and set(Profession library, Chris)
        //        protected CharRace Race;
        //get and set(Race library, Dylan)
        //        protected Background background;
        //get and set(Background libraries, Jack)
        //        protected List<Items> Inventory;
        //add and remove methods? (Item library, Catherine)
        //equiped vs. carried?
        //        protected List<string> SkillList;
        //bool[]?
        //add methods from class and background, some user interaction to pick from list
        //skills on list get proficiency bonus
        public bool[] SavingThrows
        {
            get
            {
                return this.CharClass.SavingThrows();
            }
        }
        //mark which saves get proficiency bonus, get from CharClass
        public DnDCharacter()
        {
            
            /*will need a parameterized constructor
             * may call parameterized component constructors inside?
             * this might be a bit of a mess later on*/
        }
        public DnDCharacter(int level, int p, int proPath)
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
            }
           /* this.CharClass = new ;
            this.CharClass._level = level;
            this.CharClass._proPath = proPath;
            this code would break badly*/
            //unnecessary this.SavingThrows = this.CharClass.SavingThrows();
        }
        public int ProficiencyBonus()
        {//passes the proficiency bonus to main function
            return 2 + (Level / 5);
        }

        public int[] AbilityModifiers(int[] Abilities)
        {//pass ability modifiers to main so they can be accessed there
            int[] modifiers = new int[6];
            for (int i = 0; i < 6; ++i)
            {
                if (Abilities[i] >= 10) modifiers[i] = (Abilities[i] - 10) / 2;
                else if (Abilities[i] < 10) modifiers[i] = Math.Min(((10 - Abilities[i]) / -2), -1);
            }
            return modifiers;
        }
    }
}