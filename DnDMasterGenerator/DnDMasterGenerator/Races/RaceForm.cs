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
    public partial class RaceSelect : Form
    {
        public RaceSelect()
        {
            InitializeComponent();
            for (int i = 0; i < 9; i++)
            {
                chooser.Items.Add(races[0, i]);
            }
        }

        public Race selected { get; set; }

        protected string[,] races = new string[4, 9] {
            {"Dwarf", "Elf", "Halfling", "Human", "Dragonborn", "Gnome", "Half-Elf", "Half-Orc", "Tiefling" },
            {"Hill", "High", "Lightfoot", "", "", "Forest", "", "", ""},
            {"Mountain", "Wood", "Stout", "", "", "Rock", "", "", ""},
            {"", "Dark", "", "", "", "", "", "", ""}
        };
        protected string[] ability = new string[6] { "Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma" };

        protected void setUp()
        {
            langBox.Text = ""; specialsBox.Text = ""; saasBox.Text = "";

            for (int i = 0; i < 6; i++)
            {
                if (selected.getAA()[i] != 0)
                {
                    if (saasBox.Text != "")
                        saasBox.Text += ", ";
                    saasBox.Text += ability[i] + ": +"+selected.getAA()[i];

                }
            }
            saasBox.Text += "\nAdult at "+selected.getAge().Split('-')[0] + " years old, dies around "+selected.getAge().Split('-')[1] +" years old";
            saasBox.Text += "\nSize: " + selected.getSize();
            saasBox.Text += "\nSpeed: " + selected.getSpeed().ToString();
            foreach (string i in selected.getLanguages())
            {
                if (i != selected.getLanguages()[0])
                    langBox.Text += ", ";
                langBox.Text += i;
            }
            foreach (string i in selected.getSA())
            {
                if (i == null)
                    break;
                if (i != selected.getSA()[0])
                    specialsBox.Text += ", ";
                specialsBox.Text += i;
            }
        }

        private void chooser_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = new Race(chooser.SelectedItem.ToString());
            subRaceBox.Items.Clear(); subRaceBox.Text = "(Choose One)";
            setUp();
            for (int i = 1; i < 4; i++)
            {
                if (races[i, selected.getSubRace()] != "")
                {
                    if (i == 1)
                    {
                        chooser.Width = 182;
                        subRaceBox.Visible = true;
                    }
                    subRaceBox.Items.Add(races[i, selected.getSubRace()]);
                }
                else
                {
                    if (i == 1)
                    {
                        subRaceBox.Visible = false;
                        chooser.Width = 368;
                    }
                    break;
                }
            }
        }

        private void subRaceBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected.setSubRace(subRaceBox.Text);
            selected.subChange();
            setUp();
        }
        
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (alignmentBox.Text == "(Choose One)" || chooser.Text == "(Choose One)" || (subRaceBox.Text == "(Choose One)" && subRaceBox.Visible))
                error.Visible = true;
            else
            {
                error.Visible = false;
                selected.setAlignment(alignmentBox.Text);
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        

        private void RaceSelect_Load(object sender, EventArgs e) { }
        private void specialsBox_TextChanged(object sender, EventArgs e) { }
        private void error_Click(object sender, EventArgs e) { }
        private void langBox_TextChanged_1(object sender, EventArgs e) { }
        private void alignmentBox_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void saasBox_TextChanged(object sender, EventArgs e) { }
    }
}
