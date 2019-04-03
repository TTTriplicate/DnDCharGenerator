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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //for later        DnDCharacter test = new DnDCharacter

        DnDCharacter test1 = new DnDCharacter(1, 0, 0);
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            textBox1.Text = test1.CharClass.ProfessionName();
            textBox2.Text = test1.CharClass._hitDie.ToString();
            textBox3.Text = test1.CharClass._numProSkills.ToString();
            bool[] saves = test1.SavingThrows;
            string save = "";
            foreach(bool i in saves)
            {
                save += i.ToString() + ", ";
            }
            textBox4.Text = save;
            int[] stats = test1._abilities;
            string scores = "";
            foreach (int i in stats)
            {
                scores += i + ", ";
            }
            List<string> features = test1.CharClass.CurrentFeatures();
            textBox5.Text = features[1];

        }
    }
}
