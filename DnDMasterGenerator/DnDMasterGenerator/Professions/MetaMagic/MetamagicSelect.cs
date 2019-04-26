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

        public List<int> Current { get; set; }

        public MetamagicSelect()
        {
            InitializeComponent();
            Source = SetSource();
            comboSelector.DataSource = Source;
            comboSelector.SelectedIndex = 0;
            comboSelector2.DataSource = Source;
            comboSelector2.SelectedIndex = 0;
            comboSelector2.Visible = true;

        }

        public MetamagicSelect(int[] indicies)
        {
            InitializeComponent();
            Source = SetSource();
            Current = new List<int>();
            if (indicies[0] >= 0)
            {
                comboSelector2.Enabled = false;
                comboSelector2.Visible = false;
                foreach (int i in indicies)
                {
                    Current.Add(i);
                    if (i == -1) continue;
                    else txtCurrent.AppendText(Source[i]);
                }
                Array.Sort(indicies);
                Array.Reverse(indicies);
                foreach (int i in indicies)
                {
                    if (i == -1) break;
                    else Source.RemoveAt(i);
                }
                comboSelector.DataSource = Source;
                comboSelector.SelectedIndex = 0;
                Selected = new int[1];
            }
            else
            {
                Current = new List<int> { -1, -1, -1, -1, -1 };
                comboSelector.DataSource = Source;
                comboSelector.SelectedIndex = 0;
                comboSelector2.BindingContext = new BindingContext();
                comboSelector2.DataSource = Source;
                comboSelector2.SelectedIndex = 0;
                Selected = new int[2];
            }
        }

        private List<string> SetSource()
        {
            List<string> bits = new List<string>();
            string path = Path.Combine(Environment.CurrentDirectory, @"..\..\Professions\MetaMagic\Metamagic.txt");
            //string path = @"C:\Users\csous\source\repos\DnDClassesTest\DnDClassesTest\Professions\ClassFeatures\BarbarianClassFeatures.txt";
            string[] temp = new string[8];
            temp = File.ReadAllLines(path);
            foreach (string i in temp)
            {
                bits.Add(i);
            }
            return bits;

        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (comboSelector2.Enabled)
            {
                if (comboSelector.SelectedIndex != comboSelector2.SelectedIndex)
                {
                    Selected[0] = comboSelector.SelectedIndex;
                    Selected[1] = comboSelector2.SelectedIndex;
                    foreach (int i in Selected)
                        Current[Current.IndexOf(-1)] = i;
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please select two different options.", "Same item selected.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Selected[0] = comboSelector.SelectedIndex;
                foreach (int i in Selected)
                    Current[Current.IndexOf(-1)] = i;
                DialogResult = DialogResult.OK;
                this.Close();

            }
        }
    }
}
