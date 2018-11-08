using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Threading;
using USBDeviceEnumerator;

namespace CMBT
{
    public partial class USBEnumeration : Form
    {
        Form1 Main;

        public bool USBHUB = true;
        public bool Arduino = true;
        public bool CSRSPI = true;
        public bool RelayBoard = true;
        public bool PowerSupply = true;
        public bool SoundCard = true;
        public bool DMM = true;


        public USBEnumeration(Form1 parent)
        {
            InitializeComponent();
            Main = parent;



        }


        private void button1_Click(object sender, EventArgs e)
        {



            // This section of the Program works on the Verification part by showcasing the Led's Color - Green/Red as Pass/Fail based on the VID's and PID's of a USB device//.


            // Get all attached USB devices
            Cursor.Current = Cursors.WaitCursor;
            richTextBox1.AppendText("Enumerating USB devices...\r\n");
            IList<ManagementBaseObject> usb_devices = USBDevices.GetUsbDevices();
            // Find a specific device
            richTextBox1.AppendText("Searching for specific device...\r\n");
            foreach (var device in usb_devices)
            {
                if (device.GetPropertyValue("PNPDeviceID").ToString().Contains("USB\\VID_2109&PID_0813\\"))
                    richTextBox1.AppendText(string.Format("PNPDeviceID: {0}\r\n", device.GetPropertyValue("PNPDeviceID").ToString()));

                if (device.GetPropertyValue("PNPDeviceID").ToString().Contains("USB\\VID_0A12&PID_0042\\"))
                    richTextBox1.AppendText(string.Format("PNPDeviceID: {0}\r\n", device.GetPropertyValue("PNPDeviceID").ToString()));

                if (device.GetPropertyValue("PNPDeviceID").ToString().Contains("USB\\VID_2341&PID_8037\\"))
                    richTextBox1.AppendText(string.Format("PNPDeviceID: {0}\r\n", device.GetPropertyValue("PNPDeviceID").ToString()));

                if (device.GetPropertyValue("PNPDeviceID").ToString().Contains("USB\\VID_2A19&PID_0C01\\"))
                    richTextBox1.AppendText(string.Format("PNPDeviceID: {0}\r\n", device.GetPropertyValue("PNPDeviceID").ToString()));

                if (device.GetPropertyValue("PNPDeviceID").ToString().Contains("USB\\VID_10C4&PID_EA60\\"))
                    richTextBox1.AppendText(string.Format("PNPDeviceID: {0}\r\n", device.GetPropertyValue("PNPDeviceID").ToString()));

                if (device.GetPropertyValue("PNPDeviceID").ToString().Contains("USB\\VID_08BB&PID_2902\\"))
                    richTextBox1.AppendText(string.Format("PNPDeviceID: {0}\r\n", device.GetPropertyValue("PNPDeviceID").ToString()));

                if (device.GetPropertyValue("PNPDeviceID").ToString().Contains("USB\\VID_10C4&PID_EA60\\"))
                    richTextBox1.AppendText(string.Format("PNPDeviceID: {0}\r\n", device.GetPropertyValue("PNPDeviceID").ToString()));

            }

            //USB HUB//

            if (richTextBox1.Text.Contains("PNPDeviceID: USB\\VID_2109&PID_0813\\5&E5DF9A9&0&10"))
            {
                led1.OffColor = Color.LawnGreen;
                USBHUB = true;
            }

            else
            {
                led1.OffColor = Color.Red;
                MessageBox.Show("Check the USB HUB connections");
                USBHUB = false;

            }

            Thread.Sleep(100);
            this.Refresh();

            //Arduino Micro//

            if (richTextBox1.Text.Contains("PNPDeviceID: USB\\VID_2341&PID_8037\\6&1017580D&0&4"))
            {
                led2.OffColor = Color.LawnGreen;
                Arduino = true;
            }

            else
            {
                led2.OffColor = Color.Red;
                MessageBox.Show("Check Arduino Micro Connections");
                Arduino = false;

            }

            Thread.Sleep(100);
            this.Refresh();


            //CSR SPI Programmer//
            if (richTextBox1.Text.Contains("PNPDeviceID: USB\\VID_0A12&PID_0042\\248956"))
            {
                led3.OffColor = Color.LawnGreen;
                CSRSPI = true;
            }

            else
            {
                led3.OffColor = Color.Red;
                MessageBox.Show("Check Programmer Connections");
                CSRSPI = false;

            }

            Thread.Sleep(100);
            this.Refresh();



            //Relay Board//

            if (richTextBox1.Text.Contains("PNPDeviceID: USB\\VID_2A19&PID_0C01\\6&1017580D&0&3"))
            {
                led4.OffColor = Color.LawnGreen;
                RelayBoard = true;
            }

            else
            {
                led4.OffColor = Color.Red;
                MessageBox.Show("Check the Relay Board connections");
                RelayBoard = false;

            }

            Thread.Sleep(100);
            this.Refresh();


            //Power Supply Check//
            if (richTextBox1.Text.Contains("PNPDeviceID: USB\\VID_10C4&PID_EA60\\0001"))
            {
                led5.OffColor = Color.LawnGreen;
                PowerSupply = true;
            }

            else
            {
                led5.OffColor = Color.Red;
                MessageBox.Show("Check the Power Supply Connections");
                PowerSupply = false;

            }

            Thread.Sleep(100);
            this.Refresh();


            //Sound Card//

            if (richTextBox1.Text.Contains("PNPDeviceID: USB\\VID_08BB&PID_2902\\6&1017580D&0&1"))
            {
                led6.OffColor = Color.LawnGreen;
                SoundCard = true;
            }

            else
            {
                led6.OffColor = Color.Red;
                MessageBox.Show("Check the Sound Connections");
                SoundCard = false;
            }

            Thread.Sleep(100);
            this.Refresh();



            //DMM check//
            if (richTextBox1.Text.Contains("PNPDeviceID: USB\\VID_10C4&PID_EA60\\5&E5DF9A9&0&4"))
            {
                led7.OffColor = Color.LawnGreen;
                DMM = true;
            }

            else
            {
                led7.OffColor = Color.Red;
                MessageBox.Show("Check the DMM Connections");
                DMM = false;

            }

            Thread.Sleep(100);
            this.Refresh();


        }

        private void USBEnumeration_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

            this.Dispose();
        }

        }
    }


    