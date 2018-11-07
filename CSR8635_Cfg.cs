/********************************************************************************
 *                      Module - CSR8635_Cfg.cs                                 *
 *                                                                              *
 *  This module contains the implementation of the CSR8635_Cfg class for        *
 *  programming the persistent storage registers of the CSR8635 Bluetooth       *
 *  module.                                                                     *
 *                                                                              *
 *                      ********************                                    *
 *                      * REVISION HISTORY *                                    *
 *                      ********************                                    *
 *                                                                              *
 *         Date         Author          Revisions                               *
 *      ===========     ======          =========                               *
 *      04-Jan-2018     J. Ono          * Extend byte array in DecodeDeviceName *
 *                                        to prevent exception when name is     *
 *                                        longer than 20 characters.            *
 *                                      * Added two second delay before cold    *
 *                                        reset in Program().                   *
 *                                                                              *
 *      03-Jan-2018     J. Ono          * Added PlayAudio() function.           *
 *                                      * Added Reset() function.               *
 *                                                                              *
 *      01-Jan-2018     J. Ono          * Added remaining INI functions.        *
 *                                      * Added remaining PSR configuration     *
 *                                        functions.                            *
 *                                                                              *
 *      11-Aug-2017     J. Ono          * Creation.                             *
 *                                                                              *
 ********************************************************************************/
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using TestEngineAPI;
using INIFileAPI;
#if OK_TO_USE_NLOG
  using NLog;
#endif
using System.Threading;
using NAudio.Wave;

namespace CSR8635_API
{
  /// <summary>
  /// This class provides functions to control the configuration and programming
  /// of the persistent store registers of the CSR8635 Bluetooth module using an
  /// INI file to specify certain parameters and paths.  A PlayAudio() function is
  /// also provided to play an audio file through the default output.
  /// </summary>
  public class CSR8635
  {
        /******************
         *    Constants   *
         ******************/

    // Persistent Store definitions
    private const ushort PS_STORES_DEFAULT = 0x0000,    /* default */
                         PS_STORES_I = 0x0001,          /* implementation (normal) */
                         PS_STORES_F = 0x0002,          /* factory-set */
                         PS_STORES_R = 0x0004,          /* ROM (read-only) */
                         PS_STORES_T = 0x0008,          /* transient (RAM) */
                         PS_STORES_A = 0x0010,          /* PSFS */
                         PS_STORES_FR = 0x0006,
                         PS_STORES_IF = 0x0003,
                         PS_STORES_IFR = 0x0007,
                         PS_STORES_IFAR = 0x0017,
                         PSKEY_DEVICE_NAME = 0x0108;

    /// <summary>
    /// The default path for the INI file.
    /// </summary>
    private const string DEFAULT_INI_PATH = ".\\BTA_Config.ini";

    /// <summary>
    /// The name of the device parameters section in the INI file.
    /// </summary>
    private const string DEVICE_SECTION = "DeviceParms";

    /// <summary>
    /// The key for the chip display name.
    /// </summary>
    private const string CHIP_NAME_KEY = "ChipDisplayName";

    /// <summary>
    /// The key for the device name base string.
    /// </summary>
    private const string DEVICE_NAME_KEY = "DeviceNameBase";

    /// <summary>
    /// The key for the PSR file path.
    /// </summary>
    private const string PSR_PATH_KEY = "PSRPath";

    /// <summary>
    /// The name of the serialization parameters section in the INI file.
    /// </summary>
    private const string SERIAL_SECTION = "Serialization";

    /// <summary>
    /// The key for the serial number format specifier.
    /// </summary>
    private const string SERIAL_FMT_KEY = "SerialNumFmt";

    /// <summary>
    /// The key for the minium serial number value.
    /// </summary>
    private const string MIN_SERIAL_KEY = "MinSerialNum";

    /// <summary>
    /// The key for the maxium serial number value.
    /// </summary>
    private const string MAX_SERIAL_KEY = "MaxSerialNum";

