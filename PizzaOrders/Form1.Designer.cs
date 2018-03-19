namespace PizzaOrders
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
            this.almPizzaCheckBox1 = new System.Windows.Forms.CheckBox();
            this.RejerTunAntalLabel = new System.Windows.Forms.Label();
            this.almPizzaTextbox1 = new System.Windows.Forms.TextBox();
            this.almPizzaCheckBox2 = new System.Windows.Forms.CheckBox();
            this.familyPizzaCheckBox1 = new System.Windows.Forms.CheckBox();
            this.familyPizzaCheckBox2 = new System.Windows.Forms.CheckBox();
            this.familyPizzaTextbox1 = new System.Windows.Forms.TextBox();
            this.almPizzaTextbox2 = new System.Windows.Forms.TextBox();
            this.familyPizzaTextbox2 = new System.Windows.Forms.TextBox();
            this.rejerMedTunGroupBox1 = new System.Windows.Forms.GroupBox();
            this.rejerMedTunGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // almPizzaCheckBox1
            // 
            this.almPizzaCheckBox1.AutoSize = true;
            this.almPizzaCheckBox1.Location = new System.Drawing.Point(9, 22);
            this.almPizzaCheckBox1.Name = "almPizzaCheckBox1";
            this.almPizzaCheckBox1.Size = new System.Drawing.Size(73, 17);
            this.almPizzaCheckBox1.TabIndex = 0;
            this.almPizzaCheckBox1.Text = "Almindelig";
            this.almPizzaCheckBox1.UseVisualStyleBackColor = true;
            this.almPizzaCheckBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // RejerTunAntalLabel
            // 
            this.RejerTunAntalLabel.AutoSize = true;
            this.RejerTunAntalLabel.Location = new System.Drawing.Point(138, 22);
            this.RejerTunAntalLabel.Name = "RejerTunAntalLabel";
            this.RejerTunAntalLabel.Size = new System.Drawing.Size(34, 13);
            this.RejerTunAntalLabel.TabIndex = 1;
            this.RejerTunAntalLabel.Text = "Antal:";
            // 
            // almPizzaTextbox1
            // 
            this.almPizzaTextbox1.Enabled = false;
            this.almPizzaTextbox1.Location = new System.Drawing.Point(201, 19);
            this.almPizzaTextbox1.Name = "almPizzaTextbox1";
            this.almPizzaTextbox1.Size = new System.Drawing.Size(34, 20);
            this.almPizzaTextbox1.TabIndex = 2;
            // 
            // almPizzaCheckBox2
            // 
            this.almPizzaCheckBox2.AutoSize = true;
            this.almPizzaCheckBox2.Location = new System.Drawing.Point(69, 217);
            this.almPizzaCheckBox2.Name = "almPizzaCheckBox2";
            this.almPizzaCheckBox2.Size = new System.Drawing.Size(73, 17);
            this.almPizzaCheckBox2.TabIndex = 3;
            this.almPizzaCheckBox2.Text = "Almindelig";
            this.almPizzaCheckBox2.UseVisualStyleBackColor = true;
            // 
            // familyPizzaCheckBox1
            // 
            this.familyPizzaCheckBox1.AutoSize = true;
            this.familyPizzaCheckBox1.Location = new System.Drawing.Point(9, 45);
            this.familyPizzaCheckBox1.Name = "familyPizzaCheckBox1";
            this.familyPizzaCheckBox1.Size = new System.Drawing.Size(55, 17);
            this.familyPizzaCheckBox1.TabIndex = 4;
            this.familyPizzaCheckBox1.Text = "Family";
            this.familyPizzaCheckBox1.UseVisualStyleBackColor = true;
            // 
            // familyPizzaCheckBox2
            // 
            this.familyPizzaCheckBox2.AutoSize = true;
            this.familyPizzaCheckBox2.Location = new System.Drawing.Point(69, 241);
            this.familyPizzaCheckBox2.Name = "familyPizzaCheckBox2";
            this.familyPizzaCheckBox2.Size = new System.Drawing.Size(80, 17);
            this.familyPizzaCheckBox2.TabIndex = 5;
            this.familyPizzaCheckBox2.Text = "checkBox1";
            this.familyPizzaCheckBox2.UseVisualStyleBackColor = true;
            // 
            // familyPizzaTextbox1
            // 
            this.familyPizzaTextbox1.Location = new System.Drawing.Point(201, 45);
            this.familyPizzaTextbox1.Name = "familyPizzaTextbox1";
            this.familyPizzaTextbox1.Size = new System.Drawing.Size(34, 20);
            this.familyPizzaTextbox1.TabIndex = 6;
            // 
            // almPizzaTextbox2
            // 
            this.almPizzaTextbox2.Location = new System.Drawing.Point(243, 214);
            this.almPizzaTextbox2.Name = "almPizzaTextbox2";
            this.almPizzaTextbox2.Size = new System.Drawing.Size(34, 20);
            this.almPizzaTextbox2.TabIndex = 7;
            // 
            // familyPizzaTextbox2
            // 
            this.familyPizzaTextbox2.Location = new System.Drawing.Point(243, 238);
            this.familyPizzaTextbox2.Name = "familyPizzaTextbox2";
            this.familyPizzaTextbox2.Size = new System.Drawing.Size(34, 20);
            this.familyPizzaTextbox2.TabIndex = 8;
            // 
            // rejerMedTunGroupBox1
            // 
            this.rejerMedTunGroupBox1.Controls.Add(this.familyPizzaTextbox1);
            this.rejerMedTunGroupBox1.Controls.Add(this.almPizzaTextbox1);
            this.rejerMedTunGroupBox1.Controls.Add(this.RejerTunAntalLabel);
            this.rejerMedTunGroupBox1.Controls.Add(this.almPizzaCheckBox1);
            this.rejerMedTunGroupBox1.Controls.Add(this.familyPizzaCheckBox1);
            this.rejerMedTunGroupBox1.Location = new System.Drawing.Point(69, 70);
            this.rejerMedTunGroupBox1.Name = "rejerMedTunGroupBox1";
            this.rejerMedTunGroupBox1.Size = new System.Drawing.Size(263, 100);
            this.rejerMedTunGroupBox1.TabIndex = 9;
            this.rejerMedTunGroupBox1.TabStop = false;
            this.rejerMedTunGroupBox1.Text = "Rejer med Tun     64 kr.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 492);
            this.Controls.Add(this.rejerMedTunGroupBox1);
            this.Controls.Add(this.familyPizzaTextbox2);
            this.Controls.Add(this.almPizzaTextbox2);
            this.Controls.Add(this.familyPizzaCheckBox2);
            this.Controls.Add(this.almPizzaCheckBox2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.rejerMedTunGroupBox1.ResumeLayout(false);
            this.rejerMedTunGroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox almPizzaCheckBox1;
        private System.Windows.Forms.Label RejerTunAntalLabel;
        private System.Windows.Forms.TextBox almPizzaTextbox1;
        private System.Windows.Forms.CheckBox almPizzaCheckBox2;
        private System.Windows.Forms.CheckBox familyPizzaCheckBox1;
        private System.Windows.Forms.CheckBox familyPizzaCheckBox2;
        private System.Windows.Forms.TextBox familyPizzaTextbox1;
        private System.Windows.Forms.TextBox almPizzaTextbox2;
        private System.Windows.Forms.TextBox familyPizzaTextbox2;
        private System.Windows.Forms.GroupBox rejerMedTunGroupBox1;
    }
}

