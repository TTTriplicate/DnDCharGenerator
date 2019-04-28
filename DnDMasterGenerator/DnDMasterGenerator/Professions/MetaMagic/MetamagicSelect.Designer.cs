namespace DnDMasterGenerator.Professions.ClassFeatures.MetaMagic
{
    partial class MetamagicSelect
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
            this.txtCurrent = new System.Windows.Forms.RichTextBox();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.comboSelector = new System.Windows.Forms.ComboBox();
            this.lblSelector = new System.Windows.Forms.Label();
            this.comboSelector2 = new System.Windows.Forms.ComboBox();
            this.btnDone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCurrent
            // 
            this.txtCurrent.Location = new System.Drawing.Point(13, 43);
            this.txtCurrent.Name = "txtCurrent";
            this.txtCurrent.Size = new System.Drawing.Size(100, 96);
            this.txtCurrent.TabIndex = 0;
            this.txtCurrent.Text = "";
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Location = new System.Drawing.Point(13, 13);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(110, 17);
            this.lblCurrent.TabIndex = 1;
            this.lblCurrent.Text = "Current abilities:";
            this.lblCurrent.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboSelector
            // 
            this.comboSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSelector.FormattingEnabled = true;
            this.comboSelector.Location = new System.Drawing.Point(194, 43);
            this.comboSelector.Name = "comboSelector";
            this.comboSelector.Size = new System.Drawing.Size(121, 24);
            this.comboSelector.TabIndex = 2;
            // 
            // lblSelector
            // 
            this.lblSelector.AutoSize = true;
            this.lblSelector.Location = new System.Drawing.Point(194, 12);
            this.lblSelector.Name = "lblSelector";
            this.lblSelector.Size = new System.Drawing.Size(175, 17);
            this.lblSelector.TabIndex = 3;
            this.lblSelector.Text = "Select Metamagic Abilities:";
            // 
            // comboSelector2
            // 
            this.comboSelector2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSelector2.FormattingEnabled = true;
            this.comboSelector2.Location = new System.Drawing.Point(194, 92);
            this.comboSelector2.Name = "comboSelector2";
            this.comboSelector2.Size = new System.Drawing.Size(121, 24);
            this.comboSelector2.TabIndex = 4;
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(194, 163);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 5;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // MetamagicSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 232);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.comboSelector2);
            this.Controls.Add(this.lblSelector);
            this.Controls.Add(this.comboSelector);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.txtCurrent);
            this.Name = "MetamagicSelect";
            this.Text = "MetamagicSelect";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtCurrent;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.ComboBox comboSelector;
        private System.Windows.Forms.Label lblSelector;
        private System.Windows.Forms.ComboBox comboSelector2;
        private System.Windows.Forms.Button btnDone;
    }
}