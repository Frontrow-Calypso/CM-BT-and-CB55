/************************************************
 * 32Feet Library classes are                   *
 *                                              *
 * a part of the InTheHand.Net package.         *
 *                                              *
 *                                              *
 * *********************************************/

namespace CMBT
{
  using CSR8635_API;
  using System;
  using System.Drawing;
  using System.IO;
  using System.Threading;
  using System.Windows.Forms;

  /// <summary>
  /// Defines the <see cref="Form1" />
  /// </summary>
  public partial class Form1 : Form
  {
    /// <summary>
    /// Defines the form0
    /// </summary>
    private DUT_Connections form0;

    /// <summary>
    /// Defines the form2
    /// </summary>
    private USBEnumeration form2;

    // PowerUp form3;
    // PowerUp form3;        /// <summary>
    /// Defines the form4
    /// </summary>
    private BTAuto form4;

    /// <summary>
    /// Defines the form6
    /// </summary>
    private Success form6;

    /// <summary>
    /// Defines the form7
    /// </summary>
    private Fail form7;

    /// <summary>
    /// Defines the form8
    /// </summary>
    private Power_and_DMM form8;

    /// <summary>
    /// Defines the form9
    /// </summary>
    private AudioMeasurement_Left form9;

    /// <summary>
    /// Defines the form10
    /// </summary>
    private Unpairing form10;

    /// <summary>
    /// Defines the form11
    /// </summary>
    private Programmer form11;

    /// <summary>
    /// Defines the form13
    /// </summary>
    private CB_55_Volume form13;

    /// <summary>
    /// Defines the form17
    /// </summary>
    private AudioMeasurement_Right_1KHz form17;

    /// <summary>
    /// Defines the ProgrammingResult
    /// </summary>
    public bool ProgrammingResult = true;

    /// <summary>
    /// Defines the BTNUC
    /// </summary>
    public bool BTNUC = true;

    /// <summary>
    /// Defines the BTAudio
    /// </summary>
    public bool BTAudio = true;

    /// <summary>
    /// Defines the Relay0ON
    /// </summary>
    public bool Relay0ON = true;

    /// <summary>
    /// Defines the Relay0OFF
    /// </summary>
    public bool Relay0OFF = true;

    /// <summary>
    /// Defines the Relay1ON
    /// </summary>
    public bool Relay1ON = true;

    /// <summary>
    /// Defines the Relay1OFF
    /// </summary>
    public bool Relay1OFF = true;

    /// <summary>
    /// Defines the Relay3ON
    /// </summary>
    public bool Relay3ON = true;

    /// <summary>
    /// Defines the Relay3OFF
    /// </summary>
    public bool Relay3OFF = true;

    /// <summary>
    /// Defines the ErasePair
    /// </summary>
    public bool ErasePair = true;

    /// <summary>
    /// Defines the PowerOffResult
    /// </summary>
    public bool PowerOffResult = true;

    /// <summary>
    /// Defines the IR
    /// </summary>
    public bool IR = true;

    /// <summary>
    /// Defines the Unpair
    /// </summary>
    public bool Unpair = true;

    /// <summary>
    /// Defines the AudioLeft
    /// </summary>
    public bool AudioLeft = true;

    /// <summary>
    /// Defines the AudioRight
    /// </summary>
    public bool AudioRight = true;

    /// <summary>
    /// Initializes a new instance of the <see cref="Form1"/> class.
    /// </summary>
    public Form1()
    {
      try
      {
        InitializeComponent();
      }
      catch (System.IO.FileNotFoundException e)
      {
        MessageBox.Show("Could not find " + e.FileName);
      }

      /*  PSOff();
        Thread.Sleep(1000);*/

      form0 = new DUT_Connections(this);
      form0.ShowDialog();

      Thread.Sleep(1000);
      MessageBox.Show("Please select the board type" +
               "\n 请选择板式");
    }

    /// <summary>
    /// The PowerUp
    /// </summary>
    public void PowerUp()
    {
      // Automate the 4 voltages that need to be probed by a DMM

      PS12V();
      Thread.Sleep(1000);
      form8 = new Power_and_DMM(this);
      form8.ShowDialog(this);

      if (form8.led1.OffColor == Color.LimeGreen && form8.led2.OffColor == Color.LimeGreen && form8.led3.OffColor == Color.LimeGreen && form8.led4.OffColor == Color.LimeGreen && form8.led5.OffColor == Color.LimeGreen)
      {
        led1.OffColor = Color.LawnGreen;
      }
      else
      {
        led1.OffColor = Color.Red;
      }

      this.Refresh();
      DialogResult result0 = MessageBox.Show("Is the GREEN LED ON?", "Power Verification", MessageBoxButtons.YesNo);

      if (result0 == DialogResult.Yes)
      {
        led10.OffColor = Color.LawnGreen;
      }
      else if (result0 == DialogResult.No)
      {
        led10.OffColor = Color.Red;
        MessageBox.Show("Please check the power connections to the DUT and check the Green LED on the board");
      }
      this.Refresh();
      if (radioButton1.Checked == true)
      {
        DialogResult result3 = MessageBox.Show("Is the BLUE LED ON?", "Power Verification", MessageBoxButtons.YesNo);

        if (result3 == DialogResult.Yes)
        {
          led11.OffColor = Color.LawnGreen;
        }
        else if (result3 == DialogResult.No)
        {
          DialogResult result4 = MessageBox.Show("Is the board being retested?", "Power Verification", MessageBoxButtons.YesNo);

          if (result4 == DialogResult.Yes)
          {
            led11.OffColor = Color.LawnGreen;
          }
          else if (result4 == DialogResult.No)
          {
            led11.OffColor = Color.Red;
            MessageBox.Show("Check the Blue LED on the board and the Bluetooth Module");
          }
        }
      }

      if (radioButton3.Checked == true)
      {
        DialogResult result3 = MessageBox.Show("Is the BLUE LED ON?", "Power Verification", MessageBoxButtons.YesNo);

        if (result3 == DialogResult.Yes)
        {
          led11.OffColor = Color.LawnGreen;
        }
        else if (result3 == DialogResult.No)
        {
          DialogResult result4 = MessageBox.Show("Is the board being retested?", "Power Verification", MessageBoxButtons.YesNo);

          if (result4 == DialogResult.Yes)
          {
            led11.OffColor = Color.LawnGreen;
          }
          else if (result4 == DialogResult.No)
          {
            led11.OffColor = Color.Red;
            MessageBox.Show("Check the Blue LED on the board and the Bluetooth Module");
          }
        }
      }
      this.Refresh();
    }

