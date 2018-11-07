namespace CMBT
{
  using System;
  using System.Windows.Forms;

  /// <summary>
  /// Defines the <see cref="ButtonPressBT" />
  /// </summary>
  public partial class ButtonPressBT : Form
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ButtonPressBT"/> class.
    /// </summary>
    /// <param name="parent">The <see cref="BTAuto"/></param>
    public ButtonPressBT(BTAuto parent)
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
