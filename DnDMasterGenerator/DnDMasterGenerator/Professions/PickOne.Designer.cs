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
            this.btnDone.Font = new System.Drawing.Font("Baskerville Old Face", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.Location = new System.Drawing.Point(240, 210);
            this.btnDone.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(56, 19);
            this.btnDone.TabIndex = 0;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // comboSelector
            // 
            this.comboSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSelector.Font = new System.Drawing.Font("Baskerville Old Face", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSelector.FormattingEnabled = true;
            this.comboSelector.Location = new System.Drawing.Point(240, 55);
            this.comboSelector.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboSelector.Name = "comboSelector";
            this.comboSelector.Size = new System.Drawing.Size(92, 22);
            this.comboSelector.TabIndex = 1;
            this.comboSelector.SelectedIndexChanged += new System.EventHandler(this.comboSelector_SelectedIndexChanged);
            // 
            // txtSelectionDisplay
            // 
            this.txtSelectionDisplay.Font = new System.Drawing.Font("Baskerville Old Face", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSelectionDisplay.Location = new System.Drawing.Point(26, 55);
            this.txtSelectionDisplay.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSelectionDisplay.Name = "txtSelectionDisplay";
            this.txtSelectionDisplay.Size = new System.Drawing.Size(158, 175);
            this.txtSelectionDisplay.TabIndex = 2;
            this.txtSelectionDisplay.Text = "";
            // 
            // PickOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(387, 322);
            this.Controls.Add(this.txtSelectionDisplay);
            this.Controls.Add(this.comboSelector);
            this.Controls.Add(this.btnDone);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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