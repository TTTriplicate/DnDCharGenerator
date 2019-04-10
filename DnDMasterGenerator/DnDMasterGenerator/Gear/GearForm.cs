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
            //gear = new CharGear("Barbarian", "Folk Hero", 0);
            items = gear.getOptions();
            itemString = gear.getStrings();

            int numItems = gear.getNumChoices();
            Choice1.Hide();
            Choice2.Hide();
            Choice3.Hide();
            Choice4.Hide();
            Choice5.Hide();
            Choice6.Hide();
            Secondary2.Hide();
            Secondary1.Hide();

            

            switch (numItems)
            {
                case 1:
                    Choice1.Show();
                    Choice1.DataSource = itemString[0];
                    break;
                case 2:
                    Choice1.Show();
                    Choice1.DataSource = itemString[0];
                    Choice2.Show();
                    Choice2.DataSource = itemString[1];
                    break;
                case 3:
                    Choice1.Show();
                    Choice1.DataSource = itemString[0];
                    Choice2.Show();
                    Choice2.DataSource = itemString[1];
                    Choice3.Show();
                    Choice3.DataSource = itemString[2];
                    break;
                case 4:
                    Choice1.Show();
                    Choice1.DataSource = itemString[0];
                    Choice2.Show();
                    Choice2.DataSource = itemString[1];
                    Choice3.Show();
                    Choice3.DataSource = itemString[2];
                    Choice4.Show();
                    Choice4.DataSource = itemString[3];
                    break;
                case 5:
                    Choice1.Show();
                    Choice1.DataSource = itemString[0];
                    Choice2.Show();
                    Choice2.DataSource = itemString[1];
                    Choice3.Show();
                    Choice3.DataSource = itemString[2];
                    Choice4.Show();
                    Choice4.DataSource = itemString[3];
                    Choice5.Show();
                    Choice5.DataSource = itemString[4];
                    break;
                case 6:
                    Choice1.Show();
                    Choice1.DataSource = itemString[0];
                    Choice2.Show();
                    Choice2.DataSource = itemString[1];
                    Choice3.Show();
                    Choice3.DataSource = itemString[2];
                    Choice4.Show();
                    Choice4.DataSource = itemString[3];
                    Choice5.Show();
                    Choice5.DataSource = itemString[4];
                    Choice6.Show();
                    Choice6.DataSource = itemString[5];
                    break;
                default:
                    break;
            }

            inventory = gear.getInventory();
            inventoryString = gear.getInventoryString();
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
            for (int i = 0; i < inventoryString.Count(); i++)
            {
                message = message + inventoryString[i] + "\n";
            }
            message = message + Choice1.Text + "\n";
            message = message + Choice2.Text + "\n";
            message = message + Choice3.Text + "\n";
            message = message + Choice4.Text + "\n";
            message = message + Choice5.Text + "\n";
            message = message + Choice6.Text + "\n";
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

        private void Secondary2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Secondary1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // GearForm
        //    // 
        //    this.ClientSize = new System.Drawing.Size(828, 483);
        //    this.Name = "GearForm";
        //    this.Load += new System.EventHandler(this.GearForm_Load);
        //    this.ResumeLayout(false);

        //}

        private void GearForm_Load(object sender, EventArgs e)
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
