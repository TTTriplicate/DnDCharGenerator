using System;
using System.Collections.Generic;

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