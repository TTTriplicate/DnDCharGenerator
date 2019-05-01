namespace DnDMasterGenerator.Professions
{
    partial class PickOne
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PickOne));
            this.btnDone = new System.Windows.Forms.Button();
            this.comboSelector = new System.Windows.Forms.ComboBox();
            this.txtSelectionDisplay = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(320, 259);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 0;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // comboSelector
            // 
            this.comboSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSelector.FormattingEnabled = true;
            this.comboSelector.Location = new System.Drawing.Point(320, 68);
            this.comboSelector.Name = "comboSelector";
            this.comboSelector.Size = new System.Drawing.Size(121, 24);
            this.comboSelector.TabIndex = 1;
            this.comboSelector.SelectedIndexChanged += new System.EventHandler(this.comboSelector_SelectedIndexChanged);
            // 
            // txtSelectionDisplay
            // 
            this.txtSelectionDisplay.Location = new System.Drawing.Point(35, 68);
            this.txtSelectionDisplay.Name = "txtSelectionDisplay";
            this.txtSelectionDisplay.Size = new System.Drawing.Size(209, 214);
            this.txtSelectionDisplay.TabIndex = 2;
            this.txtSelectionDisplay.Text = "";
            // 
            // PickOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(516, 396);
            this.Controls.Add(this.txtSelectionDisplay);
            this.Controls.Add(this.comboSelector);
            this.Controls.Add(this.btnDone);
            this.Name = "PickOne";
            this.Text = "PickOne";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.ComboBox comboSelector;
        private System.Windows.Forms.RichTextBox txtSelectionDisplay;
    }
}