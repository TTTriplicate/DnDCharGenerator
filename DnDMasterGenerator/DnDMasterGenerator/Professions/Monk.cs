using DnDMasterGenerator.Professions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDClassesTest
{
    class Monk : Profession
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

        private List<int> ElementSelect { get; set; }


        public Monk()
        {
            this._level = 1;
            this._hitDie = 8;
            this._caster = false;
            this._numProSkills = 2;
        }

        public Monk(int level, int path)
        {
            this._level = level;
            this._hitDie = 8;
            this._caster = false;
            this._proPath = path;
            this._numProSkills = 2;
            this.ElementSelect = new List<int>();
            this.Features = this.ClassFeatures();
            this.CurrFeatures = this.CurrentFeatures();

        }
        public override bool[] ClassSkills()
        {//Acrobatics, Athletics, History, Insight, Religion, and Stealth
            bool[] SkillList = new bool[18];
             SkillList[0] = true;
             SkillList[3] = true;
             SkillList[5] = true;
             SkillList[6] = true;
             SkillList[14] = true;
             SkillList[16] = true;
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

        protected override List<string> ClassFeatures()
        {
            List<string> features = new List<string>();
            String path = Path.Combine(Environment.CurrentDirectory, @"..\..\Professions\ClassFeatures\MonkClassFeatures.txt");
            //string path = @"C:\Users\csous\source\repos\DnDClassesTest\DnDClassesTest\Professions\ClassFeatures\BarbarianClassFeatures.txt";
            string[] temp = new string[28];
            temp = File.ReadAllLines(path);
            foreach (string i in temp)
            {
                features.Add(i);
            }

            return features;
        }



        protected override bool[] Unlocked()
        {
            bool[] unlocked = new bool[15]/*{ false, false, false, false, false, false, false, false }*/;
            unlocked[0] = true;         //false is the default, shouldn't need that
            if (this._level >= 2) unlocked[1] = true;
            if (this._level >= 3) unlocked[2] = true;
            if (this._level >= 4) unlocked[3] = true;
            if (this._level >= 5) unlocked[4] = true;
            if (this._level >= 6) unlocked[5] = true;
            if (this._level >= 7) unlocked[6] = true;
            if (this._level >= 10) unlocked[7] = true;
            if (this._level >= 11) unlocked[8] = true;
            if (this._level >= 13) unlocked[9] = true;
            if (this._level >= 14) unlocked[10] = true;
            if (this._level >= 15) unlocked[11] = true;
            if (this._level >= 17) unlocked[12] = true;
            if (this._level >= 18) unlocked[13] = true;
            if (this._level == 20) unlocked[14] = true;

            return unlocked;
        }

        protected override List<string> CurrentFeatures()
        {
            List<string> current = new List<string>();
            bool[] unlock = this.Unlocked();
            int i;
            for (i = 0; i <= 14; ++i)
            {
                if (!unlock[i])
                {
                    --i;
                    break;
                }
            }
            current = Features.GetRange(0, 1);
            if (i >= 1) current = Features.GetRange(0, 6);
            else if (i >= 2) current = Features.GetRange(0, 7);
            else if (i >= 3) current = Features.GetRange(0, 8);
            else if (i >= 4) current = Features.GetRange(0, 10);
            else if (i >= 5) current = Features.GetRange(0, 11);
            else if (i >= 6) current = Features.GetRange(0, 13);
            else if (i >= 7) current = Features.GetRange(0, 14);
            else if (i >= 9) current = Features.GetRange(0, 15);
            else if (i >= 10) current = Features.GetRange(0, 16);
            else if (i >= 11) current = Features.GetRange(0, 17);
            else if (i >= 13) current = Features.GetRange(0, 18);
            else current = Features.GetRange(0, 19);

            if (_proPath == 0)
            {
                if (i >= 2) current.Add(Features[20]);
                if (i >= 5) current.Add(Features[21]);
                if (i >= 8) current.Add(Features[22]);
                if (i >= 12) current.Add(Features[23]);
            }
            else if (_proPath == 1)
            {
                if (i >= 2) current.Add(Features[24]);
                if (i >= 5) current.Add(Features[25]);
                if (i >= 8) current.Add(Features[26]);
                if (i >= 12) current.Add(Features[27]);
            }
            else if (_proPath == 2)
            {
                if (i >= 2)
                {
                    current.Add(Features[27]);
                    current.Add(Features[28]);
                    current.Add(ElementSelector(Features.GetRange(29, 8)));
                }
                if (i >= 5) current.Add(ElementSelector(Features.GetRange(29, 10)));
                if (i >= 8) current.Add(ElementSelector(Features.GetRange(29, 13)));
                if (i >= 12) current.Add(ElementSelector(Features.GetRange(29, 16)));

            }

            return current;
        }

        private string ElementSelector(List<string> options)
        {
            if (ElementSelect.Any())
                foreach (int i in ElementSelect)
                    options.RemoveAt(i);

            var sel = new PickOne(options);
            var result = sel.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                ElementSelect.Add(sel.Selected);
                return sel.Choices[sel.Selected];
            }
            else return ElementSelector(options);
            
        }
    }
}
