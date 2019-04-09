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
    public partial class BackgroundForm : Form
    {
        public Background_Class Character = new Background_Class();

        public BackgroundForm()
        {
            InitializeComponent();
        }

        private void PERSONALITY_TextChanged(object sender, EventArgs e)
        {

        }

        private void BGChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Personality = "", Ideal = "", Flaw = "", Bond = "";
            string choice = BGChoice.Text;
            //Background_Class Character = new Background_Class(choice);

            Character.loadFile(choice);
            //TEXTBOX.Text = choice;
            //TEXTBOX.Text = Character.PersonalityTrait();
            Character.Traits(ref Personality, ref Ideal, ref Flaw, ref Bond);
            PERSONALITY.Text = Personality;
            IDEAL.Text = Ideal;
            FLAW.Text = Flaw;
            BOND.Text = Bond;
        }

        //Submit button
        //setBackground(string background);
        //setTraits(string, string, string, string)
        //setProfs(string, string, string)
        //this.Close();
    }
}

