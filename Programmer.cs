namespace CMBT
{
  using System;
  using System.Windows.Forms;

  /// <summary>
  /// Defines the <see cref="Programmer" />
  /// </summary>
  public partial class Programmer : Form
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Programmer"/> class.
    /// </summary>
    /// <param name="parent">The <see cref="Form1"/></param>
    public Programmer(Form1 parent)
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