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
    class Warlock : Profession
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

        //add patron? int(0-2) to pick between the three
        public Warlock()
        {
            this._level = 1;
            this._hitDie = 8;
            this._caster = true;
            this._numProSkills = 2;
            this.IndexedInvocations = new List<int>();
        }

        public Warlock(int level, int path)
        {
            this._level = level;
            this._hitDie = 8;
            this._caster = true;
            this._proPath = path;
            this._numProSkills = 2;
            this.IndexedInvocations = new List<int>();
            this.Features = this.ClassFeatures();
            this.CurrFeatures = this.CurrentFeatures();
            this._abilityScoreIncrease = new int[5] { 4, 8, 12, 16, 19 };
            this.PactBoon = -1;
        }
        public override bool[] ClassSkills()
        {//Arcana, Deception, History, Intimidation, Investigation, Nature, and Religion
            bool[] SkillList = new bool[18];
            SkillList[2] = true;
            SkillList[4] = true;
            SkillList[5] = true;
            SkillList[7] = true;
            SkillList[8] = true;
            SkillList[10] = true;
            SkillList[14] = true;
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

        private int PactBoon { get; set; }

        private List<int> IndexedInvocations { get; set; }

        public int ProficiencyBonus()
        {//passes the proficiency bonus to main function
            return 2 + (this._level / 5);
        }

        protected override List<string> ClassFeatures()
        {
            List<string> features = new List<string>();
            String path = Path.Combine(Environment.CurrentDirectory, @"..\..\Professions\ClassFeatures\WarlockClassFeatures.txt");
            //string path = @"C:\Users\csous\source\repos\DnDClassesTest\DnDClassesTest\Professions\ClassFeatures\BarbarianClassFeatures.txt";
            string[] temp = new string[49];
            temp = File.ReadAllLines(path);
            foreach (string i in temp)
            {
                features.Add(i);
            }

            return features;
        }

        public override List<string> CurrFeatures { get; set; }



        protected override bool[] Unlocked()
        {
            bool[] unlocked = new bool[8]/*{ false, false, false, false, false, false, false, false }*/;
            unlocked[0] = true;         //false is the default, shouldn't need that
            if (this._level >= 2) unlocked[1] = true;
            if (this._level >= 3) unlocked[2] = true;
            if (this._level >= 6) unlocked[3] = true;
            if (this._level >= 10) unlocked[4] = true;
            if (this._level >= 11) unlocked[5] = true;
            if (this._level >= 14) unlocked[6] = true;
            if (this._level == 20) unlocked[7] = true;
            return unlocked;
        }

        protected override List<string> CurrentFeatures()
        {
            List<string> current = new List<string>();
            bool[] unlock = this.Unlocked();
            int i;
            for (i = 0; i < 8; ++i)
            {
                if (!unlock[i])
                {
                    --i;
                    break;
                }
            }
            if (i >= 1)
            {
                current.Add(Features[0]);
                current.Add(InvocationSelect(2));
                current.Add(InvocationSelect(2));
            }
            if (i >= 2) current.Add(PactSelect());
            if (this._level >= 5) current.Add(InvocationSelect(5));
            if (this._level >= 7) current.Add(InvocationSelect(7));
            if (this._level >= 9) current.Add(InvocationSelect(9));
            if (i >= 5) current.Add(Features[1]);
            if (this._level >= 12) current.Add(InvocationSelect(12));
            if (this._level >= 15) current.Add(InvocationSelect(15));
            if (this._level >= 18) current.Add(InvocationSelect(18));
            if (i >= 7) current.Add(Features[2]);

            if(this._proPath == 0)
            {
                current.Add(Features[3]);
                if (i >= 2) current.Add(Features[4]);
                if (i >= 5) current.Add(Features[5]);
                if (i >= 7) current.Add(Features[6]);
            }

            if (this._proPath == 1)
            {
                current.Add(Features[7]);
                if (i >= 2) current.Add(Features[8]);
                if (i >= 5) current.Add(Features[9]);
                if (i >= 7) current.Add(Features[10]);
            }

            if (this._proPath == 2)
            {
                current.Add(Features[11]);
                if (i >= 2) current.Add(Features[12]);
                if (i >= 5) current.Add(Features[13]);
                if (i >= 7) current.Add(Features[14]);
            }

            return current;
        }

        private string PactSelect()
        {
            var pact = new PickOne(Features.GetRange(15, 3));
            var result = pact.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                this.PactBoon = pact.Selected;
                return pact.Choices[PactBoon];
            }
            else return PactSelect();
        }

        private string InvocationSelect(int currLevel)
        {//gets basic invocations to start with
            List<string> invocations = Features.GetRange(18, 14);
            if(currLevel >= 5)
            {//adds level 5 invocations if applicable
                foreach (string i in Features.GetRange(32, 3))
                    invocations.Add(i);
            }
            if(currLevel >= 7)
            {//level 7
                foreach (string i in Features.GetRange(35, 3))
                    invocations.Add(i);
            }
            if (currLevel >= 9)//level 9, just removed brackets
                foreach (string i in Features.GetRange(38, 4))
                    invocations.Add(i);
            if (currLevel >= 15)//level 15s
                foreach (string i in Features.GetRange(42, 2))
                    invocations.Add(i);
            if(PactBoon == 0)//if pact of chains, adds first invocation
            {//adds second if level requirement met
                invocations.Add(Features[44]);
                if (currLevel >= 15) invocations.Add(Features[45]);
            }
            if(PactBoon == 1)//pact of the blade invocations
            {//check level and add as appropriate
                if (currLevel >= 5) invocations.Add(Features[46]);
                if (currLevel >= 12) invocations.Add(Features[47]);
            }
            if (PactBoon == 2) invocations.Add(Features[48]);
            //pact of the tome adds it's invocation
            if (this.IndexedInvocations.Any())
            {//if any int indicating selected invocations,
                foreach (int i in this.IndexedInvocations)
                {
                    invocations.RemoveAt(i);//pull those indicies
                }
            }

            var sel = new PickOne(invocations);
            var result = sel.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.IndexedInvocations.Add(sel.Selected);
                    Console.WriteLine(sel.Selected);
                return sel.Choices[sel.Selected];
            }
            else return InvocationSelect(currLevel);
            
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
                if (i == 1)
                {
                    CurrFeatures.Add(Features[0]);
                    CurrFeatures.Add(InvocationSelect(2));
                    CurrFeatures.Add(InvocationSelect(2));
                }
                if (i == 2) CurrFeatures.Add(PactSelect());
                if (this._level == 5) CurrFeatures.Add(InvocationSelect(5));
                if (this._level == 7) CurrFeatures.Add(InvocationSelect(7));
                if (this._level == 9) CurrFeatures.Add(InvocationSelect(9));
                if (i == 5) CurrFeatures.Add(Features[1]);
                if (this._level == 12) CurrFeatures.Add(InvocationSelect(12));
                if (this._level == 15) CurrFeatures.Add(InvocationSelect(15));
                if (this._level == 18) CurrFeatures.Add(InvocationSelect(18));
                if (i == 7) CurrFeatures.Add(Features[2]);

                if (this._proPath == 0)
                {
                    CurrFeatures.Add(Features[3]);
                    if (i == 2) CurrFeatures.Add(Features[4]);
                    if (i == 5) CurrFeatures.Add(Features[5]);
                    if (i == 7) CurrFeatures.Add(Features[6]);
                }

                if (this._proPath == 1)
                {
                    CurrFeatures.Add(Features[7]);
                    if (i == 2) CurrFeatures.Add(Features[8]);
                    if (i == 5) CurrFeatures.Add(Features[9]);
                    if (i == 7) CurrFeatures.Add(Features[10]);
                }

                if (this._proPath == 2)
                {
                    CurrFeatures.Add(Features[11]);
                    if (i == 2) CurrFeatures.Add(Features[12]);
                    if (i == 5) CurrFeatures.Add(Features[13]);
                    if (i == 7) CurrFeatures.Add(Features[14]);
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
