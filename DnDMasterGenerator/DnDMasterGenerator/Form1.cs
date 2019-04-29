using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

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
            //var sheet = new CharSheet(NewChar);
            var sheet = new LoadForm(NewChar);
            sheet.ShowDialog();
            this.Close();
        }

        private void btnLoadCharacter_Click(object sender, EventArgs e)
        {
            string PDFFolder = Path.Combine(Environment.CurrentDirectory, @"..\..\PDFs");
            Process.Start(PDFFolder);
        }

        private void LandingPage_Load(object sender, EventArgs e)
        {

        }
    }
}
