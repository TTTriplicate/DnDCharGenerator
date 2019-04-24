using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DnDClassesTest
{

    public class DnDCharacter
    {
        /*most of this will probably get set in a parameterized constructor
         * not sure yet how best to implement that.
         All part of the project later on*/
        protected string Name;
        public string _name
        {
            get
            {
                return this.Name;
            }
            set
            {
                this.Name = value;
            }
        }
        protected string playerName;
        public string _playerName
        {
            get
            {
                return this.playerName;
            }
            set
            {
                this.playerName = value;
                this.playerName = value;
                this.playerName = value;
                this.playerName = value;
            }
        }
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
        protected bool[] Skills;
        public bool[] _skills
        {
            get
            {
                return Skills;
            }
            set
            {
                Skills = value;
            }
        }
        //STR, DEX, CON, INT, WIS, CHA, in that order for all int[6]
        //get and set(RNG and point buy system in user interface)
        //default to all 8s for point buy start
        protected Profession CharClass { get; set; }
        public Profession _class
        {
            get
            {
                return CharClass;
            }
            set
            {
                CharClass = value;
            }
        }
        protected int HP;
        public int _HP
        {
            get
            {
                return HP;
            }
            set
            {
                HP = value;
            }
        }
        //get and set(Profession library, Chris)
        public Race CharRace { get; set; }
        protected void raceAdditions()
        {
            for (int i = 0; i < 6; i++)
            {
                Abilities[i] += CharRace.getAA()[i];
            }
            //pretty sure I need something else here but I don't know what
        }
        public Background_Class CharBackground { get; set; }
        //get and set(Race library, Dylan)
        //protected Background_Class Background { get; set; }
        //public static string blah = "f";
        //public BackgroundForm background = new BackgroundForm(ref blah);
        //public Background_Class Background = new Background_Class(blah);
        //public void backgroundInfo(ref string Personality, ref string Ideal, ref string Flaw, ref string Bond, ref string BACKGROUND)
        //{
        //    blah = "Acolyte";
        //    BACKGROUND = "Acolyte";
        //    Background.loadFile(blah);
        //    //Background.Traits(ref Personality, ref Ideal, ref Flaw, ref Bond);
        //}
        //get and set(Background libraries, Jack)
        //       protected List<Gear> Inventory;
        protected CharGear gear { get; set; }
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
        public List<string> inventory = new List<string>();
        public int gold = 0;

        public DnDCharacter()
        {
            //CharGear gear = new CharGear("Barbarian", "Folk Hero", 2);
            //List<string> inventory = gear.getInventoryString();
            int[] a = new int[6];
            string charName, playName;
            this.CharClass = Profession.InteractiveChoice(out a, out charName, out playName);
            this._abilities = a;
            this._HP = this._class._hitDie;
            this._HP += AbilityModifiers()[2];
            this._name = charName;
            this._playerName = playName;
            this._level = this.CharClass._level;
            if (this._level > 1)
                this._HP += DnDCharacter.RollHP(this._level - 1, this._class._hitDie, this._HP) + ((this._level - 1) * this.AbilityModifiers()[2]);
            this.CharRace = Race.InteractiveChoice();
            raceAdditions();
            //Background selector
            //Race selector
            //this._skills = DnDCharacter.SkillSelectInteractive(CharClass._numProSkills, CharClass.ClassSkills()/*, Background_Class.FixedSkills = new bool[18]*/);
            //skills picker is broken....all individual checkboxes?
            //needs the remaining interactive constructor pieces
            //and I forgot to set the ability scores off that form....Chris
            CharBackground =  Background_Class.InteractiveChoice(this.CharRace);
            
            for (int i = 0; i < 16; i++)
            {
                if (CharBackground.backlanguage[i])
                {
                    CharRace.setLanguages(i);
                }
            }


            CharGear gear = new CharGear(this._class.ProfessionName(), CharBackground.Background , AbilityModifiers()[1]);
            inventory = gear.getInventoryString();
            gold = gear.getGP();
        }
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
        public List<string> getInventory()
        {
            return inventory;
        }
        public int ProficiencyBonus()
        {//passes the proficiency bonus to main function
            return 2 + (Level / 5);
        }
        public int[] AddAbilities(int[] toadd)
        {
            for (int i = 0; i < 6; ++i)
            {
                toadd[i] += this.Abilities[i];
            }
            return toadd;
        }
        private static int RollHP(int l, int d, int hp)
        {
            Random hitdie = new Random();
            if (l == 1)
            {
                return hitdie.Next(1, d);
            }
            else
            {
                hp += RollHP(l - 1, d, hp);
            }
            return hp;
        }
        public int[] AbilityModifiers()
        {//pass ability modifiers to main so they can be accessed there

            int[] modifiers = new int[6];
            for (int i = 0; i < 6; ++i)
            {
                if (Abilities[i] >= 10) modifiers[i] = (Abilities[i] - 10) / 2;
                else if (Abilities[i] < 10) modifiers[i] = Math.Min(((10 - Abilities[i]) / -2), -1);
            }
            return modifiers;
        }
        private static bool[] SkillSelectInteractive(int numSkills, bool[] classSkills)
        {

            var skills = new SkillSelect(numSkills, classSkills);
            var result = skills.ShowDialog();
            if (result == DialogResult.OK)
            {
                classSkills = skills.SkillsList;
            }
            return classSkills;
        }
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