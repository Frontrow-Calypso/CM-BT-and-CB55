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
    public partial class TP2 : Form
    {
        Power_and_DMM Main;

        public TP2(Power_and_DMM parent)
        {
            InitializeComponent();
            Main = parent;
        }



       private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

            this.Dispose();
        }
    }
}