    /// <summary>
    /// The key for the next serial number value.
    /// </summary>
    private const string NEXT_SERIAL_KEY = "NextSerialNum";

    /// <summary>
    /// The default expected chipset name for our Bluetooth module.
    /// </summary>
    private const string DEFAULT_CHIP_DISPLAY_NAME = "CSR8635";

    /// <summary>
    /// The default base string for the PSKEY_DEVICE_NAME field.
    /// </summary>
    private const string DEFAULT_NAME_BASE = "FrontRow Juno";

    /// <summary>
    /// The default minimum serial number.
    /// </summary>
    private const Int32 DEFAULT_MIN_SERIAL_NUM = 0;

    /// <summary>
    /// The default maximum serial number before rolling over.
    /// </summary>
    private const Int32 DEFAULT_MAX_SERIAL_NUM = 9999;

    /// <summary>
    /// The default serial number format for string representation.
    /// This MUST accommodate MAX_SERIAL_NUM.
    /// </summary>
    private const string DEFAULT_SERIAL_NUM_FMT = "D4";

    /// <summary>
    /// The maximum string length for various device fields.
    /// </summary>
    private const int NAME_LEN = 32;

    /**************
     *    Data    *
     **************/

    /// <summary>
    /// The persistent store file path.
    /// </summary>
    private static string _psr_path = "";

    /// <summary>
    /// The expected chipset name for our Bluetooth module.
    /// </summary>
    private static string _chip_display_name = DEFAULT_CHIP_DISPLAY_NAME;

    /// <summary>
    /// The base string for the PSKEY_DEVICE_NAME field.
    /// </summary>
    private static string _dev_name_base = DEFAULT_NAME_BASE;

    /// <summary>
    /// The minimum serial number.
    /// </summary>
    private static Int32 _min_serial_num = DEFAULT_MIN_SERIAL_NUM;

    /// <summary>
    /// The maximum serial number before rolling over.
    /// </summary>
    private static Int32 _max_serial_num = DEFAULT_MAX_SERIAL_NUM;

    /// <summary>
    /// The serial number format for string representation.
    /// This MUST accommodate _max_serial_num.
    /// </summary>
    private static string _serial_num_fmt = DEFAULT_SERIAL_NUM_FMT;

    /// <summary>
    /// The next serial number to use.
    /// </summary>
    private static Int32 _next_serial_num = 0;

    /// <summary>
    /// The logging object for this class.
    /// </summary>
#if OK_TO_USE_NLOG
    private static Logger _logger = LogManager.GetCurrentClassLogger();
#endif

    /// <summary>
    /// The INI path.
    /// </summary>
    private static string _ini_filename = DEFAULT_INI_PATH;

    /// <summary>
    /// The last name successfully written to a module.
    /// </summary>
    private static string _last_device_name = "";

    /// <summary>
    /// The device handle of the SPI programmer.
    /// </summary>
    private static uint _dev_handle = 0;

      /******************
       *    Functions   *
       ******************/

    /// <summary>
    /// Displays a MessageBox with caption and logs the error to the class logger.
    /// Note that the class logger has been configured to include a colored console target.
    /// </summary>
    /// <param name="caption">The caption for the MessageBox.</param>
    /// <param name="msg">The main text of the error message.</param>
    public static void ErrorMsg(string caption, string msg)
    {
      string error_msg = String.Format("*** {0} ***", msg);

#if OK_TO_USE_NLOG
        // Log to class logger
      _logger.Error(error_msg);
#endif

        // Display error message to user
      MessageBox.Show(error_msg,
                      caption,
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error,
                      MessageBoxDefaultButton.Button1);
    }       // End function ErrorMsg

    /// <summary>
    /// Logs the specified string as Info to the class logger.
    /// </summary>
    /// <param name="msg">The string to log.</param>
    public static void InfoMsg(string msg)
    {
      string info_msg = String.Format(">>> {0} <<<", msg);

      // Log to class logger as info
#if OK_TO_USE_NLOG
      _logger.Info(info_msg);
#endif
    }       // End function InfoMsg

