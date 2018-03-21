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
            this.PIZZA1GroupBox1 = new System.Windows.Forms.GroupBox();
            this.beregnButton1 = new System.Windows.Forms.Button();
            this.PIZZA2GroupBox1 = new System.Windows.Forms.GroupBox();
            this.PepperoniAntalLabel = new System.Windows.Forms.Label();
            this.PIZZA1 = new System.Windows.Forms.Panel();
            this.PIZZA1SubLabel = new System.Windows.Forms.Label();
            this.rejerTunKaloriGroupBox = new System.Windows.Forms.GroupBox();
            this.rejerTunKaloriPrSkiveLabel = new System.Windows.Forms.Label();
            this.rejerTunKaloriLabel = new System.Windows.Forms.Label();
            this.rejerTunKaloriTextBox = new System.Windows.Forms.TextBox();
            this.PIZZA1GroupBox2 = new System.Windows.Forms.GroupBox();
            this.PIZZA1AddCheckBox3_tun = new System.Windows.Forms.CheckBox();
            this.PIZZA1AddCheckBox2_rejer = new System.Windows.Forms.CheckBox();
            this.PIZZA1AddCheckBox1_løg = new System.Windows.Forms.CheckBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.PIZZA2 = new System.Windows.Forms.Panel();
            this.PIZZA2SubLabel = new System.Windows.Forms.Label();
            this.PIZZA2GroupBox2 = new System.Windows.Forms.GroupBox();
            this.PIZZA2AddCheckBox3_ost = new System.Windows.Forms.CheckBox();
            this.PIZZA2AddCheckBox2_champignon = new System.Windows.Forms.CheckBox();
            this.PIZZA2AddCheckBox1_pepperoni = new System.Windows.Forms.CheckBox();
            this.pepperoniKaloriGropuBox = new System.Windows.Forms.GroupBox();
            this.pepperoniKaloriPrSkiveLabel = new System.Windows.Forms.Label();
            this.pepperoniKaloriLabel = new System.Windows.Forms.Label();
            this.pepperoniKaloriTextBox = new System.Windows.Forms.TextBox();
            this.bestilButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.totalLabel = new System.Windows.Forms.Label();
            this.bestillingsNummerLabel = new System.Windows.Forms.Label();
            this.forventetLabel = new System.Windows.Forms.Label();
            this.PIZZA1GroupBox1.SuspendLayout();
            this.PIZZA2GroupBox1.SuspendLayout();
            this.PIZZA1.SuspendLayout();
            this.rejerTunKaloriGroupBox.SuspendLayout();
            this.PIZZA1GroupBox2.SuspendLayout();
            this.PIZZA2.SuspendLayout();
            this.PIZZA2GroupBox2.SuspendLayout();
            this.pepperoniKaloriGropuBox.SuspendLayout();
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
            this.almPizzaCheckBox1.CheckedChanged += new System.EventHandler(this.pizzaCheckBoxGlobal_CheckedChanged);
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
            this.almPizzaCheckBox2.CheckedChanged += new System.EventHandler(this.pizzaCheckBoxGlobal_CheckedChanged);
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
            this.familyPizzaCheckBox1.CheckedChanged += new System.EventHandler(this.pizzaCheckBoxGlobal_CheckedChanged);
            // 
            // familyPizzaCheckBox2
            // 
            this.familyPizzaCheckBox2.AutoSize = true;
            this.familyPizzaCheckBox2.Location = new System.Drawing.Point(9, 42);
            this.familyPizzaCheckBox2.Name = "familyPizzaCheckBox2";
            this.familyPizzaCheckBox2.Size = new System.Drawing.Size(55, 17);
            this.familyPizzaCheckBox2.TabIndex = 5;
            this.familyPizzaCheckBox2.Text = "Family";
            this.familyPizzaCheckBox2.UseVisualStyleBackColor = true;
            this.familyPizzaCheckBox2.CheckedChanged += new System.EventHandler(this.pizzaCheckBoxGlobal_CheckedChanged);
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
            // PIZZA1GroupBox1
            // 
            this.PIZZA1GroupBox1.Controls.Add(this.familyPizzaTextbox1);
            this.PIZZA1GroupBox1.Controls.Add(this.almPizzaTextbox1);
            this.PIZZA1GroupBox1.Controls.Add(this.RejerTunAntalLabel);
            this.PIZZA1GroupBox1.Controls.Add(this.almPizzaCheckBox1);
            this.PIZZA1GroupBox1.Controls.Add(this.familyPizzaCheckBox1);
            this.PIZZA1GroupBox1.Location = new System.Drawing.Point(14, 16);
            this.PIZZA1GroupBox1.Name = "PIZZA1GroupBox1";
            this.PIZZA1GroupBox1.Size = new System.Drawing.Size(263, 95);
            this.PIZZA1GroupBox1.TabIndex = 9;
            this.PIZZA1GroupBox1.TabStop = false;
            this.PIZZA1GroupBox1.Text = "Rejer med Tun     64 kr.";
            // 
            // beregnButton1
            // 
            this.beregnButton1.Location = new System.Drawing.Point(487, 390);
            this.beregnButton1.Name = "beregnButton1";
            this.beregnButton1.Size = new System.Drawing.Size(75, 23);
            this.beregnButton1.TabIndex = 10;
            this.beregnButton1.Text = "Beregn";
            this.beregnButton1.UseVisualStyleBackColor = true;
            this.beregnButton1.Click += new System.EventHandler(this.BeregnButton1_Click);
            // 
            // PIZZA2GroupBox1
            // 
            this.PIZZA2GroupBox1.Controls.Add(this.PepperoniAntalLabel);
            this.PIZZA2GroupBox1.Controls.Add(this.almPizzaCheckBox2);
            this.PIZZA2GroupBox1.Controls.Add(this.familyPizzaCheckBox2);
            this.PIZZA2GroupBox1.Controls.Add(this.familyPizzaTextbox2);
            this.PIZZA2GroupBox1.Controls.Add(this.almPizzaTextbox2);
            this.PIZZA2GroupBox1.Location = new System.Drawing.Point(14, 16);
            this.PIZZA2GroupBox1.Name = "PIZZA2GroupBox1";
            this.PIZZA2GroupBox1.Size = new System.Drawing.Size(263, 94);
            this.PIZZA2GroupBox1.TabIndex = 11;
            this.PIZZA2GroupBox1.TabStop = false;
            this.PIZZA2GroupBox1.Text = "Pepperoni    59 kr.";
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
            // PIZZA1
            // 
            this.PIZZA1.Controls.Add(this.PIZZA1SubLabel);
            this.PIZZA1.Controls.Add(this.rejerTunKaloriGroupBox);
            this.PIZZA1.Controls.Add(this.PIZZA1GroupBox2);
            this.PIZZA1.Controls.Add(this.PIZZA1GroupBox1);
            this.PIZZA1.Location = new System.Drawing.Point(60, 60);
            this.PIZZA1.Name = "PIZZA1";
            this.PIZZA1.Size = new System.Drawing.Size(744, 128);
            this.PIZZA1.TabIndex = 12;
            // 
            // PIZZA1SubLabel
            // 
            this.PIZZA1SubLabel.AutoSize = true;
            this.PIZZA1SubLabel.Location = new System.Drawing.Point(532, 97);
            this.PIZZA1SubLabel.Name = "PIZZA1SubLabel";
            this.PIZZA1SubLabel.Size = new System.Drawing.Size(52, 13);
            this.PIZZA1SubLabel.TabIndex = 12;
            this.PIZZA1SubLabel.Text = "Sub total:";
            // 
            // rejerTunKaloriGroupBox
            // 
            this.rejerTunKaloriGroupBox.Controls.Add(this.rejerTunKaloriPrSkiveLabel);
            this.rejerTunKaloriGroupBox.Controls.Add(this.rejerTunKaloriLabel);
            this.rejerTunKaloriGroupBox.Controls.Add(this.rejerTunKaloriTextBox);
            this.rejerTunKaloriGroupBox.Location = new System.Drawing.Point(532, 16);
            this.rejerTunKaloriGroupBox.Name = "rejerTunKaloriGroupBox";
            this.rejerTunKaloriGroupBox.Size = new System.Drawing.Size(200, 62);
            this.rejerTunKaloriGroupBox.TabIndex = 11;
            this.rejerTunKaloriGroupBox.TabStop = false;
            this.rejerTunKaloriGroupBox.Text = "Kalori";
            // 
            // rejerTunKaloriPrSkiveLabel
            // 
            this.rejerTunKaloriPrSkiveLabel.AutoSize = true;
            this.rejerTunKaloriPrSkiveLabel.Location = new System.Drawing.Point(20, 38);
            this.rejerTunKaloriPrSkiveLabel.Name = "rejerTunKaloriPrSkiveLabel";
            this.rejerTunKaloriPrSkiveLabel.Size = new System.Drawing.Size(85, 13);
            this.rejerTunKaloriPrSkiveLabel.TabIndex = 2;
            this.rejerTunKaloriPrSkiveLabel.Text = "Kalori pr. skive =";
            // 
            // rejerTunKaloriLabel
            // 
            this.rejerTunKaloriLabel.AutoSize = true;
            this.rejerTunKaloriLabel.Location = new System.Drawing.Point(17, 21);
            this.rejerTunKaloriLabel.Name = "rejerTunKaloriLabel";
            this.rejerTunKaloriLabel.Size = new System.Drawing.Size(72, 13);
            this.rejerTunKaloriLabel.TabIndex = 1;
            this.rejerTunKaloriLabel.Text = "Skær i skiver:";
            // 
            // rejerTunKaloriTextBox
            // 
            this.rejerTunKaloriTextBox.Location = new System.Drawing.Point(107, 19);
            this.rejerTunKaloriTextBox.Name = "rejerTunKaloriTextBox";
            this.rejerTunKaloriTextBox.Size = new System.Drawing.Size(40, 20);
            this.rejerTunKaloriTextBox.TabIndex = 0;
            // 
            // PIZZA1GroupBox2
            // 
            this.PIZZA1GroupBox2.Controls.Add(this.PIZZA1AddCheckBox3_tun);
            this.PIZZA1GroupBox2.Controls.Add(this.PIZZA1AddCheckBox2_rejer);
            this.PIZZA1GroupBox2.Controls.Add(this.PIZZA1AddCheckBox1_løg);
            this.PIZZA1GroupBox2.Location = new System.Drawing.Point(302, 16);
            this.PIZZA1GroupBox2.Name = "PIZZA1GroupBox2";
            this.PIZZA1GroupBox2.Size = new System.Drawing.Size(200, 95);
            this.PIZZA1GroupBox2.TabIndex = 10;
            this.PIZZA1GroupBox2.TabStop = false;
            this.PIZZA1GroupBox2.Text = "Ekstras";
            // 
            // PIZZA1AddCheckBox3_tun
            // 
            this.PIZZA1AddCheckBox3_tun.AutoSize = true;
            this.PIZZA1AddCheckBox3_tun.Location = new System.Drawing.Point(7, 68);
            this.PIZZA1AddCheckBox3_tun.Name = "PIZZA1AddCheckBox3_tun";
            this.PIZZA1AddCheckBox3_tun.Size = new System.Drawing.Size(114, 17);
            this.PIZZA1AddCheckBox3_tun.TabIndex = 2;
            this.PIZZA1AddCheckBox3_tun.Text = "Tun                7 kr.";
            this.PIZZA1AddCheckBox3_tun.UseVisualStyleBackColor = true;
            // 
            // PIZZA1AddCheckBox2_rejer
            // 
            this.PIZZA1AddCheckBox2_rejer.AutoSize = true;
            this.PIZZA1AddCheckBox2_rejer.Location = new System.Drawing.Point(7, 45);
            this.PIZZA1AddCheckBox2_rejer.Name = "PIZZA1AddCheckBox2_rejer";
            this.PIZZA1AddCheckBox2_rejer.Size = new System.Drawing.Size(114, 17);
            this.PIZZA1AddCheckBox2_rejer.TabIndex = 1;
            this.PIZZA1AddCheckBox2_rejer.Text = "Rejer            10 kr.";
            this.PIZZA1AddCheckBox2_rejer.UseVisualStyleBackColor = true;
            // 
            // PIZZA1AddCheckBox1_løg
            // 
            this.PIZZA1AddCheckBox1_løg.AutoSize = true;
            this.PIZZA1AddCheckBox1_løg.Location = new System.Drawing.Point(7, 22);
            this.PIZZA1AddCheckBox1_løg.Name = "PIZZA1AddCheckBox1_løg";
            this.PIZZA1AddCheckBox1_løg.Size = new System.Drawing.Size(113, 17);
            this.PIZZA1AddCheckBox1_løg.TabIndex = 0;
            this.PIZZA1AddCheckBox1_løg.Text = "Løg                5 kr.";
            this.PIZZA1AddCheckBox1_løg.UseVisualStyleBackColor = true;
            // 
            // PIZZA2
            // 
            this.PIZZA2.Controls.Add(this.PIZZA2SubLabel);
            this.PIZZA2.Controls.Add(this.PIZZA2GroupBox2);
            this.PIZZA2.Controls.Add(this.pepperoniKaloriGropuBox);
            this.PIZZA2.Controls.Add(this.PIZZA2GroupBox1);
            this.PIZZA2.Location = new System.Drawing.Point(60, 218);
            this.PIZZA2.Name = "PIZZA2";
            this.PIZZA2.Size = new System.Drawing.Size(744, 133);
            this.PIZZA2.TabIndex = 10;
            // 
            // PIZZA2SubLabel
            // 
            this.PIZZA2SubLabel.AutoSize = true;
            this.PIZZA2SubLabel.Location = new System.Drawing.Point(532, 97);
            this.PIZZA2SubLabel.Name = "PIZZA2SubLabel";
            this.PIZZA2SubLabel.Size = new System.Drawing.Size(49, 13);
            this.PIZZA2SubLabel.TabIndex = 14;
            this.PIZZA2SubLabel.Text = "Sub total";
            // 
            // PIZZA2GroupBox2
            // 
            this.PIZZA2GroupBox2.Controls.Add(this.PIZZA2AddCheckBox3_ost);
            this.PIZZA2GroupBox2.Controls.Add(this.PIZZA2AddCheckBox2_champignon);
            this.PIZZA2GroupBox2.Controls.Add(this.PIZZA2AddCheckBox1_pepperoni);
            this.PIZZA2GroupBox2.Location = new System.Drawing.Point(302, 16);
            this.PIZZA2GroupBox2.Name = "PIZZA2GroupBox2";
            this.PIZZA2GroupBox2.Size = new System.Drawing.Size(200, 94);
            this.PIZZA2GroupBox2.TabIndex = 12;
            this.PIZZA2GroupBox2.TabStop = false;
            this.PIZZA2GroupBox2.Text = "Ekstras";
            // 
            // PIZZA2AddCheckBox3_ost
            // 
            this.PIZZA2AddCheckBox3_ost.AutoSize = true;
            this.PIZZA2AddCheckBox3_ost.Location = new System.Drawing.Point(7, 61);
            this.PIZZA2AddCheckBox3_ost.Name = "PIZZA2AddCheckBox3_ost";
            this.PIZZA2AddCheckBox3_ost.Size = new System.Drawing.Size(117, 17);
            this.PIZZA2AddCheckBox3_ost.TabIndex = 2;
            this.PIZZA2AddCheckBox3_ost.Text = "Ost                  6 kr.";
            this.PIZZA2AddCheckBox3_ost.UseVisualStyleBackColor = true;
            // 
            // PIZZA2AddCheckBox2_champignon
            // 
            this.PIZZA2AddCheckBox2_champignon.AutoSize = true;
            this.PIZZA2AddCheckBox2_champignon.Location = new System.Drawing.Point(7, 38);
            this.PIZZA2AddCheckBox2_champignon.Name = "PIZZA2AddCheckBox2_champignon";
            this.PIZZA2AddCheckBox2_champignon.Size = new System.Drawing.Size(118, 17);
            this.PIZZA2AddCheckBox2_champignon.TabIndex = 1;
            this.PIZZA2AddCheckBox2_champignon.Text = "Champignon  11 kr.";
            this.PIZZA2AddCheckBox2_champignon.UseVisualStyleBackColor = true;
            // 
            // PIZZA2AddCheckBox1_pepperoni
            // 
            this.PIZZA2AddCheckBox1_pepperoni.AutoSize = true;
            this.PIZZA2AddCheckBox1_pepperoni.Location = new System.Drawing.Point(7, 17);
            this.PIZZA2AddCheckBox1_pepperoni.Name = "PIZZA2AddCheckBox1_pepperoni";
            this.PIZZA2AddCheckBox1_pepperoni.Size = new System.Drawing.Size(119, 17);
            this.PIZZA2AddCheckBox1_pepperoni.TabIndex = 0;
            this.PIZZA2AddCheckBox1_pepperoni.Text = "Pepperoni        8 kr.";
            this.PIZZA2AddCheckBox1_pepperoni.UseVisualStyleBackColor = true;
            // 
            // pepperoniKaloriGropuBox
            // 
            this.pepperoniKaloriGropuBox.Controls.Add(this.pepperoniKaloriPrSkiveLabel);
            this.pepperoniKaloriGropuBox.Controls.Add(this.pepperoniKaloriLabel);
            this.pepperoniKaloriGropuBox.Controls.Add(this.pepperoniKaloriTextBox);
            this.pepperoniKaloriGropuBox.Location = new System.Drawing.Point(532, 16);
            this.pepperoniKaloriGropuBox.Name = "pepperoniKaloriGropuBox";
            this.pepperoniKaloriGropuBox.Size = new System.Drawing.Size(200, 62);
            this.pepperoniKaloriGropuBox.TabIndex = 13;
            this.pepperoniKaloriGropuBox.TabStop = false;
            this.pepperoniKaloriGropuBox.Text = "Kalori";
            // 
            // pepperoniKaloriPrSkiveLabel
            // 
            this.pepperoniKaloriPrSkiveLabel.AutoSize = true;
            this.pepperoniKaloriPrSkiveLabel.Location = new System.Drawing.Point(20, 38);
            this.pepperoniKaloriPrSkiveLabel.Name = "pepperoniKaloriPrSkiveLabel";
            this.pepperoniKaloriPrSkiveLabel.Size = new System.Drawing.Size(85, 13);
            this.pepperoniKaloriPrSkiveLabel.TabIndex = 2;
            this.pepperoniKaloriPrSkiveLabel.Text = "Kalori pr. skive =";
            // 
            // pepperoniKaloriLabel
            // 
            this.pepperoniKaloriLabel.AutoSize = true;
            this.pepperoniKaloriLabel.Location = new System.Drawing.Point(17, 21);
            this.pepperoniKaloriLabel.Name = "pepperoniKaloriLabel";
            this.pepperoniKaloriLabel.Size = new System.Drawing.Size(72, 13);
            this.pepperoniKaloriLabel.TabIndex = 1;
            this.pepperoniKaloriLabel.Text = "Skær i skiver:";
            // 
            // pepperoniKaloriTextBox
            // 
            this.pepperoniKaloriTextBox.Location = new System.Drawing.Point(107, 19);
            this.pepperoniKaloriTextBox.Name = "pepperoniKaloriTextBox";
            this.pepperoniKaloriTextBox.Size = new System.Drawing.Size(40, 20);
            this.pepperoniKaloriTextBox.TabIndex = 0;
            // 
            // bestilButton
            // 
            this.bestilButton.Enabled = false;
            this.bestilButton.Location = new System.Drawing.Point(60, 460);
            this.bestilButton.Name = "bestilButton";
            this.bestilButton.Size = new System.Drawing.Size(75, 23);
            this.bestilButton.TabIndex = 13;
            this.bestilButton.Text = "Bestil";
            this.bestilButton.UseVisualStyleBackColor = true;
            this.bestilButton.Click += new System.EventHandler(this.bestilButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(156, 460);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 14;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Location = new System.Drawing.Point(612, 395);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(34, 13);
            this.totalLabel.TabIndex = 15;
            this.totalLabel.Text = "Total:";
            // 
            // bestillingsNummerLabel
            // 
            this.bestillingsNummerLabel.AutoSize = true;
            this.bestillingsNummerLabel.Location = new System.Drawing.Point(484, 460);
            this.bestillingsNummerLabel.Name = "bestillingsNummerLabel";
            this.bestillingsNummerLabel.Size = new System.Drawing.Size(108, 13);
            this.bestillingsNummerLabel.TabIndex = 16;
            this.bestillingsNummerLabel.Text = "Dit bestillingsnummer:";
            // 
            // forventetLabel
            // 
            this.forventetLabel.AutoSize = true;
            this.forventetLabel.Location = new System.Drawing.Point(484, 492);
            this.forventetLabel.Name = "forventetLabel";
            this.forventetLabel.Size = new System.Drawing.Size(88, 13);
            this.forventetLabel.TabIndex = 17;
            this.forventetLabel.Text = "Forventet færdig:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 527);
            this.Controls.Add(this.forventetLabel);
            this.Controls.Add(this.bestillingsNummerLabel);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.bestilButton);
            this.Controls.Add(this.PIZZA2);
            this.Controls.Add(this.PIZZA1);
            this.Controls.Add(this.beregnButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.PIZZA1GroupBox1.ResumeLayout(false);
            this.PIZZA1GroupBox1.PerformLayout();
            this.PIZZA2GroupBox1.ResumeLayout(false);
            this.PIZZA2GroupBox1.PerformLayout();
            this.PIZZA1.ResumeLayout(false);
            this.PIZZA1.PerformLayout();
            this.rejerTunKaloriGroupBox.ResumeLayout(false);
            this.rejerTunKaloriGroupBox.PerformLayout();
            this.PIZZA1GroupBox2.ResumeLayout(false);
            this.PIZZA1GroupBox2.PerformLayout();
            this.PIZZA2.ResumeLayout(false);
            this.PIZZA2.PerformLayout();
            this.PIZZA2GroupBox2.ResumeLayout(false);
            this.PIZZA2GroupBox2.PerformLayout();
            this.pepperoniKaloriGropuBox.ResumeLayout(false);
            this.pepperoniKaloriGropuBox.PerformLayout();
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
        private System.Windows.Forms.Button beregnButton1;

     

        private System.Windows.Forms.Label PepperoniAntalLabel;
        private System.Windows.Forms.Panel PIZZA1;

        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Panel PIZZA2;

        private System.Windows.Forms.GroupBox PIZZA1GroupBox1;
        private System.Windows.Forms.GroupBox PIZZA1GroupBox2;
        private System.Windows.Forms.GroupBox rejerTunKaloriGroupBox;

        private System.Windows.Forms.GroupBox PIZZA2GroupBox1;     
        private System.Windows.Forms.GroupBox PIZZA2GroupBox2;
        private System.Windows.Forms.GroupBox pepperoniKaloriGropuBox;

        private System.Windows.Forms.Label PIZZA1SubLabel;     
        private System.Windows.Forms.Label rejerTunKaloriPrSkiveLabel;
        private System.Windows.Forms.Label rejerTunKaloriLabel;
        private System.Windows.Forms.TextBox rejerTunKaloriTextBox;


        private System.Windows.Forms.Label PIZZA2SubLabel;       
        private System.Windows.Forms.Label pepperoniKaloriPrSkiveLabel;
        private System.Windows.Forms.Label pepperoniKaloriLabel;
        private System.Windows.Forms.TextBox pepperoniKaloriTextBox;
        private System.Windows.Forms.Button bestilButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label bestillingsNummerLabel;
        private System.Windows.Forms.Label forventetLabel;
        private System.Windows.Forms.CheckBox PIZZA1AddCheckBox3_tun;
        private System.Windows.Forms.CheckBox PIZZA1AddCheckBox2_rejer;
        private System.Windows.Forms.CheckBox PIZZA1AddCheckBox1_løg;
        private System.Windows.Forms.CheckBox PIZZA2AddCheckBox3_ost;
        private System.Windows.Forms.CheckBox PIZZA2AddCheckBox2_champignon;
        private System.Windows.Forms.CheckBox PIZZA2AddCheckBox1_pepperoni;
    }
}

