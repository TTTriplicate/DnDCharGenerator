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

namespace DnDMasterGenerator.Professions.ClassFeatures.MetaMagic
{
    public partial class MetamagicSelect : Form
    {
        public List<string> Source { get; set; }

        public int[] Selected { get; set; }

        private int[] Current { get; set; }

        public MetamagicSelect()
        {
            InitializeComponent();
        }

        public MetamagicSelect(int[] indicies)
        {
            InitializeComponent();
            Source = SetSource(indicies);
        }

        private List<string> SetSource()
        {
            List<string> bits = new List<string>();
            string path = Path.Combine(Environment.CurrentDirectory, @"..\..\Professions\ClassFeatures\MetaMagic\Metamagic.txt");
            //string path = @"C:\Users\csous\source\repos\DnDClassesTest\DnDClassesTest\Professions\ClassFeatures\BarbarianClassFeatures.txt";
            string[] temp = new string[8];
            temp = File.ReadAllLines(path);
            foreach (string i in temp)
            {
                bits.Add(i);
            }
            return bits;

        }

        private List<string> SetSource(int[] indicies)
        {
            List<string> bits = new List<string>();
            string path = Path.Combine(Environment.CurrentDirectory, @"..\..\Professions\ClassFeatures\MetaMagic\Metamagic.txt");
            //string path = @"C:\Users\csous\source\repos\DnDClassesTest\DnDClassesTest\Professions\ClassFeatures\BarbarianClassFeatures.txt";
            string[] temp = new string[8];
            temp = File.ReadAllLines(path);
            foreach (string i in temp)
            {
                bits.Add(i);
            }
            int count = 0;
            int[] indicies removed
            return bits;

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (comboSelector2.Visible)
            {
                if (comboSelector.SelectedIndex != comboSelector2.SelectedIndex)
                    DialogResult = DialogResult.OK;
            }
        }
    }
}