    /// <summary>
    /// Tries to open the USB-SPI programming adapter.
    /// </summary>
    /// <param name="handle">The device handle.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
    public static bool OpenSpiAdapter(ref uint handle)
    {
      bool ret_value = true;  // Default return

      if (handle == 0)  // Not already open
        try
       {
          handle = TestEngine.openTestEngineSpi(-1, 0, 2);  // Try to open SPI interface
          if (handle == 0)
          {
            ErrorMsg("SPI Programmer", "Could not find SPI-USB adapter!");
            ret_value = false;
          }
          else
          {
            InfoMsg("SPI-USB programmer OPENED.");
          }
        }
        catch
        {
          ErrorMsg("SPI Programmer", "Could not open SPI-USB adapter!");
          handle = 0;
          ret_value = false;
        }

      else  // Already open
      {
        InfoMsg("SPI-USB programmer already open.");
      }
      return(ret_value);
    }       // End function OpenSpiAdapter

    /// <summary>
    /// Tries to close the USB-SPI adapter and clears the handle.
    /// </summary>
    /// <param name="dev_handle">The device handle.</param>
    /// <returns><c>true</c> if handle was open on entry, <c>false</c> otherwise.</returns>
    public static bool CloseSPIAdapter(ref uint dev_handle)
    {
      if (dev_handle != 0)                        // If device is open
      {
        TestEngine.closeTestEngine(dev_handle);   //   Close the device
        dev_handle = 0;                           //   Clear the handle
        InfoMsg("USB-SPI adapter closed.");
        return (true);
      }
      else
      {
        InfoMsg("USB-SPI adapter already closed.");
        return (false);
      }
    }       // End function CloseSPIAdapter

    /// <summary>
    /// Performs a cold reset of the device.
    /// </summary>
    /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
    public static bool ColdBoot()
    {
      if (_dev_handle == 0) // If no valid handle
      {
        ErrorMsg("ColdBoot Error", "Device is not open!");
        return (false);
      }
      else
        InfoMsg("Rebooting module...");

      Int32 ret_val = TestEngine.bccmdSetColdReset(_dev_handle, 0);

      switch (ret_val)
      {
        case -1:
          ErrorMsg("ColdBoot Error", "Invalid device handle!");
          break;

        case 0:
          ErrorMsg("ColdBoot Failure", "Failed to cold reset!");
          break;

        case 1: // Success
          InfoMsg("Device rebooted.");
          return (true);

        default:
          ErrorMsg("ColdBoot Error", "Unknown return value!");
          break;
      }
      return (false);   // Default return
    }

    /// <summary>
    /// Returns the current serial number to use from the INI file.
    /// </summary>
    /// <returns>Int32.</returns>
    public static Int32 GetSerialNumber()
    {
      StringBuilder name = new StringBuilder(NAME_LEN);
      Int32 return_val;

      string serial_no = INIFile.ReadValue(SERIAL_SECTION,
                                           NEXT_SERIAL_KEY,
                                           _ini_filename,
                                           _min_serial_num.ToString(_serial_num_fmt));
      return_val = Convert.ToInt32(serial_no);  // Convert string to integer
      if (return_val < _min_serial_num)         // Limit minimum
        return_val = _min_serial_num;
      else
        if (return_val > _max_serial_num)       // Limit maximum
          return_val = _max_serial_num;
      InfoMsg("Current serial number = " + return_val.ToString(_serial_num_fmt));
      return(return_val);
    }       // End function GetSerialNumber

    /// <summary>
    /// Increments the specified serial number and saves it in the INI file.
    /// </summary>
    /// <param name="serial_num">The current serial number.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
    private static bool SaveNextSerialNumber(ref Int32 serial_num)
    {
      serial_num++;                     // Increment
      if (serial_num > _max_serial_num) // Rollover, if necessary
        serial_num = _min_serial_num;

      string serial_no = serial_num.ToString(_serial_num_fmt);

        // Save to INI file
      if (!INIFile.WriteValue(SERIAL_SECTION,
                              NEXT_SERIAL_KEY,
                              serial_no,
                              _ini_filename))
      {
        ErrorMsg("INI File Error", "Could not save serial number to INI file!");
        return(false);
      }
      else
      {
        InfoMsg("Updated serial number (" + serial_no + ") saved to " + _ini_filename + ".");
        return (true);
      }
    }       // End function SaveNextSerialNumber

