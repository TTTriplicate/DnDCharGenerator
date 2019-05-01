using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using DnDMasterGenerator;

namespace DnDClassesTest
{
    public partial class LoadForm : Form
    {
        protected DnDCharacter DisplayChar { get; set; }
        public LoadForm()
        {
            InitializeComponent();
        }
        
        public LoadForm(string nameOfCharacter)
        {
            InitializeComponent();
            btnLevelUp.Hide();
            string[] abils = { "ST Strength", "ST Dexterity", "ST Constitution", "ST Intelligence", "ST Wisdom", "ST Charisma" };
            //string[] abilities = { };

            string nameOfFile = nameOfCharacter;
            string PDFFolder = Path.Combine(Environment.CurrentDirectory, @"..\..\PDFs");
            string pdfTemplate = PDFFolder + @"\" + nameOfCharacter + ".pdf";
            string newFile = PDFFolder + @"\" + nameOfFile + ".pdf";

            PdfReader pdfReader = new PdfReader(pdfTemplate);
            //PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(newFile, FileMode.Create));
            //AcroFields pdfFormFields = pdfStamper.AcroFields;
            //var pdfReader = new PdfReader(pdfTemplate);
            //AcroFields pdfFormFields = new AcroFields(pdfReader);
            AcroFields pdfFormFields = pdfReader.AcroFields;
            
            //TopFields
            CharName.Text = pdfFormFields.GetField("CharacterName");
            PlayerName.Text = pdfFormFields.GetField("PlayerName");
            ClassAndLevel.Text = pdfFormFields.GetField("ClassLevel");
            Background.Text = pdfFormFields.GetField("Background");
            Race.Text = pdfFormFields.GetField("Race ");
            Alignment.Text = pdfFormFields.GetField("Alignment");
            EXP.Text = pdfFormFields.GetField("XP");

            //Abilities
            int count = 0;
            System.Windows.Forms.RichTextBox[] Abilities = { STR, DEX, CON, INT, WIS, CHA };
            foreach (System.Windows.Forms.RichTextBox i in Abilities)
            {
                i.Text = pdfFormFields.GetField(Abilities[count].Name);
                count++;
            }

            //Background Stuff
            PersonalTraits.Text = pdfFormFields.GetField("PersonalityTraits ");
            Ideals.Text = pdfFormFields.GetField("Ideals");
            Bonds.Text = pdfFormFields.GetField("Bonds");
            Flaws.Text = pdfFormFields.GetField("Bonds");

            //Big Boxes
            languages.Text = pdfFormFields.GetField("ProficienciesLang");
            Equipment.Text = pdfFormFields.GetField("Equipment");
            FeaturesAndTraits.Text = pdfFormFields.GetField("Features and Traits");
            if (FeaturesAndTraits.Text == "")
                FeaturesAndTraits.Text = "None";
            CP.Text = "0";
            SP.Text = "0";
            EP.Text = "0";
            GP.Text = pdfFormFields.GetField("GP");
            PP.Text = "0";

            //Small Boxes at Top
            ArmorClass.Text = pdfFormFields.GetField("AC");
            Initiative.Text = pdfFormFields.GetField("Initiative");
            Speed.Text = pdfFormFields.GetField("Speed");
            txtHP.Text = pdfFormFields.GetField("HP");

            //RadioButtons
            count = 0;
            System.Windows.Forms.RadioButton[] SkillButtons = { AcrobaticsButton, AHButton, ArcanaButton, AthleticsButton, DeceptionButton, HistoryButton, InsightButton, IntimidationButton, InvestigationButton, MedicineButton, NatureButton, PerceptionButton, PerformanceButton, PersuasionButton, ReligionButton, SleightOfHandButton, StealthButton, SurvivalButton };
            foreach(var i in SkillButtons)
            {
                if (pdfFormFields.GetField("Check Box " + (count + 23)) == "Yes")
                {
                    i.Checked = true;
                }
                else
                    i.Checked = false;
                count++;
            }

            //Skills
            System.Windows.Forms.RichTextBox[] dex = { Acrobatics, SleightOfHand, Stealth, Athletics };
            System.Windows.Forms.RichTextBox[] intel = { Arcana, History, Investigation, Nature, Religion };
            System.Windows.Forms.RichTextBox[] wis = { AnimalHandling, Insight, Medicine, Perception, Survival };
            System.Windows.Forms.RichTextBox[] cha = { Deception, Intimidation, Performance, Persuasion };
            string[] dexpdf = { "Acrobatics", "SleightofHand", "Stealth ", "Athletics" };
            string[] intelpdf = { "Arcana", "History ", "Investigation ", "Nature", "Religion" };
            string[] wispdf = { "Animal", "Insight", "Medicine", "Perception ", "Survival" };
            string[] chapdf = { "Deception ", "Intimidation", "Performance", "Persuasion" };
            count = 0;
            foreach (var i in dexpdf)
            {
                dex[count].Text = pdfFormFields.GetField(i);
                count++;
            }

            count = 0;
            foreach (var i in intelpdf)
            {
                intel[count].Text = pdfFormFields.GetField(i);
                count++;
            }

            count = 0;
            foreach (var i in wispdf)
            {
                wis[count].Text = pdfFormFields.GetField(i);
                count++;
            }

            count = 0;
            foreach (var i in chapdf)
            {
                cha[count].Text = pdfFormFields.GetField(i);
                count++;
            }

            //Saving Throws
            count = 0;
            System.Windows.Forms.RichTextBox[] saves = { STSTR, STDEX, STWIS, STCON, STINT, STCHA };
            string[] abilities = { "ST Strength", "ST Dexterity", "ST Constitution", "ST Intelligence", "ST Wisdom", "ST Charisma" };
            foreach (var i in saves)
            {
                i.Text = pdfFormFields.GetField(abilities[count]);
                count++;
            }

            pdfReader.Close();
        }

