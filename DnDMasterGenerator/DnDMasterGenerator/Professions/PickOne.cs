using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    }
}
