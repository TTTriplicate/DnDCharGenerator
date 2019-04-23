using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDClassesTest
{
    class Paladin : Profession
    {
        protected bool[] PickedSkills;
        public bool[] _pickedSkills
        {
            get
            {
                return PickedSkills;
            }
            set
            {//will be passed a bool[18], needs validations
                PickedSkills = value;
            }
        }
        protected override List<string> Features
        {
            get
            {
                return Features;
            }
            set
            {//contains full listing of class features 
             //to be passed to character sheet through ClassFeatures method
                Features = ClassFeatures();
            }
        }

        public Paladin()
        {
            this._level = 1;
            this._hitDie = 10;
            this._caster = true;
            this._numProSkills = 2;
        }

        public Paladin(int level, int path)
        {
            this._level = level;
            this._hitDie = 10;
            this._caster = true;
            this._proPath = path;
            this._numProSkills = 2;
            //this.ClassFeatures = this.Unlocked();
        }
        public override bool[] ClassSkills()
        {//Athletics, Insight, Intimidation, Medicine, Persuasion, and Religion
            bool[] SkillList = new bool[18];
            /*bool[] = true;
             * bool[] = true;
             * bool[] = true;
             * bool[] = true;
             * bool[] = true;
             bool[] = true*/
            return SkillList;
        }

        public override bool[] SavingThrows()
        {
            bool[] Saves = new bool[6] /*{ 0, 1, 0, 0, 0, 1 }*/
            ;
            Saves[4] = true;
            Saves[5] = true;
            return Saves;
        }

        public int ProficiencyBonus()
        {//passes the proficiency bonus to main function
            return 2 + (this._level / 5);
        }

        public override List<string> ClassFeatures()
        {
            int path = this._proPath;
            List<string> features = new List<string>();
            /*features.Add(Inspiration());//0
            features.Add(SongOfRest());//1
            features.Add(path == 0 ? CuttingWords() : CombatInspiration());//2
            features.Add(FontOfInspiration());//3
            features.Add(CounterCharm());//4
            features.Add(path == 0 ? ExtraSecrets() : ExtraAttack());//4
            features.Add(MagicSecrets());//5
            features.Add(path == 0 ? PeerlessSkill() : BattleMagic());//6
            features.Add(SuperiorInspiration());//7*/
            return features;

        }



        public override bool[] Unlocked()
        {
            bool[] unlocked = new bool[8]/*{ false, false, false, false, false, false, false, false }*/;
            unlocked[0] = true;         //false is the default, shouldn't need that
            if (this._level >= 2) unlocked[1] = true;
            if (this._level >= 3) unlocked[2] = true;
            if (this._level >= 5) unlocked[3] = true;
            if (this._level >= 6) unlocked[4] = true;
            if (this._level >= 10) unlocked[5] = true;
            if (this._level >= 14) unlocked[6] = true;
            if (this._level == 20) unlocked[7] = true;
            return unlocked;
        }

        public override List<string> CurrentFeatures()
        {
            List<string> current = new List<string>();
            bool[] unlock = this.Unlocked();
            int i;
            for (i = 7; i <= 0; --i)
            {
                if (unlock[i]) break;
            }
            if (i == 7) current = Features;
            else if (i == 6) current = Features.GetRange(0, 7);
            else if (i == 5) current = Features.GetRange(0, 6);
            else if (i == 4) current = Features.GetRange(0, 5);
            else if (i == 3) current = Features.GetRange(0, 3);
            else if (i == 2) current = Features.GetRange(0, 2);
            else if (i == 2) current = Features.GetRange(0, 1);
            else current.Add(Features[0]);
            return current;
        }

        //insert class feature methods here

    }
}
