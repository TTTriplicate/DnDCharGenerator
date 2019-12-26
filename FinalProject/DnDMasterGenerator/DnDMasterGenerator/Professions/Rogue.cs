﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DnDClassesTest
{
    class Rogue : Profession
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

        public Rogue()
        {
            this._level = 1;
            this._hitDie = 8;
            this._caster = (this._proPath == 2)? true : false;
            this._numProSkills = 4;
        }

        public Rogue(int level, int path)
        {
            this._level = level;
            this._hitDie = 8;
            this._proPath = path;
            this._caster = (path == 2) ? true : false;
            this._numProSkills = 4;
            this.Features = this.ClassFeatures();
            this.CurrFeatures = this.CurrentFeatures();
            this._abilityScoreIncrease = new int[5] { 4, 8, 12, 16, 19 };


        }
        public override bool[] ClassSkills()
        {//Acrobatics, Athletics, Deception. Insight, Intimidation, Investigation,
        //Perception, Performance.Persuasion, Sleight of Hand, Stealth
            bool[] SkillList = new bool[18];
            SkillList[0] = true;
            SkillList[2] = true;
            SkillList[4] = true;
            SkillList[6] = true;
            SkillList[7] = true;
            SkillList[8] = true;
            SkillList[11] = true;
            SkillList[12] = true;
            SkillList[13] = true;
            SkillList[15] = true;
            SkillList[16] = true;
            return SkillList;
        }

        public override bool[] SavingThrows()
        {
            bool[] Saves = new bool[6] /*{ 0, 1, 0, 0, 0, 1 }*/
            ;
            Saves[1] = true;
            Saves[3] = true;
            return Saves;
        }

        public int ProficiencyBonus()
        {//passes the proficiency bonus to main function
            return 2 + (this._level / 5);
        }

        protected override List<string> ClassFeatures()
        {
            List<string> features = new List<string>();
            String path = Path.Combine(Environment.CurrentDirectory, @"..\..\Professions\ClassFeatures\RogueClassFeatures.txt");
            //string path = @"C:\Users\csous\source\repos\DnDClassesTest\DnDClassesTest\Professions\ClassFeatures\BarbarianClassFeatures.txt";
            string[] temp = new string[19];
            temp = File.ReadAllLines(path);
            foreach (string i in temp)
            {
                features.Add(i);
            }

            return features;

        }



        protected override bool[] Unlocked()
        {
            bool[] unlocked = new bool[12]/*{ false, false, false, false, false, false, false, false }*/;
            unlocked[0] = true;         //false is the default, shouldn't need that
            if (this._level >= 2) unlocked[1] = true;
            if (this._level >= 3) unlocked[2] = true;
            if (this._level >= 5) unlocked[3] = true;
            if (this._level >= 7) unlocked[4] = true;
            if (this._level >= 9) unlocked[5] = true;
            if (this._level >= 11) unlocked[6] = true;
            if (this._level >= 13) unlocked[7] = true;
            if (this._level >= 14) unlocked[8] = true;
            if (this._level >= 15) unlocked[9] = true;
            if (this._level >= 17) unlocked[10] = true;
            if (this._level >= 18) unlocked[11] = true;
            if (this._level == 20) unlocked[12] = true;
            return unlocked;
        }

        protected override List<string> CurrentFeatures()
        {
            List<string> current = new List<string>();
            bool[] unlock = this.Unlocked();
            int i;
            for (i = 1; i <= 12; ++i)
            {
                if (!unlock[i])
                {
                    --i;
                    break;
                }
            }
            current = Features.GetRange(0, 2);
            if (i == 1) current = Features.GetRange(0, 3);
            else if (i == 3) current = Features.GetRange(0, 4);
            else if (i == 4) current = Features.GetRange(0, 5);
            else if (i == 6) current = Features.GetRange(0, 6);
            else if (i == 8) current = Features.GetRange(0, 7);
            else if (i == 9) current = Features.GetRange(0, 8);
            else if (i == 11) current = Features.GetRange(0, 9);
            else if (i == 12) current = Features.GetRange(0, 10);

            if(_proPath == 0)
            {
                if (i < 2) return current;
                else if (i >= 2)
                {
                    current.Add(Features[11]);
                    current.Add(Features[12]);
                }
                else if (i >= 5) current.Add(Features[13]);
                else if (i >= 7) current.Add(Features[14]);
                else if (i >= 10) current.Add(Features[15]);
            }

            else if(_proPath == 1)
            {
                if (i < 2) return current;
                else if (i >= 2)
                {
                    current.Add(Features[16]);
                    current.Add(Features[17]);
                }
                else if (i >= 5) current.Add(Features[18]);
                else if (i >= 7) current.Add(Features[19]);
                else if (i >= 10) current.Add(Features[20]);
            }

            else if (_proPath == 2)
            {
                if (i < 2) return current;
                else if (i >= 2) current.Add(Features[21]);
                else if (i >= 5) current.Add(Features[22]);
                else if (i >= 7) current.Add(Features[23]);
                else if (i >= 10) current.Add(Features[24]);
            }

            return current;
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
                if (i == 1) CurrFeatures.Add(Features[3]);
                else if (i == 3) CurrFeatures.Add(Features[4]);
                else if (i == 4) CurrFeatures.Add(Features[5]);
                else if (i == 6) CurrFeatures.Add(Features[6]);
                else if (i == 8) CurrFeatures.Add(Features[7]);
                else if (i == 9) CurrFeatures.Add(Features[8]);
                else if (i == 11) CurrFeatures.Add(Features[9]);
                else if (i == 12) CurrFeatures.Add(Features[10]);

                if (_proPath == 0)
                {
                    if (i == 2)
                    {
                        CurrFeatures.Add(Features[11]);
                        CurrFeatures.Add(Features[12]);
                    }
                    else if (i == 5) CurrFeatures.Add(Features[13]);
                    else if (i == 7) CurrFeatures.Add(Features[14]);
                    else if (i == 10) CurrFeatures.Add(Features[15]);
                }

                else if (_proPath == 1)
                {
                    if (i == 2)
                    {
                        CurrFeatures.Add(Features[16]);
                        CurrFeatures.Add(Features[17]);
                    }
                    else if (i == 5) CurrFeatures.Add(Features[18]);
                    else if (i == 7) CurrFeatures.Add(Features[19]);
                    else if (i == 10) CurrFeatures.Add(Features[20]);
                }

                else if (_proPath == 2)
                {
                    if (i == 2) CurrFeatures.Add(Features[21]);
                    else if (i == 5) CurrFeatures.Add(Features[22]);
                    else if (i == 7) CurrFeatures.Add(Features[23]);
                    else if (i == 10) CurrFeatures.Add(Features[24]);
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