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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkillSelect));
            this.lblSkills = new System.Windows.Forms.Label();
            this.btnDone = new System.Windows.Forms.Button();
            this.checkedlistSkills = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // lblSkills
            // 
            this.lblSkills.AutoSize = true;
            this.lblSkills.BackColor = System.Drawing.Color.Transparent;
            this.lblSkills.Location = new System.Drawing.Point(86, 130);
            this.lblSkills.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSkills.Name = "lblSkills";
            this.lblSkills.Size = new System.Drawing.Size(310, 25);
            this.lblSkills.TabIndex = 1;
            this.lblSkills.Text = "Choose your skill proficiencies:";
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(274, 481);
            this.btnDone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(112, 36);
            this.btnDone.TabIndex = 2;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // checkedlistSkills
            // 
            this.checkedlistSkills.CheckOnClick = true;
            this.checkedlistSkills.FormattingEnabled = true;
            this.checkedlistSkills.Items.AddRange(new object[] {
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
            this.checkedlistSkills.Location = new System.Drawing.Point(90, 186);
            this.checkedlistSkills.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkedlistSkills.Name = "checkedlistSkills";
            this.checkedlistSkills.Size = new System.Drawing.Size(445, 264);
            this.checkedlistSkills.TabIndex = 3;
            this.checkedlistSkills.SelectedIndexChanged += new System.EventHandler(this.checkedlistSkills_SelectedIndexChanged);
            // 
            // SkillSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(693, 594);
            this.Controls.Add(this.checkedlistSkills);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.lblSkills);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SkillSelect";
            this.Text = "SkillSelect";
            this.Load += new System.EventHandler(this.SkillSelect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSkills;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.CheckedListBox checkedlistSkills;
    }
}