using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DNDGear
{
    public partial class Form1 : Form
    {
        

        public Form1()
        { 
            InitializeComponent();
        }
        
        

        public void Form1_Load(object sender, EventArgs e)
        {
            CharGear gear = new CharGear("Barbarian", "Acolyte", 0);
            List<List<Gear>> items = gear.getOptions();
            List<List<string>> itemString = gear.getStrings();
            int numItems = gear.getNumChoices();



            Choice1.DataSource = items[0];
            if (numItems >= 2)
            {
                Choice2.DataSource = itemString[1];
            }
            if (numItems >= 3)
            {
                Choice3.DataSource = itemString[2];
            }
            if(numItems >= 4)
            {
                Choice4.DataSource = itemString[3];
            }
            if (numItems >= 5)
            {
                Choice4.DataSource = itemString[4];
            }
            if (numItems == 6)
            {
                Choice4.DataSource = itemString[5];
            }

        }

        public void Choice1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = Choice1.SelectedItem.ToString();
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

        public void label4_Click(object sender, EventArgs e)
        {

        }

        public void label3_Click(object sender, EventArgs e)
        {

        }

        public void label5_Click(object sender, EventArgs e)
        {

        }

        public void label6_Click(object sender, EventArgs e)
        {

        }

        private void Inventory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
