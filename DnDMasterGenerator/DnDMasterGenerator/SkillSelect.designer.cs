namespace DnDClassesTest
{
    partial class SkillSelect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checklistSkills = new System.Windows.Forms.CheckedListBox();
            this.lblSkills = new System.Windows.Forms.Label();
            this.btnDone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checklistSkills
            // 
            this.checklistSkills.CheckOnClick = true;
            this.checklistSkills.FormattingEnabled = true;
            this.checklistSkills.Items.AddRange(new object[] {
            "Acrobatics",
            "Animal Handling",
            "Arcana",
            "Athletics",
            "Deception",
            "History",
            "Insight",
            "Intimidation",
            "Investigation",
            "Medicine",
            "Nature",
            "Perception",
            "Performance",
            "Persuasion",
            "Religion",
            "Sleight of Hand",
            "Stealth",
            "Survival"});
            this.checklistSkills.Location = new System.Drawing.Point(60, 103);
            this.checklistSkills.MultiColumn = true;
            this.checklistSkills.Name = "checklistSkills";
            this.checklistSkills.Size = new System.Drawing.Size(312, 157);
            this.checklistSkills.TabIndex = 0;
            this.checklistSkills.SelectedIndexChanged += new System.EventHandler(this.checklistSkills_SelectedIndexChanged);
            // 
            // lblSkills
            // 
            this.lblSkills.AutoSize = true;
            this.lblSkills.Location = new System.Drawing.Point(57, 83);
            this.lblSkills.Name = "lblSkills";
            this.lblSkills.Size = new System.Drawing.Size(202, 17);
            this.lblSkills.TabIndex = 1;
            this.lblSkills.Text = "Choose your skill proficiencies:";
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(183, 308);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 2;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // SkillSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 380);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.lblSkills);
            this.Controls.Add(this.checklistSkills);
            this.Name = "SkillSelect";
            this.Text = "SkillSelect";
            this.Load += new System.EventHandler(this.SkillSelect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checklistSkills;
        private System.Windows.Forms.Label lblSkills;
        private System.Windows.Forms.Button btnDone;
    }
}