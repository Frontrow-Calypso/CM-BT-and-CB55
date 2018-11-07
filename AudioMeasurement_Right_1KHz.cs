namespace CMBT
{
  using DataAccess;
  using System;
  using System.Drawing;
  using System.Threading;
  using System.Windows.Forms;

  /// <summary>
  /// Defines the <see cref="AudioMeasurement_Right_1KHz" />
  /// </summary>
  public partial class AudioMeasurement_Right_1KHz : Form
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="AudioMeasurement_Right_1KHz"/> class.
    /// </summary>
    /// <param name="parent">The <see cref="Form1"/></param>
    public AudioMeasurement_Right_1KHz(Form1 parent)
    {
      InitializeComponent();
    }

    /// <summary>
    /// The wavePlayer1_Progress
    /// </summary>
    /// <param name="Sender">The <see cref="object"/></param>
    /// <param name="Args">The <see cref="Mitov.BasicLab.ProgressEventArgs"/></param>
    private void wavePlayer1_Progress(object Sender, Mitov.BasicLab.ProgressEventArgs Args)
    {
      this.UseWaitCursor = true;
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
      textBox1.Text = string.Format("{0:0.000}", responseD);
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

        if (listBox1.Items.Contains(textBox1.Text))
        {
          led1.OffColor = Color.LawnGreen;

          rmsMeter1.Dispose();
        }
        else
        {
          led1.OffColor = Color.Red;
          rmsMeter1.Dispose();
        }

        this.Refresh();
        this.Close();
        this.Dispose();
      }
    }
  }
}
