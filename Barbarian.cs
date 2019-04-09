﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
        private int[] Totem = new int[3] { 0, 0, 0 };//bear, eagle, wolf in order 0 1 2, for each use by index
        private int GetTotem(int index)
        {
            return this.Totem[index];
        }
        private bool SetTotem(int index, int totem)
        {
            try
            {
                this.Totem[index] = totem;
                return true;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }
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

        public int ProficiencyBonus()
        {//passes the proficiency bonus to main function
            return 2 + (this._level / 5);
        }

        public override List<string> ClassFeatures()
        {
            List<string> features = new List<string>();
            string path = @"C:\Users\csous\source\repos\DnDClassesTest\DnDClassesTest\Professions\ClassFeatures\BarbarianClassFeatures.txt";
            string[] temp = new string[28];
            try
            {
                temp = File.ReadAllLines(path);
                foreach (string i in temp)
                {
                    features.Add(i);
                }
            }
            catch (DirectoryNotFoundException)
            {
                return features;
            }

            return features;

        }
        public override bool[] Unlocked()
        {
            bool[] unlock = new bool[13];
            unlock[0] = true;
            if (this._level == 2) unlock[1] = true;
            if (this._level == 3) unlock[2] = true;
            if (this._level == 5) unlock[3] = true;
            if (this._level == 6) unlock[4] = true;
            if (this._level == 7) unlock[5] = true;
            if (this._level == 9) unlock[6] = true;
            if (this._level == 10) unlock[7] = true;
            if (this._level == 11) unlock[8] = true;
            if (this._level == 14) unlock[9] = true;
            if (this._level == 15) unlock[10] = true;
            if (this._level == 18) unlock[11] = true;
            if (this._level == 20) unlock[12] = true;
            return unlock;
        }
        public override List<string> CurrentFeatures()
        {
            List<string> current = new List<string>();
            bool[] unlock = this.Unlocked();
            int i;
            for (i = 12; i <= 0; --i)
            {
                if (unlock[i]) break;
            }
            try
            {
                if (i == 12) current = Features.GetRange(0, 11);
                if (_proPath == 0)
                {
                    if (i < 2) return current;
                    if (i > 2) current.Add(Features[12]);
                    if (i > 4) current.Add(Features[13]);
                    if (i > 7) current.Add(Features[14]);
                    if (i > 8) current.Add(Features[15]);
                }
                else if (_proPath == 1)
                {
                    if (i < 2) return current;
                    if (i > 2)
                    {
                        current.Add(Features[16]);
                        current.Add(Features[17]);
                        if (this.GetTotem(0) == 0) current.Add(Features[18]);
                        else if (this.GetTotem(0) == 1) current.Add(Features[19]);
                        else current.Add(Features[20]);
                    }
                    if (i > 4)
                    {
                        if (this.GetTotem(1) == 0) current.Add(Features[21]);
                        else if (this.GetTotem(1) == 1) current.Add(Features[22]);
                        else current.Add(Features[23]);
                    }
                    if (i > 7) current.Add(Features[24]);
                    if (i > 8)
                    {
                        if (this.GetTotem(2) == 0) current.Add(Features[25]);
                        else if (this.GetTotem(2) == 1) current.Add(Features[26]);
                        else current.Add(Features[27]);
                    }
                }
            }
            catch (Exception)
            {
                return current;
            }
        
            return current;
        }

        public int[] PrimalChampion()
        {
            int[] increase = new int[6] { 4, 0, 4, 0, 0, 0 };
            return increase;
        }
}
}