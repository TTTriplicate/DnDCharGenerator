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
    public partial class AttackRoll : Form
    {
        public int result = 0;
        public List<Gear> weapons = new List<Gear>();
        public List<string> weaponsString = new List<string>();
        public List<Gear> inventory = new List<Gear>();
        public CharGear gear = new CharGear();
        public AttackRoll()
        {
            InitializeComponent();
        }

        public AttackRoll(List<Gear> inventory)
        {
            InitializeComponent();
            this.inventory = inventory;
        }

        private void AttackRoll_Load(object sender, EventArgs e)
        {
            damageFactor.Hide();

            for(int i = 0; i < inventory.Count(); i++)
            {
                Console.WriteLine(inventory[i].GetType().ToString());
                if (inventory[i].GetType().ToString() == "DnDClassesTest.Weapon")
                {
                    weapons.Add(inventory[i]);

                }
            }
            for(int i = 0; i < weapons.Count(); i++)
            {
                weaponsString.Add(weapons[i].toString());
            }
            Weapons.DataSource = weaponsString;
        }

        private void Weapons_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RollResult_Click(object sender, EventArgs e)
        {

        }

        private void Roll_Click(object sender, EventArgs e)
        {
            Hit.Checked = false;
            Miss.Checked = false;
            damageFactor.Hide();
            result = rollDice();
            RollResult.Text = result.ToString();
            if (result == 1)
            {
                Miss.Checked = true;
            }
            else if (result == 20)
            {
                Hit.Checked = true;
            }
        }

        private void Hit_CheckedChanged(object sender, EventArgs e)
        {
            if (result == 1)
            {
                Miss.Checked = true;
            }
            else
            {
                //rollDice(1, weapons[Weapons.SelectedIndex].getDamage());
            }

        }

        private void Miss_CheckedChanged(object sender, EventArgs e)
        {
            if (result == 20)
            {
                Hit.Checked = true;
            }
        }

        public int rollDice(int low = 1, int high = 21)
        {
            Random random = new Random();
            return random.Next(low, high);
        }

        private void damageFactor_Click(object sender, EventArgs e)
        {

        }
    }
}
