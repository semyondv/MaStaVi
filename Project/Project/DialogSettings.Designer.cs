namespace Project
{
    partial class DialogSettings
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
            this.Drob = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Palitra = new System.Windows.Forms.CheckBox();
            this.Gradient = new System.Windows.Forms.CheckBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.AutoGenBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Drob
            // 
            this.Drob.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Drob.Location = new System.Drawing.Point(186, 20);
            this.Drob.MaxLength = 2;
            this.Drob.Name = "Drob";
            this.Drob.Size = new System.Drawing.Size(93, 23);
            this.Drob.TabIndex = 0;
            this.Drob.TabStop = false;
            this.Drob.Click += new System.EventHandler(this.Drob_Click);
            this.Drob.TextChanged += new System.EventHandler(this.Drob_TextChanged);
            this.Drob.Leave += new System.EventHandler(this.Drob_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Количество разделений\r\n         (не более 20)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(12, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Тип легенды";
            // 
            // Palitra
            // 
            this.Palitra.AutoSize = true;
            this.Palitra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Palitra.Location = new System.Drawing.Point(110, 81);
            this.Palitra.Name = "Palitra";
            this.Palitra.Size = new System.Drawing.Size(77, 19);
            this.Palitra.TabIndex = 3;
            this.Palitra.Text = "Палитра";
            this.Palitra.UseVisualStyleBackColor = true;
            this.Palitra.CheckedChanged += new System.EventHandler(this.Palitra_CheckedChanged);
            // 
            // Gradient
            // 
            this.Gradient.AutoSize = true;
            this.Gradient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Gradient.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Gradient.Location = new System.Drawing.Point(197, 81);
            this.Gradient.Name = "Gradient";
            this.Gradient.Size = new System.Drawing.Size(82, 19);
            this.Gradient.TabIndex = 4;
            this.Gradient.Text = "Градиент";
            this.Gradient.UseVisualStyleBackColor = true;
            this.Gradient.CheckedChanged += new System.EventHandler(this.Gradient_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-11, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "2";
            // 
            // AutoGenBox
            // 
            this.AutoGenBox.AutoSize = true;
            this.AutoGenBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AutoGenBox.Location = new System.Drawing.Point(12, 54);
            this.AutoGenBox.Name = "AutoGenBox";
            this.AutoGenBox.Size = new System.Drawing.Size(271, 21);
            this.AutoGenBox.TabIndex = 10;
            this.AutoGenBox.Text = "Автоматическое разделение данных";
            this.AutoGenBox.UseVisualStyleBackColor = true;
            this.AutoGenBox.CheckedChanged += new System.EventHandler(this.AutoGenBox_CheckedChanged);
            // 
            // DialogSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 647);
            this.Controls.Add(this.AutoGenBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Gradient);
            this.Controls.Add(this.Palitra);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Drob);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DialogSettings_FormClosing);
            this.Load += new System.EventHandler(this.DialogSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox Palitra;
        private System.Windows.Forms.CheckBox Gradient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label4;
		public System.Windows.Forms.CheckBox AutoGenBox;
        public System.Windows.Forms.TextBox Drob;
    }
}