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
            richTextBox1.Hide();
            lblTraits.Hide();
            DisplayChar = leeroy;
            txtName.Text = leeroy._name;
            txtPlayerName.Text = leeroy._playerName;
            txtLevel.Text = leeroy._level.ToString();
            txtClass.Text = leeroy._class.ProfessionName();
            int[] abilfill = new int[12];
            for (int i = 0; i < 6; ++i)
            {//don't touch, needed jesus
                abilfill[i * 2] = leeroy._abilities[i];
                abilfill[12 - ((i * 2) + 1)] = leeroy.AbilityModifiers()[i];
            }
            for (int i = 0; i < 12; ++i)
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

            foreach (string i in leeroy.CharRace.getLanguages())
                richTextBox2.Text += i + ", ";
            richTextBox2.Text += "\n";
            foreach (string i in leeroy.CharRace.getSA())
                txtSpecial.Text += i + ", ";
            txtRace.Text = leeroy.CharRace.getRace();

            if(leeroy._class.ProfessionName() == "Cleric")
            {
                try
                {
                    bool[] test = Cleric.Proficiencies(leeroy._class._proPath);
                    foreach (bool i in test)
                        Console.WriteLine(i);
                }
                catch (Exception)
                {

                }
            }

            //string Personality = "f", Ideal = "f", Flaw = "f", Bond = "f", Background = "f";
            //leeroy.Background.Traits(ref Personality, ref Ideal, ref Flaw, ref Bond);
            richTextBox3.Text += leeroy.CharBackground.getPersonality() + "\n";
            richTextBox3.Text += leeroy.CharBackground.getIdeal() + "\n";
            richTextBox3.Text += leeroy.CharBackground.getBond() + "\n";
            richTextBox3.Text += leeroy.CharBackground.getFlaw() + "\n";
            txtBackground.Text = leeroy.CharBackground.getBackground();


            for (int i = 0; i < leeroy.getInventoryString().Count(); i++)
            {
                displayInventory.Text += (leeroy.getInventoryString()[i]) + "\n";
            }
            
            PDF_Filler fhsduf = new PDF_Filler(leeroy);
        }

        private void displayDEXMod_TextChanged(object sender, EventArgs e)
        {

        }

        private void displayInventory_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void txtPlayerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Attack_Click_1(object sender, EventArgs e)
        {
            AttackRoll attack = new AttackRoll(DisplayChar.getInventory());
            attack.Show();
        }
    }
}
