namespace DnDClassesTest
{
    partial class loadChoicecs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loadChoicecs));
            this.label2 = new System.Windows.Forms.Label();
            this.CharName = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Error = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Baskerville Old Face", 12F);
            this.label2.Location = new System.Drawing.Point(116, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(317, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Please enter the character name below:";
            // 
            // CharName
            // 
            this.CharName.Font = new System.Drawing.Font("Baskerville Old Face", 13F);
            this.CharName.Location = new System.Drawing.Point(137, 224);
            this.CharName.Name = "CharName";
            this.CharName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CharName.Size = new System.Drawing.Size(276, 41);
            this.CharName.TabIndex = 4;
            this.CharName.Text = "";
            this.CharName.TextChanged += new System.EventHandler(this.CharName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Baskerville Old Face", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(103, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 38);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dungeon and Dragons";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Baskerville Old Face", 12F);
            this.label3.Location = new System.Drawing.Point(218, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Load Form:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(228, 313);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 32);
            this.button1.TabIndex = 7;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Error
            // 
            this.Error.AutoSize = true;
            this.Error.BackColor = System.Drawing.Color.Transparent;
            this.Error.Font = new System.Drawing.Font("Baskerville Old Face", 12F);
            this.Error.ForeColor = System.Drawing.Color.Red;
            this.Error.Location = new System.Drawing.Point(164, 273);
            this.Error.Name = "Error";
            this.Error.Size = new System.Drawing.Size(216, 23);
            this.Error.TabIndex = 8;
            this.Error.Text = "Please enter a valid name!";
            // 
            // loadChoicecs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(568, 384);
            this.Controls.Add(this.Error);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CharName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "loadChoicecs";
            this.Text = "loadChoicecs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox CharName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Error;
    }
}