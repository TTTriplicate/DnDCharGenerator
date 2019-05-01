using DnDClassesTest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnDMasterGenerator
{
    public partial class DisplayForm : Form
    {
        public DisplayForm()
        {
            //InitializeComponent();
        }

        public DisplayForm(DnDCharacter leeroy)
        {
            //InitializeComponent();
            //foreach (string s in leeroy.CharRace.getSA())
            //{
            //    if (s == null) continue;
            //    else richTextBox1.AppendText(s + "\n");
            //}
            //foreach (string s in leeroy._class.CurrFeatures)
            //    richTextBox1.AppendText(s+"\n");

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
