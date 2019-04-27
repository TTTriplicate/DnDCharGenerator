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
    public partial class SkillSelect : Form
    {
        public String[] allSkillProfs = { "Acrobatics", "Animal Handling", "Arcana", "Athletics", "Deception", "History", "Insight", "Intimidation", "Investigation", "Medicine", "Nature", "Perception", "Preformance", "Persuasion", "Religion", "Sleight of Hand", "Stealth", "Survival" };
        protected static int numToSelect { get; set; }
        public bool[] SkillsList { get; set; }
        protected bool[] PreCheck { get; set; }

        //public Barbarian selected { get; set; }

        public SkillSelect(int numSkills, bool[] classSkills)
        {
            InitializeComponent();
            numToSelect = numSkills;
            SkillsList = classSkills;
            //PreCheck = backSkills;
        }

        public SkillSelect(int numSkills, bool[] classSkills, bool[] backSkills)
        {
            InitializeComponent();
            numToSelect = numSkills;
            SkillsList = classSkills;
            PreCheck = backSkills;
        }


        private void SkillSelect_Load(object sender, EventArgs e)
        {
            //bool[] skills = new bool[18];
            //foreach (string i in allSkillProfs)
            //{
            //    checklistSkills.Items.Clear();
            //    checklistSkills.Items.Add(i);
            //}
            //int count = 0;
            for(int i = 0; i < 18; i++)
            {
                if (PreCheck[i])
                {
                    //checklistSkills.SetItemCheckState(i, CheckState.Indeterminate);
                    checklistSkills.SetItemChecked(i, true);
                }
            }
        }

        private void checklistSkills_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(numToSelect.ToString());
            if (SkillsList[checklistSkills.SelectedIndex] == false)
                checklistSkills.SetItemCheckState(checklistSkills.SelectedIndex, CheckState.Unchecked);

            if (checklistSkills.SelectedItems.Count >= numToSelect)
            {
                checklistSkills.Enabled = false;
                MessageBox.Show("Selected");
            }
            MessageBox.Show(checklistSkills.SelectedItems.Count.ToString());
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            int adjust = 0;
            foreach (bool i in PreCheck)
                if (i) ++adjust;
            
            //if (checklistSkills.SelectedItems.Count == numToSelect + adjust)
            //{
            //    SkillsList = new bool[17];
            //    foreach (int i in checklistSkills.SelectedIndices)
            //    {
            //        SkillsList[i] = true;
            //        Console.WriteLine(i);
            //    }
            //    DialogResult = DialogResult.OK;
            //}
            //else MessageBox.Show($"Please select {numToSelect - (checklistSkills.SelectedItems.Count)} more skills.", "Not enough Skills Selected");
        }
    }
}
