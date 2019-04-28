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
        //public int preCheckOne = -1, preCheckTwo;

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
            SkillsList = new bool[18];
        }


        private void SkillSelect_Load(object sender, EventArgs e)
        {
            //bool[] skills = new bool[18];
            //foreach (string i in allSkillProfs)
            //{
            //    checkedlistSkills.Items.Clear();
            //    checkedlistSkills.Items.Add(i);
            //}
            //int count = 0;
            for(int i = 0; i < 18; i++)
            {
                if (PreCheck[i])
                {
                    checkedlistSkills.SetItemCheckState(i, CheckState.Indeterminate);
                    //checkedlistSkills.SetItemChecked(i, true);
                }
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            int adjust = 0;
            foreach (bool i in PreCheck)
                if (i) ++adjust;
            //MessageBox.Show(checkedlistSkills.CheckedItems.Count.ToString());

            if (checkedlistSkills.CheckedItems.Count == numToSelect + adjust)
            {
                
                foreach (int i in checkedlistSkills.CheckedIndices)
                {
                    SkillsList[i] = true;
                    Console.WriteLine(i);
                }
                DialogResult = DialogResult.OK;
            }
            else MessageBox.Show($"Please select {(numToSelect + adjust) - (checkedlistSkills.CheckedItems.Count)} more skills.", "Not enough Skills Selected");
        }

        private void checkedlistSkills_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(numToSelect.ToString());
            if (SkillsList[checkedlistSkills.SelectedIndex] == false)
                checkedlistSkills.SetItemCheckState(checkedlistSkills.SelectedIndex, CheckState.Unchecked);

            if (checkedlistSkills.CheckedItems.Count - 2 >= numToSelect)
            { 
                checkedlistSkills.Enabled = false;
                MessageBox.Show("Maximum amount of skills selected");
            }
            //MessageBox.Show(checkedlistSkills.SelectedItems.Count.ToString());
        }
    }
}
