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
    public partial class AbilityIncrease : Form
    {
        private int[] Current { get; set; }

        public int[] Adjust { get; set; }

        private RadioButton[] FirstPoint { get; set; }

        private RadioButton[] SecondPoint { get; set; }

        private TextBox[] ShowScores { get; set; }

        public AbilityIncrease()
        {
            InitializeComponent();
        }

        public AbilityIncrease(int[] scores)
        {
            InitializeComponent();
            FirstPoint = new RadioButton[6] { STR1, DEX1, CON1, INT1, WIS1, CHA1 };
            SecondPoint = new RadioButton[6] { STR2, DEX2, CON2, INT2, WIS2, CHA2 };
            ShowScores = new TextBox[6] { txtSTR, txtDEX, txtCON, txtINT, txtWIS, txtCHA };
            Adjust = new int[6];
            Current = scores;
            for(int i = 0; i < 6; ++i)
            {
                ShowScores[i].Text = Current[i].ToString();
            }
        }
        private void btnDone_Click(object sender, EventArgs e)
        {
            int select = 0;
            bool Checkmax = true;
            for (int i = 0; i < 6; ++i)
            {
                select += Adjust[i];
                Checkmax = (Adjust[i] + Current[i]) < 21 ? true : false;
                if (!Checkmax) break;
            }
            if (select == 2 && Checkmax)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (!Checkmax)
                MessageBox.Show("Cannot increase abilty scores above 20.", "Adjustment too great");
            else if (select < 2)
                MessageBox.Show("Select two ability scores to increase.", "Not Enough Selections");
            else
                MessageBox.Show("Unable to make adjustment, please check your selections.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void NewAdjustment()
        {
            Adjust = new int[6];

            for(int i = 0; i < 6; ++i)
            {
                if (FirstPoint[i].Checked)
                    ++Adjust[i];
                if (SecondPoint[i].Checked)
                    ++Adjust[i];
                ShowScores[i].Text = (Current[i] + Adjust[i]).ToString();
            }

        }

        private void STR1_CheckedChanged(object sender, EventArgs e)
        {
            NewAdjustment();
        }

        private void DEX1_CheckedChanged(object sender, EventArgs e)
        {
            NewAdjustment();
        }

        private void CON1_CheckedChanged(object sender, EventArgs e)
        {
            NewAdjustment();
        }

        private void INT1_CheckedChanged(object sender, EventArgs e)
        {
            NewAdjustment();
        }

        private void WIS1_CheckedChanged(object sender, EventArgs e)
        {
            NewAdjustment();
        }

        private void CHA1_CheckedChanged(object sender, EventArgs e)
        {
            NewAdjustment();
        }

        private void STR2_CheckedChanged(object sender, EventArgs e)
        {
            NewAdjustment();
        }

        private void DEX2_CheckedChanged(object sender, EventArgs e)
        {
            NewAdjustment();
        }

        private void CON2_CheckedChanged(object sender, EventArgs e)
        {
            NewAdjustment();
        }

        private void INT2_CheckedChanged(object sender, EventArgs e)
        {
            NewAdjustment();
        }

        private void WIS2_CheckedChanged(object sender, EventArgs e)
        {
            NewAdjustment();
        }

        private void CHA2_CheckedChanged(object sender, EventArgs e)
        {
            NewAdjustment();
        }
    }
}
