using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DnDClassesTest
{
    public partial class StatsAndProfession : Form
    {
        public StatsAndProfession()
        {
            InitializeComponent();
        }
        public int p { get; set; }
        public int proPath { get; set; }
        public int level { get; set; }
        public int[] Abilities { get; set; }
        public string Name { get; set; }
        public string PlayerName { get; set; }

        private void comboClass_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            switch (comboClass.SelectedIndex)
            {
                case 0:
                    lblSubClass.Text = "Choose a Path:";
                    lblSubClass.Visible = true;
                    comboSubClass.DataSource = new List<string> { "Berserker", "Totem Warrior" };
                    break;
                case 1:
                    lblSubClass.Text = "Choose a College:";
                    lblSubClass.Visible = true;
                    comboSubClass.DataSource = new List<string> { "Lore", "Valor" };
                    break;
                case 2:
                    lblSubClass.Text = "Choose a Divine Domain:";
                    lblSubClass.Visible = true;
                    comboSubClass.DataSource = new List<string> { "Knowledge", "Life", "Light", "Nature", "Tempest", "Trickery", "War" };
                    break;
                case 3:
                    lblSubClass.Text = "Select a Circle:";
                    lblSubClass.Visible = true;
                    comboSubClass.DataSource = new List<string> { "Land", "Moon" };
                    break;
                case 4:
                    lblSubClass.Text = "Select an Archetype:";
                    lblSubClass.Visible = true;
                    comboSubClass.DataSource = new List<string> { "Champion", "Battle Master", "Eldritch Knight" };
                    break;
                case 5:
                    lblSubClass.Text = "Choose a Discipline";
                    lblSubClass.Visible = true;
                    comboSubClass.DataSource = new List<string> { "Way of the Open Hand", "Way of Shadows" };
                    break;
                case 6:
                    lblSubClass.Text = "Select an Oath:";
                    lblSubClass.Visible = true;
                    comboSubClass.DataSource = new List<string> { "Devotion", "The Ancients", "Vengeance" };
                    break;
                case 7:
                    lblSubClass.Text = "Choose an Archetype:";
                    lblSubClass.Visible = true;
                    comboSubClass.DataSource = new List<string> { "Hunter", "Beast Master" };
                    break;
                case 8:
                    lblSubClass.Text = "Choose a specialty:";
                    lblSubClass.Visible = true;
                    comboSubClass.DataSource = new List<string> { "Thief", "Assassin", "Arcane Trickster" };
                    break;
                case 9:
                    lblSubClass.Text = "Choose an Origin:";
                    lblSubClass.Visible = true;
                    comboSubClass.DataSource = new List<string> { "Draconic", "Wild Magic" };
                    break;
            }

        }

        private void btnNext_Click(object sender, System.EventArgs e)
        {
            p = comboClass.SelectedIndex;
            proPath = comboSubClass.SelectedIndex;
            level = (int)numLevel.Value;
            Name = txtName.Text;
            PlayerName = playerNameBox.Text;
            Abilities = new int[6] { (int)numSTR.Value, (int)numDEX.Value, (int)numCON.Value, (int)numINT.Value, (int)numWIS.Value, (int)numCHA.Value };
            DialogResult = DialogResult.OK;
            this.Close();
        }
        private Random dice = new Random();
        public int RanNumGen()
        {
            int randNum;

            randNum = dice.Next(8, 19);

            return randNum;
        }

        private void numLevel_ValueChanged(object sender, EventArgs e)
        {

        }

        private void playerNameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
            numSTR.Value = RanNumGen();
            numDEX.Value = RanNumGen();
            numCON.Value = RanNumGen();
            numINT.Value = RanNumGen();
            numWIS.Value = RanNumGen();
            numCHA.Value = RanNumGen();
        }
    }
}
