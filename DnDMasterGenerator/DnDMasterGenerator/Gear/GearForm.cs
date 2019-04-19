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
        
        public GearForm()
        { 
            InitializeComponent();
        }
        //test comment for Git
        public GearForm(CharGear passedGear)
        {
            gear = passedGear;
            InitializeComponent();
        }


        public void Form1_Load(object sender, EventArgs e)
        {
            //gear = new CharGear("Barbarian", "Folk Hero", 0);
            items = gear.getOptions();
            itemString = gear.getStrings();
            firstChoice = gear.getFirstChoice();

            int numItems = gear.getNumChoices();
            Choice1.Hide();
            Choice2.Hide();
            Choice3.Hide();
            Choice4.Hide();
            Choice5.Hide();
            Choice6.Hide();
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

            if(numItems >= 1)
            {
                Choice1.Show();
                if (firstChoice[0] != null)
                {
                    choice1a.Show();
                    choice1a.Text = firstChoice[0].toString();
                    choice1b.Show();
                }
                Choice1.DataSource = itemString[0];
                
                if(numItems >= 2)
                {
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
                inventoryString.Add(Choice1.Text);
                inventoryString.Add(Choice2.Text);
                inventoryString.Add(Choice3.Text);
                inventoryString.Add(Choice4.Text);
                inventoryString.Add(Choice5.Text);
                inventoryString.Add(Choice6.Text);

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
                message = message + choice1a.Text + "\n";
            else
                message = message + Choice1.Text + "\n";

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




        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // GearForm
        //    // 
        //    this.ClientSize = new System.Drawing.Size(1340, 651);
        //    this.Name = "GearForm";
        //    this.ResumeLayout(false);

        //}
    }
}
