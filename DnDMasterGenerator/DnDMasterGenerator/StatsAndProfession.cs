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
            }

        }

        private void btnNext_Click(object sender, System.EventArgs e)
        {
            p = comboClass.SelectedIndex;
            proPath = comboSubClass.SelectedIndex;
            level = (int)numLevel.Value;
            Name = txtName.Text;
            Abilities = new int[6] { (int)numSTR.Value, (int)numDEX.Value, (int)numCON.Value, (int)numINT.Value, (int)numWIS.Value, (int)numCHA.Value };
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void numLevel_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
