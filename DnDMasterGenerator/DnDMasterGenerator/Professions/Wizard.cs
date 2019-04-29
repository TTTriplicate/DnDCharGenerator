using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDClassesTest
{
    class Wizard : Profession
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
        { get; set; }

        public override List<string> CurrFeatures {get; set;}

        public Wizard()
        {
            this._level = 1;
            this._hitDie = 6;
            this._caster = true;
            this._numProSkills = 2;
        }

        public Wizard(int level, int path)
        {
            this._level = level;
            this._hitDie = 6;
            this._caster = true;
            this._proPath = path;
            this._numProSkills = 2;
            this.Features = this.ClassFeatures();
            this.CurrFeatures = this.CurrentFeatures();

        }
        public override bool[] ClassSkills()
        {//Arcana, History, Insight, Investigation, Medicine, and Religion
            bool[] SkillList = new bool[18];
            SkillList[2] = true;
            SkillList[5] = true;
            SkillList[6] = true;
            SkillList[8] = true;
            SkillList[9] = true;
             SkillList[14] = true;
            return SkillList;
        }

        public override bool[] SavingThrows()
        {
            bool[] Saves = new bool[6] /*{ 0, 1, 0, 0, 0, 1 }*/
            ;
            Saves[3] = true;
            Saves[4] = true;
            return Saves;
        }

        public int ProficiencyBonus()
        {//passes the proficiency bonus to main function
            return 2 + (this._level / 5);
        }

        protected override List<string> ClassFeatures()
        {
            List<string> features = new List<string>();
            string path = Path.Combine(Environment.CurrentDirectory, @"..\..\Professions\ClassFeatures\WizardClassFeatures.txt");
            //string path = @"C:\Users\csous\source\repos\DnDClassesTest\DnDClassesTest\Professions\ClassFeatures\BarbarianClassFeatures.txt";
            string[] temp = new string[43];
            temp = File.ReadAllLines(path);
            foreach (string i in temp)
            {
                features.Add(i);
            }

            return features;

        }



        protected override bool[] Unlocked()
        {
            bool[] unlocked = new bool[7]/*{ false, false, false, false, false, false, false, false }*/;
            unlocked[0] = true;         //false is the default, shouldn't need that
            if (this._level >= 2) unlocked[1] = true;
            if (this._level >= 6) unlocked[2] = true;
            if (this._level >= 10) unlocked[3] = true;
            if (this._level >= 14) unlocked[4] = true;
            if (this._level >= 18) unlocked[5] = true;
            if (this._level >= 20) unlocked[6] = true;
            return unlocked;
        }

        protected override List<string> CurrentFeatures()
        {
            List<string> current = new List<string>();
            bool[] unlock = this.Unlocked();
            int i;
            for (i = 0; i < 7; ++i)
            {
                if (!unlock[i])
                {
                    --i;
                    break;
                }
            }

            current.Add(Features[0]);
            if (i >= 5) current.Add(Features[1]);
            if (i == 6) current.Add(Features[2]);

                if (i < 1) return current;
                if (i >= 1)
                {
                    current.Add(Features[3 + (_proPath * 5)]);
                    current.Add(Features[4 + (_proPath * 5)]);
                }
                if (i >= 2) current.Add(Features[5 + (_proPath * 5)]);
                if (i >= 3) current.Add(Features[6 + (_proPath * 5)]);
                if (i >= 4) current.Add(Features[7 + (_proPath * 5)]);

            return current;
        }

        //insert class feature methods here

    }
}
