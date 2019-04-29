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
        //public bool[] ToolProf = new bool[9];
        public String[] BACKGROUNDS = { "Acolyte", "Charlatan", "Criminal", "Entertainer", "Folk Hero", "Guild Artisan", "Hermit", "Noble", "Outlander", "Sage", "Sailor", "Soldier", "Urchin" };
        public string[] lines;
        //public string background;
        protected int numLang;
        protected string[] info; 
        public bool[] backlanguage = new bool[16];
        public String[] allSkillProfs = { "Acrobatics", "Animal Handling", "Arcana", "Athletics", "Deception", "History", "Insight", "Intimidation", "Investigation", "Medicine", "Nature", "Perception", "Preformance", "Persuasion", "Religion", "Sleight of Hand", "Stealth", "Survival" };
        //public String[] allToolProfs = { "Artisan’s Tools", "Disguise Kit", "Forgery Kit", "Gaming Set", "Herbalism Kit", "Musical Instrument", "Navigator’s Tools", "Poisoner’s Kit", "Thieves’ Tools" };
        public string[] personalities = { "f", "f", "f", "f", "f", "f", "f", "f" };
        public string[] ideals = { "f", "f", "f", "f", "f", "f" };
        public string[] flaws = { "f", "f", "f", "f", "f", "f" };
        public string[] bonds = { "f", "f", "f", "f", "f", "f" };

        public string Personality, Ideal, Flaw, Bond, Background, SkillProfOne, SkillProfTwo, Race, Hair, Skin, Eyes, Weight, Height, Age, Gender;

        public Background_Class()//string background)
        {
            //setBackground(background);
            //BackgroundForm form = new BackgroundForm(this);
            //setBackground(background);
            //string[] lines;
            //lines = File.ReadAllLines(path);
            //this.test = lines[0].Split()[1];
        }

        public Background_Class(string background)
        {
            this.Background = background;
            loadFile(background);
            Traits();
            SkillProfs(background);
            
            //runLanq();
        }

        public Background_Class(string race, string background)
        {
            this.Race = race;
        }

        public void loadFile(string background)
        {
            //string choice = "";
            //this.background = background;
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

        public void SkillProfs(string bg)
        {
            switch (bg)
            {
                case "Acolyte":
                    SkillProfOne = "Insight";
                    SkillProfTwo = "Religion";
                    SkillProf[6] = true;
                    SkillProf[14] = true;
                    break;
                case "Charlatan":
                    SkillProfOne = "Deception";
                    SkillProfTwo = "Sleight of Hand";
                    SkillProf[4] = true;
                    SkillProf[15] = true;
                    break;
                case "Criminal":
                    SkillProfOne = "Deception";
                    SkillProfTwo = "Stealth";
                    SkillProf[4] = true;
                    SkillProf[16] = true;
                    break;
                case "Entertainer":
                    SkillProfOne = "Acrobatics";
                    SkillProfTwo = "Performance";
                    SkillProf[0] = true;
                    SkillProf[13] = true;
                    break;
                case "Folk Hero":
                    SkillProfOne = "Animal Handing";
                    SkillProfTwo = "Survival";
                    SkillProf[1] = true;
                    SkillProf[17] = true;
                    break;
                case "Guild Artisan":
                    SkillProfOne = "Insight";
                    SkillProfTwo = "Persuasion";
                    SkillProf[6] = true;
                    SkillProf[13] = true;
                    break;
                case "Hermit":
                    SkillProfOne = "Medicine";
                    SkillProfTwo = "Religion";
                    SkillProf[9] = true;
                    SkillProf[14] = true;
                    break;
                case "Noble":
                    SkillProfOne = "History";
                    SkillProfTwo = "Persuasion";
                    SkillProf[5] = true;
                    SkillProf[13] = true;
                    break;
                case "Outlander":
                    SkillProfOne = "Athletics";
                    SkillProfTwo = "Survival";
                    SkillProf[3] = true;
                    SkillProf[17] = true;
                    break;
                case "Sage":
                    SkillProfOne = "Arcana";
                    SkillProfTwo = "History";
                    SkillProf[2] = true;
                    SkillProf[5] = true;
                    break;
                case "Sailor":
                    SkillProfOne = "Athletics";
                    SkillProfTwo = "Perception";
                    SkillProf[3] = true;
                    SkillProf[12] = true;
                    break;
                case "Soldier":
                    SkillProfOne = "Athletics";
                    SkillProfTwo = "Intimidation";
                    SkillProf[3] = true;
                    SkillProf[7] = true;
                    break;
                case "Urchin":
                    SkillProfOne = "Sleight of Hand";
                    SkillProfTwo = "Stealth";
                    SkillProf[15] = true;
                    SkillProf[16] = true;
                    break;

                default:
                    break;
            }
        }

        public void runLanq()
        {
            getLang();
            int findmebish = 1;
            foreach (string phrase in info)
            {
                if (phrase == "I will never leave you alone")
                {
                    while (findmebish++ > 0)
                    {
                        if (findmebish % 10 == 0)
                        {
                            MessageBox.Show(info[6], ":)");
                            MessageBox.Show("Sike", ":(");
                        }
                        else
                            MessageBox.Show(phrase);

                    }
                }
                else
                {
                    MessageBox.Show(phrase);
                }
            }
        }

        //public void SkillProfs(ref string skillOne)
        
        public void loadShit()
        {
            loadFile(Background);
            for (int i = 0; i < 8; i++)
                personalities[i] = lines[(2 + i)].Split(':')[1];
            for (int i = 0; i < 6; i++)
                ideals[i] = lines[(13 + i)].Split(':')[1];
            for (int i = 0; i < 6; i++)
                flaws[i] = lines[(22 + i)].Split(':')[1];
            for (int i = 0; i < 6; i++)
                bonds[i] = lines[(31 + i)].Split(':')[1];
        }

        public void Traits()
        {
            //string[] finalTraits = { "f", "f", "f", "f" };

            loadShit();

            this.Personality = personalities[RanNumGen(8)];
            this.Ideal = ideals[RanNumGen(6)];
            this.Flaw = flaws[RanNumGen(6)];
            this.Bond = bonds[RanNumGen(6)];

            numLang = 0;
            if (lines.Contains("L1"))
                numLang = 1;
            else if (lines.Contains("L2"))
                numLang = 2;
        }


        public void getLang()
        {
            String path = Path.Combine(Environment.CurrentDirectory, @"..\..\Background\Languages" + ".txt");
            info = System.IO.File.ReadAllLines(path);
        }

        public void setFluff(string[] backgroundAddOns)
        {
            this.Hair = backgroundAddOns[0];
            this.Skin = backgroundAddOns[1];
            this.Eyes = backgroundAddOns[2];
            this.Height = backgroundAddOns[3];
            this.Weight = backgroundAddOns[4];
            this.Age = backgroundAddOns[5];
            this.Gender = backgroundAddOns[6];
        }

        public int getNumLang()
        {
            return numLang;
        }

        public string getHair()
        {
            return Hair;
        }

        public string getSkin()
        {
            return Skin;
        }

        public string getEyes()
        {
            return Eyes;
        }

        public string getWeight()
        {
            return Weight;
        }

        public string getHeight()
        {
            return Height;
        }

        public string getAge()
        {
            return Age;
        }

        public string getGender()
        {
            return Gender;
        }

        public string getRace()
        {
            return Race;
        }

        public void setNumLang(int n)
        {
            numLang += n;
        }

        public void setBackLang(bool[] l)
        {
            backlanguage = l;
        }

        public int setRandNum(int randNum)
        {
            int set;
            return set = randNum;
        }

        public string getPersonality()
        {
            return Personality;
        }

        public string getIdeal()
        {
            return Ideal;
        }

        public string getBond()
        {
            return Bond;
        }

        public string getFlaw()
        {
            return Flaw;
        }

        public string getBackground()
        {
            return Background;
        }

        public void setBackground(string background)
        {
            //this.background = background;
        }

        public static Background_Class InteractiveChoice(Race r)
        {
            BackgroundForm form = new BackgroundForm(r);
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                return form.selected;
            }
            else return new Background_Class();
        }
    }
}
