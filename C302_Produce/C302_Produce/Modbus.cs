using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C303_Produce
{
    class Modbus
    {
        /* Function 3 */
        //01-03-00-00-00-10-44-06
        public  byte[] ReadLicense()
        {
            //Array to receive CRC bytes:
            byte[] CRC = new byte[2];
            
            byte[] data = new byte[8];

            data[0] = (byte)0x01;	// Slave address
            data[1] = (byte)0x03;	// Function code  
            data[2] = (byte)0x00;
            data[3] = (byte)0x00;	
            data[4] = (byte)0x00;	
            data[5] = (byte)0x08;

            GetCRC(data, ref CRC);            

            data[data.Length - 2] = CRC[0];
            data[data.Length - 1] = CRC[1];

            return data;    
        }

        /* Function 6 */ 
        public void WriteLicense(byte[] write_data )
        {
            byte[] data = CreateWriteHeader( write_data ) ;
           // WriteAsyncData(data);
        }
        //$00,56,000D6F00036B52C0,C001,F007,01,01,FFFF,FF,FF,FF,FFFF,
        // 01 10 00 00 00 08 
        // 10 11112222333344445555666677778888A69F  <<長度16 bytes
        public  byte[] CreateWriteHeader(byte[] write_data)
        {
            //uint sizeOfMessage = 7 + length * 2;
            //uint size = length * 2 + 13;
            //Array to receive CRC bytes:
            byte[] CRC = new byte[2];
            byte[] data = new byte[25];

            data[0] = (byte)0x01;			// Slave id high byte
            data[1] = (byte)0x10;			// Slave id low byte
            data[2] = (byte)0x00;
            data[3] = (byte)0x00;	        // Message size
            data[4] = (byte)0x00;			// Slave address
            data[5] = (byte)0x08;			// Function code            
            data[6] = (byte)0x10;	        // Start address

            for (int i = 0; i < 16; i++ )
                data[7+i] = (byte)write_data[i];		    // Start address    

            GetCRC(data, ref CRC);
            data[data.Length - 2] = CRC[0];
            data[data.Length - 1] = CRC[1];
           
            return data;
        }        

        #region Build Message
        private void BuildMessage(byte address, byte type, ushort start, ushort registers, ref byte[] message)
        {
            //Array to receive CRC bytes:
            byte[] CRC = new byte[2];

            message[0] = address;
            message[1] = type;
            message[2] = (byte)(start >> 8);
            message[3] = (byte)start;
            message[4] = (byte)(registers >> 8);
            message[5] = (byte)registers;

            GetCRC(message, ref CRC);
            message[message.Length - 2] = CRC[0];
            message[message.Length - 1] = CRC[1];
        }
        #endregion

        public  UInt16 ModRTU_CRC(byte[] buf, int len)
        {
            UInt16 crc = 0xFFFF;

            for (int pos = 0; pos < len; pos++)
            {
                crc ^= (UInt16)buf[pos];          // XOR byte into least sig. byte of crc

                for (int i = 8; i != 0; i--)
                {    // Loop over each bit
                    if ((crc & 0x0001) != 0)
                    {      // If the LSB is set
                        crc >>= 1;                    // Shift right and XOR 0xA001
                        crc ^= 0xA001;
                    }
                    else                            // Else LSB is not set
                        crc >>= 1;                    // Just shift right
                }
            }
            // Note, this number has low and high bytes swapped, so use it accordingly (or swap bytes)
            return crc;
        }

        #region CRC Computation
        public void GetCRC(byte[] message, ref byte[] CRC)
        {
            //Function expects a modbus message of any length as well as a 2 byte CRC array in which to 
            //return the CRC values:

            ushort CRCFull = 0xFFFF;
            byte CRCHigh = 0xFF, CRCLow = 0xFF;
            char CRCLSB;

            for (int i = 0; i < (message.Length) - 2; i++)
            {
                CRCFull = (ushort)(CRCFull ^ message[i]);

                for (int j = 0; j < 8; j++)
                {
                    CRCLSB = (char)(CRCFull & 0x0001);
                    CRCFull = (ushort)((CRCFull >> 1) & 0x7FFF);

                    if (CRCLSB == 1)
                        CRCFull = (ushort)(CRCFull ^ 0xA001);
                }
            }
            CRC[1] = CRCHigh = (byte)((CRCFull >> 8) & 0xFF);
            CRC[0] = CRCLow = (byte)(CRCFull & 0xFF);
        }
        #endregion
    }
}
