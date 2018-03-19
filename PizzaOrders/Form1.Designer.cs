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
            this.rejerMedTunGroupBox = new System.Windows.Forms.GroupBox();
            this.beregnButton1 = new System.Windows.Forms.Button();
            this.pepperoniGroupBox = new System.Windows.Forms.GroupBox();
            this.PepperoniAntalLabel = new System.Windows.Forms.Label();
            this.rejerMedTunGroupBox.SuspendLayout();
            this.pepperoniGroupBox.SuspendLayout();
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
            this.almPizzaCheckBox1.CheckedChanged += new System.EventHandler(this.AlmPizzaCheckBox1_CheckedChanged);
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
            this.almPizzaCheckBox2.Location = new System.Drawing.Point(9, 19);
            this.almPizzaCheckBox2.Name = "almPizzaCheckBox2";
            this.almPizzaCheckBox2.Size = new System.Drawing.Size(73, 17);
            this.almPizzaCheckBox2.TabIndex = 3;
            this.almPizzaCheckBox2.Text = "Almindelig";
            this.almPizzaCheckBox2.UseVisualStyleBackColor = true;
            this.almPizzaCheckBox2.CheckedChanged += new System.EventHandler(this.almPizzaCheckBox2_CheckedChanged);
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
            this.familyPizzaCheckBox1.CheckedChanged += new System.EventHandler(this.familyPizzaCheckBox1_CheckedChanged);
            // 
            // familyPizzaCheckBox2
            // 
            this.familyPizzaCheckBox2.AutoSize = true;
            this.familyPizzaCheckBox2.Location = new System.Drawing.Point(9, 42);
            this.familyPizzaCheckBox2.Name = "familyPizzaCheckBox2";
            this.familyPizzaCheckBox2.Size = new System.Drawing.Size(80, 17);
            this.familyPizzaCheckBox2.TabIndex = 5;
            this.familyPizzaCheckBox2.Text = "checkBox1";
            this.familyPizzaCheckBox2.UseVisualStyleBackColor = true;
            this.familyPizzaCheckBox2.CheckedChanged += new System.EventHandler(this.familyPizzaCheckBox2_CheckedChanged);
            // 
            // familyPizzaTextbox1
            // 
            this.familyPizzaTextbox1.Enabled = false;
            this.familyPizzaTextbox1.Location = new System.Drawing.Point(201, 45);
            this.familyPizzaTextbox1.Name = "familyPizzaTextbox1";
            this.familyPizzaTextbox1.Size = new System.Drawing.Size(34, 20);
            this.familyPizzaTextbox1.TabIndex = 6;
            // 
            // almPizzaTextbox2
            // 
            this.almPizzaTextbox2.Enabled = false;
            this.almPizzaTextbox2.Location = new System.Drawing.Point(201, 16);
            this.almPizzaTextbox2.Name = "almPizzaTextbox2";
            this.almPizzaTextbox2.Size = new System.Drawing.Size(34, 20);
            this.almPizzaTextbox2.TabIndex = 7;
            // 
            // familyPizzaTextbox2
            // 
            this.familyPizzaTextbox2.Enabled = false;
            this.familyPizzaTextbox2.Location = new System.Drawing.Point(201, 42);
            this.familyPizzaTextbox2.Name = "familyPizzaTextbox2";
            this.familyPizzaTextbox2.Size = new System.Drawing.Size(34, 20);
            this.familyPizzaTextbox2.TabIndex = 8;
            // 
            // rejerMedTunGroupBox
            // 
            this.rejerMedTunGroupBox.Controls.Add(this.familyPizzaTextbox1);
            this.rejerMedTunGroupBox.Controls.Add(this.almPizzaTextbox1);
            this.rejerMedTunGroupBox.Controls.Add(this.RejerTunAntalLabel);
            this.rejerMedTunGroupBox.Controls.Add(this.almPizzaCheckBox1);
            this.rejerMedTunGroupBox.Controls.Add(this.familyPizzaCheckBox1);
            this.rejerMedTunGroupBox.Location = new System.Drawing.Point(69, 70);
            this.rejerMedTunGroupBox.Name = "rejerMedTunGroupBox";
            this.rejerMedTunGroupBox.Size = new System.Drawing.Size(263, 95);
            this.rejerMedTunGroupBox.TabIndex = 9;
            this.rejerMedTunGroupBox.TabStop = false;
            this.rejerMedTunGroupBox.Text = "Rejer med Tun     64 kr.";
            // 
            // beregnButton1
            // 
            this.beregnButton1.Location = new System.Drawing.Point(475, 352);
            this.beregnButton1.Name = "beregnButton1";
            this.beregnButton1.Size = new System.Drawing.Size(75, 23);
            this.beregnButton1.TabIndex = 10;
            this.beregnButton1.Text = "Beregn";
            this.beregnButton1.UseVisualStyleBackColor = true;
            this.beregnButton1.Click += new System.EventHandler(this.BeregnButton1_Click);
            // 
            // pepperoniGroupBox
            // 
            this.pepperoniGroupBox.Controls.Add(this.PepperoniAntalLabel);
            this.pepperoniGroupBox.Controls.Add(this.almPizzaCheckBox2);
            this.pepperoniGroupBox.Controls.Add(this.familyPizzaCheckBox2);
            this.pepperoniGroupBox.Controls.Add(this.familyPizzaTextbox2);
            this.pepperoniGroupBox.Controls.Add(this.almPizzaTextbox2);
            this.pepperoniGroupBox.Location = new System.Drawing.Point(69, 200);
            this.pepperoniGroupBox.Name = "pepperoniGroupBox";
            this.pepperoniGroupBox.Size = new System.Drawing.Size(263, 90);
            this.pepperoniGroupBox.TabIndex = 11;
            this.pepperoniGroupBox.TabStop = false;
            this.pepperoniGroupBox.Text = "Pepperoni    59 kr.";
            // 
            // PepperoniAntalLabel
            // 
            this.PepperoniAntalLabel.AutoSize = true;
            this.PepperoniAntalLabel.Location = new System.Drawing.Point(141, 16);
            this.PepperoniAntalLabel.Name = "PepperoniAntalLabel";
            this.PepperoniAntalLabel.Size = new System.Drawing.Size(34, 13);
            this.PepperoniAntalLabel.TabIndex = 9;
            this.PepperoniAntalLabel.Text = "Antal:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 492);
            this.Controls.Add(this.pepperoniGroupBox);
            this.Controls.Add(this.beregnButton1);
            this.Controls.Add(this.rejerMedTunGroupBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.rejerMedTunGroupBox.ResumeLayout(false);
            this.rejerMedTunGroupBox.PerformLayout();
            this.pepperoniGroupBox.ResumeLayout(false);
            this.pepperoniGroupBox.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.GroupBox rejerMedTunGroupBox;
        private System.Windows.Forms.Button beregnButton1;
        private System.Windows.Forms.GroupBox pepperoniGroupBox;
        private System.Windows.Forms.Label PepperoniAntalLabel;
    }
}

