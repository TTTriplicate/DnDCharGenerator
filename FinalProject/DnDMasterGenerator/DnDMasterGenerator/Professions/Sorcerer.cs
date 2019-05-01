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
    class Sorcerer : Profession
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

        public override List<string> CurrFeatures { get; set; }

        public Sorcerer()
        {
            this._level = 1;
            this._hitDie = 6;
            this._caster = true;
            this._numProSkills = 2;
        }

        public Sorcerer(int level, int path)
        {
            this._level = level;
            this._hitDie = 6;
            this._caster = true;
            this._proPath = path;
            this._numProSkills = 2;
            this.Features = this.ClassFeatures();
            this.CurrFeatures = this.CurrentFeatures();
            this.MetaSelect = new List<int>();
            this._abilityScoreIncrease = new int[5] { 4, 8, 12, 16, 19 };

        }
        public override bool[] ClassSkills()
        {//Arcana, Deception, Insight, Intimidation, Persuasion, and Religion
            bool[] SkillList = new bool[18];
             SkillList[2] = true;
             SkillList[4] = true;
             SkillList[6] = true;
             SkillList[7] = true;
             SkillList[13] = true;
             SkillList[14] = true;
            return SkillList;
        }

        public override bool[] SavingThrows()
        {
            bool[] Saves = new bool[6] /*{ 0, 1, 0, 0, 0, 1 }*/
            ;
            Saves[2] = true;
            Saves[5] = true;
            return Saves;
        }

        private List<int> MetaSelect { get; set; }

        public int ProficiencyBonus()
        {//passes the proficiency bonus to main function
            return 2 + (this._level / 5);
        }

        protected override List<string> ClassFeatures()
        {
            List<string> features = new List<string>();
            String path = Path.Combine(Environment.CurrentDirectory, @"..\..\Professions\ClassFeatures\SorcererClassFeatures.txt");
            //string path = @"C:\Users\csous\source\repos\DnDClassesTest\DnDClassesTest\Professions\ClassFeatures\BarbarianClassFeatures.txt";
            string[] temp = new string[20];
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
            if (this._level >= 3) unlocked[2] = true;
            if (this._level >= 6) unlocked[3] = true;
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
            if (_proPath == 0) current = Features.GetRange(3, 2);
            else current = Features.GetRange(9, 2);

            if (i >= 1)
            {
                current.Add(Features[0]);
                current.Add(SelectMetamagic());
            }
            
            if (i >= 2) current.Add(Features[1]);
            if (i >= 3 && _proPath == 0) current.Add(Features[5]);
            else if (i >= 3 && _proPath == 1) current.Add(Features[11]);
            if (i >= 4 && _proPath == 0) current.Add(Features[6]);
            if(this._level >= 10) current.Add(SelectMetamagic());
            else if (i >= 4 && _proPath == 1) current.Add(Features[12]);
            if (i >= 5 && _proPath == 0) current.Add(Features[7]);
            if(this._level >= 17) current.Add(SelectMetamagic());
            else if(i >= 5 && _proPath == 1)current.Add(Features[13]);
            if (i >= 6) current.Add(Features[2]);
            return current;
        }

        private string SelectMetamagic()
        {
            List<string> options = Features.GetRange(13, 9);
            if (this.MetaSelect.Any())
                foreach (int i in MetaSelect)
                    options.RemoveAt(i);

            var sel = new PickOne(options);
            var result = sel.ShowDialog();
            if (result == DialogResult.OK)
            {
                MetaSelect.Add(sel.Selected);
                return sel.Choices[sel.Selected];
            }
            else return SelectMetamagic();

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
                if (i >= 1)
                {
                    CurrFeatures.Add(Features[0]);
                    CurrFeatures.Add(SelectMetamagic());
                }

                if (i >= 2) CurrFeatures.Add(Features[1]);
                if (i >= 3 && _proPath == 0) CurrFeatures.Add(Features[5]);
                else if (i >= 3 && _proPath == 1) CurrFeatures.Add(Features[11]);
                if (i >= 4 && _proPath == 0) CurrFeatures.Add(Features[6]);
                if (this._level >= 10) CurrFeatures.Add(SelectMetamagic());
                else if (i >= 4 && _proPath == 1) CurrFeatures.Add(Features[12]);
                if (i >= 5 && _proPath == 0) CurrFeatures.Add(Features[7]);
                if (this._level >= 17) CurrFeatures.Add(SelectMetamagic());
                else if (i >= 5 && _proPath == 1) CurrFeatures.Add(Features[13]);
                if (i >= 6) CurrFeatures.Add(Features[2]);
            

            return true;
            }
            else
            {
                --this._level;
                return false;
            }
        }


    }
}
