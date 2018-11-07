using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMBT
{
    public partial class TP3 : Form
    {
        Power_and_DMM Main;

        public TP3(Power_and_DMM parent)
        {
            InitializeComponent();
            Main = parent;
        }

        
        private void TP3_Load(object sender, EventArgs e)
        {
            


        }
        void timer_Tick(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

            this.Dispose();
        }

    }
}