    /// <summary>
    /// The PSOn
    /// </summary>
    private void PSOn()
    {
      if (!PS.IsOpen)
      {
        PS.Open();
        PS.Write("SOUT0\r");
        Thread.Sleep(100);
        PS.DiscardOutBuffer();
        PS.Close();
      }
      else
      {
        MessageBox.Show("PS not Connected");
      }
    }

    /// <summary>
    /// The PSOff
    /// </summary>
    private void PSOff()
    {
      if (!PS.IsOpen)
      {
        PS.Open();
        PS.Write("SOUT1\r");
        Thread.Sleep(1000);
        //PS.Write("SOUT1 \r");
        PS.DiscardOutBuffer();
        PS.Close();
      }
      else
      {
        MessageBox.Show("PS not Connected");
      }
    }

    /// <summary>
    /// The PS12V
    /// </summary>
    private void PS12V()
    {
      if (!PS.IsOpen)
      {
        PS.Open();
        PS.Write("VOLT120\r");
        Thread.Sleep(1000);
        //PS.Write("SOUT1 \r");
        PS.DiscardOutBuffer();
        PS.Close();
      }
      else
      {
        MessageBox.Show("PS not Connected");
      }
    }

    /// <summary>
    /// The PowerOff
    /// </summary>
    private void PowerOff()
    {
      RelayOffLeft();
      Thread.Sleep(1000);

      RelayOffRight();
      Thread.Sleep(1000);

      if (radioButton1.Checked == true)
      {
        if (led26.OffColor == Color.LawnGreen)
        {
          led17.OffColor = Color.LawnGreen;
          PowerOffResult = true;
        }
        else
        {
          led17.OffColor = Color.Red;
          PowerOffResult = false;
        }
      }
      else if (radioButton2.Checked == true)
      {
        if (led20.OffColor == Color.LawnGreen && led21.OffColor == Color.LawnGreen)
        {
          led17.OffColor = Color.LawnGreen;
        }
        else
        {
          led17.OffColor = Color.Red;
        }
      }
      else if (radioButton3.Checked == true)
      {
        if (led26.OffColor == Color.LawnGreen && led20.OffColor == Color.LawnGreen && led21.OffColor == Color.LawnGreen)
        {
          led17.OffColor = Color.LawnGreen;
          PowerOffResult = true;
        }
        else
        {
          led17.OffColor = Color.Red;
          PowerOffResult = false;
        }
        this.Refresh();
      }
    }

    /// <summary>
    /// The USBEnumeration
    /// </summary>
    private void USBEnumeration()
    {
      form2 = new USBEnumeration(this);
      form2.ShowDialog(this);
      if (form2.led1.OffColor == Color.LawnGreen && form2.led2.OffColor == Color.LawnGreen && form2.led3.OffColor == Color.LawnGreen && form2.led4.OffColor == Color.LawnGreen && form2.led5.OffColor == Color.LawnGreen && form2.led6.OffColor == Color.LawnGreen && form2.led7.OffColor == Color.LawnGreen)
      {
        led9.OffColor = Color.LawnGreen;
      }
      else
      {
        led9.OffColor = Color.Red;
        MessageBox.Show("Please check USB connections");
      }
      //DialogResult result2 = MessageBox.Show("Is the GREEN LED ON?", "Power Verification", MessageBoxButtons.YesNoCancel);
      this.Refresh();
    }

    /// <summary>
    /// The Programming
    /// </summary>
    private void Programming()
    {
      form11 = new Programmer(this);
      form11.ShowDialog(this);
      if (CSR8635.Program() == string.Empty)
      {
        led2.OffColor = Color.Red;
        ProgrammingResult = false;
      }
      else
      {
        led2.OffColor = Color.LawnGreen;
        ProgrammingResult = true;
      }
      this.Refresh();
    }

    /// <summary>
    /// The BluetoothwithNUC
    /// </summary>
    private void BluetoothwithNUC()
    {
      form4 = new BTAuto(this);
      form4.ShowDialog(this);
      if (form4.led1.OffColor == Color.LawnGreen)
      {
        led3.OffColor = Color.LawnGreen;
        BTNUC = true;
      }
      else
      {
        led3.OffColor = Color.Red;
        BTNUC = false;
      }
      this.Refresh();
    }

    /// <summary>
    /// The BTAudioMeasurement
    /// </summary>
    private void BTAudioMeasurement()
    {
      if (form4.led2.OffColor == Color.LawnGreen && form4.led3.OffColor == Color.LawnGreen)
      {
        led4.OffColor = Color.LawnGreen;
        BTAudio = true;
      }
      else
      {
        led4.OffColor = Color.Red;
        BTAudio = false;
      }
      this.Refresh();
    }

    /// <summary>
    /// The RelayOnLeft
    /// </summary>
    private void RelayOnLeft()
    {
      //Serial Port Communication Automation
      if (RelayPort.IsOpen)
      {
        //RelayPort.Open();
        RelayPort.Write("relay on 0 \r");
        System.Threading.Thread.Sleep(500);
        RelayPort.Write("relay on 2 \r");
        System.Threading.Thread.Sleep(500);
        RelayPort.DiscardOutBuffer();
      }
      else
      {
        MessageBox.Show("Check the (Left)Relay Board USB Connection to the PC");
      }
    }

