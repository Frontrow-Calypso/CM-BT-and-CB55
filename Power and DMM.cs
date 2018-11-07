namespace CMBT
{
  using DataAccess;
  using System;
  using System.Drawing;
  using System.Threading;
  using System.Windows.Forms;

  /// <summary>
  /// Defines the <see cref="Power_and_DMM" />
  /// </summary>
  public partial class Power_and_DMM : Form
  {
    /// <summary>
    /// Defines the form9
    /// </summary>
    private MeasurementGuide form9;

    /// <summary>
    /// Defines the form10
    /// </summary>
    private TP2 form10;

    /// <summary>
    /// Defines the form11
    /// </summary>
    private TP3 form11;

    /// <summary>
    /// Defines the form12
    /// </summary>
    private TP4 form12;

    /// <summary>
    /// Initializes a new instance of the <see cref="Power_and_DMM"/> class.
    /// </summary>
    /// <param name="parent">The <see cref="Form1"/></param>
    public Power_and_DMM(Form1 parent)
    {
      InitializeComponent();
    }

    /// <summary>
    /// The button1_Click
    /// </summary>
    /// <param name="sender">The <see cref="object"/></param>
    /// <param name="e">The <see cref="EventArgs"/></param>
    public void button1_Click(object sender, EventArgs e)
    {
      CurrentSwitch();
      Thread.Sleep(1000);

      CurrentRead();
      Thread.Sleep(1000);

      VoltageSwitch();
      Thread.Sleep(1000);
    }

    /// <summary>
    /// The CurrentSwitch
    /// </summary>
    private void CurrentSwitch()
    {
      if (!DMM.IsOpen)
      {
        DMM.Open();
        DMM.Write("FUNC CURR:DC \r");
        System.Threading.Thread.Sleep(3000);
        DMM.Write("FUNC CURR:DC \r");
        DMM.DiscardOutBuffer();
      }
      else
      {
        MessageBox.Show("Check the DMM Connections");
        led1.OffColor = Color.Red;
      }

      this.Refresh();
    }

    /// <summary>
    /// The CurrentRead
    /// </summary>
    private void CurrentRead()
    {
      if (DMM.IsOpen)
      {
        // DMM.Open();
        // DMM.DiscardInBuffer();
        DMM.Write("FETCh?\r");
        System.Threading.Thread.Sleep(3000);
        // DMM.Write(":FETCh? \r");
        string response = DMM.ReadExisting();                                                 //read response string

        //System.Threading.Thread.Sleep(3000);
        textBox1.Text = response;

        /* decimal responseD = decimal.Parse(response);
         textBox1.Text = String.Format("{0:n4}", responseD);*/

        DMM.DiscardOutBuffer();
        // this.Refresh();

        DataAccess.DataTable dt = DataAccess.DataTable.New.ReadCsv(@"Voltage.csv");

        // Query via the DataTable.Rows enumeration.
        foreach (Row row in dt.Rows)
        {
          listBox5.Items.Add(row["Current"]);
        }

        if (listBox5.Items.Contains(textBox1.Text))
        {
          led1.OffColor = Color.LimeGreen;
        }
        else
        {
          MessageBox.Show("Please check the DMM USB connections");
          led1.OffColor = Color.Red;
        }
      }
      else
      {
        MessageBox.Show("Please check the DMM USB connections");
        led1.OffColor = Color.Red;
      }

      this.Refresh();
    }

    /// <summary>
    /// The VoltageSwitch
    /// </summary>
    private void VoltageSwitch()
    {
      if (DMM.IsOpen)
      {
        //DMM.Open();
        DMM.Write("FUNC VOLT:DC \r");
        System.Threading.Thread.Sleep(1000);
        DMM.DiscardOutBuffer();
      }
      else
      {
        MessageBox.Show("Check the DMM Connections");
        led2.OffColor = Color.Red;
      }

      this.Refresh();
    }

    /// <summary>
    /// The VoltageRead1
    /// </summary>
    private void VoltageRead1()
    {
      form9 = new MeasurementGuide(this);
      form9.ShowDialog(this);

      while (form9.Visible == true)
      {
        Application.DoEvents();
      }
      if (DMM.IsOpen)
      {
        // DMM.Open();
        DMM.DiscardInBuffer();
        DMM.Write(":FETCh? \r");
        System.Threading.Thread.Sleep(3000);
        string response = DMM.ReadExisting();                                                 //read response string
        double responseD = double.Parse(response);
        textBox2.Text = string.Format("{0:0.000}", responseD);

        DMM.DiscardOutBuffer();
        //this.Refresh();

        DataAccess.DataTable dt = DataAccess.DataTable.New.ReadCsv(@"Voltage.csv");

        // Query via the DataTable.Rows enumeration.
        foreach (Row row in dt.Rows)
        {
          listBox1.Items.Add(row["Voltage 1"]);
        }

        if (listBox1.Items.Contains(textBox2.Text))
        {
          led2.OffColor = Color.LimeGreen;
        }
        else
        {
          MessageBox.Show("Please check the DMM USB connections");
          led2.OffColor = Color.Red;
        }
      }
      else
      {
        MessageBox.Show("Please check the DMM USB connections");
        led2.OffColor = Color.Red;
      }

      this.Refresh();
    }

    /// <summary>
    /// The VoltageRead2
    /// </summary>
    private void VoltageRead2()
    {
      form10 = new TP2(this);
      form10.ShowDialog(this);

      while (form10.Visible == true)
      {
        Application.DoEvents();
      }

      if (DMM.IsOpen)
      {
        //DMM.Open();
        DMM.DiscardInBuffer();
        DMM.Write(":FETCh? \r");
        System.Threading.Thread.Sleep(3000);
        string response = DMM.ReadExisting();                                                 //read response string
        textBox3.Text = response;

        double responseD = double.Parse(response);
        textBox3.Text = string.Format("{0:0.000}", responseD);

        DMM.DiscardOutBuffer();
        //this.Refresh();

        DataAccess.DataTable dt = DataAccess.DataTable.New.ReadCsv(@"Voltage.csv");

        // Query via the DataTable.Rows enumeration.
        foreach (Row row in dt.Rows)
        {
          listBox2.Items.Add(row["Voltage2"]);
        }

        if (listBox2.Items.Contains(textBox3.Text))

        {
          led3.OffColor = Color.LimeGreen;
        }
        else
        {
          MessageBox.Show("Please check the DMM USB connections");
          led3.OffColor = Color.Red;
        }
      }
      else
      {
        MessageBox.Show("Please check the DMM USB connections");
        led3.OffColor = Color.Red;
      }

      this.Refresh();
    }

    /// <summary>
    /// The VoltageRead3
    /// </summary>
    private void VoltageRead3()
    {
      form11 = new TP3(this);
      form11.ShowDialog(this);

      while (form11.Visible == true)
      {
        Application.DoEvents();
      }
      if (DMM.IsOpen)
      {
        //DMM.Open();
        DMM.DiscardInBuffer();
        DMM.Write(":FETCh? \r");
        System.Threading.Thread.Sleep(3000);
        string response = DMM.ReadExisting();                                                 //read response string
        textBox4.Text = response;
        double responseD = double.Parse(response);
        textBox4.Text = string.Format("{0:0.000}", responseD);

        DMM.DiscardOutBuffer();
        //this.Refresh();

        DataAccess.DataTable dt = DataAccess.DataTable.New.ReadCsv(@"Voltage.csv");

        // Query via the DataTable.Rows enumeration.
        foreach (Row row in dt.Rows)
        {
          listBox3.Items.Add(row["Voltage3"]);
        }

        if (listBox3.Items.Contains(textBox4.Text))
        {
          led4.OffColor = Color.LimeGreen;
        }
        else
        {
          MessageBox.Show("Please check the DMM USB connections");
          led4.OffColor = Color.Red;
        }
      }
      else
      {
        MessageBox.Show("Please check the DMM USB connections");
        led4.OffColor = Color.Red;
      }

      this.Refresh();
    }

    /// <summary>
    /// The VoltageRead4
    /// </summary>
    private void VoltageRead4()
    {
      form12 = new TP4(this);
      form12.ShowDialog(this);

      while (form12.Visible == true)
      {
        Application.DoEvents();
      }

      if (DMM.IsOpen)
      {
        //DMM.Open();
        DMM.DiscardInBuffer();
        DMM.Write(":FETCh? \r");
        System.Threading.Thread.Sleep(3000);
        string response = DMM.ReadExisting();                                                 //read response string
        textBox5.Text = response;
        double responseD = double.Parse(response);
        textBox5.Text = string.Format("{0:0.000}", responseD);

        DMM.DiscardOutBuffer();
        //this.Refresh();

        DataAccess.DataTable dt = DataAccess.DataTable.New.ReadCsv(@"Voltage.csv");

        // Query via the DataTable.Rows enumeration.
        foreach (Row row in dt.Rows)
        {
          listBox4.Items.Add(row["Voltage 4"]);
        }

        if (listBox4.Items.Contains(textBox5.Text))
        {
          led5.OffColor = Color.LimeGreen;
        }
        else
        {
          MessageBox.Show("Please check the DMM USB connections");
          led5.OffColor = Color.Red;
        }
      }
      else
      {
        MessageBox.Show("Please check the DMM USB connections");
        led5.OffColor = Color.Red;
      }

      this.Refresh();
    }

    /// <summary>
    /// The button2_Click
    /// </summary>
    /// <param name="sender">The <see cref="object"/></param>
    /// <param name="e">The <see cref="EventArgs"/></param>
    private void button2_Click(object sender, EventArgs e)
    {
      VoltageRead1();
      Thread.Sleep(1000);
    }

    /// <summary>
    /// The button3_Click
    /// </summary>
    /// <param name="sender">The <see cref="object"/></param>
    /// <param name="e">The <see cref="EventArgs"/></param>
    private void button3_Click(object sender, EventArgs e)
    {
      VoltageRead2();
      Thread.Sleep(1000);
    }

    /// <summary>
    /// The button4_Click
    /// </summary>
    /// <param name="sender">The <see cref="object"/></param>
    /// <param name="e">The <see cref="EventArgs"/></param>
    private void button4_Click(object sender, EventArgs e)
    {
      VoltageRead3();
      Thread.Sleep(1000);
    }

    /// <summary>
    /// The button5_Click
    /// </summary>
    /// <param name="sender">The <see cref="object"/></param>
    /// <param name="e">The <see cref="EventArgs"/></param>
    private void button5_Click(object sender, EventArgs e)
    {
      VoltageRead4();
      Thread.Sleep(1000);
    }

    /// <summary>
    /// The button6_Click
    /// </summary>
    /// <param name="sender">The <see cref="object"/></param>
    /// <param name="e">The <see cref="EventArgs"/></param>
    private void button6_Click(object sender, EventArgs e)
    {
      this.Close();
      this.Dispose();
    }
  }
}
