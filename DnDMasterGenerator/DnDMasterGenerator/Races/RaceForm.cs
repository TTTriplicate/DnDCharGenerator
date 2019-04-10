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
    public partial class RaceSelect : Form
    {
        public RaceSelect()
        {
            InitializeComponent();
            for (int i = 0; i < 9; i++)
            {
                chooser.Items.Add(races[0,i]);
            }
        }

        public Race selected { get; set; }

        protected string[,] races = new string[4, 9] {
            {"Dwarf", "Elf", "Halfling", "Human", "Dragonborn", "Gnome", "Half-Elf", "Half-Orc", "Tiefling" },
            {"Hill", "High", "Lightfoot", "", "", "Forest", "", "", ""},
            {"Mountain", "Wood", "Stout", "", "", "Rock", "", "", ""},
            {"", "Dark", "", "", "", "", "", "", ""}
        };

        private void label1_Click(object sender, EventArgs e)
        {
            
        }


        private void chooser_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = new Race(chooser.SelectedItem.ToString());
            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = ""; textBox5.Text = ""; textBox6.Text = ""; textBox7.Text = "";
            
            foreach (int i in selected.getAA())
                textBox1.Text += i + ", ";
            textBox2.Text = selected.getAge();
            textBox3.Text = selected.getAlignment();
            textBox4.Text = selected.getSize();
            textBox5.Text = selected.getSpeed().ToString();
            foreach (bool i in selected.getLanguages())
                textBox6.Text += i + ", ";
            foreach (string i in selected.getSA())
                textBox7.Text += i + ", ";
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