    /// <summary>
    /// The RelayReadLeft
    /// </summary>
    private void RelayReadLeft()
    {
      if (RelayPort.IsOpen)
      {
        RelayPort.DiscardInBuffer();
        RelayPort.Write("relay read 0 \r");
        System.Threading.Thread.Sleep(500);
        RelayPort.Write("relay read 2 \r");
        System.Threading.Thread.Sleep(500);

        string response = RelayPort.ReadExisting();                                                 //read response string
        textBox2.Text = response.Substring(13, 4);
        RelayPort.DiscardOutBuffer();

        if ((textBox2.Text.Contains("on")))
        {
          led25.OffColor = Color.LawnGreen;
          Relay0ON = true;
        }
      }
      else
      {
        MessageBox.Show("Please check the LEFT Relay connections!");
        led25.OffColor = Color.Red;
        Relay0ON = false;
      }
      this.Refresh();
    }

    /// <summary>
    /// The RelayOffLeft
    /// </summary>
    private void RelayOffLeft()
    {
      //Serial Port Communication Automation
      if (RelayPort.IsOpen)
      {
        // RelayPort.Open();
        RelayPort.Write("relay off 0 \r");
        System.Threading.Thread.Sleep(500);
        RelayPort.Write("relay off 2 \r");
        System.Threading.Thread.Sleep(500);
        RelayPort.DiscardOutBuffer();

        Thread.Sleep(1000);

        RelayPort.DiscardInBuffer();
        RelayPort.Write("relay read 0 \r");
        System.Threading.Thread.Sleep(500);
        RelayPort.Write("relay read 2 \r");
        System.Threading.Thread.Sleep(500);
        string response = RelayPort.ReadExisting();                                                 //read response string
        textBox2.Text = response.Substring(13, 5);
        RelayPort.DiscardOutBuffer();

        if ((textBox2.Text.Contains("off")))
        {
          led21.OffColor = Color.LawnGreen;
          Relay0OFF = true;
        }
      }
      else
      {
        MessageBox.Show("Check the (LEFT Read) Relay Board USB Connection to the PC");
        led21.OffColor = Color.Red;
        Relay0OFF = false;
      }
      this.Refresh();
    }

    /// <summary>
    /// The RelayOnRight
    /// </summary>
    private void RelayOnRight()
    {
      //Serial Port Communication Automation

      if (RelayPort.IsOpen)
      {
        //RelayPort.Open();
        RelayPort.Write("relay on 1 \r");
        System.Threading.Thread.Sleep(500);
        RelayPort.Write("relay on 2 \r");
        System.Threading.Thread.Sleep(500);
        RelayPort.DiscardOutBuffer();
      }
      else
      {
        MessageBox.Show("Check the (Right) Relay Board USB Connection to the PC");
      }
    }

    /// <summary>
    /// The RelayReadRight
    /// </summary>
    private void RelayReadRight()
    {
      if (RelayPort.IsOpen)
      {
        RelayPort.DiscardInBuffer();
        RelayPort.Write("relay read 1 \r");
        System.Threading.Thread.Sleep(500);
        RelayPort.Write("relay read 2 \r");
        System.Threading.Thread.Sleep(500);

        string response = RelayPort.ReadExisting();                                                 //read response string
        textBox2.Text = response.Substring(13, 4);
        RelayPort.DiscardOutBuffer();

        if ((textBox2.Text.Contains("on")))
        {
          led24.OffColor = Color.LawnGreen;
          Relay1ON = true;
        }
      }
      else
      {
        MessageBox.Show("Please check the Right Relay board connections!");
        led24.OffColor = Color.Red;
        Relay1ON = false;
      }

      this.Refresh();
    }

    /// <summary>
    /// The RelayOffRight
    /// </summary>
    private void RelayOffRight()
    {
      //Serial Port Communication Automation

      if (RelayPort.IsOpen)
      {
        //RelayPort.Open();
        RelayPort.Write("relay off 1 \r");
        System.Threading.Thread.Sleep(500);
        RelayPort.Write("relay off 2 \r");
        System.Threading.Thread.Sleep(500);
        RelayPort.DiscardOutBuffer();

        Thread.Sleep(1000);

        RelayPort.DiscardInBuffer();
        RelayPort.Write("relay read 1 \r");
        System.Threading.Thread.Sleep(500);
        RelayPort.Write("relay read 2 \r");
        System.Threading.Thread.Sleep(500);
        string response = RelayPort.ReadExisting();                                                 //read response string
        textBox2.Text = response.Substring(13, 5);
        RelayPort.DiscardOutBuffer();

        if ((textBox2.Text.Contains("off")))
        {
          led20.OffColor = Color.LawnGreen;
          Relay1OFF = true;
        }
      }
      else
      {
        MessageBox.Show("Check the (right read) Relay Board USB Connection to the PC");
        led20.OffColor = Color.Red;
        Relay1OFF = false;
      }

      this.Refresh();
    }

    /// <summary>
    /// The RelayOn0
    /// </summary>
    public void RelayOn0()
    {
      //Serial Port Communication Automation

      if (!RelayPort.IsOpen)
      {
        RelayPort.Open();
        RelayPort.Write("relay on 3 \r");
        System.Threading.Thread.Sleep(500);
        RelayPort.DiscardOutBuffer();
      }
      else
      {
        MessageBox.Show("Check the Relay Board USB Connection to the PC");
      }
    }

    /// <summary>
    /// The RelayRead0
    /// </summary>
    public void RelayRead0()
    {
      if (RelayPort.IsOpen)
      {
        RelayPort.DiscardInBuffer();
        RelayPort.Write("relay read 3 \r");
        System.Threading.Thread.Sleep(500);
        string response = RelayPort.ReadExisting();                                                 //read response string
        textBox2.Text = response.Substring(13, 4);
        RelayPort.DiscardOutBuffer();

        if ((textBox2.Text.Contains("on")))
        {
          led5.OffColor = Color.LawnGreen;
          Relay3ON = true;
        }
      }
      else
      {
        MessageBox.Show("Please check the Relay board connections!");
        led5.OffColor = Color.Red;
        Relay3ON = false;
      }

      this.Refresh();
    }

