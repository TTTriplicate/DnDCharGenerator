using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        string[] allLanguages = {"Common", "Dwarvish", "Elvish", "Giant", "Gnomish", "Goblin", "Halfling", "Orc", "Abyssal", "Celestial", "Draconic", "Deep Speech", "Infernal", "Primordial", "Sylvan", "Undercommon"};
        protected int[] AbilityAdjust = new int[6];
        protected string age;
        protected string alignment;
        protected string size;
        protected int speed;
        protected bool[] languages = new bool[16];
        protected string[] specialAbilities = new string[7];
        protected string[] temp = new string[3];

        public string[] info;
        

        public Race(string race)
        {
            //will have to change the path to be for anyone
            info = System.IO.File.ReadAllLines(@"C:\Users\dylan.bryant\OneDrive - SNHU\SoftwareEngineering\DnD\" + race + ".txt") ;
            for (int i = 0; i < 6; i++)
                AbilityAdjust[i] = (int)Char.GetNumericValue(info[1][i]);
            age = info[2];
            alignment = info[3];
            size = info[4];
            speed = int.Parse(info[5]);

            temp = info[6].Split(' ');
            for (int i = 0; i < temp.Length; i++)
            {
                //Language, checks number, if + continues to else
                if (temp[i] != "+")
                    languages[int.Parse(temp[i])] = true;
                else
                    continue; //will open a dropbox that allows the choice of a language in Main class
            }

            if (info.Last() != info[6])
                specialAbilities = info[7].Split(',');
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
            string[] l;
            int num = 0;
            for (int i = 0; i < 16; i++){
                if (languages[i])
                    l[num++] = allLanguages[i];
            }
            return l;
        }
        public string[] getSA()
        {
            return specialAbilities;
        }
        public string[,] getraces()
        {
            return races;
        }
        public static Race InteractiveChoice()
        {
            using(var form = new RaceSelect())
            {
                var result = form.ShowDialog();
                if(result == System.Windows.Forms.DialogResult.OK)
                {
                    return form.selected;
                }
            }
            return new Race("Human");
        }
    }
}
