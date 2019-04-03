using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DnDClassesTest
{
    public class Background_Class
    {
        public String[] SkillProf = { };
        public String[] ToolProf = { };
        public String[] BACKGROUNDS = { "Acolyte", "Charlatan", "Criminal", "Entertainer", "Folk Hero", "Guild Artisan", "Hermit", "Noble", "Outlander", "Sage", "Sailor", "Soldier", "Urchin" };
        public string[] lines;

        public Background_Class()
        {
            //string[] lines;
            //lines = File.ReadAllLines(path);
            //this.test = lines[0].Split()[1];
        }

        public String loadFile(string background)
        {
            string choice = "";
            String path = Path.Combine(Environment.CurrentDirectory, @"..\..\" + background +".txt");
            lines = File.ReadAllLines(path);
            choice = background;

            return choice;
        }

        public int RanNumGen(int sides)
        {
            int randNum;

            Random dice = new Random();

            randNum = dice.Next(1, sides);

            return randNum;
        }

        //public String PersonalityTrait()
        //{
        //    string[] traits = { "f", "f", "f", "f", "f", "f", "f", "f"};
        //    string trait = "";

        //    int randNum = RanNumGen(8);

        //    for (int i = 1; i < 8; i++)
        //        traits[i] = lines[(2 + i)].Split(':')[1];

        //    trait = traits[randNum];

        //    return trait;
        //}

        //public String Ideal()
        //{
        //    string[] traits = { "f", "f", "f", "f", "f", "f"};
        //    string finalTrait = "";

        //    int randNum = RanNumGen(6);

        //    for (int i = 0; i < 6; i++)
        //        traits[i] = lines[(14 + i)].Split(':')[1];

        //    finalTrait = traits[randNum];

        //    return finalTrait;
        //}

        public void Traits(ref string Personality, ref string Ideal, ref string Flaw, ref string Bond)
        {
            string[] personalities = { "f", "f", "f", "f", "f", "f", "f", "f" };
            string[] ideals = { "f", "f", "f", "f", "f", "f" };
            string[] flaws = { "f", "f", "f", "f", "f", "f" };
            string[] bonds = { "f", "f", "f", "f", "f", "f" };
            //string[] finalTraits = { "f", "f", "f", "f" };

            for (int i = 1; i < 8; i++)
                personalities[i] = lines[(2 + i)].Split(':')[1];
            for (int i = 1; i < 6; i++)
                ideals[i] = lines[(13 + i)].Split(':')[1];
            for (int i = 1; i < 6; i++)
                flaws[i] = lines[(22 + i)].Split(':')[1];
            for (int i = 1; i < 6; i++)
                bonds[i] = lines[(31 + i)].Split(':')[1];

            Personality = personalities[RanNumGen(8)];
            Ideal = ideals[RanNumGen(6)];
            Flaw = flaws[RanNumGen(6)];
            Bond = bonds[RanNumGen(6)];
        }
    }
}
