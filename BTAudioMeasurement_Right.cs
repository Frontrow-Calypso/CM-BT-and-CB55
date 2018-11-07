namespace CMBT
{
  using DataAccess;
  using System;
  using System.Drawing;
  using System.Threading;
  using System.Windows.Forms;

  /// <summary>
  /// Defines the <see cref="BTAudioMeasurement_Right" />
  /// </summary>
  public partial class BTAudioMeasurement_Right : Form
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="BTAudioMeasurement_Right"/> class.
    /// </summary>
    /// <param name="parent">The <see cref="BTAuto"/></param>
    public BTAudioMeasurement_Right(BTAuto parent)
    {
      InitializeComponent();
    }

    /// <summary>
    /// The rmsMeter1_ValueChange
    /// </summary>
    /// <param name="Sender">The <see cref="object"/></param>
    /// <param name="Args">The <see cref="Mitov.BasicLab.RealNotifyEventArgs"/></param>
    private void rmsMeter1_ValueChange(object Sender, Mitov.BasicLab.RealNotifyEventArgs Args)
    {
      String RMS1 = Args.Value.ToString();

      double responseD = double.Parse(RMS1);
      textBox2.Text = string.Format("{0:0.000}", responseD);
    }

    /// <summary>
    /// The timer1_Tick
    /// </summary>
    /// <param name="sender">The <see cref="object"/></param>
    /// <param name="e">The <see cref="EventArgs"/></param>
    private void timer1_Tick(object sender, EventArgs e)
    {
      scope1.Hold = true;
      Thread.Sleep(1000);
      if (scope1.Hold == true)
      {
        DataAccess.DataTable dt = DataAccess.DataTable.New.ReadCsv(@"Voltage.csv");

        // Query via the DataTable.Rows enumeration.
        foreach (Row row in dt.Rows)
        {
          listBox1.Items.Add(row["Audio"]);
        }

        if (listBox1.Items.Contains(textBox2.Text))
        {
          led1.OffColor = Color.LawnGreen;
        }
        else
        {
          //MessageBox.Show("Please check the DMM USB connections");
          led1.OffColor = Color.Red;
        }

        this.Refresh();
        this.Close();
        this.Dispose();
      }
    }
  }
}
