using DnDMasterGenerator.Professions.ClassFeatures.MetaMagic;
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
            string[] temp = new string[13];
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
                current.AddRange(SelectMetamagic());
            }
            
            if (i >= 2) current.Add(Features[1]);
            if (i >= 3 && _proPath == 0) current.Add(Features[5]);
            else if (i >= 3 && _proPath == 1) current.Add(Features[11]);
            if (i >= 4 && _proPath == 0) current.Add(Features[6]);
            if(this._level >= 10) current.AddRange(SelectMetamagic());
            else if (i >= 4 && _proPath == 1) current.Add(Features[12]);
            if (i >= 5 && _proPath == 0) current.Add(Features[7]);
            if(this._level >= 17) current.AddRange(SelectMetamagic());
            else if(i >= 5 && _proPath == 1)current.Add(Features[13]);
            if (i >= 6) current.Add(Features[2]);
            return current;
        }

        private List<string> SelectMetamagic()
        {
 //           int[] indicies = this.MetaSelect;
            List<string> select = new List<string>();
   /*         var choose = new MetamagicSelect(indicies);
            
            var result = choose.ShowDialog();
            if(result == DialogResult.OK)
            {
                foreach (int i in choose.Selected)
                    select.Add(choose.Source[i]);
                for (int i = 0; i < MetaSelect.Length; ++i)
                    MetaSelect[i] = choose.Current[i];
            }
            */
            return select;
        }
         public override bool LevelUp(){return true;}

    }
}
