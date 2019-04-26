namespace DnDMasterGenerator
{
    partial class FightingStyles
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
            this.comboSelector = new System.Windows.Forms.ComboBox();
            this.lblSelector = new System.Windows.Forms.Label();
            this.btnDone = new System.Windows.Forms.Button();
            this.txtCurrent = new System.Windows.Forms.RichTextBox();
            this.lblStyles = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboSelector
            // 
            this.comboSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSelector.FormattingEnabled = true;
            this.comboSelector.Location = new System.Drawing.Point(166, 75);
            this.comboSelector.Name = "comboSelector";
            this.comboSelector.Size = new System.Drawing.Size(121, 24);
            this.comboSelector.TabIndex = 0;
            this.comboSelector.SelectedIndexChanged += new System.EventHandler(this.comboSelector_SelectedIndexChanged);
            // 
            // lblSelector
            // 
            this.lblSelector.AutoSize = true;
            this.lblSelector.Location = new System.Drawing.Point(166, 52);
            this.lblSelector.Name = "lblSelector";
            this.lblSelector.Size = new System.Drawing.Size(98, 17);
            this.lblSelector.TabIndex = 1;
            this.lblSelector.Text = "Select a Style:";
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(166, 208);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 2;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // txtCurrent
            // 
            this.txtCurrent.Location = new System.Drawing.Point(12, 72);
            this.txtCurrent.Name = "txtCurrent";
            this.txtCurrent.Size = new System.Drawing.Size(100, 96);
            this.txtCurrent.TabIndex = 3;
            this.txtCurrent.Text = "";
            // 
            // lblStyles
            // 
            this.lblStyles.AutoSize = true;
            this.lblStyles.Location = new System.Drawing.Point(12, 48);
            this.lblStyles.Name = "lblStyles";
            this.lblStyles.Size = new System.Drawing.Size(131, 17);
            this.lblStyles.TabIndex = 4;
            this.lblStyles.Text = "Your current styles:";
            // 
            // FightingStyles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 334);
            this.Controls.Add(this.lblStyles);
            this.Controls.Add(this.txtCurrent);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.lblSelector);
            this.Controls.Add(this.comboSelector);
            this.Name = "FightingStyles";
            this.Text = "FightingStyles";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboSelector;
        private System.Windows.Forms.Label lblSelector;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.RichTextBox txtCurrent;
        private System.Windows.Forms.Label lblStyles;
    }
}