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
    public partial class TP4 : Form
    {
        Power_and_DMM Main;
        public TP4(Power_and_DMM parent)
        {
            InitializeComponent();
            Main = parent;
        }


//System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private void TP4_Load(object sender, EventArgs e)
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
