using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using DnDMasterGenerator.Professions;

namespace DnDClassesTest
{
    public class Barbarian : Profession
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

        public Barbarian()
        {
            this._level = 1;
            this._hitDie = 12;
            this._caster = false;
            this._numProSkills = 2;
        }
        public Barbarian(int level, int path)
        {
            this._level = level;
            this._hitDie = 12;
            this._caster = false;
            this._numProSkills = 2;
            this._proPath = path;
            this.Features = ClassFeatures();

        }
        public override bool[] ClassSkills()
        {
            bool[] SkillList = new bool[18];
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

        public override List<string> ClassFeatures()
        {
            List<string> features = new List<string>();
            String path = Path.Combine(Environment.CurrentDirectory, @"..\..\Professions\ClassFeatures\BarbarianClassFeatures.txt");
            //string path = @"C:\Users\csous\source\repos\DnDClassesTest\DnDClassesTest\Professions\ClassFeatures\BarbarianClassFeatures.txt";
            string[] temp = new string[28];
            temp = File.ReadAllLines(path);
            foreach (string i in temp)
            {
                features.Add(i);
            }

            return features;

        }
        public override bool[] Unlocked()
        {
            Console.WriteLine("this.level == " + this._level);
            bool[] unlock = new bool[13];
            unlock[0] = true;
            if (this._level >= 2) unlock[1] = true;
            if (this._level >= 3) unlock[2] = true;
            if (this._level >= 5) unlock[3] = true;
            if (this._level >= 6) unlock[4] = true;
            if (this._level >= 7) unlock[5] = true;
            if (this._level >= 9) unlock[6] = true;
            if (this._level >= 10) unlock[7] = true;
            if (this._level >= 11) unlock[8] = true;
            if (this._level >= 14) unlock[9] = true;
            if (this._level >= 15) unlock[10] = true;
            if (this._level >= 18) unlock[11] = true;
            if (this._level >= 20) unlock[12] = true;
            return unlock;
        }
        public override List<string> CurrentFeatures()
        {//word
            List<string> current = new List<string>();
            bool[] unlock = this.Unlocked();
            int i;
            for (i = 0; i <= 12; ++i)
            {
                if (unlock[i]) continue;
                else break;
            }
            current = Features.GetRange(0, 2);
            if (i >= 1)
            {
                current.Add(Features[2]);
                current.Add(Features[3]);
            }
            else if (i >= 3)
            {
                current.Add(Features[4]);
                current.Add(Features[5]);
            }
            else if (i >= 5) current.Add(Features[6]);
            else if (i >= 6) current.Add(Features[7]);
            else if (i >= 8) current.Add(Features[8]);
            else if (i >= 10) current.Add(Features[9]);
            else if (i >= 11) current.Add(Features[10]);
            else if (i >= 12) current.Add(Features[11]);

            if (_proPath == 0)
            {
                if (i < 2) return current;
                if (i >= 2) current.Add(Features[12]);
                if (i >= 4) current.Add(Features[13]);
                if (i >= 7) current.Add(Features[14]);
                if (i >= 8) current.Add(Features[15]);
            }
            else if (_proPath == 1)
            {
                if (i < 2) return current;
                if (i >= 2)
                {
                    current.Add(Features[16]);
                    current.Add(Features[17]);
                    current.Add(this.TotemChoice(Features.GetRange(18, 3)));
                }
                if (i >= 4) current.Add(this.TotemChoice(Features.GetRange(21, 3)));
                if (i >= 7) current.Add(Features[24]);
                if (i >= 8) current.Add(this.TotemChoice(Features.GetRange(25, 3)));

            }

            return current;
        }

        public int[] PrimalChampion()
        {
            int[] increase = new int[6] { 4, 0, 4, 0, 0, 0 };
            return increase;
        }

        private string TotemChoice(List<string> choices)
        {
            var sel = new PickOne(choices);
            var result = sel.ShowDialog();
            if (result == DialogResult.OK)
            {
                return sel.Choices[sel.Selected];
            }
            else
                return this.TotemChoice(choices);
        }
        //public static SkillSelect skillInteractive(int numSkills, bool[] skillRestrictions)
        //{
        //    SkillSelect form = new SkillSelect(numSkills, skillRestrictions);
        //    DialogResult result = form.ShowDialog();
        //    if (result == DialogResult.OK)
        //    {
        //        return form.selected;
        //    }
        //    else return new SkillSelect(numSkills, skillRestrictions);
        //}
    }
}