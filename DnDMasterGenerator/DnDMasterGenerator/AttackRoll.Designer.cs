namespace DnDClassesTest
{
    partial class AttackRoll
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Hit = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.RollResult = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Weapons";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(91, 221);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 36);
            this.button1.TabIndex = 2;
            this.button1.Text = "Roll 1d20";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioButton2);
            this.panel2.Controls.Add(this.Hit);
            this.panel2.Location = new System.Drawing.Point(61, 263);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(169, 36);
            this.panel2.TabIndex = 4;
            // 
            // Hit
            // 
            this.Hit.AutoSize = true;
            this.Hit.Location = new System.Drawing.Point(3, 4);
            this.Hit.Name = "Hit";
            this.Hit.Size = new System.Drawing.Size(46, 21);
            this.Hit.TabIndex = 0;
            this.Hit.TabStop = true;
            this.Hit.Text = "Hit";
            this.Hit.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(112, 4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(57, 21);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Miss";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // RollResult
            // 
            this.RollResult.AutoSize = true;
            this.RollResult.Location = new System.Drawing.Point(136, 191);
            this.RollResult.Name = "RollResult";
            this.RollResult.Size = new System.Drawing.Size(16, 17);
            this.RollResult.TabIndex = 6;
            this.RollResult.Text = "0";
            // 
            // AttackRoll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(311, 375);
            this.Controls.Add(this.RollResult);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "AttackRoll";
            this.Text = "AttackRoll";
            this.Load += new System.EventHandler(this.AttackRoll_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton Hit;
        private System.Windows.Forms.Label RollResult;
    }
}