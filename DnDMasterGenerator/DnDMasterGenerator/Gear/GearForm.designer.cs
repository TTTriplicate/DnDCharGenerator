namespace DnDClassesTest
{
    partial class GearForm
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
            this.Choice2 = new System.Windows.Forms.ComboBox();
            this.Choice3 = new System.Windows.Forms.ComboBox();
            this.Choice4 = new System.Windows.Forms.ComboBox();
            this.Choice5 = new System.Windows.Forms.ComboBox();
            this.Choice6 = new System.Windows.Forms.ComboBox();
            this.Choice1 = new System.Windows.Forms.ComboBox();
            this.Submit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Inventory = new System.Windows.Forms.ListBox();
            this.Secondary2 = new System.Windows.Forms.ComboBox();
            this.Secondary1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Choice2
            // 
            this.Choice2.FormattingEnabled = true;
            this.Choice2.Location = new System.Drawing.Point(114, 121);
            this.Choice2.Margin = new System.Windows.Forms.Padding(2);
            this.Choice2.Name = "Choice2";
            this.Choice2.Size = new System.Drawing.Size(687, 24);
            this.Choice2.TabIndex = 1;
            this.Choice2.SelectedIndexChanged += new System.EventHandler(this.Choice2_SelectedIndexChanged);
            // 
            // Choice3
            // 
            this.Choice3.FormattingEnabled = true;
            this.Choice3.Location = new System.Drawing.Point(114, 173);
            this.Choice3.Margin = new System.Windows.Forms.Padding(2);
            this.Choice3.Name = "Choice3";
            this.Choice3.Size = new System.Drawing.Size(687, 24);
            this.Choice3.TabIndex = 2;
            this.Choice3.SelectedIndexChanged += new System.EventHandler(this.Choice3_SelectedIndexChanged);
            // 
            // Choice4
            // 
            this.Choice4.FormattingEnabled = true;
            this.Choice4.Location = new System.Drawing.Point(114, 226);
            this.Choice4.Margin = new System.Windows.Forms.Padding(2);
            this.Choice4.Name = "Choice4";
            this.Choice4.Size = new System.Drawing.Size(687, 24);
            this.Choice4.TabIndex = 3;
            this.Choice4.SelectedIndexChanged += new System.EventHandler(this.Choice4_SelectedIndexChanged);
            // 
            // Choice5
            // 
            this.Choice5.FormattingEnabled = true;
            this.Choice5.Location = new System.Drawing.Point(114, 279);
            this.Choice5.Margin = new System.Windows.Forms.Padding(2);
            this.Choice5.Name = "Choice5";
            this.Choice5.Size = new System.Drawing.Size(687, 24);
            this.Choice5.TabIndex = 4;
            this.Choice5.SelectedIndexChanged += new System.EventHandler(this.Choice5_SelectedIndexChanged);
            // 
            // Choice6
            // 
            this.Choice6.FormattingEnabled = true;
            this.Choice6.Location = new System.Drawing.Point(114, 329);
            this.Choice6.Margin = new System.Windows.Forms.Padding(2);
            this.Choice6.Name = "Choice6";
            this.Choice6.Size = new System.Drawing.Size(687, 24);
            this.Choice6.TabIndex = 5;
            this.Choice6.SelectedIndexChanged += new System.EventHandler(this.Choice6_SelectedIndexChanged);
            // 
            // Choice1
            // 
            this.Choice1.FormattingEnabled = true;
            this.Choice1.Location = new System.Drawing.Point(114, 68);
            this.Choice1.Margin = new System.Windows.Forms.Padding(2);
            this.Choice1.Name = "Choice1";
            this.Choice1.Size = new System.Drawing.Size(687, 24);
            this.Choice1.TabIndex = 6;
            this.Choice1.SelectedIndexChanged += new System.EventHandler(this.Choice1_SelectedIndexChanged);
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(407, 383);
            this.Submit.Margin = new System.Windows.Forms.Padding(2);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(117, 44);
            this.Submit.TabIndex = 7;
            this.Submit.Text = "Done";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1281, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Current Inventory";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(109, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Please choose your gear:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Inventory
            // 
            this.Inventory.FormattingEnabled = true;
            this.Inventory.ItemHeight = 16;
            this.Inventory.Location = new System.Drawing.Point(1286, 68);
            this.Inventory.Margin = new System.Windows.Forms.Padding(2);
            this.Inventory.Name = "Inventory";
            this.Inventory.Size = new System.Drawing.Size(335, 356);
            this.Inventory.TabIndex = 14;
            this.Inventory.SelectedIndexChanged += new System.EventHandler(this.Inventory_SelectedIndexChanged);
            // 
            // Secondary2
            // 
            this.Secondary2.FormattingEnabled = true;
            this.Secondary2.Location = new System.Drawing.Point(861, 121);
            this.Secondary2.Name = "Secondary2";
            this.Secondary2.Size = new System.Drawing.Size(323, 24);
            this.Secondary2.TabIndex = 16;
            this.Secondary2.SelectedIndexChanged += new System.EventHandler(this.Secondary2_SelectedIndexChanged);
            // 
            // Secondary1
            // 
            this.Secondary1.FormattingEnabled = true;
            this.Secondary1.Location = new System.Drawing.Point(861, 68);
            this.Secondary1.Name = "Secondary1";
            this.Secondary1.Size = new System.Drawing.Size(323, 24);
            this.Secondary1.TabIndex = 17;
            this.Secondary1.SelectedIndexChanged += new System.EventHandler(this.Secondary1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1693, 582);
            this.Controls.Add(this.Secondary1);
            this.Controls.Add(this.Secondary2);
            this.Controls.Add(this.Inventory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.Choice1);
            this.Controls.Add(this.Choice6);
            this.Controls.Add(this.Choice5);
            this.Controls.Add(this.Choice4);
            this.Controls.Add(this.Choice3);
            this.Controls.Add(this.Choice2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Choice2;
        private System.Windows.Forms.ComboBox Choice3;
        private System.Windows.Forms.ComboBox Choice4;
        private System.Windows.Forms.ComboBox Choice5;
        private System.Windows.Forms.ComboBox Choice6;
        private System.Windows.Forms.ComboBox Choice1;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox Inventory;
        private System.Windows.Forms.ComboBox Secondary2;
        private System.Windows.Forms.ComboBox Secondary1;
    }
}

