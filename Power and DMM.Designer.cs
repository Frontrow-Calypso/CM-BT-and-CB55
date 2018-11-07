namespace CMBT
{
    partial class Power_and_DMM
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
            this.DMM = new System.IO.Ports.SerialPort(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.led1 = new NationalInstruments.UI.WindowsForms.Led();
            this.led2 = new NationalInstruments.UI.WindowsForms.Led();
            this.led3 = new NationalInstruments.UI.WindowsForms.Led();
            this.led4 = new NationalInstruments.UI.WindowsForms.Led();
            this.led5 = new NationalInstruments.UI.WindowsForms.Led();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.listBox5 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.led1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led5)).BeginInit();
            this.SuspendLayout();
            // 
            // DMM
            // 
            this.DMM.PortName = "COM3";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(60, 397);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 51);
            this.button1.TabIndex = 0;
            this.button1.Text = "Measure/度量衡";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(176, 59);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(101, 22);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(176, 123);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(176, 185);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 3;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(177, 259);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 22);
            this.textBox4.TabIndex = 4;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(177, 327);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 22);
            this.textBox5.TabIndex = 5;
            // 
            // led1
            // 
            this.led1.LedStyle = NationalInstruments.UI.LedStyle.Round3D;
            this.led1.Location = new System.Drawing.Point(310, 56);
            this.led1.Name = "led1";
            this.led1.Size = new System.Drawing.Size(36, 35);
            this.led1.TabIndex = 8;
            // 
            // led2
            // 
            this.led2.LedStyle = NationalInstruments.UI.LedStyle.Round3D;
            this.led2.Location = new System.Drawing.Point(310, 117);
            this.led2.Name = "led2";
            this.led2.Size = new System.Drawing.Size(36, 35);
            this.led2.TabIndex = 9;
            // 
            // led3
            // 
            this.led3.LedStyle = NationalInstruments.UI.LedStyle.Round3D;
            this.led3.Location = new System.Drawing.Point(310, 178);
            this.led3.Name = "led3";
            this.led3.Size = new System.Drawing.Size(36, 35);
            this.led3.TabIndex = 10;
            // 
            // led4
            // 
            this.led4.LedStyle = NationalInstruments.UI.LedStyle.Round3D;
            this.led4.Location = new System.Drawing.Point(310, 254);
            this.led4.Name = "led4";
            this.led4.Size = new System.Drawing.Size(36, 35);
            this.led4.TabIndex = 11;
            // 
            // led5
            // 
            this.led5.LedStyle = NationalInstruments.UI.LedStyle.Round3D;
            this.led5.Location = new System.Drawing.Point(310, 319);
            this.led5.Name = "led5";
            this.led5.Size = new System.Drawing.Size(36, 34);
            this.led5.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 40);
            this.label1.TabIndex = 13;
            this.label1.Text = "Power Up\r\nCurrent\r\n";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(456, 81);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(226, 292);
            this.listBox1.TabIndex = 22;
            this.listBox1.UseWaitCursor = true;
            this.listBox1.Visible = false;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(495, 421);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 22);
            this.maskedTextBox1.TabIndex = 23;
            this.maskedTextBox1.UseWaitCursor = true;
            this.maskedTextBox1.Visible = false;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 16;
            this.listBox2.Location = new System.Drawing.Point(456, 116);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(226, 292);
            this.listBox2.TabIndex = 24;
            this.listBox2.UseWaitCursor = true;
            this.listBox2.Visible = false;
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 16;
            this.listBox3.Location = new System.Drawing.Point(456, 110);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(226, 292);
            this.listBox3.TabIndex = 25;
            this.listBox3.UseWaitCursor = true;
            this.listBox3.Visible = false;
            // 
            // listBox4
            // 
            this.listBox4.FormattingEnabled = true;
            this.listBox4.ItemHeight = 16;
            this.listBox4.Location = new System.Drawing.Point(456, 81);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(226, 292);
            this.listBox4.TabIndex = 26;
            this.listBox4.UseWaitCursor = true;
            this.listBox4.Visible = false;
            // 
            // listBox5
            // 
            this.listBox5.FormattingEnabled = true;
            this.listBox5.ItemHeight = 16;
            this.listBox5.Location = new System.Drawing.Point(456, 81);
            this.listBox5.Name = "listBox5";
            this.listBox5.Size = new System.Drawing.Size(226, 292);
            this.listBox5.TabIndex = 27;
            this.listBox5.UseWaitCursor = true;
            this.listBox5.Visible = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(60, 123);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 30);
            this.button2.TabIndex = 32;
            this.button2.Text = "3V7";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(60, 189);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 30);
            this.button3.TabIndex = 33;
            this.button3.Text = "4V0";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(60, 258);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 30);
            this.button4.TabIndex = 34;
            this.button4.Text = "5V0";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(60, 327);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 30);
            this.button5.TabIndex = 35;
            this.button5.Text = "-5V0";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(293, 397);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 51);
            this.button6.TabIndex = 36;
            this.button6.Text = "OK";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Power_and_DMM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(420, 477);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox5);
            this.Controls.Add(this.listBox4);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.led5);
            this.Controls.Add(this.led4);
            this.Controls.Add(this.led3);
            this.Controls.Add(this.led2);
            this.Controls.Add(this.led1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Power_and_DMM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Measurement Values";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.led1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public NationalInstruments.UI.WindowsForms.Led led1;
        public NationalInstruments.UI.WindowsForms.Led led2;
        public NationalInstruments.UI.WindowsForms.Led led3;
        public NationalInstruments.UI.WindowsForms.Led led4;
        public NationalInstruments.UI.WindowsForms.Led led5;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.ListBox listBox4;
        private System.Windows.Forms.ListBox listBox5;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.TextBox textBox3;
        public System.Windows.Forms.TextBox textBox4;
        public System.Windows.Forms.TextBox textBox5;
        public System.Windows.Forms.Button button1;
        public System.IO.Ports.SerialPort DMM;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}