    /// <summary>
    /// The RelayOff0
    /// </summary>
    public void RelayOff0()
    {
      //Serial Port Communication Automation

      if (RelayPort.IsOpen)
      {
        // RelayPort.Open();
        RelayPort.Write("relay off 3 \r");
        System.Threading.Thread.Sleep(500);
        RelayPort.DiscardOutBuffer();

        Thread.Sleep(1000);

        RelayPort.DiscardInBuffer();
        RelayPort.Write("relay read 3 \r");
        System.Threading.Thread.Sleep(500);
        string response = RelayPort.ReadExisting();                                                 //read response string
        textBox2.Text = response.Substring(13, 5);
        RelayPort.DiscardOutBuffer();

        if ((textBox2.Text.Contains("off")))
        {
          led26.OffColor = Color.LawnGreen;
          Relay3OFF = true;
        }
      }
      else
      {
        MessageBox.Show("Check the Relay Board USB Connection to the PC");
        led26.OffColor = Color.Red;
        Relay3OFF = false;
      }

      this.Refresh();
    }

    /// <summary>
    /// The AudioLeftMeasurement
    /// </summary>
    private void AudioLeftMeasurement()
    {
      if (led13.OffColor == Color.LawnGreen && led27.OffColor == Color.LawnGreen && led28.OffColor == Color.LawnGreen)
      {
        led23.OffColor = Color.LawnGreen;
      }
      else
      {
        led23.OffColor = Color.Red;
      }
    }

    /// <summary>
    /// The AudioRightMeasurement
    /// </summary>
    private void AudioRightMeasurement()
    {
      if (led30.OffColor == Color.LawnGreen && led31.OffColor == Color.LawnGreen && led32.OffColor == Color.LawnGreen)
      {
        led22.OffColor = Color.LawnGreen;
      }
      else
      {
        led22.OffColor = Color.Red;
      }
    }

    /// <summary>
    /// The AudioMeasurement_Left
    /// </summary>
    private void AudioMeasurement_Left()
    {
      //  if (led25.OffColor == Color.LawnGreen)
      //    {
      form9 = new AudioMeasurement_Left(this);
      form9.ShowDialog(this);
    }

    /// <summary>
    /// The AudioMeasurement_Right_1KHz
    /// </summary>
    private void AudioMeasurement_Right_1KHz()
    {
      if (led24.OffColor == Color.LawnGreen)
      {
        form17 = new AudioMeasurement_Right_1KHz(this);
        form17.ShowDialog(this);

        if (form17.led1.OffColor == Color.LawnGreen)
        {
          led31.OffColor = Color.LawnGreen;
          AudioRight = true;
        }
        else
        {
          led31.OffColor = Color.Red;
          AudioRight = false;
        }
      }
      else if (led24.OffColor == Color.Red)
      {
        MessageBox.Show(" Please check the Relay Board");
        led31.OffColor = Color.Red;
        AudioRight = false;
      }

      this.Refresh();
    }

    /// <summary>
    /// The LineInLineOut
    /// </summary>
    private void LineInLineOut()
    {
      if (led25.OffColor == Color.LawnGreen && led23.OffColor == Color.LawnGreen && led21.OffColor == Color.LawnGreen && led24.OffColor == Color.LawnGreen && led22.OffColor == Color.LawnGreen && led20.OffColor == Color.LawnGreen)
      {
        led8.OffColor = Color.LawnGreen;
      }
      else
      {
        led8.OffColor = Color.Red;
      }

      this.Refresh();
    }

    /// <summary>
    /// The IRBlaster
    /// </summary>
    private void IRBlaster()
    {
      // Arduino Communication

      if (!Arduino.IsOpen)
      {
        Arduino.Open();
        Arduino.Write("1 \r");
        System.Threading.Thread.Sleep(500);
        Arduino.DiscardOutBuffer();

        DialogResult result2 = MessageBox.Show("Is the BLUE pairing LED ON?", "Pairing Verification", MessageBoxButtons.YesNoCancel);

        if (result2 == DialogResult.Yes)
        {
          led6.OffColor = Color.LawnGreen;
          IR = true;
        }
        else if (result2 == DialogResult.No)
        {
          led6.OffColor = Color.Red;
          MessageBox.Show("Check the Arduino Connections");
          IR = false;
        }
      }
      else
      {
        MessageBox.Show("Check Arduino Connections");
        IR = false;
      }
    }

    /// <summary>
    /// The IRBlasterOFF
    /// </summary>
    private void IRBlasterOFF()
    {
      // Arduino Communication

      if (!Arduino.IsOpen)
      {
        Arduino.Open();
        Arduino.Write("0 \r");
        // System.Threading.Thread.Sleep(500);
        //Arduino.Write("relay on 1 \r");
        System.Threading.Thread.Sleep(500);
        Arduino.DiscardOutBuffer();
      }
      else
      {
        MessageBox.Show("Check Arduino Connections");
      }
    }

    /// <summary>
    /// The ErasePairingList
    /// </summary>
    private void ErasePairingList()
    {
      led12.OffColor = Color.Yellow;
      Thread.Sleep(4000);

      if (form2.led2.OffColor == Color.LawnGreen)
      {
        led12.OffColor = Color.LawnGreen;

        //Thread.Sleep(4000);
        ErasePair = true;
      }
      else
      {
        led12.OffColor = Color.Red;
        ErasePair = false;
      }
    }

    /// <summary>
    /// The BluetoothUnPairingwithTB16
    /// </summary>
    private void BluetoothUnPairingwithTB16()
    {
      if (led6.OffColor == Color.LawnGreen)
      {
        form10 = new Unpairing(this);
        form10.Show();

        while (form10.Visible == true)
        {
          Application.DoEvents();
        }

        DialogResult result2 = MessageBox.Show("Is the BLUE LED blinking?", "Switch Verification", MessageBoxButtons.YesNoCancel);

        if (result2 == DialogResult.Yes)
        {
          led7.OffColor = Color.Red;
          MessageBox.Show("Please double press the pairing button");
          led8.OffColor = Color.Yellow;
          Unpair = false;
        }
        else if (result2 == DialogResult.No)
        {
          led7.OffColor = Color.LawnGreen;
          Thread.Sleep(500);
          led8.OffColor = Color.Yellow;
          Unpair = true;
        }
      }
      else
      {
        MessageBox.Show("Please check the Bluetooth Module!");
      }
      this.Refresh();
    }

