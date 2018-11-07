namespace CMBT
{
  using InTheHand.Net.Bluetooth;
  using InTheHand.Net.Sockets;
  using System;
  using System.Drawing;
  using System.Threading;
  using System.Windows.Forms;

  /// <summary>
  /// Defines the <see cref="BTAuto" />
  /// </summary>
  public partial class BTAuto : Form
  {
    /// <summary>
    /// Defines the Main
    /// </summary>
    private Form1 Main;

    /// <summary>
    /// Defines the form13
    /// </summary>
    private ButtonPressBT form13;

    /// <summary>
    /// Defines the form11
    /// </summary>
    private BTAudioMeasurement_Left form11;

    /// <summary>
    /// Defines the form12
    /// </summary>
    private BTAudioMeasurement_Right form12;

    /// <summary>
    /// Initializes a new instance of the <see cref="BTAuto"/> class.
    /// </summary>
    /// <param name="parent">The <see cref="Form1"/></param>
    public BTAuto(Form1 parent)
    {
      InitializeComponent();
      Main = parent;
    }

    /// <summary>
    /// The button1_Click
    /// </summary>
    /// <param name="sender">The <see cref="object"/></param>
    /// <param name="e">The <see cref="EventArgs"/></param>
    private void button1_Click(object sender, EventArgs e)
    {
      button2.Enabled = false;
      button3.Enabled = false;
      form13 = new ButtonPressBT(this);
      form13.ShowDialog(this);

      DialogResult result1 = MessageBox.Show("Is the Blue LED blinking?", "Bluetooth Verification", MessageBoxButtons.YesNoCancel);
      if (result1 == DialogResult.Yes)
      {
        scan();
        Thread.Sleep(2000);
      }
      else if (result1 == DialogResult.No)
      {
        MessageBox.Show("Press the pairing button again");
      }

      Thread.Sleep(500);
      this.Refresh();
      // form11.BTAudioMeasurement_Load(null, new EventArgs());
      button1.Enabled = false;
      button3.Enabled = true;
    }

    /********************************************************************************************************
     * This section of the code focuses on                                                                  *
     * "Scan, Pair and Connect to JBAR"                                                                     *
     *                                                                                                      *
     *  The steps are as follows:                                                                           *
     *                                                                                                      *
     * 1. Scans the enivronment for the available Bluetooth Devices                                         *
     * 2. Looks for "Frontrow Juno XXXX" Bluetooth Device (JBAR should be in pairing mode)                  *
     * 3. Sends a pairing request                                                                           *
     * 4. Notifies the user about the pairing                                                               *
     * 5. It pairs and connects with the JBAR automatically                                                 *
     * *****************************************************************************************************/
    /// <summary>
    /// The scan
    /// </summary>
    private void scan()
    {
      Cursor.Current = Cursors.WaitCursor;

      BluetoothRadio.PrimaryRadio.Mode = RadioMode.Connectable;
      BluetoothClient client = new BluetoothClient();
      BluetoothDeviceInfo[] devices = client.DiscoverDevices();
      BluetoothClient bluetoothClient = new BluetoothClient();
      String authenticated;
      String classOfDevice;
      String connected;
      String deviceAddress;
      String deviceName;
      String installedServices;
      String lastSeen;
      String lastUsed;
      String remembered;
      String rssi;
      foreach (BluetoothDeviceInfo device in devices)
      {
          try
          {
              authenticated = device.Authenticated.ToString();
              classOfDevice = device.ClassOfDevice.ToString();
              connected = device.Connected.ToString();
              deviceAddress = device.DeviceAddress.ToString();
              deviceName = device.DeviceName.ToString();
              installedServices = device.InstalledServices.ToString();
              lastSeen = device.LastSeen.ToString();
              lastUsed = device.LastUsed.ToString();
              remembered = device.Remembered.ToString();
              rssi = device.Rssi.ToString();
              string[] row = new string[] { authenticated, classOfDevice, connected, deviceAddress, deviceName, installedServices, lastSeen, lastUsed, remembered, rssi };
              dataGridView1.Rows.Add(row);
          }

          catch
          {
              MessageBox.Show("Error Occured during Scanning the devices");

          }

        if (device.DeviceName.Contains("FrontRow"))
        {
          BluetoothSecurity.PairRequest(device.DeviceAddress, " ");
          Cursor.Current = Cursors.Default;
            break;
        }

                                                
      }

      this.Refresh();
    }

     

    /************************************************************
     * This section of the code focuses on                      *
     * "Removal of the Paired Device"                           *
     *                                                          *
     * Removal of the device conatins two steps:                *
     *                                                          *
     * 1. Disconnect the device from Windows 10 PC              *
     * 2. Remove the device from the pairing list on CMBT       *
     * *********************************************************/
    /// <summary>
    /// The RemoveDevice
    /// </summary>
    private void RemoveDevice()
    {
      BluetoothRadio.PrimaryRadio.Mode = RadioMode.Connectable;
      BluetoothClient client = new BluetoothClient();
      BluetoothDeviceInfo[] devices = client.DiscoverDevices();
      BluetoothClient bluetoothClient = new BluetoothClient();
      String authenticated;
      String classOfDevice;
      String connected;
      String deviceAddress;
      String deviceName;
      String installedServices;
      String lastSeen;
      String lastUsed;
      String remembered;
      String rssi;
      foreach (BluetoothDeviceInfo device in devices)
      {
        authenticated = device.Authenticated.ToString();
        classOfDevice = device.ClassOfDevice.ToString();
        connected = device.Connected.ToString();
        deviceAddress = device.DeviceAddress.ToString();
        deviceName = device.DeviceName.ToString();
        installedServices = device.InstalledServices.ToString();
        lastSeen = device.LastSeen.ToString();
        lastUsed = device.LastUsed.ToString();
        remembered = device.Remembered.ToString();
        rssi = device.Rssi.ToString();
        string[] row = new string[] { authenticated, classOfDevice, connected, deviceAddress, deviceName, installedServices, lastSeen, lastUsed, remembered, rssi };
        dataGridView1.Rows.Add(row);

        if (device.DeviceName.Contains("CM-BT"))
        {
          led1.OffColor = Color.LawnGreen;
                    BluetoothSecurity.RemoveDevice(device.DeviceAddress); // This disconnects and removes the device from the pairing list
        }
        else
        {
          // led1.OffColor = Color.Red;
        }
      }
      this.Refresh();
    }

    /// <summary>
    /// The CheckDevice
    /// </summary>
    private void CheckDevice()
    {
      BluetoothRadio.PrimaryRadio.Mode = RadioMode.Connectable;
      BluetoothClient client = new BluetoothClient();
      BluetoothDeviceInfo[] devices = client.DiscoverDevices();
      BluetoothClient bluetoothClient = new BluetoothClient();
      String authenticated;
      String classOfDevice;
      String connected;
      String deviceAddress;
      String deviceName;
      String installedServices;
      String lastSeen;
      String lastUsed;
      String remembered;
      String rssi;
      foreach (BluetoothDeviceInfo device in devices)
      {
        authenticated = device.Authenticated.ToString();
        classOfDevice = device.ClassOfDevice.ToString();
        connected = device.Connected.ToString();
        deviceAddress = device.DeviceAddress.ToString();
        deviceName = device.DeviceName.ToString();
        installedServices = device.InstalledServices.ToString();
        lastSeen = device.LastSeen.ToString();
        lastUsed = device.LastUsed.ToString();
        remembered = device.Remembered.ToString();
        rssi = device.Rssi.ToString();
        string[] row = new string[] { authenticated, classOfDevice, connected, deviceAddress, deviceName, installedServices, lastSeen, lastUsed, remembered, rssi };
        dataGridView1.Rows.Add(row);

        if (device.Connected.Equals(true))
        {
          led4.OffColor = Color.LawnGreen;
          //BluetoothSecurity.RemoveDevice(device.DeviceAddress); // This disconnects and removes the device from the pairing list
        }
        else
        {
          //  led4.OffColor = Color.Red;
        }
      }
      this.Refresh();
    }

    /*private void sendfile()
{
    WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

    wplayer.URL = "C:\\Users\\vaka\\Desktop\\Stereo_Audio_Test_Left_Right[ListenVid.com].mp3";
}

private void button3_Click(object sender, EventArgs e)
{
    sendfile();
}*/
    /// <summary>
    /// The AudioPlay_Left
    /// </summary>
    private void AudioPlay_Left()
    {
      form11 = new BTAudioMeasurement_Left(this);
      form11.ShowDialog(this);
      if (form11.led1.OffColor == Color.LawnGreen)
      {
        led2.OffColor = Color.LawnGreen;
      }
      else
      {
        led2.OffColor = Color.Red;
      }
    }

    /// <summary>
    /// The AudioPlay_Right
    /// </summary>
    private void AudioPlay_Right()
    {
      form12 = new BTAudioMeasurement_Right(this);
      form12.ShowDialog(this);
      button2.Enabled = true;
      if (form12.led1.OffColor == Color.LawnGreen)
      {
        led3.OffColor = Color.LawnGreen;
      }
      else
      {
        led3.OffColor = Color.Red;
      }
    }

    /// <summary>
    /// The button2_Click
    /// </summary>
    /// <param name="sender">The <see cref="object"/></param>
    /// <param name="e">The <see cref="EventArgs"/></param>
    private void button2_Click(object sender, EventArgs e)
    {
      RemoveDevice();
      Thread.Sleep(1000);
    }

    /// <summary>
    /// The button3_Click
    /// </summary>
    /// <param name="sender">The <see cref="object"/></param>
    /// <param name="e">The <see cref="EventArgs"/></param>
    private void button3_Click(object sender, EventArgs e)
    {
      CheckDevice();
      // Thread.Sleep(1000);

      if (led4.OffColor == Color.LawnGreen)
      {
        AudioPlay_Left();
        Thread.Sleep(1000);

        AudioPlay_Right();
        Thread.Sleep(1000);

        this.Refresh();
      }
      else if (led4.OffColor == Color.Red)
      {
        MessageBox.Show("Bluetooth Connection Failed");
      }

      this.Refresh();

      button3.Enabled = false;
      button2.Enabled = true;
    }

    /// <summary>
    /// The button4_Click
    /// </summary>
    /// <param name="sender">The <see cref="object"/></param>
    /// <param name="e">The <see cref="EventArgs"/></param>
    private void button4_Click(object sender, EventArgs e)
    {
      this.Close();
      this.Dispose();
    }
  }
}
