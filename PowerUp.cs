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
    public partial class PowerUp : Form
    {
        Form1 Main;
        public PowerUp(Form1 parent)
        {
            InitializeComponent();
            Main = parent;
        }
    }
}