    /// <summary>
    /// The Results
    /// </summary>
    private void Results()
    {
      if (radioButton2.Checked == true)
      {
        if (led9.OffColor == Color.LawnGreen && led6.OffColor == Color.LawnGreen && led7.OffColor == Color.LawnGreen && led8.OffColor == Color.LawnGreen && led25.OffColor == Color.LawnGreen && led23.OffColor == Color.LawnGreen && led21.OffColor == Color.LawnGreen && led24.OffColor == Color.LawnGreen && led22.OffColor == Color.LawnGreen && led20.OffColor == Color.LawnGreen && led17.OffColor == Color.LawnGreen)
        {
          form6 = new Success(this);
          form6.ShowDialog(this);
        }
        else
        {
          form7 = new Fail(this);
          form7.ShowDialog(this);
        }
      }

      if (radioButton1.Checked == true)
      {
        if (led1.OffColor == Color.LawnGreen && led10.OffColor == Color.LawnGreen && led11.OffColor == Color.LawnGreen && led9.OffColor == Color.LawnGreen && led2.OffColor == Color.LawnGreen && led5.OffColor == Color.LawnGreen && led3.OffColor == Color.LawnGreen && led4.OffColor == Color.LawnGreen && led26.OffColor == Color.LawnGreen && led17.OffColor == Color.LawnGreen && led12.OffColor == Color.LawnGreen)
        {
          form6 = new Success(this);
          form6.ShowDialog(this);
        }
        else
        {
          form7 = new Fail(this);
          form7.ShowDialog(this);
        }
      }

      if (radioButton3.Checked == true)
      {
        if (led1.OffColor == Color.LawnGreen && led10.OffColor == Color.LawnGreen && led11.OffColor == Color.LawnGreen && led9.OffColor == Color.LawnGreen && led2.OffColor == Color.LawnGreen && led5.OffColor == Color.LawnGreen && led3.OffColor == Color.LawnGreen && led4.OffColor == Color.LawnGreen && led26.OffColor == Color.LawnGreen && led17.OffColor == Color.LawnGreen && led12.OffColor == Color.LawnGreen && led9.OffColor == Color.LawnGreen && led6.OffColor == Color.LawnGreen && led7.OffColor == Color.LawnGreen && led8.OffColor == Color.LawnGreen && led25.OffColor == Color.LawnGreen && led23.OffColor == Color.LawnGreen && led21.OffColor == Color.LawnGreen && led24.OffColor == Color.LawnGreen && led22.OffColor == Color.LawnGreen && led20.OffColor == Color.LawnGreen && led17.OffColor == Color.LawnGreen)
        {
          form6 = new Success(this);
          form6.ShowDialog(this);
        }
        else
        {
          form7 = new Fail(this);
          form7.ShowDialog(this);
        }
      }
    }

    /// <summary>
    /// The TestData
    /// </summary>
    public void TestData()
    {
      string filename = "C:\\CMBT ATE Data\\Test Data" + DateTime.Now.ToString("yyyyMMdd") + ".csv";
      string timestring = DateTime.Now.ToString("h:mm:ss tt");
      if (radioButton1.Checked == true)
      {
        if (!File.Exists(filename))
        {
          using (StreamWriter sw = File.AppendText(filename))
          {
            sw.WriteLine("PowerUp Current " + "Voltage1" + "Voltage2" + "Voltage3" + "Voltage4" + "USB1" + "USB2" + "USB3"
                          + "USB4" + "USB5" + "USB6" + "Programming" + "SerialNumber" + "5VRelay" + "BluetoothNUCTest" + "BluetoothNUCAudio" +
                            "12VRelay" + "ErasePairingList" + "PowerOff");
          }

          using (StreamWriter sw = File.AppendText(filename))
          {
            sw.WriteLine(form8.textBox1.Text + "," + form8.textBox2.Text + "," + form8.textBox3.Text + "," + form8.textBox4.Text + "," + form8.textBox5.Text + "," +

                   "," + Convert.ToString(form2.USBHUB) + "," + Convert.ToString(form2.Arduino) + "," + Convert.ToString(form2.CSRSPI) + "," + Convert.ToString(form2.RelayBoard) + "," + Convert.ToString(form2.PowerSupply) + "," + Convert.ToString(form2.SoundCard) +

                 "," + Convert.ToString(form2.DMM) + "," + Convert.ToString(ProgrammingResult) + "," + "," + Convert.ToString(Relay3ON) + "," + Convert.ToString(BTNUC) + "," + Convert.ToString(BTAudio) + "," + Convert.ToString(Relay3OFF)
                + "," + Convert.ToString(ErasePair) + "," + Convert.ToString(PowerOffResult));
          }
        }
        else if (radioButton2.Checked == true)
        {
          if (!File.Exists(filename))
          {
            using (StreamWriter sw = File.AppendText(filename))
            {
              sw.WriteLine("USB1" + "USB2" + "USB3" + "USB4" + "USB5" + "USB6" + "IRBlast" + "Unpairing" + "LeftRelayON" + "LeftAudioMeasurement" + "LeftRelayOFF" +
                              "RightRelayON" + "RightAudioMeasurement" + "RightRelayOff" + "PowerOff");
            }
          }
          else if (radioButton3.Checked == true)
          {
            if (!File.Exists(filename))
            {
              using (StreamWriter sw = File.AppendText(filename))
              {
                sw.WriteLine("PowerUp Current " + "Voltage1" + "Voltage2" + "Voltage3" + "Voltage4" + "USB1" + "USB2" + "USB3"
                      + "USB4" + "USB5" + "USB6" + "Programming" + "SerialNumber" + "5VRelay" + "BluetoothNUCTest" + "BluetoothNUCAudio" +
                        "12VRelay" + "ErasePairingList" + "PowerOff" + "USB1" + "USB2" + "USB3" + "USB4" + "USB5" + "USB6" + "IRBlast" + "Unpairing" + "LeftRelayON" + "LeftAudioMeasurement" + "LeftRelayOFF" +
                                "RightRelayON" + "RightAudioMeasurement" + "RightRelayOff" + "PowerOff");
              }

              using (StreamWriter sw = File.AppendText(filename))
              {
                sw.WriteLine(form8.textBox1.Text + "," + form8.textBox2.Text + "," + form8.textBox3.Text + "," + form8.textBox4.Text + "," + form8.textBox5.Text + "," +

               "," + Convert.ToString(form2.USBHUB) + "," + Convert.ToString(form2.Arduino) + "," + Convert.ToString(form2.CSRSPI) + "," + Convert.ToString(form2.RelayBoard) + "," + Convert.ToString(form2.PowerSupply) + "," + Convert.ToString(form2.SoundCard) +

             "," + Convert.ToString(form2.DMM) + "," + Convert.ToString(ProgrammingResult) + "," + "," + Convert.ToString(Relay3ON) + "," + Convert.ToString(BTNUC) + "," + Convert.ToString(BTAudio) + "," + Convert.ToString(Relay3OFF)
            + "," + Convert.ToString(ErasePair) + "," + Convert.ToString(PowerOffResult) + "," + Convert.ToString(form2.USBHUB) + "," + Convert.ToString(form2.Arduino) + "," + Convert.ToString(form2.CSRSPI) + "," + Convert.ToString(form2.RelayBoard) + "," + Convert.ToString(form2.PowerSupply) + "," + Convert.ToString(form2.SoundCard) +

                 "," + Convert.ToString(form2.DMM) + "," + Convert.ToString(IR) + "," + Convert.ToString(Unpair) + "," + Convert.ToString(Relay0ON) + "," + Convert.ToString(AudioLeft) + "," + Convert.ToString(Relay0OFF) + "," + Convert.ToString(Relay1ON) + "," +
                 Convert.ToString(AudioRight) + "," + Convert.ToString(Relay1OFF) + "," + Convert.ToString(PowerOffResult));
              }
            }
          }
        }
      }
    }