    /// <summary>
    /// Decodes a PSKEY_DEVICE_NAME value from an array of 16-bit words into a string.
    /// </summary>
    /// <param name="device_name">Name of the device as returned from module in an
    /// array of 16-bit words.</param>
    /// <param name="words">The number of 16-bit words in the name.</param>
    /// <returns>System.String-version of device name.</returns>
    private static string DecodeDeviceName(ushort[] device_name, ushort words)
    {
      byte[] name_arr = new byte[100];
      int len = 0;

      for (int i = 0; i < words; i++)
      {
        byte b = (byte)(device_name[i] & 0xFF);

        if (b != 0x00)                      // If non-null byte
        {
          name_arr[len++] = b;              //   Save it
          b = (byte)(device_name[i] >> 8);  //   Get the next char
          if (b != 0x00)                    //   If non-null
            name_arr[len++] = b;            //     Save it
        }
      }
      Array.Resize(ref name_arr, len);  // Truncate the array
      return (Encoding.ASCII.GetString(name_arr, 0, name_arr.Length));
    }       // End function DecodeDeviceName

    /// <summary>
    /// Encodes a string as an array of 16-bit words for use as PSKEY_DEVICE_NAME.
    /// </summary>
    /// <param name="device_name">String name of the device.</param>
    /// <param name="name_array">The resulting array of 16-bit words formatted for PSKEY_DEVICE_NAME. 
    /// Note that the array will be resized by this function.</param>
    /// <returns>Number of words in array.</returns>
    private static ushort EncodeDeviceName(string device_name, ref ushort[] name_array)
    {
      int string_len = device_name.Length;
      byte[] name_str = Encoding.ASCII.GetBytes(device_name);
      ushort words = (ushort)(string_len / 2);
      int byte_index = 0;

      Array.Resize(ref name_array, words + 1);  // Ensure that array is large enough
      for (int i = 0; i < words; i++)
      {
        name_array[i] = (ushort)(name_str[byte_index++]);
        name_array[i] |= (ushort)((ushort)(name_str[byte_index++]) << 8);
      }
      if ((string_len & 1) != 0)                              // If odd number of bytes
        name_array[words++] = (ushort)(name_str[byte_index]); //   Store the last byte
      return (words);
    }       // End function EncodeDeviceName

    /// <summary>
    /// Returns the PSKEY_DEVICE_NAME value as a string.
    /// </summary>
    /// <returns>System.String.</returns>
    private static string GetDeviceName()
    {
      const ushort ARRAY_LEN = 20;
      ushort[] key_data = new ushort[ARRAY_LEN];
      ushort len;
      string device_name = "";  // Default string
      int ret_val = TestEngine.psRead(_dev_handle, PSKEY_DEVICE_NAME, PS_STORES_I, ARRAY_LEN, key_data, out len);
      switch(ret_val)
      {
        case -1:
          ErrorMsg("Error Getting Device Name", "Invalid device handle!");
          break;

        case 0:
          ErrorMsg("Error Getting Device Name", "ERROR!");
          break;

        case 1: // Success
          device_name = DecodeDeviceName(key_data, len);  // Unscramble data
          InfoMsg("Device name: " + device_name);
          break;

        case 2:
          ErrorMsg("Error Getting Device Name", "Unsupported function!");
          break;

        default:
          ErrorMsg("Error Getting Device Name", "Unknown return value!");
          break;
      }
      return (device_name); 
    }       // End function GetDeviceName

