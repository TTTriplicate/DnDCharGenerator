using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnDClassesTest
{
    public partial class LoadForm : Form
    {
        protected DnDCharacter DisplayChar { get; set; }
        public LoadForm()
        {
            InitializeComponent();
        }

        public LoadForm(DnDCharacter leeroy)
        {
            //Top Fields
            InitializeComponent();
            DisplayChar = leeroy;
            CharName.Text = leeroy._name;
            PlayerName.Text = leeroy._playerName;
            ClassAndLevel.Text = leeroy._class.ProfessionName() + " " + leeroy._level.ToString();
            Background.Text = leeroy.CharBackground.getBackground();
            Race.Text = leeroy.CharRace.getRace();
            Alignment.Text = leeroy.CharRace.getAlignment();

            //Abilities
            int count = 0;
            System.Windows.Forms.RichTextBox[] Abilities = { STR, DEX, CON, INT, WIS, CHA };
            foreach(System.Windows.Forms.RichTextBox i in Abilities)
            {
                i.Text = leeroy._abilities[count].ToString();
                count++;
            }

            //Background Stuff
            PersonalTraits.Text = leeroy.CharBackground.getPersonality();
            Ideals.Text = leeroy.CharBackground.getIdeal();
            Bonds.Text = leeroy.CharBackground.getBond();
            Flaws.Text = leeroy.CharBackground.getFlaw();

            //Languages
            foreach (string i in leeroy.CharRace.getLanguages())
            {
                if (languages.Text != "")
                    languages.Text += ", ";
                languages.Text += i;
            }

            //Equipment
            for (int i = 0; i < leeroy.getInventoryString().Count(); i++)
            {
                Equipment.Text += (leeroy.getInventoryString()[i]) + "\n";
            }

            //Features and Traits
            foreach (string i in leeroy.CharRace.getSA())
            {
                if (i == null)
                    break;
                if (i != leeroy.CharRace.getSA()[0])
                    FeaturesAndTraits.Text += ", ";
                FeaturesAndTraits.Text += i;
            }

            //Small Boxes at Top
            ArmorClass.Text = leeroy.getAC().ToString();
            Initiative.Text = leeroy.AbilityModifiers()[1].ToString();
            Speed.Text = leeroy.CharRace.getSpeed().ToString();

            //SkillRadioButtons
            count = 0;
            bool[] skills = new bool[18];
            System.Windows.Forms.RadioButton[] SkillButtons = { AcrobaticsButton, AHButton, ArcanaButton, AthleticsButton, DeceptionButton, HistoryButton, InsightButton, IntimidationButton, InvestigationButton, MedicineButton, NatureButton, PerceptionButton, PerformanceButton, PersuasionButton, ReligionButton, SleightOfHandButton, StealthButton, SurvivalButton };
            foreach (bool i in leeroy._skills)
            {
                if (i == true)
                {
                    SkillButtons[count].Checked = true;
                    skills[count] = true;
                    MessageBox.Show(SkillButtons[count].Name.ToString() + " " +SkillButtons[count].ToString());
                    //SkillButtons[count].L = false;
                }
                else
                    SkillButtons[count].Checked = false;
                count++;
            }

            //Skills
            System.Windows.Forms.RichTextBox[] dex = { Acrobatics, SleightOfHand, Stealth, Athletics };
            int[] dexIndexs = { 0, 15, 16, 3};
            System.Windows.Forms.RichTextBox[] intel = { Arcana, History, Investigation, Nature, Religion };
            int[] intelIndexs = { 2, 5, 8, 10, 14 };
            System.Windows.Forms.RichTextBox[] wis = { AnimalHandling, Insight, Medicine, Perception, Survival };
            int[] wisIndexs = { 1, 6, 9, 11, 17 };
            System.Windows.Forms.RichTextBox[] cha = { Deception, Intimidation, Performance, Persuasion };
            int[] chaIndexs = { 4, 7, 12, 13 };

            string indexNum = "0";
            foreach (var i in dex)
            {
                //Must do radio buttons first
            }
            //foreach (string i in dex)
            //{
            //    if (i.Length < 3)
            //    {
            //        indexNum = i;
            //    }
            //    else if (i.Length > 3)
            //    {
            //        if (i == "Athletics")
            //        {
            //            if (skillBoxes[int.Parse(indexNum)])
            //            {
            //                pdfFormFields.SetField(i, (newChar.AbilityModifiers()[0] + newChar.ProficiencyBonus()).ToString());
            //                //MessageBox.Show("bingo");
            //            }
            //            else
            //                pdfFormFields.SetField(i, newChar.AbilityModifiers()[0].ToString());
            //        }
            //        //MessageBox.Show((int.Parse(indexNum).ToString() + skillBoxes[int.Parse(indexNum)].ToString()));
            //        else if (skillBoxes[int.Parse(indexNum)])
            //        {
            //            pdfFormFields.SetField(i, (newChar.AbilityModifiers()[1] + newChar.ProficiencyBonus()).ToString());
            //            //MessageBox.Show("bingo");
            //        }
            //        else
            //            pdfFormFields.SetField(i, newChar.AbilityModifiers()[1].ToString());
            //    }
            //    //indexNum = "0";
            //}

            
        }
        private void CharName_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void WIS_TextChanged(object sender, EventArgs e)
        {
            WIS.SelectAll();
            WIS.SelectionAlignment = HorizontalAlignment.Center;
            WIS.DeselectAll();
        }

        private void CON_TextChanged(object sender, EventArgs e)
        {
            CON.SelectAll();
            CON.SelectionAlignment = HorizontalAlignment.Center;
            CON.DeselectAll();
        }

        private void INT_TextChanged(object sender, EventArgs e)
        {
            INT.SelectAll();
            INT.SelectionAlignment = HorizontalAlignment.Center;
            INT.DeselectAll();
        }

        private void DEX_TextChanged(object sender, EventArgs e)
        {
            DEX.SelectAll();
            DEX.SelectionAlignment = HorizontalAlignment.Center;
            DEX.DeselectAll();
        }

        private void CHA_TextChanged(object sender, EventArgs e)
        {
            CHA.SelectAll();
            CHA.SelectionAlignment = HorizontalAlignment.Center;
            CHA.DeselectAll();
        }

        private void Equipment_TextChanged(object sender, EventArgs e)
        {

        }

        private void STR_TextChanged(object sender, EventArgs e)
        {
            STR.SelectAll();
            STR.SelectionAlignment = HorizontalAlignment.Center;
            STR.DeselectAll();
        }
    }
}
