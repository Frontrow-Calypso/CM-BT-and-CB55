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
    public partial class Unpairing : Form
    {
        Form1 Main;
        public Unpairing(Form1 parent)
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
