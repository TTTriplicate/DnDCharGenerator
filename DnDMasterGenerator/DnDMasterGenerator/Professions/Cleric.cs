using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDClassesTest
{
    class Cleric : Profession
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
            get;            set;            //contains full listing of class features 
             //to be passed to character sheet through ClassFeatures method
        }
        public bool[] Proficiencies()//bool[6] {light, medium, heavy, sheild, simple, martial}
        {
            bool[] pros = new bool[6] { true, true, (_proPath % 2 != 0)? true : false, true, true, (this._proPath == 3 || this._proPath == 5)? true:false };
            return pros;
        }

        public Cleric()
        {
            this._level = 1;
            this._hitDie = 8;
            this._caster = true;
            this._numProSkills = 2;
        }

        public Cleric(int level, int path)
        {
            this._level = level;
            this._hitDie = 8;
            this._caster = true;
            this._proPath = path;
            this._numProSkills = 2;
            this.Features = this.ClassFeatures();
        }
        public override bool[] ClassSkills()
        {//history insight medicine persuasion religion
            bool[] SkillList = new bool[18];
            /*bool[] = true;
             * bool[] = true;
             * bool[] = true;
             * bool[] = true;
             * bool[] = true;*/
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
            List<string> features = new List<string>();
            String path = Path.Combine(Environment.CurrentDirectory, @"..\..\Professions\ClassFeatures\ClericClassFeatures.txt");
            //string path = @"C:\Users\csous\source\repos\DnDClassesTest\DnDClassesTest\Professions\ClassFeatures\BarbarianClassFeatures.txt";
            string[] temp = new string[33];
            temp = File.ReadAllLines(path);
            foreach (string i in temp)
            {
                features.Add(i);
            }

            return features;
        }



        public override bool[] Unlocked()
        {
            bool[] unlocked = new bool[7]/*{ false, false, false, false, false, false, false, false }*/;
            unlocked[0] = true;         //false is the default, shouldn't need that
            if (this._level >= 2) unlocked[1] = true;
            if (this._level >= 5) unlocked[2] = true;
            if (this._level >= 6) unlocked[3] = true;
            if (this._level >= 8) unlocked[4] = true;
            if (this._level >= 10) unlocked[5] = true;
            if (this._level >= 17) unlocked[6] = true;
            return unlocked;
        }

        public override List<string> CurrentFeatures()
        {
            List<string> current = new List<string>();
            bool[] unlock = this.Unlocked();
            int i;
            for (i = 0; i <= 6; ++i)
            {
                if (!unlock[i]) break;
            }
            current.Add(Features[0]);
            if (i == 1) current = Features.GetRange(0, 1);
            else if (i == 2) current = Features.GetRange(0, 2);
            else if (i >= 5) current = Features.GetRange(0, 3);

            if (_proPath == 0)
            {
                if (i < 1) return current;
                if (i >= 1) current.Add(Features[4]);
                if (i >= 2) current.Add(Features[5]);
                if (i >= 4) current.Add(Features[6]);
                if (i >= 6) current.Add(Features[7]);
            }
            else if (_proPath == 1)
            {
                current.Add(Features[8]);
                if (i < 1) return current;
                if (i >= 1) current.Add(Features[9]);
                if (i >= 2) current.Add(Features[10]);
                if (i >= 4) current.Add(Features[11]);
                if (i >= 6) current.Add(Features[12]);
            }
            else if (_proPath == 2)
            {
                current.Add(Features[13]);
                current.Add(Features[14]);
                if (i < 1) return current;
                if (i >= 1) current.Add(Features[15]);
                if (i >= 2) current.Add(Features[16]);
                if (i >= 4) current.Add(Features[17]);
                if (i >= 6) current.Add(Features[18]);

            }
            else if (_proPath == 3)
            {
                if (i < 1) return current;
                if (i >= 1) current.Add(Features[19]);
                if (i >= 2) current.Add(Features[20]);
                if (i >= 4) current.Add(Features[21]);
                if (i >= 6) current.Add(Features[22]);
            }
            else if (_proPath == 4)
            {
                current.Add(Features[23]);
                if (i < 1) return current;
                if (i >= 1) current.Add(Features[24]);
                if (i >= 2) current.Add(Features[25]);
                if (i >= 4) current.Add(Features[26]);
                if (i >= 6) current.Add(Features[27]);
            }
            else if (_proPath == 5)
            {
                current.Add(Features[28]);
                if (i < 1) return current;
                if (i >= 1) current.Add(Features[29]);
                if (i >= 2) current.Add(Features[30]);
                if (i >= 4) current.Add(Features[31]);
                if (i >= 6) current.Add(Features[32]);

            }
            return current;
        }

        //insert class feature methods here
    }
}

