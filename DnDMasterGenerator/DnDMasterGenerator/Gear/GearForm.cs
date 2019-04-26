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
    public partial class GearForm : Form 
    {
        public CharGear gear = new CharGear();
        public List<List<Gear>> items = new List<List<Gear>>();
        public List<List<string>> itemString = new List<List<string>>();
        public List<Gear> inventory = new List<Gear>();
        public List<string> inventoryString = new List<string>();
        public List<Gear> firstChoice;
        public List<List<string>> twoMartialIsStupid = new List<List<string>>();
        public List<List<string>> wackadooIsAlsoStupid = new List<List<string>>();

        public GearForm()
        { 
            InitializeComponent();
        }

        public GearForm(CharGear passedGear)
        {
            gear = passedGear;
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            items = gear.getOptions();
            itemString = gear.getStrings();
            twoMartialIsStupid = gear.getStrings();
            wackadooIsAlsoStupid = gear.getStrings();
            firstChoice = gear.getFirstChoice();

            int numItems = gear.getNumChoices();
            Choice1.Hide();
            Choice2.Hide();
            Choice3.Hide();
            Choice4.Hide();
            Choice5.Hide();
            Choice6.Hide();
            twoMartial.Hide(); //Literally only for fighter, paladin, and ranger.  The name is misleading because ranger uses two simple melee weapons instead of two martial weapons but I don't give a fuck
            choice1a.Hide();
            choice1b.Hide();
            choice2a.Hide();
            choice2b.Hide();
            choice3a.Hide();
            choice3b.Hide();
            choice4a.Hide();
            choice4b.Hide();
            choice5a.Hide();
            choice5b.Hide();
            choice6a.Hide();
            choice6b.Hide();
            wackadooThingy.Hide(); //Literally only for fighter because fighter is a whole bitch.  Oh wait, also for paladin

            if(numItems >= 1)
            {
                Choice1.Show();
                choice1b.Checked = true;
               
                if (gear.classType == "Ranger")
                {
                    choice1a.Show();
                    choice1a.Text = firstChoice[0].toString();
                    choice1b.Show();
                    twoMartial.Show();
                    twoMartial.DataSource = twoMartialIsStupid[0];
                }
                else if (firstChoice[0] != null)
                {
                    choice1a.Show();
                    choice1a.Text = firstChoice[0].toString();
                    choice1b.Show();
                }
                else if (gear.classType == "Fighter" || gear.classType == "Paladin") 
                {
                    choice1a.Show();
                    choice1b.Show();
                    choice1a.Text = "Shield and ";
                    wackadooThingy.Show();
                    wackadooThingy.DataSource = wackadooIsAlsoStupid[0];
                    twoMartial.Show();
                    twoMartial.DataSource = twoMartialIsStupid[0];
                }
                Choice1.DataSource = itemString[0];
                
                if(numItems >= 2)
                {
                    choice2b.Checked = true;
                    if (firstChoice[1] != null)
                    {
                        choice2a.Show();
                        choice2a.Text = firstChoice[1].toString();
                        choice2b.Show();
                    }
                    
                    Choice2.Show();
                    Choice2.DataSource = itemString[1];

                    if(numItems >= 3)
                    {
                        choice3b.Checked = true;
                        if (firstChoice[2] != null)
                        {
                            choice3a.Show();
                            choice3a.Text = firstChoice[2].toString();
                            choice3b.Show();
                        }
                        Choice3.Show();
                        Choice3.DataSource = itemString[2];

                        if(numItems >= 4)
                        {
                            choice4b.Checked = true;
                            if (firstChoice[3] != null)
                            {
                                choice4a.Show();
                                choice4a.Text = firstChoice[3].toString();
                                choice4b.Show();
                            }
                            Choice4.Show();
                            Choice4.DataSource = itemString[3];

                            if(numItems >= 5)
                            {
                                choice5b.Checked = true;
                                if (firstChoice[4] != null)
                                {
                                    choice5a.Show();
                                    choice5a.Text = firstChoice[4].toString();
                                    choice5b.Show();
                                }
                                Choice5.Show();
                                Choice5.DataSource = itemString[4];

                                if(numItems == 6)
                                {
                                    choice6b.Checked = true;
                                    if (firstChoice[5] != null)
                                    {
                                        choice6a.Show();
                                        choice6a.Text = firstChoice[5].toString();
                                        choice6b.Show();
                                    }
                                    Choice6.Show();
                                    Choice6.DataSource = itemString[5];
                                }
                            }
                        }
                    }
                }
            }
            inventory = gear.getInventory();
            inventoryString = gear.convertInventoryString();
            Inventory.DataSource = inventoryString;
        }

        public void Choice1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        public void label1_Click(object sender, EventArgs e)
        {
        }

        public void Choice2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        public void Choice3_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        public void Choice4_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        public void Choice5_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        public void Choice6_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        public void label2_Click(object sender, EventArgs e)
        {
        }

        private void Inventory_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            string message = "Are you sure this is the gear you want?\n";
            message = populateMessage(message);
            
            string caption = "Done";
            DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (choice1a.Checked)
                {
                    if(gear.classType == "Fighter" || gear.classType == "Paladin")
                    {
                        inventoryString.Add("Shield    " + (2 + gear.dexMod));
                        inventory.Add(new Armor("Shield", 2));
                        inventoryString.Add(wackadooThingy.Text);
                        inventory.Add(items[0][wackadooThingy.SelectedIndex]);
                    }
                    else
                    {
                        inventoryString.Add(choice1a.Text);
                        inventory.Add(firstChoice[0]);
                    }
                }
                else if (choice2b.Checked)
                {
                    if(gear.classType == "Fighter" || gear.classType == "Paladin" || gear.classType == "Ranger")
                    {
                        inventory.Add(items[0][Choice1.SelectedIndex]);
                        inventory.Add(items[0][twoMartial.SelectedIndex]);
                        inventoryString.Add(Choice1.Text);
                        inventoryString.Add(twoMartial.Text);
                    }
                    else
                    {
                        inventoryString.Add(Choice1.Text);
                        inventory.Add(items[0][Choice1.SelectedIndex]);
                    }
                }

                /*
                 * or (int i = 2, num = 1; i < 7; i++)
                {
                    if (choice2a.Checked)
                    {
                        inventoryString.Add(choice2a.Text);
                        inventory.Add(firstChoice[1]);
                    }    
                    else if (choice2b.Checked)
                    {
                        inventoryString.Add(Choice2.Text);
                        inventory.Add(items[num][Choice2.SelectedIndex]);
                    }
                }*/

                if (choice2a.Checked)
                {
                    inventoryString.Add(choice2a.Text);
                    inventory.Add(firstChoice[1]);
                }    
                else if (choice2b.Checked)
                {
                    inventoryString.Add(Choice2.Text);
                    inventory.Add(items[1][Choice2.SelectedIndex]);
                }
                if (choice3a.Checked)
                {
                    inventoryString.Add(choice3a.Text);
                    inventory.Add(firstChoice[2]);
                }
                else if (choice3b.Checked)
                {
                    inventoryString.Add(Choice3.Text);
                    inventory.Add(items[2][Choice3.SelectedIndex]);
                }
                if (choice4a.Checked)
                {
                    inventoryString.Add(choice4a.Text);
                    inventory.Add(firstChoice[3]);
                }
                else if (choice4b.Checked)
                {
                    inventoryString.Add(Choice4.Text);
                    inventory.Add(items[3][Choice4.SelectedIndex]);
                }
                if (choice5a.Checked)
                {
                    inventoryString.Add(choice5a.Text);
                    inventory.Add(firstChoice[4]);
                } 
                else if (choice5b.Checked)
                {
                    inventoryString.Add(Choice5.Text);
                    inventory.Add(items[4][Choice5.SelectedIndex]);
                }
                if (choice6a.Checked)
                {
                    inventoryString.Add(choice6a.Text);
                    inventory.Add(firstChoice[5]);
                }
                else if (choice6b.Checked)
                {
                    inventoryString.Add(Choice6.Text);
                    inventory.Add(items[5][Choice6.SelectedIndex]);
                }   
                
                gear.formatting(ref inventory, ref inventoryString);

                gear.setInventory(inventory);
                gear.setInventoryString(inventoryString);

                this.Close();
            }
        }

        public string populateMessage(string message)
        {
            for (int i = 0; i < inventoryString.Count(); i++)
            {
                message = message + inventoryString[i] + "\n";
            }
            if(choice1a.Checked)
            {
                if(gear.classType == "Fighter" || gear.classType == "Paladin")
                {
                    message = message + ("Shield    " + (2 + gear.dexMod)) + "\n";
                    message = message + wackadooThingy.Text + "\n";
                }
                else
                {
                    message = message + choice1a.Text + "\n";
                }
            }  
            else
            {
                if (gear.classType == "Fighter" || gear.classType == "Paladin" || gear.classType == "Ranger")
                {
                    message = message + Choice1.Text + "\n";
                    message = message + twoMartial.Text + "\n";
                }
                else
                {
                    message = message + Choice1.Text + "\n";
                }
            }  

            if (choice2a.Checked)
                message = message + choice2a.Text + "\n";
            else
                message = message + Choice2.Text + "\n";

            if (choice3a.Checked)
                message = message + choice3a.Text + "\n";
            else
                message = message + Choice3.Text + "\n";

            if (choice4a.Checked)
                message = message + choice4a.Text + "\n";
            else
                message = message + Choice4.Text + "\n";

            if (choice5a.Checked)
                message = message + choice5a.Text + "\n";
            else
                message = message + Choice5.Text + "\n";

            if (choice6a.Checked)
                message = message + choice6a.Text + "\n";
            else
                message = message + Choice6.Text + "\n";

            return message;
        }

        private void GearForm_Load(object sender, EventArgs e)
        {
        }

        private void choice4a_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void choice1a_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void choice1b_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void choice2a_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void choice2b_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void choice3a_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void choice3b_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void choice4b_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void choice5a_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void choice5b_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void choice6a_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void choice6b_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void twoMartial_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void wackadooThingy_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
