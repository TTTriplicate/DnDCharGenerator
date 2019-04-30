using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DnDMasterGenerator;
using System.Windows.Forms;
using DnDMasterGenerator.Professions;

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
        protected override List<string> Features { get; set; }

        public override List<string> CurrFeatures { get; set; }

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
            this.Features = this.ClassFeatures();
            this.CurrFeatures = this.CurrentFeatures();
            this._abilityScoreIncrease = new int[5] { 4, 8, 12, 16, 19 };

        }
        public override bool[] ClassSkills()
        {//Athletics, Insight, Intimidation, Medicine, Persuasion, and Religion
            bool[] SkillList = new bool[18];
            SkillList[3] = true;
            SkillList[6] = true;
            SkillList[7] = true;
            SkillList[8] = true;
            SkillList[13] = true;
            SkillList[14] = true;
            return SkillList;
        }

        public override bool[] SavingThrows()
        {
            bool[] Saves = new bool[6]; //{ 0, 1, 0, 0, 0, 1 }
            Saves[4] = true;
            Saves[5] = true;
            return Saves;
        }

        public int ProficiencyBonus()
        {//passes the proficiency bonus to main function
            return 2 + (this._level / 5);
        }

        protected override List<string> ClassFeatures()
        {
            List<string> features = new List<string>();
            String path = Path.Combine(Environment.CurrentDirectory, @"..\..\Professions\ClassFeatures\PaladinClassFeatures.txt");
            //string path = @"C:\Users\csous\source\repos\DnDClassesTest\DnDClassesTest\Professions\ClassFeatures\BarbarianClassFeatures.txt";
            string[] temp = new string[22];
            temp = File.ReadAllLines(path);
            foreach (string i in temp)
            {
                features.Add(i);
            }

            return features;

        }



        protected override bool[] Unlocked()
        {
            bool[] unlocked = new bool[10]/*{ false, false, false, false, false, false, false, false }*/;
            unlocked[0] = true;         //false is the default, shouldn't need that
            if (this._level >= 2) unlocked[1] = true;
            if (this._level >= 3) unlocked[2] = true;
            if (this._level >= 5) unlocked[3] = true;
            if (this._level >= 6) unlocked[4] = true;
            if (this._level >= 7) unlocked[5] = true;
            if (this._level >= 10) unlocked[6] = true;
            if (this._level >= 11) unlocked[7] = true;
            if (this._level >= 14) unlocked[8] = true;
            if (this._level >= 15) unlocked[9] = true;
            if (this._level == 20) unlocked[10] = true;
            return unlocked;
        }

        protected override List<string> CurrentFeatures()
        {
            List<string> current = new List<string>();
            bool[] unlock = this.Unlocked();
            int i;
            for (i = 0; i <= 10; ++i)
            {
                if (!unlock[i])
                {
                    --i;
                    break;
                }
            }
            current = Features.GetRange(0, 1);
            if (i >= 1)
            {
                current = Features.GetRange(0, 3);
                current.Add(this.ChooseFightingStyle());
            }
            else if (i >= 2) current.Add(Features[4]);
            else if (i >= 3) current.Add(Features[5]);
            else if (i >= 4) current.Add(Features[6]);
            else if (i >= 6) current.Add(Features[7]);
            else if (i >= 7) current.Add(Features[8]);
            else if (i >= 8) current.Add(Features[9]);

            if (_proPath == 0)
            {
                if (i < 2) return current;
                else if (i >= 2) current.Add(Features[10]);
                if (i >= 5) current.Add(Features[11]);
                if (i >= 8) current.Add(Features[12]);
                if (i >= 10) current.Add(Features[13]);
            }
            else if (_proPath == 1)
            {
                if (i < 2) return current;
                else if (i >= 2) current.Add(Features[14]);
                if (i >= 5) current.Add(Features[15]);
                if (i >= 8) current.Add(Features[16]);
                if (i >= 10) current.Add(Features[17]);
            }
            else if (_proPath == 2)
            {
                if (i < 2) return current;
                else if (i >= 2) current.Add(Features[18]);
                if (i >= 5) current.Add(Features[19]);
                if (i >= 8) current.Add(Features[20]);
                if (i >= 10) current.Add(Features[21]);
            }

            return current;
        }
        private string ChooseFightingStyle()
        {
            var picker = new PickOne(this.ProfessionName());
            var result = picker.ShowDialog();
            if (result == DialogResult.OK)
            {
                return picker.Choices[picker.Selected];
            }

            else
            {

                return ChooseFightingStyle();
            }
        }
        public override bool LevelUp()
        {
            ++this._level;
            if (this._level < 21)
            {
                bool[] check = this.Unlocked();
                int i;
                for (i = 0; i < check.Length; ++i)
                {
                    if (!check[i])
                    {
                        --i;
                        break;
                    }
                }
                if (i == 1)
                {
                    CurrFeatures = Features.GetRange(0, 3);
                    CurrFeatures.Add(this.ChooseFightingStyle());
                }
                else if (i == 2) CurrFeatures.Add(Features[4]);
                else if (i == 3) CurrFeatures.Add(Features[5]);
                else if (i == 4) CurrFeatures.Add(Features[6]);
                else if (i == 6) CurrFeatures.Add(Features[7]);
                else if (i == 7) CurrFeatures.Add(Features[8]);
                else if (i == 8) CurrFeatures.Add(Features[9]);

                if (_proPath == 0)
                {
                    if (i == 2) CurrFeatures.Add(Features[10]);
                    if (i == 5) CurrFeatures.Add(Features[11]);
                    if (i == 8) CurrFeatures.Add(Features[12]);
                    if (i == 10) CurrFeatures.Add(Features[13]);
                }
                else if (_proPath == 1)
                {
                    if (i == 2) CurrFeatures.Add(Features[14]);
                    if (i == 5) CurrFeatures.Add(Features[15]);
                    if (i == 8) CurrFeatures.Add(Features[16]);
                    if (i == 10) CurrFeatures.Add(Features[17]);
                }
                else if (_proPath == 2)
                {
                    if (i == 2) CurrFeatures.Add(Features[18]);
                    if (i == 5) CurrFeatures.Add(Features[19]);
                    if (i == 8) CurrFeatures.Add(Features[20]);
                    if (i == 10) CurrFeatures.Add(Features[21]);
                }
                return true;
            }
            else
            {
                --this._level;
                return false;
            }
        }


        //insert class feature methods here

    }
}