    /// <summary>
    /// Returns the existing device name if it is possibly valid.  Null otherwise
    /// </summary>
    /// <returns>System.String.</returns>
    private static string ValidDeviceName()
    {
      string dev_name = GetDeviceName();

      if (dev_name.Length >= _dev_name_base.Length + 1)
      {
        string dev_str = dev_name.Substring(0, _dev_name_base.Length);
        if (String.Compare(dev_str, _dev_name_base, false) == 0)  // Match
          return (dev_name);
      }
      return ("");  // No valid device name
    }       // End function ValidDeviceName

    /// <summary>
    /// Sets the PSKEY_DEVICE_NAME value from a string.
    /// </summary>
    /// <param name="device_name">Name of the device.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
    private static bool SetDeviceName(string device_name)
    {
      ushort[] key_data = new ushort[10];
      ushort len = EncodeDeviceName(device_name, ref key_data);

      int ret_val = TestEngine.psWrite(_dev_handle, PSKEY_DEVICE_NAME, PS_STORES_I, len, key_data);
      switch(ret_val)
      {
        case -1:
          ErrorMsg("Error Setting Device Name", "Invalid device handle!");
          break;

        case 0:
          ErrorMsg("Error Setting Device Name", "ERROR!");
          break;

        case 1: // Success
          InfoMsg("\"" + device_name + "\" saved as PSKEY_DEVICE_NAME.");
          _last_device_name = device_name;
          return (true);

        case 2:
          ErrorMsg("Error Setting Device Name", "Unsupported function!");
          break;

        default:
          ErrorMsg("Error Setting Device Name", "Unknown return value!");
          break;
      }
      return (false); // Failure
    }       // End function SetDeviceName

    /// <summary>
    /// Verifies the chip display name against the specified string.
    /// </summary>
    /// <param name="name">The expected name of the chipset.</param>
    /// <returns><c>true</c> if names match, <c>false</c> otherwise.</returns>
    public static bool VerifyChipsetName(string name = "")
    {
      if (_dev_handle == 0)   // Only works if device is already open
      {
        ErrorMsg("Programmer Device Error", "SPI-USB programmer not open.");
        return (false);
      }

      StringBuilder chipset_name = new StringBuilder(NAME_LEN);
      for (int i = 0; i < NAME_LEN; i++)
        chipset_name.Append('\0');

      if (name.Length == 0)         // If no name specified
        name = _chip_display_name;  //   Use predetermined name

      int ret_val = TestEngine.teGetChipDisplayName(_dev_handle, NAME_LEN, chipset_name);
      switch(ret_val)
      {
        case -1:
          ErrorMsg("Chipset Name Error", "Invalid device handle in teGetChipDisplayName().");
          break;

        case 0:
          ErrorMsg("Chipset Name Error", "Error calling teGetChipDisplayName().");
          break;

        case 2:
          ErrorMsg("Chipset Name Error", "Unsupported function: teGetChipDisplayName().");
          break;

        case 1:
          if (String.Compare(chipset_name.ToString(), name) == 0)  // Names match
          {
            InfoMsg(chipset_name + " chipset verified.");
            return (true);   // Success
          }
          else
            ErrorMsg("Chipset Name Mismatch", "Found chip display name of " +
                                              chipset_name.ToString() +
                                              " when expecting " + name + ".");
          break;

        default:
          ErrorMsg("Chipset Name Error", "Unknown return value from teGetChipDisplayName().");
          break;
      }
      return(false);    // Failure
    }       // End function VerifyChipsetName

    /// <summary>
    /// Checks the specified path for valid PSR file.
    /// </summary>
    /// <param name="psr_path">The PSR path to check.</param>
    /// <returns><c>true</c> if path is specified and valid, <c>false</c> otherwise.</returns>
    private static bool PSRFileIsPresent(string psr_path)
    {
      if (psr_path.Length == 0)   // If no PSR file path in INI file
      {
        ErrorMsg("PSR Config File Not Specified", "INI file is missing " + PSR_PATH_KEY + " value.");
        return (false);
      }

      if (!File.Exists(psr_path)) // If PSR file not found
      {
        ErrorMsg("PSR Config File Missing", "Cannot find " + psr_path + "!");
        return (false);
      }
      else
        InfoMsg("Using PSR file: " + psr_path);
      return (true);  // Success
    }       // End function PSRFileIsPresent

