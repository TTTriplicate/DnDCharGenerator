using DnDMasterGenerator;
using DnDMasterGenerator.Professions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnDClassesTest
{
    class Ranger : Profession
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
        {            get; set;        }

        public Ranger()
        {
            this._level = 1;
            this._hitDie = 10;
            this._caster = true;
            this._numProSkills = 3;
        }

        public Ranger(int level, int path)
        {
            this._level = level;
            this._hitDie = 10;
            this._caster = true;
            this._proPath = path;
            this._numProSkills = 3;
            this.Features = this.ClassFeatures();
        }
        public override bool[] ClassSkills()
        {
            bool[] SkillList = new bool[18];
            //Animal Handling, Athletics, Insight, Investigation, Nature, Perception,
              //  Stealth, and Survival
             SkillList[1] = true;
             SkillList[3] = true;
             SkillList[6] = true;
             SkillList[8] = true;
             SkillList[10] = true;
             SkillList[11] = true;
             SkillList[16] = true;
             SkillList[17] = true;
            return SkillList;
        }

        public override bool[] SavingThrows()
        {
            bool[] Saves = new bool[6] /*{ 0, 1, 0, 0, 0, 1 }*/
            ;
            Saves[0] = true;
            Saves[1] = true;
            return Saves;
        }

        public int ProficiencyBonus()
        {//passes the proficiency bonus to main function
            return 2 + (this._level / 5);
        }

        public override List<string> ClassFeatures()
        {
            List<string> features = new List<string>();
            String path = Path.Combine(Environment.CurrentDirectory, @"..\..\Professions\ClassFeatures\RangerClassFeatures.txt");
            //string path = @"C:\Users\csous\source\repos\DnDClassesTest\DnDClassesTest\Professions\ClassFeatures\BarbarianClassFeatures.txt";
            string[] temp = new string[18];
            temp = File.ReadAllLines(path);
            foreach (string i in temp)
            {
                features.Add(i);
            }

            return features;

        }



        public override bool[] Unlocked()
        {
            bool[] unlocked = new bool[12]/*{ false, false, false, false, false, false, false, false }*/;
            unlocked[0] = true;         //false is the default, shouldn't need that
            if (this._level >= 2) unlocked[1] = true;
            if (this._level >= 3) unlocked[2] = true;
            if (this._level >= 5) unlocked[3] = true;
            if (this._level >= 7) unlocked[4] = true;
            if (this._level >= 8) unlocked[5] = true;
            if (this._level >= 10) unlocked[6] = true;
            if (this._level >= 11) unlocked[7] = true;
            if (this._level >= 14) unlocked[8] = true;
            if (this._level >= 15) unlocked[9] = true;
            if (this._level >= 18) unlocked[10] = true;
            if (this._level == 20) unlocked[11] = true;
            return unlocked;
        }

        public override List<string> CurrentFeatures()
        {
            List<string> current = new List<string>();
            bool[] unlock = this.Unlocked();
            int i;
            for (i = 0; i <= 11; ++i)
            {
                if (!unlock[i]) break;
            }
            current = Features.GetRange(0, 2);
            if (i >= 1) {
                current.Add(Features[2]);
                current.Add(this.ChooseFightingStyle());
            }
            else if (i >= 2) current.Add(Features[3]);
            else if (i >= 3) current.Add(Features[4]);
            else if (i >= 5) current.Add(Features[5]);
            else if (i >= 6) current.Add(Features[6]);
            else if (i >= 8) current.Add(Features[7]);
            else if (i >= 10) current.Add(Features[8]);
            else if (i >= 11) current.Add(Features[9]);

                if (_proPath == 0)
                {
                    if (i < 2) return current;
                    else if (i >= 2) current.Add(this.ChooseOne(Features.GetRange(10, 3)));
                    if (i >= 4) current.Add(this.ChooseOne(Features.GetRange(13, 3)));
                    if (i >= 7) current.Add(this.ChooseOne(Features.GetRange(16, 3)));
                    if (i >= 8) current.Add(this.ChooseOne(Features.GetRange(18, 3)));
                }
                else if (_proPath == 1)
                {
                    if (i < 2) return current;
                    else if (i >= 2) current.Add(Features[21]);
                    if (i >= 4) current.Add(Features[22]);
                    if (i >= 7) current.Add(Features[23]);
                    if (i >= 8) current.Add(Features[24]);
                }
            return current;

        }
        private string ChooseFightingStyle()
        {
            var picker = new FightingStyles(this.ProfessionName());
            var result = picker.ShowDialog();
            if (result == DialogResult.OK)
            {
                return picker.Source[picker.Index];
            }

            else return "";
        }

        private string ChooseOne(List<string> choices)
        {
            var sel = new PickOne(choices);
            var result = sel.ShowDialog();
            if (result == DialogResult.OK)
            {
                return sel.Choices[sel.Selected];
            }
            else
                return this.ChooseOne(choices);
        }

    }
}


