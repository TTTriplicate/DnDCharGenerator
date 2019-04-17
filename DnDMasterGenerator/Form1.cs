using System;
using System.Windows.Forms;

namespace DnDClassesTest
{
    public partial class LandingPage : Form
    {
        public LandingPage()
        {
            InitializeComponent();
        }
        //for later        DnDCharacter test = new DnDCharacter

        private void btnDisplay_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DnDCharacter NewChar = new DnDCharacter();
            var sheet = new CharSheet(NewChar);
            sheet.ShowDialog();
            this.Close();
        }
    }
}
