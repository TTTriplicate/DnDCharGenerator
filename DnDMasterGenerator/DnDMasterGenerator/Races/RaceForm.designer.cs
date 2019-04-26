namespace DnDClassesTest
{
    partial class RaceSelect
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
            this.subRaceBox = new System.Windows.Forms.ComboBox();
            this.specialsBox = new System.Windows.Forms.RichTextBox();
            this.error = new System.Windows.Forms.Label();
            this.langBox = new System.Windows.Forms.RichTextBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.chooser = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.alignmentBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.saasBox = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // subRaceBox
            // 
            this.subRaceBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subRaceBox.FormattingEnabled = true;
            this.subRaceBox.Location = new System.Drawing.Point(456, 175);
            this.subRaceBox.Name = "subRaceBox";
            this.subRaceBox.Size = new System.Drawing.Size(242, 46);
            this.subRaceBox.TabIndex = 37;
            this.subRaceBox.Visible = false;
            this.subRaceBox.SelectedIndexChanged += new System.EventHandler(this.subRaceBox_SelectedIndexChanged);
            // 
            // specialsBox
            // 
            this.specialsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.specialsBox.Location = new System.Drawing.Point(208, 465);
            this.specialsBox.Name = "specialsBox";
            this.specialsBox.ReadOnly = true;
            this.specialsBox.Size = new System.Drawing.Size(490, 110);
            this.specialsBox.TabIndex = 36;
            this.specialsBox.Text = "";
            this.specialsBox.TextChanged += new System.EventHandler(this.specialsBox_TextChanged);
            // 
            // error
            // 
            this.error.AutoSize = true;
            this.error.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.error.ForeColor = System.Drawing.Color.Red;
            this.error.Location = new System.Drawing.Point(366, 811);
            this.error.Name = "error";
            this.error.Size = new System.Drawing.Size(221, 24);
            this.error.TabIndex = 35;
            this.error.Text = "Please fill out all fields";
            this.error.Visible = false;
            this.error.Click += new System.EventHandler(this.error_Click);
            // 
            // langBox
            // 
            this.langBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.langBox.Location = new System.Drawing.Point(208, 336);
            this.langBox.Name = "langBox";
            this.langBox.ReadOnly = true;
            this.langBox.Size = new System.Drawing.Size(490, 97);
            this.langBox.TabIndex = 34;
            this.langBox.Text = "";
            this.langBox.TextChanged += new System.EventHandler(this.langBox_TextChanged_1);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(433, 785);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 33;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // chooser
            // 
            this.chooser.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooser.FormattingEnabled = true;
            this.chooser.Location = new System.Drawing.Point(208, 175);
            this.chooser.Name = "chooser";
            this.chooser.Size = new System.Drawing.Size(490, 46);
            this.chooser.TabIndex = 32;
            this.chooser.Text = " (Choose One)";
            this.chooser.SelectedIndexChanged += new System.EventHandler(this.chooser_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(281, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(338, 135);
            this.label1.TabIndex = 26;
            this.label1.Text = "Race";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // alignmentBox
            // 
            this.alignmentBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alignmentBox.FormattingEnabled = true;
            this.alignmentBox.Items.AddRange(new object[] {
            "Lawful Good",
            "Lawful Neutral",
            "Lawful Evil",
            "Neutral Good",
            "True Neutral",
            "Neutral Evil",
            "Chaotic Good",
            "Chaotic Neutral",
            "Chaotic Evil"});
            this.alignmentBox.Location = new System.Drawing.Point(208, 257);
            this.alignmentBox.Name = "alignmentBox";
            this.alignmentBox.Size = new System.Drawing.Size(490, 46);
            this.alignmentBox.TabIndex = 38;
            this.alignmentBox.Text = "(Choose One)";
            this.alignmentBox.SelectedIndexChanged += new System.EventHandler(this.alignmentBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(203, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 25);
            this.label2.TabIndex = 39;
            this.label2.Text = "Alignment";
            // 
            // saasBox
            // 
            this.saasBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saasBox.Location = new System.Drawing.Point(208, 589);
            this.saasBox.Name = "saasBox";
            this.saasBox.ReadOnly = true;
            this.saasBox.Size = new System.Drawing.Size(490, 172);
            this.saasBox.TabIndex = 40;
            this.saasBox.Text = "";
            this.saasBox.TextChanged += new System.EventHandler(this.saasBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(203, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 25);
            this.label4.TabIndex = 42;
            this.label4.Text = "Languages";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(203, 438);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 25);
            this.label5.TabIndex = 43;
            this.label5.Text = "Special Abilities";
            // 
            // RaceSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 858);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.saasBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.alignmentBox);
            this.Controls.Add(this.subRaceBox);
            this.Controls.Add(this.specialsBox);
            this.Controls.Add(this.error);
            this.Controls.Add(this.langBox);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.chooser);
            this.Controls.Add(this.label1);
            this.Name = "RaceSelect";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox subRaceBox;
        private System.Windows.Forms.RichTextBox specialsBox;
        private System.Windows.Forms.Label error;
        private System.Windows.Forms.RichTextBox langBox;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ComboBox chooser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox alignmentBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox saasBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

