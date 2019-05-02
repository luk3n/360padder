namespace _360padder
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.batteryMeter = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_Vibrate = new Controls.BlueButton();
            this.btn_Disable = new Controls.BlueButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.batteryMeter);
            this.panel1.ForeColor = System.Drawing.Color.Maroon;
            this.panel1.Location = new System.Drawing.Point(17, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(306, 7);
            this.panel1.TabIndex = 8;
            // 
            // batteryMeter
            // 
            this.batteryMeter.BackColor = System.Drawing.Color.Green;
            this.batteryMeter.Location = new System.Drawing.Point(2, 1);
            this.batteryMeter.Name = "batteryMeter";
            this.batteryMeter.Size = new System.Drawing.Size(300, 3);
            this.batteryMeter.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.YellowGreen;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "XBOX CONTROLLER";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.YellowGreen;
            this.panel2.Location = new System.Drawing.Point(12, 286);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2, 20);
            this.panel2.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.YellowGreen;
            this.label2.Location = new System.Drawing.Point(20, 286);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 12;
            this.label2.Text = "EVENT LOG";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.DarkGray;
            this.textBox1.Location = new System.Drawing.Point(12, 312);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(681, 140);
            this.textBox1.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.YellowGreen;
            this.panel3.Location = new System.Drawing.Point(18, 51);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(500, 2);
            this.panel3.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.YellowGreen;
            this.label3.Location = new System.Drawing.Point(333, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 14);
            this.label3.TabIndex = 17;
            this.label3.Text = "BATTERY";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.YellowGreen;
            this.panel4.Location = new System.Drawing.Point(392, 65);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(2, 15);
            this.panel4.TabIndex = 16;
            // 
            // btn_Vibrate
            // 
            this.btn_Vibrate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Vibrate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(66)))), ((int)(((byte)(86)))));
            this.btn_Vibrate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(52)))), ((int)(((byte)(47)))));
            this.btn_Vibrate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(78)))), ((int)(((byte)(100)))));
            this.btn_Vibrate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Vibrate.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Vibrate.ForeColor = System.Drawing.Color.White;
            this.btn_Vibrate.Location = new System.Drawing.Point(17, 138);
            this.btn_Vibrate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btn_Vibrate.MinimumSize = new System.Drawing.Size(100, 30);
            this.btn_Vibrate.Name = "btn_Vibrate";
            this.btn_Vibrate.Padding = new System.Windows.Forms.Padding(3);
            this.btn_Vibrate.Size = new System.Drawing.Size(233, 30);
            this.btn_Vibrate.TabIndex = 18;
            this.btn_Vibrate.Text = "VIBRATE";
            this.btn_Vibrate.UseVisualStyleBackColor = false;
            this.btn_Vibrate.Click += new System.EventHandler(this.btn_Vibrate_Click);
            // 
            // btn_Disable
            // 
            this.btn_Disable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Disable.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(66)))), ((int)(((byte)(86)))));
            this.btn_Disable.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(52)))), ((int)(((byte)(47)))));
            this.btn_Disable.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(78)))), ((int)(((byte)(100)))));
            this.btn_Disable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Disable.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Disable.ForeColor = System.Drawing.Color.White;
            this.btn_Disable.Location = new System.Drawing.Point(17, 99);
            this.btn_Disable.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btn_Disable.MinimumSize = new System.Drawing.Size(100, 30);
            this.btn_Disable.Name = "btn_Disable";
            this.btn_Disable.Padding = new System.Windows.Forms.Padding(3);
            this.btn_Disable.Size = new System.Drawing.Size(233, 30);
            this.btn_Disable.TabIndex = 15;
            this.btn_Disable.Text = "DISABLE/ENABLE CONTROLLER";
            this.btn_Disable.UseVisualStyleBackColor = false;
            this.btn_Disable.Click += new System.EventHandler(this.btn_Disable_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(707, 468);
            this.Controls.Add(this.btn_Vibrate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btn_Disable);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "360padder";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel batteryMeter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel3;
        private Controls.BlueButton btn_Disable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private Controls.BlueButton btn_Vibrate;
    }
}