        public LoadForm(DnDCharacter leeroy)
        {
            //Top Fields
            InitializeComponent();
            //btnLevelUp.Hide();
            DisplayChar = leeroy;
            CharName.Text = leeroy._name;
            PlayerName.Text = leeroy._playerName;
            ClassAndLevel.Text = leeroy._class.ProfessionName() + " " + leeroy._level.ToString();
            Background.Text = leeroy.CharBackground.getBackground();
            Race.Text = leeroy.CharRace.getRace();
            Alignment.Text = leeroy.CharRace.getAlignment();
            EXP.Text = leeroy.ExperiencePoints(leeroy._level).ToString();

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
            CP.Text = "0";
            SP.Text = "0";
            EP.Text = "0";
            GP.Text = leeroy.gold.ToString();
            PP.Text = "0";

            //Features and Traits
            foreach (string i in leeroy.CharRace.getSA())
            {
                if (i == null)
                    break;
                if (i != leeroy.CharRace.getSA()[0])
                    FeaturesAndTraits.Text += ", ";
                FeaturesAndTraits.Text += i;
            }
            if (FeaturesAndTraits.Text == "")
                FeaturesAndTraits.Text = "None";

            //Small Boxes at Top
            ArmorClass.Text = leeroy.getAC().ToString();
            Initiative.Text = leeroy.AbilityModifiers()[1].ToString();
            Speed.Text = leeroy.CharRace.getSpeed().ToString();
            txtHP.Text = leeroy._HP.ToString();

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
                    //MessageBox.Show(SkillButtons[count].Name.ToString() + " " +SkillButtons[count].ToString());
                    //SkillButtons[count].L = false;
                }
                else
                    SkillButtons[count].Checked = false;
                count++;
            }

