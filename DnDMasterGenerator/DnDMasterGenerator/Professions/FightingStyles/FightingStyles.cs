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

namespace DnDMasterGenerator
{
    public partial class FightingStyles : Form
    {
        public List<string> Source { get; set; }
        public int Index { get; set; }

        public FightingStyles()
        {
            InitializeComponent();
        }

        public FightingStyles(string profession)
        {
            InitializeComponent();
            Source = setSource(profession);
            comboSelector.DataSource = Source;
            comboSelector.SelectedIndex = 0;
        }

        public FightingStyles(string profession, int style)
        {
            InitializeComponent();
            Source = setSource(profession);
            if (style != -1)
            {
                txtCurrent.AppendText(Source[style]);
                Source.RemoveAt(style);
            }
            comboSelector.DataSource = Source;
            comboSelector.SelectedIndex = 0;
        }

        private void comboSelector_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private List<string> setSource(string pro)
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
            if(pro == "Paladin")
            {
                styles.RemoveAt(0);
                styles.RemoveAt(4);
            }
            if(pro == "Ranger")
            {
                styles.RemoveRange(3, 2);
            }
            return styles;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            Index = comboSelector.SelectedIndex;
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