    /// <summary>
    /// The button1_Click
    /// </summary>
    /// <param name="sender">The <see cref="object"/></param>
    /// <param name="e">The <see cref="EventArgs"/></param>
    private void button1_Click(object sender, EventArgs e)
    {
      if (radioButton3.Checked == true)
      {
      /*  form13 = new CB_55_Volume(this);
        form13.ShowDialog();
        button2.Enabled = false;

        /*   USBEnumeration();
           Thread.Sleep(100);

           PSOn();
           Thread.Sleep(1000);

           PowerUp();
           Thread.Sleep(100);

           Programming();
           Thread.Sleep(100);

           RelayOn0();
           Thread.Sleep(100);

           RelayRead0();
           Thread.Sleep(100);

           RelayOnLeft();
           Thread.Sleep(500);

           RelayOnRight();
           Thread.Sleep(500);*/

           BluetoothwithNUC();
           Thread.Sleep(1000);

         /*  BTAudioMeasurement();
           Thread.Sleep(100);

           RelayOff0();
           Thread.Sleep(1000);

           ErasePairingList();
           Thread.Sleep(1000);

           IRBlaster();
           Thread.Sleep(100);

           BluetoothUnPairingwithTB16();
           Thread.Sleep(100);

           RelayOn0();
           Thread.Sleep(100);

           RelayOff0();
           Thread.Sleep(100);

           RelayOnLeft();
           Thread.Sleep(100);

           RelayReadLeft();
           Thread.Sleep(100);*/

   /*     AudioMeasurement_Left();
        Thread.Sleep(500);

        AudioLeftMeasurement();
        Thread.Sleep(100);*/

        /*    RelayOffLeft();
            Thread.Sleep(100);

            RelayOnRight();
            Thread.Sleep(100);

            RelayReadRight();
            Thread.Sleep(100);*/

      /*  AudioMeasurement_Right_1KHz();
        Thread.Sleep(500);

        AudioRightMeasurement();
        Thread.Sleep(100);

        /*   RelayOffRight();
            Thread.Sleep(100);
            LineInLineOut();

            Thread.Sleep(100);
            PSOff();
            Thread.Sleep(1000);

            PowerOff();
            Thread.Sleep(100);

            TestData();
            Thread.Sleep(100);

            Results();
            Thread.Sleep(100);*/

        button2.Enabled = true;
      }
      else if (radioButton1.Checked == true)
      {
        form13 = new CB_55_Volume(this);
        form13.ShowDialog(this);

        /* radioButton2.Enabled = false;
         radioButton2.Visible = false;*/

        button2.Enabled = false;

        USBEnumeration();
        Thread.Sleep(1000);

        PSOn();
        Thread.Sleep(100);

        PowerUp();
        Thread.Sleep(100);

        Programming();
        Thread.Sleep(100);

        RelayOn0();
        Thread.Sleep(100);

        RelayRead0();
        Thread.Sleep(1000);

        RelayOnLeft();
        Thread.Sleep(500);

        RelayOnRight();
        Thread.Sleep(500);

        BluetoothwithNUC();
        Thread.Sleep(1000);

        BTAudioMeasurement();
        Thread.Sleep(100);

        RelayOff0();
        Thread.Sleep(1000);

        ErasePairingList();
        Thread.Sleep(1000);

        PSOff();
        Thread.Sleep(100);

        PowerOff();
        Thread.Sleep(1000);

        TestData();
        Thread.Sleep(100);

        Results();
        Thread.Sleep(1000);

        button2.Enabled = true;
      }
      else if (radioButton2.Checked == true)
      {
        form13 = new CB_55_Volume(this);
        form13.ShowDialog(this);

        /*radioButton1.Visible = false;
        radioButton1.Enabled = false;*/

        button2.Enabled = false;
        USBEnumeration();
        Thread.Sleep(1000);

        PSOn();
        Thread.Sleep(1000);

        PS12V();
        Thread.Sleep(1000);

        IRBlaster();
        Thread.Sleep(100);

        BluetoothUnPairingwithTB16();
        Thread.Sleep(100);

        RelayOn0();
        Thread.Sleep(100);

        RelayOff0();
        Thread.Sleep(100);

        RelayOnLeft();
        Thread.Sleep(100);

        RelayReadLeft();
        Thread.Sleep(100);

        AudioMeasurement_Left();
        Thread.Sleep(500);

        AudioLeftMeasurement();
        Thread.Sleep(500);

        RelayOffLeft();
        Thread.Sleep(100);

        RelayOnRight();
        Thread.Sleep(100);

        RelayReadRight();
        Thread.Sleep(100);

        AudioMeasurement_Right_1KHz();
        Thread.Sleep(500);

        AudioRightMeasurement();
        Thread.Sleep(100);

        RelayOffRight();
        Thread.Sleep(100);

        LineInLineOut();
        Thread.Sleep(100);

        PSOff();
        Thread.Sleep(100);

        PowerOff();
        Thread.Sleep(100);

        TestData();
        Thread.Sleep(100);

        Results();
        Thread.Sleep(100);

        button2.Enabled = true;
      }
    }

