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
            this.lblSkills.Font = new System.Drawing.Font("Baskerville Old Face", 12F);
            this.lblSkills.Location = new System.Drawing.Point(57, 83);
            this.lblSkills.Name = "lblSkills";
            this.lblSkills.Size = new System.Drawing.Size(255, 23);
            this.lblSkills.TabIndex = 1;
            this.lblSkills.Text = "Choose your skill proficiencies:";
            // 
            // btnDone
            // 
            this.btnDone.Font = new System.Drawing.Font("Baskerville Old Face", 9F);
            this.btnDone.Location = new System.Drawing.Point(183, 308);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 2;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // checkedlistSkills
            // 
            this.checkedlistSkills.CheckOnClick = true;
            this.checkedlistSkills.Font = new System.Drawing.Font("Baskerville Old Face", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.checkedlistSkills.Location = new System.Drawing.Point(60, 119);
            this.checkedlistSkills.Name = "checkedlistSkills";
            this.checkedlistSkills.Size = new System.Drawing.Size(298, 157);
            this.checkedlistSkills.TabIndex = 3;
            this.checkedlistSkills.SelectedIndexChanged += new System.EventHandler(this.checkedlistSkills_SelectedIndexChanged);
            // 
            // SkillSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(462, 380);
            this.Controls.Add(this.checkedlistSkills);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.lblSkills);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
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