using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;//sleep use
using System.Collections;

namespace C303_Produce
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            comListGet();
                        
            CsvLoad();
        }
        enum C303Stat : ulong { SERIAL, ID, TEST1, TEST2, TEST3, TEST4,TIME, FINISH, MACADDRESS, OPEN, CLOSE, JOIN, LEAVE, SUCCESS, FAIL };
        enum LicenseStat : ulong { SERIAL, ID,  MACADDRESS, MacAddressCheck, EZRP, C303, Encryption, Dencryption, WriteLicense, ReadLicense, FINISH, OPEN, CLOSE, JOIN, LEAVE, SUCCESS, FAIL, Default };

        

        /* Encryption Area */
        private Encryption enc = new Encryption();
        byte[] encrypted  ;
        string license;
        string SENSOR_CMD_START = "$";
        
        /* Modbus */
        private Modbus mb = new Modbus();

        /* CsvFile Name */
        string filename;
        private List<Row> csvData = new List<Row>();
        
        private int rowNumber = 0;
        string serialNumber, macAddress ,result1, result2, result3, result4,ledgreen, ledyellow,resultTime;

        /*COM list*/
        ArrayList comPort = new ArrayList();

        /* Zigbee command for develop test */
        string barcode;
        string EZRP;
        
        /* crc16 */
        string ember = "$21,FF,000D6F000072FCA9,FF,FF,C001,0C00,FF,FF,00FF,FF,FF,00,AAE0,02,"; //0EB7

        //string queryMac        = "$00,21,FFFFFFFFFFFF0000,C001,0C00,FF,FF,FFFF,03,FF,FF,FFFF";
        string joinNetwork       = "$00,23,000D6F000072FCA9,C001,0C00,FF,FF,FFFF,01,0A,FF,FFFF";
        string leaveNetwork      = "$00,23,000D6F000072FCA9,0000,0034,FF,FF,FFFF,FF,FF,FF,FFFF,0000000000000000";

        /* Zigbee command */
        string joinNetworkHead   = "$00,23,";
        string joinNetworkTail   = ",C001,0C00,FF,FF,FFFF,01,0A,FF,FFFF";
        string leaveNetworkHead  = "$00,23,";
        string leaveNetworkTail  = ",0000,0034,FF,FF,FFFF,FF,FF,FF,FFFF,0000000000000000";
        string outPutHead        = "$01,CD,";
        string outPutTail        = ",C001,F008,01,01,FFFF,01,01,00,FFFF,10000000";
        string idIdentifyHead    = "$01,12,";
        string idIdentifyTail    = ",0104,0003,01,01,FFFF,00,01,00,FFFF,0A00";
        string stopPairingHead   = "$00,23,";
        string stopPairingTail   = ",C001,0C00,FF,FF,FFFF,01,00,FF,FFFF\r\n";
        string WriteDataHead     = "$00,56,";
        string WriteDataTail     = ",C001,F007,01,01,FFFF,FF,FF,FF,FFFF,";
        string WRiteDataEnd      = "\r\n";
        string ReadDataHead      = "$00,56,";
        string ReadDataTail      = ",C001,F007,01,01,FFFF,FF,FF,FF,FFFF,";

        /* C303 Command */
        byte[] Signature         = new byte[] { 0xFF, 0xAD };

        byte[] MessageIDRead     = new byte[] { 0x00, 0x01 };
        byte[] MessageIDResponse = new byte[] { 0x80, 0x01 };

        byte[] C303Write         = new byte[] { 0xFF, 0xAD, 0x00, 0x01 };
        byte[] C303WriteResponse = new byte[] { 0xFF, 0xAD, 0x80, 0x01 };

        byte[] C303Read          = new byte[] { 0xFF, 0xAD,0x00,0x02 };
        byte[] C303ReadResponse  = new byte[] { 0xFF, 0xAD,0x80,0x02 };

        byte[] write = new byte[] { 0xFF, 0xAD, 0x00, 0x01,
                                    0x00,0x0D, 0x6F, 0x00,0x02,0x5A,0x0C,0xF3};
        string readLicenseHead = "$00,56,";
        string readLicenseTail = ",C001,F007,01,01,FFFF,FF,FF,FF,FFFF,FFAD0002";

        string invalidMacaddress = "00540400A654BFBE";

        /*EZRP Llicense command*/ 
        // $00,56,000D6F00036BCEAD,C001,F007,01,01,FFFF,FF,FF,FF,FFFF,010300000008440C
        string readEZRPLicenseHead = "$00,56,";
        string readEZRPLicenseTail = ",C001,F007,01,01,FFFF,FF,FF,FF,FFFF,010300000008440C";
       
        /*Response */
        string rsp               = "0102030405060708090A0B0C0D0E0F101112131415161718191A1B1C1D1E1F202122232425262728292A2B2C2D2E2F303132333435363738393A3B3C3D3E3F404142434445464748494A4B4C4D4E4F505152535455565758595A5B5C5D5E5F606162636465666768696A6B6C6D6E6F707172737475767778797A7B7C7D7E7F808182838485868788898A8B8C8D8E8F909192939495969798999A9B9C9D9E9FA0A1A2A3A4A5A6A7A8A9AAABACADAEAFB0B1B2B3B4B5B6B7B8B9BABBBCBDBEBFC0C1C2C3C4C5C6C7C8C9CACBCCCDCECFD0D1D2D3D4D5D6D7D8D9DADBDCDDDEDFE0E1E2E3E4E5E6E7E8E9EAEBECEDEEEFF0F1F2F3F4F5F6F7F8F9FAFBFCFDFEFF";
        string rsp2              = "746573740D0A0102030405060708090A0B0C0D0E0F101112131415161718191A1B1C1D1E1F202122232425262728292A2B2C2D2E2F303132333435363738393A3B3C3D3E3F404142434445464748494A4B4C4D4E4F505152535455565758595A5B5C5D5E5F606162636465666768696A6B6C6D6E6F707172737475767778797A7B7C7D7E7F808182838485868788898A8B8C8D8E8F909192939495969798999A9B9C9D9E9FA0A1A2A3A4A5A6A7A8A9AAABACADAEAFB0B1B2B3B4B5B6B7B8B9BABBBCBDBEBFC0C1C2C3C4C5C6C7C8C9CACBCCCDCECFD0D1D2D3D4D5D6D7D8D9DADBDCDDDEDFE0E1E2E3E4E5E6E7E8E9EAEBECEDEEEFF0F1F2F3F4F5F6F7F8F9FAFBFCFDFEFF";
        string rspReset          = "0123456789ABCDEF";

        /* com3 read Thread*/
        private Thread t;
        private Boolean receiving,c303,ezrpLicense,c303License;    
        

        private void Form1_Load(object sender, EventArgs e)
        {
            init();
        }

        private void init()
        {
            this.Show();
            if (tbxBarcode.CanFocus)
            {
                tbxBarcode.Focus();
                //MessageBox.Show("can focus");
            }
            else
            {
                //MessageBox.Show("can't focus");
            }
            rdbEZRP.Checked = true;            
            //lblLicenseStatus.Text = "EZRP";    
        }

        private void rdbEZRP_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbEZRP.Checked == true)
                lblLicenseStatus.Text = "EZRP";

        }

        private void rdbC303_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbC303.Checked == true)
                lblLicenseStatus.Text = "C303";
        }


        private void rdbICB_CheckedChanged(object sender, EventArgs e)
        {

            if (rdbICB.Checked == true)
                lblLicenseStatus.Text = "ICB";
        }  

        #region GUI Delegate Declarations

        private void logLicenseMac(string msg)
        {
            lblLicenseMac.Invoke(new EventHandler(delegate
            {                
                lblLicenseMac.Text = msg;
                lblLicenseMac.Refresh();     
            }));
        }

        private void logLicenseResult(string msg)
        {
            lblLicenseResult.Invoke(new EventHandler(delegate
            {              
                lblLicenseResult.Text = msg;
                lblLicenseResult.Refresh();              
            }));
        }

        private void logLicenseStatus(string msg)
        {
            lblLicenseStatus.Invoke(new EventHandler(delegate
            {
                lblLicenseStatus.Text = msg;
                lblLicenseStatus.Refresh();
            }));
        }
        private void logMacAddress(string msg)
        {
            lblMacAddress.Invoke(new EventHandler(delegate
            {
                //lblMacAddress.SelectedText = string.Empty;
                //lblMacAddress.SelectionFont = new Font(lblMacAddress.SelectionFont, FontStyle.Bold);
                lblMacAddress.Text = msg;
                lblMacAddress.Refresh();
            }));
        }
        private void logTestResult(string msg)
        {
            lblTestResult.Invoke(new EventHandler(delegate
            {
                //lblMacAddress.SelectedText = string.Empty;
                //lblMacAddress.SelectionFont = new Font(lblMacAddress.SelectionFont, FontStyle.Bold);
                lblTestResult.Text = msg;
                lblTestResult.Refresh();
            }));
        }
        private void logResetResult(string msg)
        {
            btnReset.Invoke(new EventHandler(delegate
            {
                //lblMacAddress.SelectedText = string.Empty;
                //lblMacAddress.SelectionFont = new Font(lblMacAddress.SelectionFont, FontStyle.Bold);
                if (string.Compare(msg, "Pass") == 0)
                    btnReset.ForeColor = Color.Green;
                else if (string.Compare(msg, "Fail") == 0)
                    btnReset.ForeColor = Color.Red;
                btnReset.Text = msg;
                btnReset.Refresh();
                //MessageBox.Show("msg"+msg);
            }));
        }

        #endregion
        
        #region Csv

        List<String[]> PrepareCSVData()
        {
            int colCount = 9;
            List<String[]> ls = new List<String[]>();
            String[] title = { "SerialNumber ", "Mac Address", "Debug->Rs485", "Rs485-Debug", "Pairing", "Reset", "Led Green", "Led Green", "Test Time" };
            ls.Add(title);

            for (int i = 0; i < csvData.Count; i++)
            {

                Row r = (Row)csvData[i];
                String[] rowStringArray = new String[colCount];
                rowStringArray[0] = r.Column1;
                rowStringArray[1] = r.Column2;
                rowStringArray[2] = r.Column3;
                rowStringArray[3] = r.Column4;
                rowStringArray[4] = r.Column5;
                rowStringArray[5] = r.Column6;
                rowStringArray[6] = r.Column7;
                rowStringArray[7] = r.Column8;
                rowStringArray[8] = r.Column9;
                ls.Add(rowStringArray);
            }
            return ls;
        }

        void CsvLoad()
        {
            filename = DateTime.Now.ToString("yyyyMdHHmmss") + ".csv";
            CSV.WriteCSV(filename, PrepareCSVData());
        }

        void CsvWrite()
        {
            //MessageBox.Show("ledgreen "+ledgreen + " ledyellow " + ledyellow);
            //MessageBox.Show("result1 " + result1 + " result2 " + result2 + " result3 " + result3);

            //Row may be a Student or a Company class in your software product.
            Row row = new Row();
            row.Column1 = serialNumber;
            row.Column2 = macAddress;
            row.Column3 = result1;
            row.Column4 = result2;
            row.Column5 = result3;
            row.Column6 = result4;
            row.Column7 = ledgreen;
            row.Column8 = ledyellow;
            row.Column9 = resultTime;
            csvData.Add(row);

            CSV.WriteCSV(filename, PrepareCSVData());

            /* Clear test Result */
            serialNumber = macAddress = result1 = result2 = result3 = result4 = ledgreen = ledyellow = resultTime = string.Empty;

            /* Clear dataGridView line 1  */
            //dataGridView.Rows[dataGridView.Rows.Count - 1].Cells[0].Value = string.Empty;
            //dataGridView.Rows[dataGridView.Rows.Count - 1].Cells[1].Value = string.Empty;
            //dataGridView.Rows[dataGridView.Rows.Count - 1].Cells[2].Value = string.Empty;
            //dataGridView.Rows[dataGridView.Rows.Count - 1].Cells[3].Value = string.Empty;
            //dataGridView.Rows[dataGridView.Rows.Count - 1].Cells[4].Value = string.Empty;
        }   

        #endregion

        #region Button 

        private void btnGreenPass_CheckedChanged(object sender, EventArgs e)
        {
            btnGreenPass.ForeColor = Color.Red;
            if (btnGreenFail.ForeColor == Color.Red)
                btnGreenFail.ForeColor = Color.Black;
        }

        private void btnGreenFail_CheckedChanged(object sender, EventArgs e)
        {
            btnGreenFail.ForeColor = Color.Red;
            if (btnGreenPass.ForeColor == Color.Red)
                btnGreenPass.ForeColor = Color.Black;
        }

        private void btnYellowPass_CheckedChanged(object sender, EventArgs e)
        {
            btnYellowPass.ForeColor = Color.Red;
            if (btnYellowFail.ForeColor == Color.Red)
                btnYellowFail.ForeColor = Color.Black;
        }

        private void btnYellowFail_CheckedChanged(object sender, EventArgs e)
        {
            btnYellowFail.ForeColor = Color.Red;
            if (btnYellowPass.ForeColor == Color.Red)
                btnYellowPass.ForeColor = Color.Black;
        }

        private void btnOpenCom3_Click(object sender, EventArgs e)
        {
            if (!comPort3.IsOpen)
                OpenCom3();
        }

        private void btnCloseCom3_Click(object sender, EventArgs e)
        {
            if (comPort3.IsOpen)
                comPort3.Close();
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            clearLogLicense();

            getMacAddress();

            sendCmd(joinNetworkHead + macAddress + joinNetworkTail);

        }

        private void btnLeave_Click(object sender, EventArgs e)
        {
            clearLogLicense();

            getMacAddress();

            //MessageBox.Show(joinNetworkHead + macAddress + joinNetworkTail);
            sendCmd(leaveNetworkHead + macAddress + leaveNetworkTail);

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenAllCom();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseAllCom();
        }



        private void btnReset_Click(object sender, EventArgs e)
        {
            //btnReset.ForeColor = Color.Red;
            btnReset.Enabled = false;

            /* Recive Pair Confirm response => 0x0013 */
            receiving = c303 = true;

            if (!resetWorker.IsBusy)
                resetWorker.RunWorkerAsync();

            for (int i = 0; i < 5000; i += 1000)
            {
                pBar.PerformStep();
                Thread.Sleep(1000);
            }


            /* Stop recv Data */
            if (!receiving)
                resetWorker.CancelAsync();  /* Stop bgWorker */
        }

        #endregion

        #region ComPort Control

        private void comListGet()
        {
            /*新增陣列列表*/
            //ArrayList comPort = new ArrayList();

            /* 取得現有 com port list*/
            foreach (string s in SerialPort.GetPortNames())
            {
                /* 加入 陣列列表*/
                comPort.Add(s);
            }
            /* 做排序*/
            comPort.Sort();

            /* Dump com port list*/
            for (int i = 0; i < comPort.Count; i++)
            {
                //MessageBox.Show(comPort[i].ToString());
                // Console.WriteLine("{0}: {1}", i, comPort[i]);
            }
            /* 加入至combox 列表 */
            cmbRs232.Items.AddRange(comPort.ToArray());
            cmbRs485.Items.AddRange(comPort.ToArray());
            cmbEmber.Items.AddRange(comPort.ToArray());

            //cmbRs232.Text = cmbRs232.Items[1].ToString();
            //cmbRs485.Text = cmbRs485.Items[2].ToString();
            //cmbEmber.Text = cmbEmber.Items[3].ToString();

            //comboPort1.Items.AddRange(comPort.ToArray());
            //comboPort2.Items.AddRange(comPort.ToArray());
            //comboPort3.Items.AddRange(comPort.ToArray());
        }

        private void OpenCom1()
        {
            try
            {
                //comPort1.PortName = comPort[1].ToString();
                comPort1.PortName = cmbRs232.Text;
                comPort1.ReadTimeout = 2000;
                comPort1.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void OpenCom2()
        {
            // Get a list of serial port names.
            //string[] ports = SerialPort.GetPortNames();           
            try
            {
                //MessageBox.Show(comPort[3].ToString());
                //comPort2.PortName = comPort[3].ToString();
                comPort2.PortName = cmbRs485.Text;
                comPort2.ReadTimeout = 2000;
                comPort2.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void OpenCom3()
        {
            //Get a list of serial port names.
            //string[] ports = SerialPort.GetPortNames();
            if (comPort3.IsOpen)
                return;

            try
            {

                //MessageBox.Show(comPort[4].ToString());
                //comPort3.PortName = comPort[4].ToString();
                comPort3.PortName = cmbEmber.Text;
                //comPort3.ReadTimeout = 17000;
                comPort3.ReadTimeout  = 3000;
                comPort3.WriteTimeout = 3000;
                comPort3.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void OpenAllCom()
        {
            if (!comPort1.IsOpen)
                OpenCom1();
            if (!comPort2.IsOpen)
                OpenCom2();
            if (!comPort3.IsOpen)
                OpenCom3();
        }
        private void CloseAllCom()
        {
            if (comPort1.IsOpen)
                comPort1.Close();
            if (comPort2.IsOpen)
                comPort2.Close();
            if (comPort3.IsOpen)
                comPort3.Close();
        }

        #endregion

        private byte[] HexStringToByteArray(string s)
        {

            byte[] buffer = new byte[s.Length / 2];
            try
            {
                for (int i = 0; i < s.Length; i += 2)
                    buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("輸入偶數個數字");
            }
            return buffer;
        }
        
        private string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            return sb.ToString().ToUpper();
        }

        private int sendcmd1to2()
        {
            int retry = 4;
            string cmd = "test";
           
            if (!comPort1.IsOpen || !comPort2.IsOpen)
            {
              //  Log("comPort1 or comPort2 is not open !\r\n");
                return -1;
            }
            
            try
            {                
                comPort1.WriteLine(cmd+"\r");                  
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            //catch (TimeoutException) { Log("com1 Write TimeOut!"); return -1; }

            while (comPort2.BytesToRead < 255 && retry-- !=0 )
            {
                Thread.Sleep(500);               //TIMEOUT = 500*4 = 2second
            }       

            try
            {
                int bytes = comPort2.BytesToRead;
                byte[] buffer = new byte[bytes];
                comPort2.Read(buffer, 0, bytes);
                //MessageBox.Show(bytes.ToString() + " GET \r\n" + ByteArrayToHexString(buffer));

                if (String.Compare(rsp, ByteArrayToHexString(buffer)) == 0)
                {                   
                    result1 = "Pass";
                    //lblTestResult.Text = "Pass";
                    logTestResult("Pass");
                    return 0;
                }
                else
                {           
                    result1 = "Fail";
                    //lblTestResult.Text = "Fail";
                    logTestResult("Fail");
                    return 1;
                }
            }
            catch (TimeoutException) 
            { 
               // Log("com2 Read TimeOut!"); 
                return -1; 
            }                     
        }
        private int sendcmd2to1()
        {
            int retry = 4;
            string cmd = "test";
            if (!comPort1.IsOpen || !comPort2.IsOpen)
            {
                //Log("comPort1 or comPort2 is not open !\r\n");
                return -1;
            }

            try
            {
                comPort2.WriteLine(cmd + "\r");
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            //catch (TimeoutException) { Log("com1 Write TimeOut!"); return -1; }

            while (comPort1.BytesToRead < 255 && retry-- != 0)
            {
                Thread.Sleep(500);               //TIMEOUT = 500*4 = 2second
            }

            try
            {
                int bytes = comPort1.BytesToRead;
                byte[] buffer = new byte[bytes];
                comPort1.Read(buffer, 0, bytes);
                //MessageBox.Show(bytes.ToString() + " GET \r\n" + ByteArrayToHexString(buffer));
                
                if (String.Compare(rsp, ByteArrayToHexString(buffer)) == 0
                    || String.Compare(rsp2, ByteArrayToHexString(buffer)) == 0)
                {                    
                    result2 = "Pass";
                    if( string.Compare(result1,"Pass") == 0 )
                        lblTestResult.Text = "Pass";
                    return 0;
                }
                else
                {                    
                    result2 = "Fail";
                    lblTestResult.Text = "Fail";
                    return 1;
                }
            }
            catch (TimeoutException) 
            {
                //Log("com1 Read TimeOut!"); 
                return -1; 
            }
        }
        private void sendcmd3()
        {
            if (!comPort3.IsOpen) 
                return ;

            /* Send join command */
            sendCmd( joinNetworkHead + macAddress + joinNetworkTail);

            /* Recive Pair Confirm response => 0x0013 */
            c303 = receiving = true;
            if (!bgWorker.IsBusy)            
                bgWorker.RunWorkerAsync();              
            
            /* Progress Bar */
            //barGo();

            for (int i=0; i < 12000; i += 1000)
            {
                pBar.PerformStep();
                Thread.Sleep(1000);
            }
            
            /* Send idIdentify Command , Let  yellow led is blink */    
            sendCmd( outPutHead + macAddress + outPutTail);                        
            sendCmd( idIdentifyHead + macAddress + idIdentifyTail);

            Thread.Sleep(2000);                                     

            sendCmd(leaveNetworkHead + macAddress + leaveNetworkTail);

            /* Stop recv Data */
            if (bgWorker.IsBusy)            
                bgWorker.CancelAsync();  /* Stop bgWorker */                          
        }

        

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //e.Argument接入RunWorkerAsync傳入的參數             
            DoReceive(sender as BackgroundWorker);
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pBar.PerformStep();
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //if (string.Compare(result1, "Pass") == 0 || string.Compare(result2, "Pass") == 0)
            //    lblTestResult.Text =result3;
            pBar.Value = 0;
        }

        private void sendCmd(string cmd)
        {
            if (!comPort3.IsOpen) return;
            try
            {
                //MessageBox.Show("testcmd1 長度 = " + cmd.Length.ToString() + " sendCmd = " + cmd);
             
                comPort3.WriteLine(cmd);
                comPort3.Write("\r");               
            }
            //catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            catch (TimeoutException) 
            { 
                logLicenseStatus("TimeOut!"); 
                //return -1; 
            }
        }
        private string bytetostring(byte[] data)
        {
            int i;
            string str = "";
            foreach (byte byteValue in data)
                str += byteValue.ToString("X2");
            return str;
        }
        

        private void tbxBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {            
            C303Stat stat;
            if (barcode == "")
            {                 
                tbxBarcode.Text="";
            }

            barcode += e.KeyChar;

            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    stat = (C303Stat)Enum.Parse(typeof(C303Stat), tbxBarcode.Text.ToUpper());
                }
                catch (ArgumentException) { stat = C303Stat.SERIAL; }

                barcode = barcode.ToUpper();               

                if (tbxBarcode.Text.CompareTo("id")>0)
                    stat = C303Stat.ID ;
                if (tbxBarcode.Text.CompareTo("FINSIH") > 0)
                    stat = C303Stat.FINISH;

                if (tbxBarcode.Text.Length == 10)
                {
                    stat = C303Stat.SERIAL;
                    serialNumber = tbxBarcode.Text;
                }
                else if (tbxBarcode.Text.Length == 16)
                {
                    stat = C303Stat.MACADDRESS;
                    macAddress = tbxBarcode.Text;                   
                
                    logMacAddress(macAddress);
                    logTestResult("Running");
                }

                if (barcode.Length == 11 )
                {
                    stat = C303Stat.SERIAL;
                    serialNumber = barcode.Replace("\r", "");
                }
                else if (barcode.Length == 17 )
                {
                    stat = C303Stat.MACADDRESS;
                    macAddress = barcode.Replace("\r", "");
                   
                    logMacAddress(macAddress);
                    logTestResult("Running");
                }
                
                switch (stat)
                {
                    case C303Stat.SERIAL:
                        lblSerialNumber.Text = serialNumber;
                        break;
                    case C303Stat.MACADDRESS:                        
                       
                        sendcmd1to2();
                        sendcmd2to1();
                        sendcmd3();
                        
                        pBar.Value = 0;
                        resultTime = DateTime.Now.ToString("yyyy-M-d HH:mm:ss");
                        
                        break;
                   
                    case C303Stat.TEST3:
                        //sendCmd(leaveNetwork);                    
                        sendCmd(leaveNetworkHead + macAddress + leaveNetworkTail);
                        receiving = true;
                        c303 = true;
                        if (!bgWorker.IsBusy)
                            bgWorker.RunWorkerAsync();
                        //sendCmd(joinNetwork);  
                        sendCmd(joinNetworkHead + macAddress + joinNetworkTail);

                      
                        break;
                    case C303Stat.FINISH:
                        tbxBarcode.Text = string.Empty;
                                            
                        if (ledGreen() < 0 || ledYellow() <0 ) return;                       

                        CsvWrite();

                        lblSerialNumber.Text = string.Empty;
                        lblMacAddress.Text = string.Empty;
                        lblTestResult.Text = string.Empty;
                        break;
                    case C303Stat.ID:
                        lblTestResult.Text = "id is running";
                        sendCmd(outPutHead + macAddress + outPutTail);
                        sendCmd(idIdentifyHead + macAddress + idIdentifyTail);
                        break;

                    default:
                        /* Get SerialNumber read & error cmd contorl */
                        if (tbxBarcode.Text.Length == 11)
                        {
                            serialNumber = tbxBarcode.Text.Replace("\r", "");                           
                        }
                        else if (tbxBarcode.Text.Length == 17) /* Get macAddress*/
                        {
                            macAddress = tbxBarcode.Text.Replace("\r", "");                           
                        }
                      
                        break;
                }
                barcode = "";
                tbxBarcode.Text = "";
            }
        }                              
        

        

        /**/
        delegate void UpdateLableHandler(string text);
        
        private void printResult(string result) 
        {
            lblTestResult.Text = result;           
        }
       

        private int ledGreen()
        {
            /* To dectet led button */
            if (!btnGreenPass.Checked && !btnGreenFail.Checked)
            {
                MessageBox.Show("Green-Led is not check yet!");
                return -1;
            }
            if (btnGreenPass.Checked)
            {
                ledgreen = "Pass";
                //MessageBox.Show("Ledgreen = Pass");
            }
            else if (btnGreenFail.Checked)
                ledgreen = "Fail";

            btnGreenPass.Checked = false;
            btnGreenFail.Checked = false;
            return 0;
        }
        private int ledYellow()
        {
            if (!btnYellowPass.Checked && !btnYellowFail.Checked)
            {
                MessageBox.Show("Yellow-Led is not check yet!");
                return -1;
            }
            if (btnYellowPass.Checked)
            {
                ledyellow = "Pass";
                //MessageBox.Show(" ledyellow = Pass " );
            }
                
            else if (btnYellowFail.Checked)
                ledyellow = "Fail";

            btnYellowPass.Checked = false;
            btnYellowFail.Checked = false;
            return 0;
        }

        

       
        private void DoReset(BackgroundWorker worker)
        {
            if (resetWorker.CancellationPending) return;
            if (!comPort1.IsOpen) 
                c303 = ezrpLicense = receiving = false;

            comPort1.ReadTimeout = 5000;

            string tmp = "";
            while (receiving)
            {
                if (c303 == true)
                {
                    try
                    {
                        tmp = comPort1.ReadLine();

                    }
                    catch (TimeoutException)
                    {
                        result4 = "Fail";
                        logResetResult(result4);
                        c303 = receiving = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        c303 = receiving = false;
                    }

                    if (tmp.Contains("0123456789ABCDEF"))
                    {
                        result4 = "Pass";
                        logResetResult(result4);
                        c303 = receiving = false;
                        break;
                    }
                    else
                    {
                        //bgWorker.ReportProgress(0);                   
                    }
                
               
                }
            }
        }
        private void resetWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //e.Argument接入RunWorkerAsync傳入的參數             
            DoReset(sender as BackgroundWorker);
        }

        private void resetWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pBar.Value = 0;
            btnReset.Checked = false;
            btnReset.Enabled = true;
        }

        public void memset(ref byte[] bytes, byte value, int length)
        {
            for (int i=0; i < length; i++)
                bytes[i] = value;
        }

        public byte[] Checksum(byte[] bytes)
        {            
            int i;

            for (i = 0; i < bytes.Length/5; i+=4)
            {
                bytes[i] = bytes[i + 2];
                bytes[i+1] = bytes[i + 3];            
            }
            //MessageBox.Show("CheckSUM =" + ByteArrayToHexString(bytes));

            return bytes;
        }

        UInt16 CRC16(byte[] Msg, int len)
        {
            int i;
            UInt16 checkSum = 0;

            //heckSum += SENSOR_CMD_START;

            for (i = 0; i < len; i++)
            {
                //MessageBox.Show("Msg[i]" + Msg[i].ToString("X2"));
                checkSum += Msg[i];
            }
            //MessageBox.Show("checkSum" + checkSum.ToString("X4"));
            return checkSum;
        }

        private string stringChecksum(string dataToCalculate, byte[] crc16)
        {
            string tmp;
            byte[] byteToCalculate = Encoding.ASCII.GetBytes(dataToCalculate);
            Int16 checksum = 0;
            foreach (Int16 chData in byteToCalculate)
            {
                checksum += chData;
            }
            //checksum &= 0xffff;
            tmp = checksum.ToString("X4");
            crc16[0] = (byte)Convert.ToByte(tmp.Substring(0, 2), 16);
            crc16[1] = (byte)Convert.ToByte(tmp.Substring(2, 2), 16);

            return checksum.ToString("X4");
        }

        private void LicenseSendToC303(byte[] Licensedata)
        {
            int i;
            if (!comPort3.IsOpen)
                return;
            byte[] request = new byte[22];
            UInt16 crc16;
            memset(ref request, 0, request.Length);       
   
            /* */
            //for (i = 0; i < 4; i++)  //0~3
            //    request[i] = C303Write[i];

            Array.Copy(C303Write, 0, request, 0, 4);
                
            Array.Copy(Licensedata, 0, request, 4, 16);//4~19           

            /* Cal crc16 */
            crc16 = CRC16(request, request.Length);
            request[20] = (byte)((crc16 >>8)& 0xff);
            request[21] = (byte)(crc16 & 0xff);                                  
                     
            
            //MessageBox.Show("sendToC303 = " + ByteArrayToHexString(request));           
            //MessageBox.Show("macAddress = " + macAddress);

            logLicenseResult( ByteArrayToHexString(request) );

            /* Send command */
            sendCmd(WriteDataHead + macAddress + WriteDataTail + ByteArrayToHexString(request));           
        }

        private void LicenseSendToEZRP(byte[] Data)
        {

            if (!comPort3.IsOpen)
                return;

           

            //MessageBox.Show("lienceseData =" + bytetostring(Data));
            /* Write License */
            sendCmd(WriteDataHead + macAddress + WriteDataTail + bytetostring(Data));
        }

       

        private void licenseC303Check()
        {
            if (!comPort3.IsOpen)
                return;
            getMacAddress();        
        
            //Send to C303
            //sendCmd(readLicenseHead + macAddress + readLicenseTail);
            readFormC303(readLicenseHead + macAddress + readLicenseTail);
        }

        private void licenseEZRPCheck()
        {
            if (!comPort3.IsOpen)
                return;

            getMacAddress();

            byte[] tmp = new byte[8];
            tmp = mb.ReadLicense();
            readFormEZRP(tmp);
        }


        private void readFormC303(string command)
        {
            if (!comPort3.IsOpen)
                return;
            sendCmd(command);

            /* Recive Pair Confirm response */
            c303License = receiving = true;

            if (!bgWorker.IsBusy)
                bgWorker.RunWorkerAsync();

            for (int i = 0; i < 500; i += 100)
            {
                pBar.PerformStep();
                Thread.Sleep(100);
                if (receiving == false)
                    break;
            }

            /* Stop recv Data */
            if (bgWorker.IsBusy)
                bgWorker.CancelAsync();  /* Stop bgWorker */
        }



        private void readFormEZRP(byte[] Data)
        {
            if (!comPort3.IsOpen)
                return;
            //MessageBox.Show(readEZRPLicenseHead + macAddress + readEZRPLicenseTail);

            sendCmd(readEZRPLicenseHead + macAddress + readEZRPLicenseTail);
            
            /* Recive Pair Confirm response => 0x0013 */
            ezrpLicense = receiving = true;
            if (!bgWorker.IsBusy)
                bgWorker.RunWorkerAsync();

            for (int i = 0; i < 2000; i += 100)
            {                
                pBar.PerformStep();
                Thread.Sleep(100);
                if (receiving == false)
                    break;
            }           

            /* Stop recv Data */
            if (bgWorker.IsBusy)
                bgWorker.CancelAsync();  /* Stop bgWorker */ 
        }       

        private void tbxEZRP_KeyPress(object sender, KeyPressEventArgs e)
        {
            LicenseStat stat;
            if (EZRP == "")
            {
                tbxLicense.Text = "";
            }

            EZRP += e.KeyChar;

            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    stat = (LicenseStat)Enum.Parse(typeof(LicenseStat), tbxLicense.Text.ToUpper());
                }
                catch (ArgumentException) { stat = LicenseStat.SERIAL; }

                EZRP = EZRP.ToUpper();

                if (tbxLicense.Text.CompareTo("id") > 0)
                    stat = LicenseStat.ID;
                if (tbxLicense.Text.CompareTo("FINSIH") > 0)
                    stat = LicenseStat.FINISH;
                if (tbxLicense.Text.CompareTo("C303") > 0)
                    rdbC303.Checked = true;
                if (tbxLicense.Text.CompareTo("EZRP") > 0)
                    rdbEZRP.Checked = true;
                if (tbxLicense.Text.CompareTo("ICB") > 0)
                    rdbICB.Checked = true;
               

                if (tbxLicense.Text.Length == 10)
                {
                    stat = LicenseStat.SERIAL;
                    serialNumber = tbxLicense.Text;
                }
                else if (tbxLicense.Text.Length == 16)
                {
                    stat = LicenseStat.MACADDRESS;
                    macAddress = tbxLicense.Text;
                    logLicenseMac(macAddress);
                    //logMacAddress(macAddress);
                    //logTestResult("Running");
                }

                if (EZRP.Length == 11)
                {
                    stat = LicenseStat.SERIAL;
                    serialNumber = EZRP.Replace("\r", "");
                }
                else if (EZRP.Length == 17)
                {
                    stat = LicenseStat.MACADDRESS;
                    macAddress = EZRP.Replace("\r", "");
                    logLicenseMac(macAddress);
                    //logMacAddress(macAddress);
                    //logTestResult("Running");
                }               

              //}               
                return; //for button control , ryanadd

                switch (stat)
                {                 
                    case LicenseStat.WriteLicense:
                        btnWrite_Click(null, null);
                        break;
                    case LicenseStat.ReadLicense:
                        btnRead_Click(null, null);
                        break;
                    case LicenseStat.JOIN:
                        btnJoin_Click(null, null);
                        break;
                    case LicenseStat.LEAVE:
                        btnLeave_Click(null, null);
                        break;
                    case LicenseStat.MACADDRESS:
                        lblLicenseStatus.Text = "Mac Address";

                    if( rdbEZRP.Checked == true)
                    {
                        lblLicenseStatus.Text = "EZRP";
                        if (!comPort3.IsOpen)
                        {
                            lblLicenseResult.Text = "Com Port isn't opening !";

                            return;
                        }

                        /* join EZRP */
                        sendCmd(joinNetworkHead + macAddress + joinNetworkTail);
                        Thread.Sleep(8000);

                        /* Encryption */
                        encrypted = enc.encryption(macAddress);

                        /* Save license for Confirm Use*/
                        license = bytetostring(encrypted);

                        /* Send to device Function 06 */
                        LicenseSendToEZRP(mb.CreateWriteHeader(encrypted));

                        /* Check License */
                        licenseEZRPCheck();

                        /* Leave network */
                        sendCmd(leaveNetworkHead + macAddress + leaveNetworkTail);

                        /* Stop Actions */
                        pBar.Value = 0;


                    }
                    else if (rdbC303.Checked == true)
                    {                   
                        
                        lblLicenseStatus.Text = "C303";
                        if (!comPort3.IsOpen)
                        {
                            lblLicenseResult.Text = "Com Port isn't opening !";
                            return;
                        }

                        /* join EZRP */
                        sendCmd(joinNetworkHead + macAddress + joinNetworkTail);
                        Thread.Sleep(8000);

                        //Encryption
                        license = bytetostring(enc.encryption(macAddress));

                        /* Send to device Function 06 */
                        LicenseSendToC303(enc.encryption(macAddress));

                        /* Check License */
                        licenseC303Check();

                        /* Leave network */
                        sendCmd(leaveNetworkHead + macAddress + leaveNetworkTail);

                        /* Stop Actions */
                        pBar.Value = 0;
                    }                
                        break;

                  

                    case LicenseStat.Encryption:
                        //enc.encryption(macAddress);                    
                        //string tmp = bytetostring(enc.encryption(macAddress));
                        MessageBox.Show(bytetostring(enc.encryption(macAddress)));
                        break;
                    case LicenseStat.FINISH:
                        break;
                    case LicenseStat.ID:
                        lblLicenseStatus.Text = "id is running";
                        sendCmd(outPutHead + macAddress + outPutTail);
                        sendCmd(idIdentifyHead + macAddress + idIdentifyTail);
                        break;

                    default:
                        lblLicenseStatus.Text = " invalid command or Macaddress";
                        /* Get SerialNumber read & error cmd contorl */
                        if (tbxBarcode.Text.Length == 17) /* Get macAddress*/
                        {
                            macAddress = tbxBarcode.Text.Replace("\r", "");
                        }
                        //else

                        //Log("invalid command " + barcode + barcode.Length.ToString());
                        break;
                }
                barcode = string.Empty;
                EZRP = string.Empty;
            }
        }

        private void clearLogLicense()
        {
            logLicenseMac(string.Empty);
            logLicenseResult(string.Empty);
            logLicenseStatus(string.Empty);
        }

        private void getMacAddress()
        {
            if (tbxLicense.Text.Length == 16)
            {
                macAddress = tbxLicense.Text;
                logLicenseMac(macAddress);

            }
            else if (tbxLicense.Text.Length == 17)
            {
                macAddress = tbxLicense.Text.Replace("\r", "");
                logLicenseMac(macAddress);
            }            
        }



        private void btnWrite_Click(object sender, EventArgs e)
        {
            if (!comPort3.IsOpen)
            {
                logLicenseStatus("Com Port isn't opening !");                
                return;
            }

            //MessageBox.Show(tbxLicense.Text + " length = " + tbxLicense.Text.Length);
            clearLogLicense();            

            getMacAddress();

            if (rdbC303.Checked == true)
            {
                lblLicenseStatus.Text = "C303";    
                //Encryption
                //license = bytetostring(enc.encryption(tbxLicense.Text));
                license = bytetostring(enc.encryption(macAddress));

                /* Send to device Function 06 */
                LicenseSendToC303(enc.encryption(macAddress));

                /* Check License */
                //licenseC303Check();
                c303License = receiving = true;
                if (!bgWorker.IsBusy)
                    bgWorker.RunWorkerAsync();

                for (int i = 0; i < 500; i += 100)
                {
                    pBar.PerformStep();
                    Thread.Sleep(100);
                    if (receiving == false)
                        break;
                }

                /* Leave network */
                //sendCmd(leaveNetworkHead + macAddress + leaveNetworkTail);

                /* Stop Actions */
                pBar.Value = 0;
            }
            else if (rdbEZRP.Checked == true || rdbICB.Checked ==true )
            {
                lblLicenseStatus.Text = "EZRP";              

                /* Encryption */
                encrypted = enc.encryption(macAddress);

                /* Save license for Confirm Use*/
                license = bytetostring(encrypted);

                logLicenseResult(license);

                /* Send to device Function 06 */
                LicenseSendToEZRP(mb.CreateWriteHeader(encrypted));

                ezrpLicense = receiving = true;
                if (!bgWorker.IsBusy)
                    bgWorker.RunWorkerAsync();

                for (int i = 0; i < 500; i += 100)
                {
                    pBar.PerformStep();
                    Thread.Sleep(100);
                    if (receiving == false)
                        break;
                }


                /* Check License */
                //licenseEZRPCheck();

                /* Leave network */
                //sendCmd(leaveNetworkHead + macAddress + leaveNetworkTail);

                /* Stop Actions */
                pBar.Value = 0;
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (!comPort3.IsOpen)
            {
                lblLicenseStatus.Text = "Com Port isn't opening !";
                return;
            }

            clearLogLicense();

            getMacAddress();

            if (rdbEZRP.Checked == true || rdbICB.Checked == true)
                licenseEZRPCheck();
            if (rdbC303.Checked == true) 
                licenseC303Check();
        }        


        private void DoReceive(BackgroundWorker worker)
        {

            if (bgWorker.CancellationPending) return;
            if (!comPort3.IsOpen)
               receiving = c303 = ezrpLicense = c303License  = false;

            string response = "";
            while (receiving)
            {
                if (c303 == true)
                {
                    try
                    {
                        response = comPort3.ReadLine();
                    }
                    catch (TimeoutException)
                    {
                        result3 = "Fail";
                        logTestResult("Fail");                      
                    }
                    catch (Exception ex) { MessageBox.Show(ex.ToString()); }

                    if (response.Contains("0013"))
                    {
                        //MessageBox.Show("Find 0013");                   
                        result3 = "Pass";
                        if (string.Compare(result1, "Pass") == 0 || string.Compare(result2, "Pass") == 0)
                            logTestResult("Pass");
                        c303= receiving = false;

                        /* Stop Pairing Immediately */
                        sendCmd(stopPairingHead + macAddress + stopPairingTail);
                        break;
                    }
                    else
                    {
                        //bgWorker.ReportProgress(0);                   
                    }
                }
                else if (ezrpLicense == true)
                {
                    //MessageBox.Show("ezrpLicense");
                    try
                    {
                        response = comPort3.ReadLine();
                    }                  
                    catch (TimeoutException)
                    {
                        ezrpLicense = receiving = false;
                        logLicenseStatus("Time out");
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.ToString());
                        ezrpLicense = receiving = false;
                    }

                    //MessageBox.Show("response = " + response.ToString() + "response.Length = " + response.Length.ToString());
                    if (response.Contains("011000000008")) //寫入回應
                    {
                        //MessageBox.Show("response = " + response.ToString() + "response.Length = " + response.Length.ToString());
                        
                        logLicenseStatus("EZRP License Success!!");
                        ezrpLicense = receiving = false;
                    }
                    else if (response.Contains("010310")) //讀取的回應
                    {                     
#if false

                        /* Display Write License Result */
                        if (response.Length > 103)
                        {
                            logLicenseResult(response.Substring(71, 32));                          
                        }
#endif
                        /* Display Write License Result */
                        if (response.Length > 103)
                        {
                           // MessageBox.Show("read response = " + response);
                            string tmp = enc.dencryption(response.Substring(71, 32));
                            logLicenseResult(tmp);

                            int cmp = string.Compare(tmp, macAddress);

                            if (cmp == 0)
                            {
                                logLicenseStatus("License Compare Success!");
                            }
                            else
                            {
                                logLicenseStatus("License Compare Fail!");
                            }
                        }
                        ezrpLicense = receiving = false;
                        break;
                    }
                    else
                    {
                        //bgWorker.ReportProgress(0);                   
                    }
                }
                else if (c303License == true)
                {
                    //MessageBox.Show("c303License"); 
                    try
                    {
                        response = comPort3.ReadLine();
                    }
                    catch (TimeoutException)
                    {
                        c303License = receiving = false;
                        logLicenseStatus("Time out");
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.ToString());
                        logLicenseStatus(ex.ToString());
                        c303License = receiving = false;
                    }

                    //MessageBox.Show("response = " + response.ToString()+Environment.NewLine + " response.length"+response.Length.ToString());
                    if (response.Contains("FFAD80010000"))   //寫入的回應
                    {
                        //logLicense("C303 License Success!!");
                        logLicenseStatus("C303 License Success!!");
                        c303License = receiving = false;
                    }
                    else if (response.Contains("FFAD80010001"))//寫入的回應
                    {
                        //logLicense("CRC error!!");
                        logLicenseStatus("CRC error!!");
                        c303License = receiving = false;
                    }
                    else if (response.Contains("FFAD80010002"))//寫入的回應
                    {
                        //logLicense("Fail to write!!");
                        logLicenseStatus("Fail to write!!");
                        c303License = receiving = false;
                    }
                    else if (response.Contains("$80,56," + macAddress))//讀取的回應
                    {
                        /* Display Write License Result */
                        if (response.Length > 103)
                        {                          
                            string tmp = enc.dencryption(response.Substring(73, 32));                        
                            logLicenseResult(tmp);

                            int cmp = string.Compare(tmp,macAddress);
                            
                            if (cmp == 0)
                            {
                                logLicenseStatus("License Compare Success!");
                            }
                            else
                            {
                                logLicenseStatus("License Compare Fail!");
                            }
                        }
                        c303License = receiving = false;
                        break;
                    }    
                    else
                    {
                        //bgWorker.ReportProgress(0);                   
                    }
                
                }
            }
        }

        private void btnIdentify_Click(object sender, EventArgs e)
        {
            clearLogLicense();

            getMacAddress();

            sendCmd(idIdentifyHead + macAddress + idIdentifyTail);
        }

        //btnWriteInvalid
        private void button1_Click(object sender, EventArgs e)
        {
            if (!comPort3.IsOpen)
            {
                logLicenseStatus("Com Port isn't opening !");
                return;
            }
            
            clearLogLicense();

            getMacAddress();

            if (rdbC303.Checked == true)
            {
                lblLicenseStatus.Text = "C303";
                //Encryption
                //license = bytetostring(enc.encryption(tbxLicense.Text));
                license = bytetostring(enc.encryption(invalidMacaddress));

                /* Send to device Function 06 */
                LicenseSendToC303(enc.encryption(invalidMacaddress));

                /* Check License */
                //licenseC303Check();
                c303License = receiving = true;
                if (!bgWorker.IsBusy)
                    bgWorker.RunWorkerAsync();

                /* Leave network */
                //sendCmd(leaveNetworkHead + macAddress + leaveNetworkTail);

                /* Stop Actions */
                pBar.Value = 0;
            }
            else if (rdbEZRP.Checked == true || rdbICB.Checked == true )
            {
                lblLicenseStatus.Text = "EZRP";

                /* Encryption */
                encrypted = enc.encryption(invalidMacaddress);

                /* Save license for Confirm Use*/
                license = bytetostring(encrypted);

                logLicenseResult(license);

                /* Send to device Function 06 */
                LicenseSendToEZRP(mb.CreateWriteHeader(encrypted));

                ezrpLicense = receiving = true;
                if (!bgWorker.IsBusy)
                    bgWorker.RunWorkerAsync();
                /* Check License */
                //licenseEZRPCheck();

                /* Leave network */
                //sendCmd(leaveNetworkHead + macAddress + leaveNetworkTail);

                /* Stop Actions */
                pBar.Value = 0;
            }
        }
                              
    }
}
