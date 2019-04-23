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
            this.Weapons = new System.Windows.Forms.ComboBox();
            this.WeaponsLabel = new System.Windows.Forms.Label();
            this.Roll = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Hit = new System.Windows.Forms.RadioButton();
            this.RollResult = new System.Windows.Forms.Label();
            this.Miss = new System.Windows.Forms.RadioButton();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.damageFactor = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Weapons
            // 
            this.Weapons.FormattingEnabled = true;
            this.Weapons.Location = new System.Drawing.Point(12, 30);
            this.Weapons.Name = "Weapons";
            this.Weapons.Size = new System.Drawing.Size(121, 24);
            this.Weapons.TabIndex = 0;
            this.Weapons.SelectedIndexChanged += new System.EventHandler(this.Weapons_SelectedIndexChanged);
            // 
            // WeaponsLabel
            // 
            this.WeaponsLabel.AutoSize = true;
            this.WeaponsLabel.Location = new System.Drawing.Point(12, 10);
            this.WeaponsLabel.Name = "WeaponsLabel";
            this.WeaponsLabel.Size = new System.Drawing.Size(68, 17);
            this.WeaponsLabel.TabIndex = 1;
            this.WeaponsLabel.Text = "Weapons";
            // 
            // Roll
            // 
            this.Roll.Location = new System.Drawing.Point(15, 78);
            this.Roll.Name = "Roll";
            this.Roll.Size = new System.Drawing.Size(111, 36);
            this.Roll.TabIndex = 2;
            this.Roll.Text = "Roll 1d20";
            this.Roll.UseVisualStyleBackColor = true;
            this.Roll.Click += new System.EventHandler(this.Roll_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Miss);
            this.panel2.Controls.Add(this.Hit);
            this.panel2.Location = new System.Drawing.Point(12, 156);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(152, 36);
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
            this.Hit.CheckedChanged += new System.EventHandler(this.Hit_CheckedChanged);
            // 
            // RollResult
            // 
            this.RollResult.AutoSize = true;
            this.RollResult.Location = new System.Drawing.Point(85, 126);
            this.RollResult.Name = "RollResult";
            this.RollResult.Size = new System.Drawing.Size(16, 17);
            this.RollResult.TabIndex = 6;
            this.RollResult.Text = "0";
            this.RollResult.Click += new System.EventHandler(this.RollResult_Click);
            // 
            // Miss
            // 
            this.Miss.AutoSize = true;
            this.Miss.Location = new System.Drawing.Point(64, 4);
            this.Miss.Name = "Miss";
            this.Miss.Size = new System.Drawing.Size(57, 21);
            this.Miss.TabIndex = 7;
            this.Miss.TabStop = true;
            this.Miss.Text = "Miss";
            this.Miss.UseVisualStyleBackColor = true;
            this.Miss.CheckedChanged += new System.EventHandler(this.Miss_CheckedChanged);
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Location = new System.Drawing.Point(15, 126);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(48, 17);
            this.ResultLabel.TabIndex = 8;
            this.ResultLabel.Text = "Result";
            // 
            // damageFactor
            // 
            this.damageFactor.AutoSize = true;
            this.damageFactor.Location = new System.Drawing.Point(17, 211);
            this.damageFactor.Name = "damageFactor";
            this.damageFactor.Size = new System.Drawing.Size(109, 17);
            this.damageFactor.TabIndex = 9;
            this.damageFactor.Text = "Damage Factor:";
            this.damageFactor.Click += new System.EventHandler(this.damageFactor_Click);
            // 
            // AttackRoll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(311, 375);
            this.Controls.Add(this.damageFactor);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.RollResult);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Roll);
            this.Controls.Add(this.WeaponsLabel);
            this.Controls.Add(this.Weapons);
            this.Name = "AttackRoll";
            this.Text = "AttackRoll";
            this.Load += new System.EventHandler(this.AttackRoll_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Weapons;
        private System.Windows.Forms.Label WeaponsLabel;
        private System.Windows.Forms.Button Roll;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton Hit;
        private System.Windows.Forms.Label RollResult;
        private System.Windows.Forms.RadioButton Miss;
        private System.Windows.Forms.Label ResultLabel;
        private System.Windows.Forms.Label damageFactor;
    }
}