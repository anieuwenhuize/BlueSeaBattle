namespace BlueSeaBattle
{
    partial class Form1
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
            this.Gridpanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTotalShips = new System.Windows.Forms.Label();
            this.labelSunkShips = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Gridpanel
            // 
            this.Gridpanel.Location = new System.Drawing.Point(15, 8);
            this.Gridpanel.Name = "Gridpanel";
            this.Gridpanel.Size = new System.Drawing.Size(996, 532);
            this.Gridpanel.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1031, 280);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 63);
            this.button1.TabIndex = 2;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1028, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total ships";
            // 
            // labelTotalShips
            // 
            this.labelTotalShips.AutoSize = true;
            this.labelTotalShips.Location = new System.Drawing.Point(1094, 38);
            this.labelTotalShips.Name = "labelTotalShips";
            this.labelTotalShips.Size = new System.Drawing.Size(14, 13);
            this.labelTotalShips.TabIndex = 4;
            this.labelTotalShips.Text = "#";
            // 
            // labelSunkShips
            // 
            this.labelSunkShips.AutoSize = true;
            this.labelSunkShips.Location = new System.Drawing.Point(1094, 84);
            this.labelSunkShips.Name = "labelSunkShips";
            this.labelSunkShips.Size = new System.Drawing.Size(14, 13);
            this.labelSunkShips.TabIndex = 6;
            this.labelSunkShips.Text = "#";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1028, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sunk";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 589);
            this.Controls.Add(this.labelSunkShips);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelTotalShips);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Gridpanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Gridpanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTotalShips;
        private System.Windows.Forms.Label labelSunkShips;
        private System.Windows.Forms.Label label3;
    }
}

