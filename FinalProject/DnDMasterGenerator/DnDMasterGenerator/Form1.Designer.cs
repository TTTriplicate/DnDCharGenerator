namespace DnDClassesTest
{
    partial class LandingPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LandingPage));
            this.btnNewCharacter = new System.Windows.Forms.Button();
            this.btnLoadCharacter = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnNewCharacter
            // 
            this.btnNewCharacter.BackColor = System.Drawing.Color.White;
            this.btnNewCharacter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewCharacter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNewCharacter.Font = new System.Drawing.Font("Baskerville Old Face", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewCharacter.Location = new System.Drawing.Point(124, 145);
            this.btnNewCharacter.Name = "btnNewCharacter";
            this.btnNewCharacter.Size = new System.Drawing.Size(75, 23);
            this.btnNewCharacter.TabIndex = 0;
            this.btnNewCharacter.Text = "New";
            this.btnNewCharacter.UseVisualStyleBackColor = false;
            this.btnNewCharacter.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLoadCharacter
            // 
            this.btnLoadCharacter.BackColor = System.Drawing.Color.White;
            this.btnLoadCharacter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadCharacter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoadCharacter.Font = new System.Drawing.Font("Baskerville Old Face", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadCharacter.Location = new System.Drawing.Point(282, 145);
            this.btnLoadCharacter.Name = "btnLoadCharacter";
            this.btnLoadCharacter.Size = new System.Drawing.Size(75, 23);
            this.btnLoadCharacter.TabIndex = 1;
            this.btnLoadCharacter.Text = "Load";
            this.btnLoadCharacter.UseVisualStyleBackColor = false;
            this.btnLoadCharacter.Click += new System.EventHandler(this.btnLoadCharacter_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Font = new System.Drawing.Font("Baskerville Old Face", 11F);
            this.lblWelcome.Location = new System.Drawing.Point(3, 53);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(488, 22);
            this.lblWelcome.TabIndex = 2;
            this.lblWelcome.Text = "Would you like to load a character, or create a new character?";
            // 
            // LandingPage
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(510, 210);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnLoadCharacter);
            this.Controls.Add(this.btnNewCharacter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LandingPage";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.LandingPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNewCharacter;
        private System.Windows.Forms.Button btnLoadCharacter;
        private System.Windows.Forms.Label lblWelcome;
    }
}

