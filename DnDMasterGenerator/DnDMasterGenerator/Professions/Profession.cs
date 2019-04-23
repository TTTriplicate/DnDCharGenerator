using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DnDClassesTest
{
    public abstract class Profession
    {
        //need here too for determining what players do or do not have from class
        protected int level;
        public int _level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
            }
        }

        protected bool Caster;
        public bool _caster
        {
            get
            {
                return Caster;
            }
            set
            {
                Caster = value;
            }
        }
        protected int HitDie;
        public int _hitDie
        {
            get
            {
                return HitDie;
            }
            set
            {
                HitDie = value;
            }
        }
        protected int ProPath;
        public int _proPath
        {
            get
            {
                return ProPath;
            }
            set
            {
                ProPath = value;
            }
        }
        protected int NumProSkills;
        public int _numProSkills
        {
            get
            {
                return NumProSkills;
            }
            set
            {
                NumProSkills = value;
            }
        }
        protected int[] AbilityIncreaseLevels;
        public int[] _abilityScoreIncrease
        {
            get
            {
                return AbilityIncreaseLevels;
            }
            set
            {
                AbilityIncreaseLevels = new int[5] { 4, 8, 12, 16, 19 };
            }
        }
        protected abstract List<string> Features { get; set; }

        public abstract List<string> CurrentFeatures();

        public abstract bool[] ClassSkills();

        public abstract bool[] Unlocked();

        public abstract bool[] SavingThrows();

        public abstract List<string> ClassFeatures();

        public static Profession InteractiveChoice(out int[] abilities, out string name, out string playerName)
        {
            int p = 1, proPath = 9, level = 12;
            name = "";
            playerName = "";
            Profession CharClass = new Bard();

            using (var first = new StatsAndProfession())
            {
                abilities = new int[6];
                var result = first.ShowDialog();
                if (result == DialogResult.OK)
                {
                    p = first.p;
                    proPath = first.proPath;
                    level = first.level;
                    abilities = first.Abilities;
                    name = first.Name;
                    playerName = first.PlayerName;
                }
                switch (p)
                {
                    case 0:
                        CharClass = new Barbarian(level, proPath);
                        /*foreach (string i in CharClass.CurrentFeatures())
                        {
                            Console.WriteLine(i);
                        }*/
                        break;
                    case 1:
                        CharClass = new Bard(level, proPath);
                        break;
                    case 2:
                        CharClass = new Cleric(level, proPath);
                        break;
                    case 3:
                        CharClass = new Druid(level, proPath);
                        break;
                    case 4:
                        CharClass = new Fighter(level, proPath);
                        break;
                    case 5:
                        CharClass = new Monk(level, proPath);
                        break;
                    case 6:
                        CharClass = new Paladin(level, proPath);
                        break;
                    case 7:
                        CharClass = new Ranger(level, proPath);
                        break;
                    case 8:
                        CharClass = new Rogue(level, proPath);
                        break;
                    case 9:
                        CharClass = new Sorcerer(level, proPath);
                        break;
                    case 10:
                        CharClass = new Wizard(level, proPath);
                        break;
                }
            }
            return CharClass;
        }

        public bool LevelUp()
        {
            if (this._level < 20)
            {
                ++this._level;
                this.Features = this.ClassFeatures();
                return true;
            }
            else return false;
        }
        public string ProfessionName()
        {
            return this.GetType().Name;
        }

    }
}