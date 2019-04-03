using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDClassesTest
{
    class Fighter : Profession
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
        public Fighter()
        {
            this._level = 1;
            this._hitDie = 10;
            this._caster = false;
            this._numProSkills = 2;
        }
        public Fighter(int level, int path)
        {
            this._level = level;
            this._hitDie = 10;
            this._caster = (path == 2) ? true : false;
            this._numProSkills = 2;
            this._proPath = path;
            this.AbilityIncreaseLevels = new int[] { 4, 6, 8, 12, 14, 16, 19 };
        }
        public override bool[] ClassSkills()
        {
            bool[] SkillList = new bool[18];
            /*Acrobatics, Animal Handling, Athletics, History, Insight, Intimidation, Perception, and Survival
            SkillList[1] = true;
            SkillList[3] = true;
            SkillList[7] = true;
            SkillList[10] = true;
            SkillList[11] = true;
            SkillList[17] = true;*/
            return SkillList;
        }

        public override bool[] SavingThrows()
        {
            bool[] Saves = new bool[6] /*{ 1, 0, 1, 0, 0, 0 }*/;
            Saves[0] = true;
            Saves[2] = true;
            return Saves;
        }

        public int ProficiencyBonus()
        {//passes the proficiency bonus to main function
            return 2 + (this._level / 5);
        }

        public override List<string> ClassFeatures()
        {
            List<string> features = new List<string>();
            /*features.Add(Rage());//0
            features.Add(UnarmoredDefense());//1
            features.Add(RecklessAttack());//2
            features.Add(DangerSense());//3
            if (_proPath == 0) features.Add(Frenzy());//4
            else
            {
                features.Add(SpiritSeeker());//4
                features.Add(TotemSpirit());//5
            }
            features.Add(ExtraAttack());//5 or 6
            Features.Add(FastMovement());//6 or 7
            features.Add((_proPath == 0) ? MindlessRage() : AspectOfTheBeast());
            features.Add(FeralInstinct());
            features.Add(BrutalCrit());
            features.Add((_proPath == 0) ? IntimidatingPresence() : SpiritWalker());
            features.Add(RelentlessRage());
            features.Add((_proPath == 0) ? Retaliation() : TotemAttunement());
            features.Add(PersistentRage());
            features.Add(IndomitableMight());*/

            return features;
        }
        public override bool[] Unlocked()
        {//this might need jesus on this one...three classes in a trenchcoat....
            bool[] unlock = new bool[13];
            unlock[0] = true;
            if (this._level == 2) unlock[1] = true;
            if (this._level == 3) unlock[2] = true;
            if (this._level == 5) unlock[3] = true;
            if (this._level == 6) unlock[4] = true;
            if (this._level == 7) unlock[5] = true;
            if (this._level == 9) unlock[6] = true;
            if (this._level == 10) unlock[7] = true;
            if (this._level == 11) unlock[8] = true;
            if (this._level == 14) unlock[9] = true;
            if (this._level == 15) unlock[10] = true;
            if (this._level == 18) unlock[11] = true;
            if (this._level == 20) unlock[12] = true;
            return unlock;
        }
        public override List<string> CurrentFeatures()
        {
            List<string> current = new List<string>();
            bool[] unlock = this.Unlocked();
            int i;
            for (i = 12; i <= 0; --i)
            {
                if (unlock[i]) break;
            }
            if (i == 12) return Features;
            else if (_proPath == 0)
            {
                if (i == 11) current = Features.GetRange(0, 13);
                else if (i == 10) current = Features.GetRange(0, 12);
                else if (i == 9) current = Features.GetRange(0, 11);
                else if (i == 3) current = Features.GetRange(0, 3);
                else if (i == 2) current = Features.GetRange(0, 2);
                else if (i == 2) current = Features.GetRange(0, 4);
                else current = Features.GetRange(0, 1);
            }
            else if (_proPath == 1)
            {
                if (i == 11) current = Features.GetRange(0, 14);
                else if (i == 5) current = Features.GetRange(0, 6);
                else if (i == 4) current = Features.GetRange(0, 5);
                else if (i == 3) current = Features.GetRange(0, 3);
                else if (i == 2) current = Features.GetRange(0, 2);
                else if (i == 2) current = Features.GetRange(0, 1);
                else current.Add(Features[0]);

            }
            return current;
        }
        //class feature methods here
    }
}
