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
    public partial class BackgroundForm : Form
    {
        public Race race = new DnDClassesTest.Race();

        public string Personality, Ideal, Bond, Flaw, Race;

        string[] allLanguages = { "Common", "Dwarvish", "Elvish", "Giant", "Gnomish", "Goblin", "Halfling", "Orc", "Abyssal", "Celestial", "Draconic", "Deep Speech", "Infernal", "Primordial", "Sylvan", "Undercommon" };
        public bool[] bl = new bool[16];

        public BackgroundForm()
        {
            InitializeComponent();
        }

        public BackgroundForm(Race race) //Runs backgroundForm properly
        {
            InitializeComponent();
            this.race = race;
            PersonalityDropDown.Visible = false;
            IdealDropDown.Visible = false;
            FlawDropDown.Visible = false;
            BondDropDown.Visible = false;
            ChooseTraits.Visible = false;
            ageValid.Hide();
            HeightError.Hide();
        }

        private void btnNext_Click(object sender, EventArgs e) //Activates when press done
        {
            int num = 0;
            string[] backgroundAddOns = new string[7];
            

            string[] ages = race.getAge().Split('-');
            if (AgeMasked.Text == "")
            {
                ageValid.Hide();
                HeightError.Hide();
                for (int i = 0; i < 8; i++)
                {
                    if (num < langList.CheckedItems.Count && langList.CheckedItems[num].ToString() == allLanguages[i])
                    {
                        bl[i] = true;
                        num++;
                    }
                }
                //sets stuff in array to send back to Background_Class
                backgroundAddOns[0] = HairMasked.Text;
                backgroundAddOns[1] = SkinMasked.Text;
                backgroundAddOns[2] = EyesMasked.Text;
                backgroundAddOns[3] = HeightMasked.Text;
                backgroundAddOns[4] = WeightMasked.Text;
                backgroundAddOns[5] = AgeMasked.Text;
                backgroundAddOns[6] = GenderMasked.Text;

                selected.setBackLang(bl);
                selected.setFluff(backgroundAddOns);
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (int.Parse(AgeMasked.Text) < 0) //verifies age
            {
                ageValid.Text = "Please choose an age \nbetween " + 0.ToString() + " and " + ages[1];
                ageValid.Show();
            }
            else if (int.Parse(AgeMasked.Text) > int.Parse(ages[1]))
            {
                ageValid.Text = "Please choose an age \nbetween " + 0.ToString() + " and " + ages[1];
                ageValid.Show();
            }
            else if (int.Parse(HeightMasked.Text) - (int.Parse(HeightMasked.Text) % 100) > 12)
            {
                HeightError.Text = "Please have less than 12 inches";
                HeightError.Show();
            }
            else
            {
                ageValid.Hide();
                for (int i = 0; i < 8; i++)
                {
                    if (num < langList.CheckedItems.Count && langList.CheckedItems[num].ToString() == allLanguages[i])
                    {
                        bl[i] = true;
                        num++;
                    }
                }
                //sets stuff in array to send back to Background_Class
                backgroundAddOns[0] = HairMasked.Text;
                backgroundAddOns[1] = SkinMasked.Text;
                backgroundAddOns[2] = EyesMasked.Text;
                backgroundAddOns[3] = HeightMasked.Text;
                backgroundAddOns[4] = WeightMasked.Text;
                backgroundAddOns[5] = AgeMasked.Text;
                backgroundAddOns[6] = GenderMasked.Text;

                selected.setBackLang(bl);
                selected.setFluff(backgroundAddOns);
                DialogResult = DialogResult.OK;
                this.Close();
            }
       
        }

        private void langList_SelectedIndexChanged(object sender, EventArgs e) //updates languages box
        {
            if (langList.CheckedItems.Count == selected.getNumLang())
                langList.Enabled = false;
        }

        private void PERSONALITY_TextChanged(object sender, EventArgs e)
        {

        }

        public Background_Class selected { get; set; }

        private void BGChoice_SelectedIndexChanged(object sender, EventArgs e) 
        {
            selected = new Background_Class(BGChoice.SelectedItem.ToString());

            ChooseTraits.Visible = true;

            PERSONALITY.Text = selected.Personality;
            IDEAL.Text = selected.Ideal;
            FLAW.Text = selected.Flaw;
            BOND.Text = selected.Bond;

            if (selected.getNumLang() > 0)
            {
                chooseLang();
                langList.Visible = true;
                button1.Visible = true;
            }
            else
            {
                langList.Visible = false;
                button1.Visible = false;
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void IDEAL_TextChanged(object sender, EventArgs e)
        {

        }

        private void ChooseTraits_CheckedChanged(object sender, EventArgs e)
        {
            if (ChooseTraits.Checked == true)
            {
                selected.loadShit();
                PersonalityDropDown.DataSource = selected.personalities;
                PersonalityDropDown.Visible = true;
                IdealDropDown.DataSource = selected.ideals;
                IdealDropDown.Visible = true;
                FlawDropDown.DataSource = selected.flaws;
                FlawDropDown.Visible = true;
                BondDropDown.DataSource = selected.bonds;
                BondDropDown.Visible = true;
            }
            else if(ChooseTraits.Checked == false)
            {
                string[] blank = new string[9];
                PersonalityDropDown.Visible = false;
                PersonalityDropDown.DataSource = blank;
                IdealDropDown.Visible = false;
                IdealDropDown.DataSource = blank;
                FlawDropDown.DataSource = blank;
                FlawDropDown.Visible = false;
                BondDropDown.DataSource = blank;
                BondDropDown.Visible = false;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            chooseLang();
        }


        private void HairMasked_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void EyesMasked_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void AgeMasked_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void WeightMasked_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void GenderMasked_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void SkinMasked_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void HeightMasked_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void BackgroundForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        //Race race = new Race();
        protected void chooseLang()
        {
            selected.setNumLang(race.getMoreLang());
            langList.Items.Clear();
            for (int i = 0; i < 8; i++)
            {
                if (!(race.getLangRace(i)))
                {
                    langList.Items.Add(allLanguages[i]);
                }
            }
            langList.Enabled = true;
        }

        public void setInfo(ref string Personality, ref string Ideal, ref string Flaw, ref string Bond)
        {
            this.Personality = Personality;
            this.Ideal = Ideal;
            this.Flaw = Flaw;
            this.Bond = Bond;
        }

        //Submit button
        //setBackground(string background);
        //setTraits(string, string, string, string)
        //setProfs(string, string, string)
        //this.Close();
    }
}

