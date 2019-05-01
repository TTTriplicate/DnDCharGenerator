using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace DnDClassesTest
{
    public partial class loadChoicecs : Form
    {
        public loadChoicecs()
        {
            InitializeComponent();
            Error.Visible = false;
        }

        private void CharName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = "";
            name = CharName.Text;
            string locationOfPdf = Path.Combine(Environment.CurrentDirectory, @"..\..\PDFs\" + name + ".pdf");

            if (name == "")
                Error.Visible = true;
            else if (File.Exists(locationOfPdf))
            {
                Error.Visible = false;
                LoadForm load = new LoadForm(name);
                load.ShowDialog();
                this.Hide();
            }
            else
            {
                Error.Visible = true;
            }
        }
    }
}
