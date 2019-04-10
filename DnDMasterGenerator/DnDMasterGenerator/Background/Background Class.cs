using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace DnDClassesTest
{
    public class Background_Class
    {
        public bool[] SkillProf = new bool[18];
        public String[] ToolProf = { "Artisan's Tools", "Disguise Kit", "Forgery Kit", "Gaming Set", "Herbalism Kit", "Musical Instrument", "Navigator's tools", "Poisoner's kit", "Theives' Tools" };
        public String[] BACKGROUNDS = { "Acolyte", "Charlatan", "Criminal", "Entertainer", "Folk Hero", "Guild Artisan", "Hermit", "Noble", "Outlander", "Sage", "Sailor", "Soldier", "Urchin" };
        public string[] lines;
        public string background;
        //public String[] SkillProfs = { "Acrobatics", "Animal Handling", "Arcana", "Athletics", "Deception", "History", "Insight", "Intimidation", "Investigation", "Medicine", "Nature", "Perception", "Preformance", "Persuasion", "Religion", "Sleight of Hand", "Stealth", "Survival" };

        public Background_Class()//string background)
        {
            setBackground(background);
            //BackgroundForm form = new BackgroundForm(this);
            //setBackground(background);
            //string[] lines;
            //lines = File.ReadAllLines(path);
            //this.test = lines[0].Split()[1];
        }

        public void loadFile(string background)
        {
            string choice = "";
            String path = Path.Combine(Environment.CurrentDirectory, @"..\..\Background\" + background + ".txt");
            lines = File.ReadAllLines(path);
            //choice = background;
        }

        public int RanNumGen(int sides)
        {
            int randNum;

            Random dice = new Random();

            randNum = dice.Next(1, sides);

            return randNum;
        }

        public void SkillProfs(ref string skillProfOne, ref string skillProfTwo)
        {

        }

        //public void SkillProfs(ref string skillOne)

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

        public void setBackground(string background)
        {
            this.background = background;
        }

        public Background_Class getBackground()
        {
            return this;
        }

        public static Background_Class InteractiveChoice()
        {
            BackgroundForm form = new BackgroundForm();
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                return form.Character;
            }
            else return new Background_Class();
        }
    }
}