    /// <summary>
    /// Writes the specified file to the Persistent Store memory of the device.
    /// </summary>
    /// <param name="psr_path">A valid PSR file path.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
    private static bool WritePSRFile(string psr_path)
    {
      byte[] psr_filepath = Encoding.ASCII.GetBytes(psr_path);

      InfoMsg("Writing " + psr_path + " to Bluetooth device...");

      int ret_val = TestEngine.psMergeFromFile(_dev_handle, psr_filepath);

      switch(ret_val)
      {
        case -1:
          ErrorMsg("Error Writing Persistent Store", "Invalid device handle!");
          break;

        case 0:
          ErrorMsg("Failure Writing Persistent Store", "FAILURE!");
          break;

        case 1: // Success
          InfoMsg("Persistent Store programmed using " + psr_path + ".");
          return (true);

        default:
          ErrorMsg("Error Writing Persistent Store", "Unknown return value!");
          break;
      }
      return (false); // Failure
    }       // End function WritePSRFile

    /// <summary>
    /// Writes new PSKEY_DEVICE_NAME value to device.
    /// If an existing device name is specified (non-null), the user is given the option to
    /// retain it.  Otherwise, a new serialized name will be assigned.
    /// </summary>
    /// <param name="old_dev_name">Old name of the dev.</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
    private static bool WriteNewDeviceName(string old_dev_name)
    {
      if (old_dev_name.Length > 0)
      {
        if (MessageBox.Show("Keep the existing device name for this module?",
                            "Device Name: " + old_dev_name,
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button1) == DialogResult.Yes)
        {
          InfoMsg("Keeping existing device name: \"" + old_dev_name + "\".");
          return (SetDeviceName(old_dev_name));
        }
      }
      // Otherwise, create serialized device name
      string serial_no = _next_serial_num.ToString(_serial_num_fmt);
      string new_dev_name = _dev_name_base + " " + serial_no;
      if (SetDeviceName(new_dev_name))                        // If new device name saved
        return (SaveNextSerialNumber(ref _next_serial_num));  //   Increment serial number and exit
      else                                                    // Else
        return (false);                                       //   Failure
    }       // End function WriteNewDeviceName

    /// <summary>
    /// Opens this instance.  Attempts to open the USB-SPI programming adapter
    /// and will set the device handle property on success.  Attempts to read from an
    /// INI file, if specified.
    /// </summary>
    /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
    public static bool Open(string ini_file = DEFAULT_INI_PATH)
    {
      if (!File.Exists(ini_file))
      { // Check for INI file
        ErrorMsg("INI File Not Found", "Could not find " + ini_file);
        return (false);             // Exit if not found
      }
      else
      {
        _ini_filename = ini_file;   // Else save it
        InfoMsg(ini_file + " found.");
      }

      if (!OpenSpiAdapter(ref _dev_handle)) // If unable to open programming adapter
        return (false);                     //   Exit
      else
      {   // Get expected chipset name
        _chip_display_name = INIFile.ReadValue(DEVICE_SECTION, CHIP_NAME_KEY, _ini_filename);
        if (!VerifyChipsetName(_chip_display_name))   // If chipset does not match expected name
        {
          CloseSPIAdapter(ref _dev_handle);           //   Close the programmer device
          return (false);                             //   And exit
        }
      }

        // Get PSR file path
      _psr_path = INIFile.ReadValue(DEVICE_SECTION, PSR_PATH_KEY, _ini_filename);
      if (!PSRFileIsPresent(_psr_path))   // If no valid PSR config file path
      {
        CloseSPIAdapter(ref _dev_handle); //   Close the adapter handle
        return (false);                   //   And exit
      }

        // Get other INI parameters
      _dev_name_base = INIFile.ReadValue(DEVICE_SECTION, DEVICE_NAME_KEY, _ini_filename);
      _serial_num_fmt = INIFile.ReadValue(SERIAL_SECTION, SERIAL_FMT_KEY, _ini_filename, DEFAULT_SERIAL_NUM_FMT);
      _min_serial_num = Convert.ToInt32(INIFile.ReadValue(SERIAL_SECTION, MIN_SERIAL_KEY, _ini_filename, DEFAULT_MIN_SERIAL_NUM.ToString(_serial_num_fmt)));
      _max_serial_num = Convert.ToInt32(INIFile.ReadValue(SERIAL_SECTION, MAX_SERIAL_KEY, _ini_filename, DEFAULT_MAX_SERIAL_NUM.ToString(_serial_num_fmt)));
      _next_serial_num = GetSerialNumber();
      InfoMsg("CSR8635 opened.");
      return (true);
    }       // End function Open

