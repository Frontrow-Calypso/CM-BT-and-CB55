namespace CMBT
{
    partial class BTAuto
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ClassOfDevice = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.led1 = new NationalInstruments.UI.WindowsForms.Led();
            this.button2 = new System.Windows.Forms.Button();
            this.led2 = new NationalInstruments.UI.WindowsForms.Led();
            this.led3 = new NationalInstruments.UI.WindowsForms.Led();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.led4 = new NationalInstruments.UI.WindowsForms.Led();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led4)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.ClassOfDevice,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column2,
            this.Column9});
            this.dataGridView1.Location = new System.Drawing.Point(3, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(10, 12);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Authentication";
            this.Column1.Name = "Column1";
            // 
            // ClassOfDevice
            // 
            this.ClassOfDevice.HeaderText = "ClassOfDevice";
            this.ClassOfDevice.Name = "ClassOfDevice";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Connected";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "DeviceAddress";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "DeviceName";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "InstalledServices";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "LastSeen";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "LastUsed";
            this.Column8.Name = "Column8";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Remembered";
            this.Column2.Name = "Column2";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "RSSI";
            this.Column9.Name = "Column9";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(82, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 47);
            this.button1.TabIndex = 5;
            this.button1.Text = "BT Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // led1
            // 
            this.led1.LedStyle = NationalInstruments.UI.LedStyle.Round3D;
            this.led1.Location = new System.Drawing.Point(573, 46);
            this.led1.Name = "led1";
            this.led1.Size = new System.Drawing.Size(43, 43);
            this.led1.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(432, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 47);
            this.button2.TabIndex = 8;
            this.button2.Text = "Remove BT Device";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // led2
            // 
            this.led2.LedStyle = NationalInstruments.UI.LedStyle.Round3D;
            this.led2.Location = new System.Drawing.Point(365, 133);
            this.led2.Name = "led2";
            this.led2.Size = new System.Drawing.Size(33, 33);
            this.led2.TabIndex = 9;
            // 
            // led3
            // 
            this.led3.LedStyle = NationalInstruments.UI.LedStyle.Round3D;
            this.led3.Location = new System.Drawing.Point(365, 202);
            this.led3.Name = "led3";
            this.led3.Size = new System.Drawing.Size(33, 33);
            this.led3.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(241, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "BTAudioLeft";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(230, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "BTAudioRight";
            // 
            // led4
            // 
            this.led4.LedStyle = NationalInstruments.UI.LedStyle.Round3D;
            this.led4.Location = new System.Drawing.Point(24, 50);
            this.led4.Name = "led4";
            this.led4.Size = new System.Drawing.Size(39, 39);
            this.led4.TabIndex = 13;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(256, 45);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 47);
            this.button3.TabIndex = 14;
            this.button3.Text = "BT Play";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(279, 268);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 29);
            this.button4.TabIndex = 15;
            this.button4.Text = "OK";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // BTAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 323);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.led4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.led3);
            this.Controls.Add(this.led2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.led1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "BTAuto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BTAuto";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewLinkColumn Column1;
        private System.Windows.Forms.DataGridViewLinkColumn ClassOfDevice;
        private System.Windows.Forms.DataGridViewLinkColumn Column3;
        private System.Windows.Forms.DataGridViewLinkColumn Column4;
        private System.Windows.Forms.DataGridViewLinkColumn Column5;
        private System.Windows.Forms.DataGridViewLinkColumn Column6;
        private System.Windows.Forms.DataGridViewLinkColumn Column7;
        private System.Windows.Forms.DataGridViewLinkColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewLinkColumn Column9;
        private System.Windows.Forms.Button button1;
        public NationalInstruments.UI.WindowsForms.Led led1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public NationalInstruments.UI.WindowsForms.Led led2;
        public NationalInstruments.UI.WindowsForms.Led led3;
        private NationalInstruments.UI.WindowsForms.Led led4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}