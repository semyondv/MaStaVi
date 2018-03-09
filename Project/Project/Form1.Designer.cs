namespace Project
{
    partial class Font1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.OpenFile = new System.Windows.Forms.Button();
            this.Picture2D = new System.Windows.Forms.Button();
            this.Picture3D = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Settings = new System.Windows.Forms.Button();
            this.MainPicture = new System.Windows.Forms.PictureBox();
            this.LegendPicture = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Years = new System.Windows.Forms.TrackBar();
            this.YearBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.MainPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LegendPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Years)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenFile
            // 
            this.OpenFile.BackColor = System.Drawing.Color.Transparent;
            this.OpenFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.OpenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenFile.Image = global::Project.Properties.Resources.but1;
            this.OpenFile.Location = new System.Drawing.Point(69, 7);
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(130, 40);
            this.OpenFile.TabIndex = 0;
            this.OpenFile.UseVisualStyleBackColor = false;
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // Picture2D
            // 
            this.Picture2D.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Picture2D.Image = global::Project.Properties.Resources.but2;
            this.Picture2D.Location = new System.Drawing.Point(229, 7);
            this.Picture2D.Name = "Picture2D";
            this.Picture2D.Size = new System.Drawing.Size(130, 40);
            this.Picture2D.TabIndex = 1;
            this.Picture2D.UseVisualStyleBackColor = true;
            this.Picture2D.Click += new System.EventHandler(this.Picture2D_Click);
            // 
            // Picture3D
            // 
            this.Picture3D.Enabled = false;
            this.Picture3D.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Picture3D.Image = global::Project.Properties.Resources.but3;
            this.Picture3D.Location = new System.Drawing.Point(412, 7);
            this.Picture3D.Name = "Picture3D";
            this.Picture3D.Size = new System.Drawing.Size(130, 40);
            this.Picture3D.TabIndex = 2;
            this.Picture3D.UseVisualStyleBackColor = true;
            this.Picture3D.Click += new System.EventHandler(this.Picture3D_Click);
            // 
            // Save
            // 
            this.Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Save.Image = global::Project.Properties.Resources.but4;
            this.Save.Location = new System.Drawing.Point(589, 7);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(130, 40);
            this.Save.TabIndex = 3;
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Settings
            // 
            this.Settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Settings.Image = global::Project.Properties.Resources.but5;
            this.Settings.Location = new System.Drawing.Point(758, 7);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(130, 40);
            this.Settings.TabIndex = 4;
            this.Settings.UseVisualStyleBackColor = true;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // MainPicture
            // 
            this.MainPicture.BackColor = System.Drawing.Color.Transparent;
            this.MainPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainPicture.Enabled = false;
            this.MainPicture.Location = new System.Drawing.Point(13, 92);
            this.MainPicture.Name = "MainPicture";
            this.MainPicture.Size = new System.Drawing.Size(947, 471);
            this.MainPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MainPicture.TabIndex = 5;
            this.MainPicture.TabStop = false;
            // 
            // LegendPicture
            // 
            this.LegendPicture.BackColor = System.Drawing.Color.White;
            this.LegendPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LegendPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LegendPicture.Cursor = System.Windows.Forms.Cursors.Default;
            this.LegendPicture.Location = new System.Drawing.Point(26, 579);
            this.LegendPicture.Name = "LegendPicture";
            this.LegendPicture.Size = new System.Drawing.Size(693, 43);
            this.LegendPicture.TabIndex = 6;
            this.LegendPicture.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Impact", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(195, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(591, 34);
            this.label1.TabIndex = 7;
            this.label1.Text = "Концентрация ресурсов банковского сектора РФ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Years
            // 
            this.Years.AutoSize = false;
            this.Years.BackColor = System.Drawing.Color.White;
            this.Years.Location = new System.Drawing.Point(745, 569);
            this.Years.Maximum = 20;
            this.Years.Name = "Years";
            this.Years.Size = new System.Drawing.Size(215, 32);
            this.Years.TabIndex = 8;
            // 
            // YearBox
            // 
            this.YearBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.YearBox.Location = new System.Drawing.Point(803, 607);
            this.YearBox.Name = "YearBox";
            this.YearBox.ReadOnly = true;
            this.YearBox.Size = new System.Drawing.Size(100, 23);
            this.YearBox.TabIndex = 9;
            this.YearBox.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gray;
            this.pictureBox1.Location = new System.Drawing.Point(744, 568);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(217, 34);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // Font1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Project.Properties.Resources.font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(979, 647);
            this.Controls.Add(this.YearBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LegendPicture);
            this.Controls.Add(this.MainPicture);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Picture3D);
            this.Controls.Add(this.Picture2D);
            this.Controls.Add(this.OpenFile);
            this.Controls.Add(this.Years);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Font1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Map Statistical Visualisator (Beta)";
            this.Load += new System.EventHandler(this.Font1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LegendPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Years)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenFile;
        private System.Windows.Forms.Button Picture2D;
        private System.Windows.Forms.Button Picture3D;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Settings;
        private System.Windows.Forms.PictureBox LegendPicture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox MainPicture;
        private System.Windows.Forms.TrackBar Years;
        private System.Windows.Forms.TextBox YearBox;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