    /// <summary>
    /// The button3_Click
    /// </summary>
    /// <param name="sender">The <see cref="object"/></param>
    /// <param name="e">The <see cref="EventArgs"/></param>
    private void button3_Click(object sender, EventArgs e)
    {
      PowerOff();
      Thread.Sleep(1000);
      this.Close();
    }

    /// <summary>
    /// The radioButton1_CheckedChanged
    /// </summary>
    /// <param name="sender">The <see cref="object"/></param>
    /// <param name="e">The <see cref="EventArgs"/></param>
    private void radioButton1_CheckedChanged(object sender, EventArgs e)
    {
      /* radioButton2.Visible = false;
       radioButton2.Enabled = false;*/

      pictureBox1.Enabled = true;
      pictureBox1.Visible = true;

      pictureBox3.Enabled = false;
      pictureBox3.Visible = false;

      pictureBox2.Enabled = false;
      pictureBox2.Visible = false;

      pictureBox4.Enabled = false;
      pictureBox4.Visible = false;

      label1.Enabled = true;
      label1.Visible = true;
      led1.Visible = true;

      label2.Enabled = true;
      label2.Visible = true;
      led2.Visible = true;

      label3.Enabled = true;
      label3.Visible = true;
      led2.Visible = true;

      label4.Enabled = true;
      label4.Visible = true;
      led3.Visible = true;

      label3.Enabled = true;
      label3.Visible = true;
      led4.Visible = true;

      led10.Visible = true;
      led11.Visible = true;

      label4.Enabled = true;
      label4.Visible = true;
      led9.Visible = true;

      label7.Enabled = true;
      label7.Visible = true;
      label18.Enabled = true;
      label18.Visible = true;

      label8.Visible = true;
      label8.Enabled = true;
      led5.Visible = true;

      label10.Visible = true;
      label10.Enabled = true;

      label11.Visible = true;
      label11.Enabled = true;
      led26.Visible = true;

      label9.Visible = false;
      label9.Enabled = false;
      led6.Visible = false;

      label6.Visible = false;
      label6.Enabled = false;
      led7.Visible = false;

      label5.Visible = false;
      label5.Enabled = false;
      led8.Visible = false;

      label26.Visible = false;
      label26.Enabled = false;
      led25.Visible = false;

      label24.Visible = false;
      label24.Enabled = false;
      led23.Visible = false;

      label22.Visible = false;
      label22.Enabled = false;
      led21.Visible = false;

      label25.Visible = false;
      label25.Enabled = false;
      led24.Visible = false;

      label23.Visible = false;
      label23.Enabled = false;
      led22.Visible = false;

      label21.Visible = false;
      label21.Enabled = false;
      led20.Visible = false;

      label12.Visible = true;
      label12.Enabled = true;
      led12.Visible = true;

      this.Refresh();
    }

    /// <summary>
    /// The radioButton2_CheckedChanged
    /// </summary>
    /// <param name="sender">The <see cref="object"/></param>
    /// <param name="e">The <see cref="EventArgs"/></param>
    private void radioButton2_CheckedChanged(object sender, EventArgs e)
    {
      /* radioButton1.Visible = false;
       radioButton1.Enabled = false;*/

      pictureBox3.Enabled = true;
      pictureBox3.Visible = true;

      pictureBox1.Enabled = false;
      pictureBox1.Visible = false;

      pictureBox2.Enabled = false;
      pictureBox2.Visible = false;

      pictureBox4.Enabled = false;
      pictureBox4.Visible = false;

      label1.Enabled = false;
      label1.Visible = false;
      led1.Visible = false;

      label2.Enabled = false;
      label2.Visible = false;
      led2.Visible = false;

      label4.Enabled = true;
      label4.Visible = true;
      led3.Visible = false;

      label3.Enabled = false;
      label3.Visible = false;
      led4.Visible = false;

      led9.Visible = true;

      led10.Visible = false;

      led11.Visible = false;

      label7.Enabled = false;
      label7.Visible = false;

      label8.Enabled = false;
      label8.Visible = false;
      led5.Visible = false;

      label18.Enabled = false;
      label18.Visible = false;

      label10.Enabled = false;
      label10.Visible = false;

      label11.Enabled = false;
      label11.Visible = false;
      led26.Visible = false;

      label9.Visible = true;
      label9.Enabled = true;
      led6.Visible = true;

      label6.Visible = true;
      label6.Enabled = true;
      led7.Visible = true;

      label5.Visible = true;
      label5.Enabled = true;
      led8.Visible = true;

      label26.Visible = true;
      label26.Enabled = true;
      led25.Visible = true;

      label24.Visible = true;
      label24.Enabled = true;
      led23.Visible = true;

      label22.Visible = true;
      label22.Enabled = true;
      led21.Visible = true;

      label25.Visible = true;
      label25.Enabled = true;
      led24.Visible = true;

      label23.Visible = true;
      label23.Enabled = true;
      led22.Visible = true;

      label21.Visible = true;
      label21.Enabled = true;
      led20.Visible = true;

      label12.Visible = false;
      label12.Enabled = false;
      led12.Visible = false;

      label17.Visible = true;
      label17.Enabled = true;
      led17.Visible = true;

      this.Refresh();
    }

