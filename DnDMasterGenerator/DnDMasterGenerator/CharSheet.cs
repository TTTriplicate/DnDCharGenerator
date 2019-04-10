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
    public partial class CharSheet : Form
    {
        protected DnDCharacter DisplayChar { get; set; }
        public CharSheet()
        {
            InitializeComponent();
        }
        public CharSheet(DnDCharacter leeroy)
        {
            InitializeComponent();
            DisplayChar = leeroy;
            txtName.Text = leeroy._name;
            txtLevel.Text = leeroy._level.ToString();
            txtClass.Text = leeroy._class.ProfessionName();
            int[] abilfill = new int[12];
            for(int i = 0; i < 6; ++i)
            {//don't touch, needed jesus
                abilfill[i*2] = leeroy._abilities[i];
                abilfill[12-((i*2) + 1)] = leeroy.AbilityModifiers()[i];
            }
            for(int i = 0; i < 12; ++i)
            {
                paneAbilities.Controls[i].Text = abilfill[i].ToString();
                if (i % 2 == 1)
                {
                    if (leeroy.SavingThrows[i / 2])
                        panelSaves.Controls[i / 2].Text = (abilfill[i] + leeroy.ProficiencyBonus()).ToString();
                    else panelSaves.Controls[i / 2].Text = abilfill[i].ToString();
                }
            }
            txtHP.Text = leeroy._HP.ToString();
            foreach (string s in leeroy._class.CurrentFeatures())
                txtSpecial.AppendText(s + "\n");
            txtMelee.Text = (leeroy.ProficiencyBonus() + leeroy.AbilityModifiers()[0]).ToString();
            txtRanged.Text = (leeroy.ProficiencyBonus() + leeroy.AbilityModifiers()[1]).ToString();
            //displayInventory.Text = (leeroy.)
        }

        private void displayDEXMod_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRace_TextChanged(object sender, EventArgs e)
        {

        }

        private void displayInventory_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
