namespace UDP_Control
{
    partial class Pantek_Demo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pantek_Demo));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tbxTemp = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tbxCount = new System.Windows.Forms.TextBox();
            this.tbxHeatbeat = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(40, 380);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 50);
            this.button1.TabIndex = 4;
            this.button1.Text = "Dummy";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(302, 380);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 50);
            this.button2.TabIndex = 5;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbxTemp
            // 
            this.tbxTemp.BackColor = System.Drawing.Color.White;
            this.tbxTemp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxTemp.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbxTemp.Font = new System.Drawing.Font("Verdana", 46.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxTemp.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbxTemp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbxTemp.Location = new System.Drawing.Point(149, 220);
            this.tbxTemp.Name = "tbxTemp";
            this.tbxTemp.Size = new System.Drawing.Size(292, 94);
            this.tbxTemp.TabIndex = 6;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(41, 325);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(400, 49);
            this.listBox1.TabIndex = 11;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::UDP_Control.Properties.Resources.unnamed;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(41, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(102, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::UDP_Control.Properties.Resources.heart_beat;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(41, 116);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(102, 96);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = global::UDP_Control.Properties.Resources.termometr_sun_512;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(40, 220);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(102, 96);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // tbxCount
            // 
            this.tbxCount.BackColor = System.Drawing.Color.White;
            this.tbxCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxCount.Font = new System.Drawing.Font("Verdana", 46.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbxCount.Location = new System.Drawing.Point(149, 12);
            this.tbxCount.Name = "tbxCount";
            this.tbxCount.Size = new System.Drawing.Size(292, 94);
            this.tbxCount.TabIndex = 16;
            // 
            // tbxHeatbeat
            // 
            this.tbxHeatbeat.BackColor = System.Drawing.Color.White;
            this.tbxHeatbeat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxHeatbeat.Font = new System.Drawing.Font("Verdana", 46.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxHeatbeat.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbxHeatbeat.Location = new System.Drawing.Point(149, 116);
            this.tbxHeatbeat.Name = "tbxHeatbeat";
            this.tbxHeatbeat.Size = new System.Drawing.Size(292, 94);
            this.tbxHeatbeat.TabIndex = 17;
            // 
            // Pantek_Demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImage = global::UDP_Control.Properties.Resources.gray;
            this.ClientSize = new System.Drawing.Size(490, 442);
            this.Controls.Add(this.tbxHeatbeat);
            this.Controls.Add(this.tbxCount);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tbxTemp);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Pantek_Demo";
            this.Text = "Pantek Demo";
            this.Load += new System.EventHandler(this.Pantek_Demo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbxTemp;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox tbxCount;
        private System.Windows.Forms.TextBox tbxHeatbeat;
    }
}

