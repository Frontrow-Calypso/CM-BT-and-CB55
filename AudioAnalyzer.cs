namespace CMBT
{
  using System;
  using System.Windows.Forms;

  /// <summary>
  /// Defines the <see cref="AudioAnalyzer" />
  /// </summary>
  public partial class AudioAnalyzer : Form
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="AudioAnalyzer"/> class.
    /// </summary>
    public AudioAnalyzer()
    {
      InitializeComponent();
    }

    /// <summary>
    /// The openWaveToolStripMenuItem_Click
    /// </summary>
    /// <param name="sender">The <see cref="object"/></param>
    /// <param name="e">The <see cref="EventArgs"/></param>
    private void openWaveToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OpenFileDialog open = new OpenFileDialog();
      open.Filter = "wave File (*.wav)|*.wav;";

      if (open.ShowDialog() != DialogResult.OK) return;
      waveViewer1.WaveStream = new NAudio.Wave.WaveFileReader(open.FileName);
    }
  }
}
