using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnDMasterGenerator.Professions
{
    public partial class PickOne : Form
    {
        public List<string> Choices { get; set; }
        public List<string> Options { get; set; }
        public int Selected { get; set; }

        public PickOne()
        {
            InitializeComponent();
        }

        public PickOne(List<string> choices)
        {
            InitializeComponent();
            Choices = choices;
            Options = new List<string>();
            foreach (string i in choices)
            {
                Options.Add(i.Split(':')[0]);
            }
            comboSelector.DataSource = Options;
        }

        public PickOne(string pro)
        {
            InitializeComponent();
            Choices = this.FightingStyles(pro);
            Options = new List<string>();
            foreach (string i in Choices)
            {
                Options.Add(i.Split(':')[0]);
            }
            comboSelector.DataSource = Options;

        }

        private void comboSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSelectionDisplay.Text = Choices[comboSelector.SelectedIndex];
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            Selected = comboSelector.SelectedIndex;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private List<string> FightingStyles(string pro)
        {
            List<string> styles = new List<string>();
            string path = Path.Combine(Environment.CurrentDirectory, @"..\..\Professions\FightingStyles\FightingStyles.txt");
            //string path = @"C:\Users\csous\source\repos\DnDClassesTest\DnDClassesTest\Professions\ClassFeatures\BarbarianClassFeatures.txt";
            string[] temp = new string[6];
            temp = File.ReadAllLines(path);
            foreach (string i in temp)
            {
                styles.Add(i);
            }
            if (pro == "Paladin")
            {
                styles.RemoveAt(0);
                styles.RemoveAt(4);
            }
            if (pro == "Ranger")
            {
                styles.RemoveRange(3, 2);
            }
            return styles;
        }
    }
}
}
