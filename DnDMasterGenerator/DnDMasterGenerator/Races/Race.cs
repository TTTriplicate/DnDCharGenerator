using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace DnDClassesTest
{


    public class Race
    {
        protected string[,] races = new string[4, 9] {
            {"Dwarf", "Elf", "Halfling", "Human", "Dragonborn", "Gnome", "Half-Elf", "Half-Orc", "Tiefling" },
            {"Hill", "High", "Lightfoot", "", "", "Forest", "", "", ""},
            {"Mountain", "Wood", "Stout", "", "", "Rock", "", "", ""},
            {"", "Dark", "", "", "", "", "", "", ""}
        };
        string[] allLanguages = { "Common", "Dwarvish", "Elvish", "Giant", "Gnomish", "Goblin", "Halfling", "Orc", "Abyssal", "Celestial", "Draconic", "Deep Speech", "Infernal", "Primordial", "Sylvan", "Undercommon" };
        protected int[] AbilityAdjust = new int[6];
        //protected int[] subAA = new int[6];
        protected string age;
        protected string alignment;
        protected string size;
        protected int speed;
        protected bool[] languages = new bool[16];
        protected string[] specialAbilities = new string[15];
        protected string[] temp = new string[10];
        protected string race;
        protected string subRace;
        protected string[] info;
        protected int moreLang;


        public Race(string r)
        {
            //Fixed to be universal with project -Jack
            String path = Path.Combine(Environment.CurrentDirectory, @"..\..\Races\" + r + ".txt");
            info = System.IO.File.ReadAllLines(path);
            setAll();
        }

        protected void setAll()
        {
            race = info[0].Substring(8);
            for (int i = 0; i < 6; i++)
                AbilityAdjust[i] = (int)Char.GetNumericValue(info[1][i]);
            age = info[2];
            alignment = info[3];
            size = info[4];
            speed = int.Parse(info[5]);

            temp = info[6].Split(' ');
            moreLang = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                //Language, checks number, if + continues to else
                if (temp[i] != "+")
                    languages[int.Parse(temp[i])] = true;
                else
                    moreLang++; //will open a dropbox that allows the choice of a language in Main class
            }

            if (info.Last() != info[6])
                specialAbilities = info[7].Split(',');
            setSubRace("");
        }

        public void subChange()
        {
            int i;
            specialAbilities = info[7].Split(',');
            for (i = 9; i < 18; i += 4)
                if (info[i] == subRace)
                    break;
            for (int j = 0; j < 6; j++)
                AbilityAdjust[j] = (int)Char.GetNumericValue(info[1][j]) + (int)Char.GetNumericValue(info[i + 1][j]);
            Array.Resize(ref specialAbilities, 20);
            for (int j = 0; j < specialAbilities.Length; j++)
            {
                if (specialAbilities.ElementAt(j) == null)
                {
                    info[i + 2].Split(',').CopyTo(specialAbilities, j);
                    break;
                }
            }
            if (race == "Elf")
                overWrite();
            else if (race == "Human")
            {

            }
        }

        protected void overWrite()
        {
            if (specialAbilities[0] == "Darkvision(60ft)" && specialAbilities[4] == "Superior Darkvision(120ft)")
            {
                for (int i = 0; i < specialAbilities.Length - 1; i++)
                {
                    specialAbilities[i] = specialAbilities[i + 1];
                }
            }
            else if (specialAbilities[6] == " Fleet of Foot")
            {
                speed = 35;
                specialAbilities[6] = null;
            }
            else if (specialAbilities[6] == " +1 Language")
            {
                //add one to jacks numLang
                specialAbilities[6] = null;
            }

        }


        public int[] getAA()
        {
            return AbilityAdjust;
        }
        public string getAge()
        {
            return age;
        }
        public string getAlignment()
        {
            return alignment;
        }
        public void setAlignment(string a)
        {
            alignment = a;
        }
        public string getSize()
        {
            return size;
        }
        public int getSpeed()
        {
            return speed;
        }
        public string[] getLanguages()
        {
            int num = 0;
            for (int i = 0; i < 16; i++)
            {
                if (languages[i])
                    num++;
            }
            string[] l = new string[num];
            num = 0;
            for (int i = 0; i < 16; i++)
            {
                if (languages[i])
                    l[num++] = allLanguages[i];
            }
            return l;
        }
        public bool[] getLangRace()
        {
            return languages;
        }
        public void setLanguages()
        {

        }
        public string[] getSA()
        {
            return specialAbilities;
        }
        public string getRace()
        {
            return race;
        }
        public int getSubRace()
        {
            for (int i = 0; i < 9; i++)
            {
                if (race == races[0, i])
                    return i;
            }
            return 0;
        }
        public void setSubRace(string sr)
        {
            subRace = sr;
        }
        public int getMoreLang()
        {
            return moreLang;
        }


        public static Race InteractiveChoice()
        {
            using (var form = new RaceSelect())
            {
                var result = form.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    return form.selected;
                }
            }
            return new Race("Human");
        }
    }
}