namespace DnDClassesTest
{
    partial class BackgroundForm
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
            this.BOND = new System.Windows.Forms.TextBox();
            this.FLAW = new System.Windows.Forms.TextBox();
            this.IDEAL = new System.Windows.Forms.TextBox();
            this.PERSONALITY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BGChoice = new System.Windows.Forms.ComboBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BOND
            // 
            this.BOND.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BOND.Location = new System.Drawing.Point(27, 281);
            this.BOND.Name = "BOND";
            this.BOND.Size = new System.Drawing.Size(495, 27);
            this.BOND.TabIndex = 11;
            // 
            // FLAW
            // 
            this.FLAW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FLAW.Location = new System.Drawing.Point(27, 248);
            this.FLAW.Name = "FLAW";
            this.FLAW.Size = new System.Drawing.Size(495, 27);
            this.FLAW.TabIndex = 10;
            // 
            // IDEAL
            // 
            this.IDEAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDEAL.Location = new System.Drawing.Point(26, 215);
            this.IDEAL.Name = "IDEAL";
            this.IDEAL.Size = new System.Drawing.Size(495, 27);
            this.IDEAL.TabIndex = 9;
            // 
            // PERSONALITY
            // 
            this.PERSONALITY.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PERSONALITY.Location = new System.Drawing.Point(26, 182);
            this.PERSONALITY.Name = "PERSONALITY";
            this.PERSONALITY.Size = new System.Drawing.Size(495, 27);
            this.PERSONALITY.TabIndex = 8;
            this.PERSONALITY.TextChanged += new System.EventHandler(this.PERSONALITY_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(183, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 29);
            this.label1.TabIndex = 7;
            this.label1.Text = "Background:";
            // 
            // BGChoice
            // 
            this.BGChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BGChoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BGChoice.FormattingEnabled = true;
            this.BGChoice.ItemHeight = 25;
            this.BGChoice.Items.AddRange(new object[] {
            "Acolyte",
            "Charlatan",
            "Criminal",
            "Entertainer",
            "Folk Hero",
            "Guild Artisan",
            "Hermit",
            "Noble",
            "Outlander",
            "Sage",
            "Sailor",
            "Soldier",
            "Urchin"});
            this.BGChoice.Location = new System.Drawing.Point(188, 118);
            this.BGChoice.MaxDropDownItems = 13;
            this.BGChoice.Name = "BGChoice";
            this.BGChoice.Size = new System.Drawing.Size(143, 33);
            this.BGChoice.Sorted = true;
            this.BGChoice.TabIndex = 6;
            this.BGChoice.SelectedIndexChanged += new System.EventHandler(this.BGChoice_SelectedIndexChanged);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(218, 348);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 13;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // BackgroundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 456);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.BOND);
            this.Controls.Add(this.FLAW);
            this.Controls.Add(this.IDEAL);
            this.Controls.Add(this.PERSONALITY);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BGChoice);
            this.Name = "BackgroundForm";
            this.Text = "BackgroundForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox BOND;
        private System.Windows.Forms.TextBox FLAW;
        private System.Windows.Forms.TextBox IDEAL;
        private System.Windows.Forms.TextBox PERSONALITY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox BGChoice;
        private System.Windows.Forms.Button btnNext;
    }
}