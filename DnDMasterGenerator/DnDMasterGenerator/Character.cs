using DnDMasterGenerator;
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
        public List<string> inventoryString = new List<string>();
        public List<Gear> inventory = new List<Gear>();
        public List<int> attackBonus = new List<int>();
        public List<string> attackBonusWeapons = new List<string>();
        public List<string> attackDamage = new List<string>();
        public int ArmorClass = 0;
        public int gold = 0;

        public DnDCharacter()
        {
            int[] a = new int[6];
            string charName, playName;
            this.CharClass = Profession.InteractiveChoice(out a, out charName, out playName);
            this._abilities = a;
            this._name = charName;
            this._playerName = playName;
            this._level = this.CharClass._level;
            this.CharRace = Race.InteractiveChoice();
            raceAdditions();
            this._HP = this._class._hitDie;
            this._HP += AbilityModifiers()[2];
            if (this._level > 1)
            {
                for (int l = 0; l < this._level; ++l)
                {
                    if(this._class.ProfessionName() == "Barbarian" && l == 19)
                    {
                        for (int h = 0; h < 6; ++h)
                            this.Abilities[h] += Barbarian.PrimalChampion()[h];
                    }
                    for(int i = 0; i < 5; ++i)
                        if (l == this._class._abilityScoreIncrease[i])
                        {
                            this.AbilityScoreIncrease();
                        }
                    this._HP += DnDCharacter.RollHP(this._class._hitDie) + this.AbilityModifiers()[2];
                }
            }
                //has to change to account for level adjusted ability scores
                //                this._HP += DnDCharacter.RollHP(this._level - 1, this._class._hitDie, this._HP) + ((this._level - 1) * this.AbilityModifiers()[2]);
            //Background selector
            //Race selector
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
            this._skills = DnDCharacter.SkillSelectInteractive(CharClass._numProSkills, CharClass.ClassSkills(), this.CharBackground.SkillProf);

            if (this._class.ProfessionName() == "Cleric")
            {
                this.gear = new CharGear(this._class.ProfessionName(), CharBackground.Background, AbilityModifiers()[1], this._class._proPath);
            }
            else
            {
                this.gear = new CharGear(this._class.ProfessionName(), CharBackground.Background, AbilityModifiers()[1]);
            }
            
            inventoryString = gear.getInventoryString();
            inventory = gear.getInventory();
            ArmorClass = gear.getAC();
            gold = gear.getGP();
            int count = 0;
            attackBonus.Add(0);
            attackBonus.Add(0);
            attackBonus.Add(0);
            attackBonusWeapons.Add("");
            attackBonusWeapons.Add("");
            attackBonusWeapons.Add("");
            attackDamage.Add("");
            attackDamage.Add("");
            attackDamage.Add("");
            for (int i = 0; i < inventory.Count; i++)
            {
                if (count >= 3)
                {
                    break;
                }
                else
                {
                    if (inventory[i].GetType().ToString() == "DnDClassesTest.Weapon")
                    {
                        attackBonus[count] = (((Weapon)inventory[i]).calcATKBonus(this));
                        attackBonusWeapons[count] = (inventory[i].name);
                        attackDamage[count] = (((Weapon)inventory[i]).calcDamage(this));
                        count++;
                    }
                } 
            }
        }
        public bool LevelUp()
        {
            if (this._level == 20) return false;
            else
            {
                ++this._level;
                if (this._class.LevelUp())
                {
                    foreach (int i in this._class._abilityScoreIncrease)
                    {
                        if (i == this._level)
                        {
                            this.AbilityScoreIncrease();
                            break;
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        public int ExperiencePoints(int lvl)
        {
            switch(lvl)
            {
                case 1:
                    return 0;
                case 2:
                    return 300;
                case 3:
                    return 900;
                case 4:
                    return 2700;
                case 5:
                    return 6500;
                case 6:
                    return 14000;
                case 7:
                    return 23000;
                case 8:
                    return 34000;
                case 9:
                    return 48000;
                case 10:
                    return 64000;
                case 11:
                    return 85000;
                case 12:
                    return 100000;
                case 13:
                    return 120000;
                case 14:
                    return 140000;
                case 15:
                    return 165000;
                case 16:
                    return 195000;
                case 17:
                    return 225000;
                case 18:
                    return 265000;
                case 19:
                    return 305000;
                case 20:
                    return 355000;
                default:
                    return 0;

            }
        }

        private void AbilityScoreIncrease()
        {
            var sel = new AbilityIncrease(this.Abilities);
            var result = sel.ShowDialog();
            if (result == DialogResult.OK)
            {
                for (int j = 0; j < 6; ++j)
                    this.Abilities[j] += sel.Adjust[j];
            }
            else AbilityScoreIncrease();

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
        public List<string> getInventoryString() //passes string representation of the finalized inventory to charsheet and pdf filler, among other things
        {
            return inventoryString;
        }
        public int getAC() //passes the character's attack bonus to the pdf filler
        {
            return ArmorClass;
        }

        public List<Gear> getInventory() //passes the finalized inventory to charsheet and pdf filler
        {
            return inventory;
        }

        public List<int> getATK()
        {
            return attackBonus;
        }

        public List<string> getAttackWeapons()
        {
            return attackBonusWeapons;
        }

        public List<string> getDamage()
        {
            return attackDamage;
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
        private static int RollHP(int d)
        {
            Random hitdie = new Random();
            
                return hitdie.Next(1, d);
        }
        public int[] AbilityModifiers()
        {//pass ability modifiers to main so they can be accessed there

            int[] modifiers = new int[6];
            for (int i = 0; i < 6; ++i)
            {
                if (Abilities[i] != 9) modifiers[i] = (Abilities[i] - 10) / 2;
                else modifiers[i] = -1;
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

        private static bool[] SkillSelectInteractive(int numSkills, bool[] classSkills, bool[] backSkills)
        {

            var skills = new SkillSelect(numSkills, classSkills, backSkills);
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