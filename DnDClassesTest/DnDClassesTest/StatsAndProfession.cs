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

        private void comboClass_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            switch (comboClass.SelectedIndex)
            {
                case 0:
                    lblSubClass.Text = "Choose a Path:";
                    lblSubClass.Visible = true;
                    comboSubClass.DataSource = new List<string> { "Berserker", "Totem Warrior" };
                    break;
            }

        }

        private void btnNext_Click(object sender, System.EventArgs e)
        {
            p = comboClass.SelectedIndex;
            proPath = comboSubClass.SelectedIndex;
            level = (int)numLevel.Value;
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