            //Skills
            System.Windows.Forms.RichTextBox[] dex = { Acrobatics, SleightOfHand, Stealth, Athletics };
            //int[] dexIndexs = { 0, 15, 16, 3};
            System.Windows.Forms.RichTextBox[] intel = { Arcana, History, Investigation, Nature, Religion };
            //int[] intelIndexs = { 2, 5, 8, 10, 14 };
            System.Windows.Forms.RichTextBox[] wis = { AnimalHandling, Insight, Medicine, Perception, Survival };
            //int[] wisIndexs = { 1, 6, 9, 11, 17 };
            System.Windows.Forms.RichTextBox[] cha = { Deception, Intimidation, Performance, Persuasion };
            //int[] chaIndexs = { 4, 7, 12, 13 };

            count = 0;
            foreach (var i in dex)
            {
                if (i == Athletics)
                    if (skills[count])
                        i.Text = (leeroy.AbilityModifiers()[0] + leeroy.ProficiencyBonus()).ToString();
                    else
                        i.Text = leeroy.AbilityModifiers()[0].ToString();
                if (skills[count])
                    i.Text = (leeroy.AbilityModifiers()[1] + leeroy.ProficiencyBonus()).ToString();
                else
                    i.Text = leeroy.AbilityModifiers()[1].ToString();
                count++;
            }

            foreach (var i in intel)
            {
                if (skills[count])
                    i.Text = (leeroy.AbilityModifiers()[3] + leeroy.ProficiencyBonus()).ToString();
                else
                    i.Text = leeroy.AbilityModifiers()[3].ToString();
                count++;
            }

            foreach (var i in wis)
            {
                if (skills[count])
                    i.Text = (leeroy.AbilityModifiers()[4] + leeroy.ProficiencyBonus()).ToString();
                else
                    i.Text = leeroy.AbilityModifiers()[4].ToString();
                count++;
            }

            foreach (var i in cha)
            {
                if (skills[count])
                    i.Text = (leeroy.AbilityModifiers()[5] + leeroy.ProficiencyBonus()).ToString();
                else
                    i.Text = leeroy.AbilityModifiers()[5].ToString();
                count++;
            }

            //Saving Throws
            if (leeroy.SavingThrows[0])
                STSTR.Text = (leeroy.AbilityModifiers()[0] + leeroy.ProficiencyBonus()).ToString();
            else
                STSTR.Text = leeroy.AbilityModifiers()[0].ToString();

            if (leeroy.SavingThrows[1])
                STDEX.Text = (leeroy.AbilityModifiers()[1] + leeroy.ProficiencyBonus()).ToString();
            else
                STDEX.Text = leeroy.AbilityModifiers()[1].ToString();

            if (leeroy.SavingThrows[2])
                STCON.Text = (leeroy.AbilityModifiers()[2] + leeroy.ProficiencyBonus()).ToString();
            else
                STCON.Text = leeroy.AbilityModifiers()[2].ToString();

            if (leeroy.SavingThrows[3])
                STINT.Text = (leeroy.AbilityModifiers()[3] + leeroy.ProficiencyBonus()).ToString();
            else
                STINT.Text = leeroy.AbilityModifiers()[3].ToString();

            if (leeroy.SavingThrows[4])
                STWIS.Text = (leeroy.AbilityModifiers()[4] + leeroy.ProficiencyBonus()).ToString();
            else
                STWIS.Text = leeroy.AbilityModifiers()[4].ToString();

            if (leeroy.SavingThrows[5])
                STCHA.Text = (leeroy.AbilityModifiers()[5] + leeroy.ProficiencyBonus()).ToString();
            else
                STCHA.Text = leeroy.AbilityModifiers()[5].ToString();


            PDF_Filler fhsduf = new PDF_Filler(leeroy);
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

        private void Acrobatics_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnLevelUp_Click(object sender, EventArgs e)
        {
            if (DisplayChar.LevelUp())
            {
                var updated = new LoadForm(DisplayChar);
                this.Hide();
                updated.ShowDialog();
                this.Close();
            }
            else
                MessageBox.Show("Your character is already at the highest level!", "Max Level");
        }
        private void LoadForm_Load(object sender, EventArgs e)
        {
            if (DisplayChar != null)
            {
                var display = new DisplayForm(DisplayChar);
                display.Show();
            }
        }

        private void EXP_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
