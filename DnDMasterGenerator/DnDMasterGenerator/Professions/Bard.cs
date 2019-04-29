using System;
using System.Collections.Generic;
using System.IO;

namespace DnDClassesTest
{

    public class Bard : Profession
    {   //needs gear proficiencies to pass to character
        //and populate list based on race/background/profession/extras
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
            get; set;
        }

        public override List<string> CurrFeatures { get; set; }


        public Bard()
        {
            this._level = 1;
            this._hitDie = 8;
            this._caster = true;
            this._numProSkills = (_proPath == 0 && _level >= 3) ? 6 : 3;
        }

        public Bard(int level, int path)
        {
            this._level = level;
            this._hitDie = 8;
            this._caster = true;
            this._proPath = path;
            this._numProSkills =(_proPath == 0 && _level >= 3)? 6 : 3;
            this.Features = this.ClassFeatures();
            this.CurrFeatures = this.CurrentFeatures();
        }
        public override bool[] ClassSkills()
        {
            bool[] SkillList = new bool[18];
            for (int i = 0; i < 18; ++i)
                SkillList[i] = true;
            return SkillList;
        }

        public override bool[] SavingThrows()
        {
            bool[] Saves = new bool[6] /*{ 0, 1, 0, 0, 0, 1 }*/;
            Saves[1] = true;
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
            String path = Path.Combine(Environment.CurrentDirectory, @"..\..\Professions\ClassFeatures\BardClassFeatures.txt");
            //string path = @"C:\Users\csous\source\repos\DnDClassesTest\DnDClassesTest\Professions\ClassFeatures\BarbarianClassFeatures.txt";
            string[] temp = new string[16];
            temp = File.ReadAllLines(path);
            foreach (string i in temp)
            {
                features.Add(i);
            }
            return features;
        }



        protected override bool[] Unlocked()
        {
            bool[] unlocked = new bool[8]/*{ false, false, false, false, false, false, false, false }*/;
            unlocked[0] = true;         //false is the default, shouldn't need that
            if (this._level >= 2) unlocked[1] = true;
            if (this._level >= 3) unlocked[2] = true;
            if (this._level >= 5) unlocked[3] = true;
            if (this._level >= 6) unlocked[4] = true;
            if (this._level >= 10) unlocked[5] = true;
            if (this._level >= 14) unlocked[6] = true;
            if (this._level == 20) unlocked[7] = true;
            return unlocked;
        }

        protected override List<string> CurrentFeatures()
        {
            List<string> current = new List<string>();
            bool[] unlock = this.Unlocked();
            int i;
            for (i = 0; i <= 7; ++i)
                if (!unlock[i])
                {
                    --i;
                    break;
                }
            current.Add( Features[0]);
            if (i == 1) current = Features.GetRange(0, 2);
            else if (i == 2) current = Features.GetRange(0, 3);
            else if (i == 3) current = Features.GetRange(0, 4);
            else if (i == 4) current = Features.GetRange(0, 5);
            else if (i == 5) current = Features.GetRange(0, 6);
            else if (i == 7) current = Features.GetRange(0, 7);

            if (_proPath == 0)
            {
                if (i < 2) return current;
                if (i > 2)
                {
                    current.Add(Features[8]);
                    current.Add(Features[9]);
                }
                if (i > 4) current.Add(Features[10]);
                if (i > 6) current.Add(Features[11]);
            }
            else if (_proPath == 1)
            {
                if (i < 2) return current;
                if (i > 2)
                {
                    current.Add(Features[12]);
                    current.Add(Features[13]);
                }
                if (i > 4) current.Add(Features[14]);
                if (i > 6) current.Add(Features[15]);
            }
            return current;
        }


        public int[] JackOfAllTrades()
        {//half proficiency bonus to non-proficient skills
            int n = this.ProficiencyBonus() / 2;
            int[] nonPro = new int[18];
            for (int i = 0; i < 18; ++i)
            {
                if (_pickedSkills[i] == true) nonPro[i] = n;
                else nonPro[i] = 0;
            }
            return nonPro;
        }
        
        /*need to fill with all the crunch
         * stats and description for class features
         * IOT read against ClassFeatures bool[]
         [0] = inspiration
         [1] = song of rest, jack of all trades
         [2] = expertise, class path feature 1
         [3] = font of inspiration
         [4] = countercharm, class path 2
         [5] = magical secrets
         [6] = class path 3
         [7] = superior inspiration
         most of this is just write to character sheet
         write from files at given indexes?*/
    }
}