    /// <summary>
    /// Closes this instance.  Closes the USB-SPI device handle.
    /// </summary>
    public static void Close()
    {
      CloseSPIAdapter(ref _dev_handle);
      InfoMsg("CSR8635 closed.");
    }       // End function Close

    /// <summary>
    /// Programs the current device according to the contents of the
    /// specified INI file.  Upon success, the current serial number will
    /// be incremented and saved in the INI file.  If the device already
    /// has a valid PSKEY_DEVICE_NAME, the user will be given the option
    /// to keep it.  If programming is successful, the device name string
    /// is returned.  Otherwise, a null string is returned.
    /// </summary>
    /// <param name="ini_file">The INI file to use for all programming parameters.</param>
    /// <returns>System.String.</returns>
    public static string Program(string ini_file = DEFAULT_INI_PATH)
    {
      string return_value = ""; // Default return

      if (Open(ini_file))
      {
        string old_dev_name = ValidDeviceName();                      // See if there's a legal existing device name
        if (WritePSRFile(_psr_path))                                  // If PSR values written successfully
          if (WriteNewDeviceName(old_dev_name))                       //   If device name is written successfully
          {
            Thread.Sleep(2000);                                       //     Wait a bit
            ColdBoot();                                               //     Reboot the module
            string device_name = GetDeviceName();                     //     Read back the device name
            if (String.Compare(device_name, _last_device_name) != 0)  //     If device name does not match
            {                                                         //       Error
              ErrorMsg("Programming Failure", "Device name not saved properly!");
              return_value = device_name;
            }
            else                                                      //     Else
            {                                                         //       Device name verified
              string msg = "Device verified as \"" + _last_device_name + "\".";

              InfoMsg(msg);
              MessageBox.Show(msg,
                              "Device Name Verified",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information,
                              MessageBoxDefaultButton.Button1);
              return_value = _last_device_name;
            }
          }
        Close();
      }
      return (return_value);
    }       // End function Program

    /// <summary>
    /// Plays an audio file using the default output.
    /// </summary>
    /// <param name="audio_file">The audio file.</param>
    public static void PlayAudio(string audio_file = "Stereo_Audio_Test_Left_Right.mp3")
    {
      if (!File.Exists(audio_file))
      {
        ErrorMsg("Audio File Error", "Could not find " + audio_file + "!");
        return;
      }

      using (var fr = new AudioFileReader(audio_file))
      using (var audio_output = new WaveOutEvent())
      {
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
        new Thread(new ThreadStart(delegate
        {
          MessageBox.Show("Playing " + audio_file,
                          "Audio File Playback",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
        })).Start();
        fr.Volume = 0;
        audio_output.Init(fr);
        audio_output.Play();

        while (audio_output.PlaybackState == PlaybackState.Playing)
        {
          Thread.Sleep(200);
          if (fr.Volume < 1.0f)
            fr.Volume += 0.1f;
          else
          {
            if (fr.Volume > 1.0f)
              fr.Volume = 1.0f;
          }
        }
        audio_output.Dispose();
        fr.Dispose();
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
      }
    }       // End function PlayAudio
  }     // End class CSR8635
}