    /// <summary>
    /// The button2_Click
    /// </summary>
    /// <param name="sender">The <see cref="object"/></param>
    /// <param name="e">The <see cref="EventArgs"/></param>
    private void button2_Click(object sender, EventArgs e)
    {
      RelayPort.Close();
      form8.DMM.Close();
      Arduino.Close();
      PS.Close();

      label1.Enabled = false;
      label1.Visible = true;
      led1.OffColor = Color.Black;

      label4.Enabled = false;
      label4.Visible = true;
      led9.OffColor = Color.Black;

      label2.Enabled = false;
      label2.Visible = true;
      led10.OffColor = Color.Black;

      label3.Enabled = false;
      label3.Visible = true;
      led11.OffColor = Color.Black;

      label7.Enabled = false;
      label7.Visible = true;
      led2.OffColor = Color.Black;

      label8.Enabled = false;
      label8.Visible = true;
      led5.OffColor = Color.Black;

      label18.Enabled = false;
      label18.Visible = true;
      led3.OffColor = Color.Black;

      label10.Enabled = false;
      label10.Visible = true;
      led4.OffColor = Color.Black;

      label11.Enabled = false;
      label11.Visible = true;
      led26.OffColor = Color.Black;

      label9.Enabled = false;
      label9.Visible = true;
      led6.OffColor = Color.Black;

      label6.Enabled = false;
      label6.Visible = true;
      led7.OffColor = Color.Black;

      label5.Enabled = false;
      label5.Visible = true;
      led8.OffColor = Color.Black;

      label26.Enabled = false;
      label26.Visible = true;
      led25.OffColor = Color.Black;

      label24.Enabled = false;
      label24.Visible = true;
      led23.OffColor = Color.Black;

      label22.Enabled = false;
      label22.Visible = true;
      led21.OffColor = Color.Black;

      label25.Enabled = false;
      label25.Visible = true;
      led24.OffColor = Color.Black;

      label23.Enabled = false;
      label23.Visible = true;
      led22.OffColor = Color.Black;

      label21.Enabled = false;
      label21.Visible = true;
      led20.OffColor = Color.Black;

      label12.Enabled = true;
      label12.Visible = true;
      led12.OffColor = Color.Black;

      label17.Enabled = false;
      label17.Visible = true;
      led17.OffColor = Color.Black;

      label27.Enabled = false;
      label27.Visible = true;
      led27.OffColor = Color.Black;

      label28.Enabled = false;
      label28.Visible = true;
      led28.OffColor = Color.Black;

      label29.Enabled = false;
      label29.Visible = true;
      led13.OffColor = Color.Black;

      label32.Enabled = false;
      label32.Visible = true;
      led32.OffColor = Color.Black;

      label31.Enabled = false;
      label31.Visible = true;
      led31.OffColor = Color.Black;

      label30.Enabled = false;
      label30.Visible = true;
      led30.OffColor = Color.Black;

      this.Refresh();
    }

    /// <summary>
    /// The Form1_FormClosed
    /// </summary>
    /// <param name="sender">The <see cref="object"/></param>
    /// <param name="e">The <see cref="FormClosedEventArgs"/></param>
    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
    }

    /// <summary>
    /// The radioButton3_CheckedChanged
    /// </summary>
    /// <param name="sender">The <see cref="object"/></param>
    /// <param name="e">The <see cref="EventArgs"/></param>
    private void radioButton3_CheckedChanged(object sender, EventArgs e)
    {
      pictureBox2.Enabled = true;
      pictureBox2.Visible = true;

      pictureBox4.Enabled = true;
      pictureBox4.Visible = true;

      pictureBox1.Enabled = false;
      pictureBox1.Visible = false;

      pictureBox3.Enabled = false;
      pictureBox3.Visible = false;

      label1.Enabled = true;
      label1.Visible = true;
      led1.Visible = true;

      label2.Enabled = true;
      label2.Visible = true;
      led2.Visible = true;

      label3.Enabled = true;
      label3.Visible = true;
      led2.Visible = true;

      label4.Enabled = true;
      label4.Visible = true;
      led3.Visible = true;

      label3.Enabled = true;
      label3.Visible = true;
      led4.Visible = true;

      led10.Visible = true;
      led11.Visible = true;

      label4.Enabled = true;
      label4.Visible = true;
      led9.Visible = true;

      label7.Enabled = true;
      label7.Visible = true;
      label18.Enabled = true;
      label18.Visible = true;

      label8.Visible = true;
      label8.Enabled = true;
      led5.Visible = true;

      label10.Visible = true;
      label10.Enabled = true;

      label11.Visible = true;
      label11.Enabled = true;
      led26.Visible = true;

      label9.Visible = true;
      label9.Enabled = true;
      led6.Visible = true;

      label6.Visible = true;
      label6.Enabled = true;
      led7.Visible = true;

      label5.Visible = true;
      label5.Enabled = true;
      led8.Visible = true;

      label26.Visible = true;
      label26.Enabled = true;
      led25.Visible = true;

      label24.Visible = true;
      label24.Enabled = true;
      led23.Visible = true;

      label22.Visible = true;
      label22.Enabled = true;
      led21.Visible = true;

      label25.Visible = true;
      label25.Enabled = true;
      led24.Visible = true;

      label23.Visible = true;
      label23.Enabled = true;
      led22.Visible = true;

      label21.Visible = true;
      label21.Enabled = true;
      led20.Visible = true;

      label12.Visible = true;
      label12.Enabled = true;
      led12.Visible = true;

      this.Refresh();
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }
  }
}
