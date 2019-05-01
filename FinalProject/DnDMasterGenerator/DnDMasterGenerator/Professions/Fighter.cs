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
        protected override List<string> Features { get; set; }

        public override List<string> CurrFeatures { get; set; }


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
            this.Features = this.ClassFeatures();
            this.Manuevers = new List<int>();
            this.Styles = new List<int>();
            this.CurrFeatures = this.CurrentFeatures();
        }
        public override bool[] ClassSkills()
        {
            bool[] SkillList = new bool[18];
            //Acrobatics, Animal Handling, Athletics, History, Insight, Intimidation, Perception, and Survival
            SkillList[0] = true;
            SkillList[1] = true;
            SkillList[3] = true;
            SkillList[7] = true;
            SkillList[10] = true;
            SkillList[11] = true;
            SkillList[17] = true;
            return SkillList;
        }

        public override bool[] SavingThrows()
        {
            bool[] Saves = new bool[6] /*{ 1, 0, 1, 0, 0, 0 }*/;
            Saves[0] = true;
            Saves[2] = true;
            return Saves;
        }

        private List<int> Manuevers { get; set; }

        private List<int> Styles { get; set; }

        public int ProficiencyBonus()
        {//passes the proficiency bonus to main function
            return 2 + (this._level / 5);
        }

        protected override List<string> ClassFeatures()
        {
            List<string> features = new List<string>();
            String path = Path.Combine(Environment.CurrentDirectory, @"..\..\Professions\ClassFeatures\FighterClassFeatures.txt");
            //string path = @"C:\Users\csous\source\repos\DnDClassesTest\DnDClassesTest\Professions\ClassFeatures\BarbarianClassFeatures.txt";
            string[] temp = new string[35];
            temp = File.ReadAllLines(path);
            foreach (string i in temp)
            {
                features.Add(i);
            }

            return features;
        }
        protected override bool[] Unlocked()
        {//this might need jesus on this one...three classes in a trenchcoat....
            bool[] unlock = new bool[9];
            unlock[0] = true;
            if (this._level >= 2) unlock[1] = true;
            if (this._level >= 3) unlock[2] = true;
            if (this._level >= 5) unlock[3] = true;
            if (this._level >= 7) unlock[4] = true;
            if (this._level >= 9) unlock[5] = true;
            if (this._level >= 10) unlock[6] = true;
            if (this._level >= 15) unlock[7] = true;
            if (this._level >= 18) unlock[8] = true;
            return unlock;
        }
        protected override List<string> CurrentFeatures()
        {
            List<string> current = new List<string>();
            bool[] unlock = this.Unlocked();
            int i;
            for (i = 0; i <= 8; ++i)
            {
                if (!unlock[i])
                {
                    --i;
                    break;
                }
            }
            Console.WriteLine(i);
            current.Add(Features[0]);

            current.Add(this.ChooseFightingStyle());
            if (i >= 1) current.Add(Features[1]);
            if (i >= 2) current.Add(Features[2]);
            if (i >= 5) current.Add(Features[3]);

            if (_proPath == 0)
            {
                if (i < 2) return current;
                if (i >= 2) current.Add(Features[4]);
                if (i >= 4) current.Add(Features[5]);
                if (i >= 6)
                {
                    current.Add(Features[6]);
                    current.Add(this.ChooseFightingStyle());
                    if (i >= 7) current.Add(Features[7]);
                    if (i >= 8) current.Add(Features[8]);
                }
            }
            else if (_proPath == 1)
            {
                if (i < 2) return current;
                if (i >= 2)
                {
                    current.Add(Features[9]);
                    current.Add(Features[10]);
                    int j = 0;
                    while (j < 3)
                    {
                        current.Add(this.ChooseManeuver(Features.GetRange(19, 15)));
                        ++j;
                    }
                }
                if (i >= 4)
                {
                    current.Add(Features[11]);
                    int j = 0;
                    while (j < 2)
                    {
                        current.Add(this.ChooseManeuver(Features.GetRange(19, 15)));
                        ++j;
                    }
                }
                if (i >= 6) {
                    current.Add(Features[12]);
                    int j = 0;
                    while (j < 2)
                    {
                        current.Add(this.ChooseManeuver(Features.GetRange(19, 15)));
                        ++j;
                    }
                }
                if (i >= 7) {
                    current.Add(Features[13]);
                    int j = 0;
                    while (j < 2)
                    {
                        current.Add(this.ChooseManeuver(Features.GetRange(19, 15)));
                        ++j;
                    }
                }
            }
            else if (_proPath == 2)
            {
                if (i < 2) return current;
                if (i >= 2) current.Add(Features[14]);
                if (i >= 4) current.Add(Features[15]);
                if (i >= 6) current.Add(Features[16]);
                if (i >= 7) current.Add(Features[17]);
                if (i >= 8) current.Add(Features[18]);

            }
            return current;

        }


    
        private string ChooseFightingStyle()
        {
            var picker = new PickOne(this.ProfessionName());
            var result = picker.ShowDialog();
            if (result == DialogResult.OK)
            {
                Styles.Add(picker.Selected);
                return picker.Choices[picker.Selected];
            }

            else
            {
                
                return ChooseFightingStyle();
            }
        }
        private string ChooseManeuver(List<string> maneuvers)
        {
            if (this.Manuevers.Any())
            {
                List<int> rem = this.Manuevers;
                rem.Sort();
                rem.Reverse();
                foreach(int i in rem)
                {
                    maneuvers.RemoveAt(i);
                }
            }
            var sel = new PickOne(maneuvers);
            var result = sel.ShowDialog();
            if (result == DialogResult.OK)
            {
                Manuevers.Add(sel.Selected);
                return sel.Choices[sel.Selected];
            }
            else return ChooseManeuver(maneuvers);
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

                if (i == 1) CurrFeatures.Add(Features[1]);
                if (i == 2) CurrFeatures.Add(Features[2]);
                if (i == 5) CurrFeatures.Add(Features[3]);

                if (_proPath == 0)
                {
                    if (i == 2) CurrFeatures.Add(Features[4]);
                    if (i == 4) CurrFeatures.Add(Features[5]);
                    if (i == 6)
                    {
                        CurrFeatures.Add(Features[6]);
                        CurrFeatures.Add(this.ChooseFightingStyle());
                    }
                    if (i == 7) CurrFeatures.Add(Features[7]);
                    if (i == 8) CurrFeatures.Add(Features[8]);

                }
                else if (_proPath == 1)
                {
                    if (i == 2)
                    {
                        CurrFeatures.Add(Features[9]);
                        CurrFeatures.Add(Features[10]);
                        int j = 0;
                        while (j < 3)
                        {
                            CurrFeatures.Add(this.ChooseManeuver(Features.GetRange(19, 15)));
                            ++j;
                        }
                    }
                    if (i == 4)
                    {
                        CurrFeatures.Add(Features[11]);
                        int j = 0;
                        while (j < 2)
                        {
                            CurrFeatures.Add(this.ChooseManeuver(Features.GetRange(19, 15)));
                            ++j;
                        }
                    }
                    if (i == 6)
                    {
                        CurrFeatures.Add(Features[12]);
                        int j = 0;
                        while (j < 2)
                        {
                            CurrFeatures.Add(this.ChooseManeuver(Features.GetRange(19, 15)));
                            ++j;
                        }
                    }
                    if (i == 7)
                    {
                        CurrFeatures.Add(Features[13]);
                        int j = 0;
                        while (j < 2)
                        {
                            CurrFeatures.Add(this.ChooseManeuver(Features.GetRange(19, 15)));
                            ++j;
                        }
                    }
                }
                else if (_proPath == 2)
                {
                    if (i == 2) CurrFeatures.Add(Features[14]);
                    if (i == 4) CurrFeatures.Add(Features[15]);
                    if (i == 6) CurrFeatures.Add(Features[16]);
                    if (i == 7) CurrFeatures.Add(Features[17]);
                    if (i == 8) CurrFeatures.Add(Features[18]);

                }

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
