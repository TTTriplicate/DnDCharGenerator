using System;
using System.Collections.Generic;

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
            //this.ClassFeatures = this.Unlocked();
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

        public override List<string> ClassFeatures()
        {
            int path = this._proPath;
            List<string> features = new List<string>();
            features.Add(Inspiration());//0
            features.Add(SongOfRest());//1
            features.Add(path == 0 ? CuttingWords() : CombatInspiration());//2
            features.Add(FontOfInspiration());//3
            features.Add(CounterCharm());//4
            features.Add(path == 0 ? ExtraSecrets() : ExtraAttack());//4
            features.Add(MagicSecrets());//5
            features.Add(path == 0 ? PeerlessSkill() : BattleMagic());//6
            features.Add(SuperiorInspiration());//7
            return features;

        }



        public override bool[] Unlocked()
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

        public override List<string> CurrentFeatures()
        {
            List<string> current = new List<string>();
            bool[] unlock = this.Unlocked();
            int i;
            for (i = 0; i <= 7; ++i)
            {
                if (unlock[i]) break;
            }
            if (i == 7) current = Features;
            else if (i == 6) current = Features.GetRange(0, 7);
            else if (i == 5) current = Features.GetRange(0, 6);
            else if (i == 4) current = Features.GetRange(0, 5);
            else if (i == 3) current = Features.GetRange(0, 3);
            else if (i == 2) current = Features.GetRange(0, 2);
            else if (i == 1) current = Features.GetRange(0, 1);
            else current.Add(Features[0]);
            return current;
        }


        public string Inspiration()
        {
            string inspire = this.Features[0];
            inspire.Replace("#", $"{6 + ((this._level / 5) * 2)}");
            return inspire;
        }
        public string SongOfRest()
        {
            return $"If you or any friendly creatures who can hear your performance regain hit points at the end of the short rest, each of those creatures regains an extra 1d{6 + (this._level / 2)} hit points.";
        }
        protected string CuttingWords()
        {
            return "When a creature that you can see within 60 feet of you makes an attack roll, an ability check, or a damage roll, you can use your reaction to expend one of your uses of Bardic Inspiration, rolling a Bardic Inspiration die and subtracting the number rolled from the creature’s roll. The creature is immune if it can’t hear you or if it’s immune to being charmed.";
        }
        protected string CombatInspiration()
        {
            return "A creature that has a Bardic Inspiration die from you can roll that die and add the number rolled to a weapon damage roll it just made.Alternatively, when an attack roll is made against the creature, it can use its reaction to roll the Bardic Inspiration die and add the number rolled to its AC against that attack, after seeing the roll but before knowing whether it hits or misses.";
        }
        protected string FontOfInspiration()
        {
            return "you regain all of your expended uses of Bardic Inspiration when you finish a short or long rest.";
        }
        protected string CounterCharm()
        {
            return "At 6th level, you gain the ability to use musical notes or words of power to disrupt mind - influencing effects.As   an action, you can start a performance that lasts until the end of your next turn.During that time, you and any friendly creatures within 30 feet of you have advantage on saving throws against being frightened or charmed. A creature must be able to hear you to gain this benefit. The performance ends early if you are incapacitated or silenced or if you voluntarily end it(no action required).";
        }
        protected string ExtraSecrets()
        {
            return "you learn two spells of your choice from any class. A spell you choose must be of a level you can cast, as shown on the Bard table, or a cantrip.The chosen spells count as bard spells for you but don’t count against the number of bard spells you know.";
        }
        protected string ExtraAttack()
        {
            return "you can attack twice, instead of once, whenever you take the Attack action on your turn.";
        }
        protected string MagicSecrets()
        {
            return "Choose two spells from any class, including this one. A spell you choose must be of a level you can cast, as shown on the Bard table, or a cantrip. The chosen spells count as bard spells for you and are included in the number in the Spells Known column of the Bard table. You learn two additional spells from any class at 14th level and again at 18th level.";
        }
        protected string PeerlessSkill()
        {
            return "when you make an ability check, you can expend one use of Bardic Inspiration.Roll a Bardic Inspiration die and add the number rolled to your ability check.";
        }
        protected string BattleMagic()
        {
            return "Battle Magic: \nWhen you use your action to cast a bard spell, you can make one weapon attack as a bonus action.";
        }
        protected string SuperiorInspiration()
        {
            return "when you roll initiative and have no uses of Bardic Inspiration left, you regain one use.";
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