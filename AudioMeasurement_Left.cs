namespace CMBT
{
  using DataAccess;
  using System;
  using System.Drawing;
  using System.Threading;
  using System.Windows.Forms;

  /// <summary>
  /// Defines the <see cref="AudioMeasurement_Left" />
  /// </summary>
  public partial class AudioMeasurement_Left : Form
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="AudioMeasurement_Left"/> class.
    /// </summary>
    /// <param name="parent">The <see cref="Form1"/></param>
    public AudioMeasurement_Left(Form1 parent)
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
    /// The timer1_Tick
    /// </summary>
    /// <param name="sender">The <see cref="object"/></param>
    /// <param name="e">The <see cref="EventArgs"/></param>
    private void timer1_Tick(object sender, EventArgs e)
    {
      scope1.Hold = true;
      

        this.Refresh();
        this.Close();
        this.Dispose();
      }
    }
  }

