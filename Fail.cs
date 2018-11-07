namespace CMBT
{
  using System;
  using System.Windows.Forms;

  /// <summary>
  /// Defines the <see cref="Fail" />
  /// </summary>
  public partial class Fail : Form
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Fail"/> class.
    /// </summary>
    /// <param name="parent">The <see cref="Form1"/></param>
    public Fail(Form1 parent)
    {
      InitializeComponent();
    }

    /// <summary>
    /// The button1_Click
    /// </summary>
    /// <param name="sender">The <see cref="object"/></param>
    /// <param name="e">The <see cref="EventArgs"/></param>
    private void button1_Click(object sender, EventArgs e)
    {
      this.Close();
      this.Dispose();
    }
  }
}
