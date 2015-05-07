using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


namespace C303_Produce
{
    class Encryption
    {
        byte[] bArray = new byte[16];
        byte mac1, mac2, mac3, mac4, mac5, mac6, mac7, mac8;
        byte key1, key2;
        byte reserved1, reserved2, reserved3, reserved4, reserved5, reserved6;

        Random random = new System.Random();

        public string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            return sb.ToString().ToUpper();
        }

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

        private void generatorMacaddress(string macAddress)
        {
            bArray[2] = mac1 = Convert.ToByte(macAddress.Substring(0, 2), 16);
            bArray[3] = mac2 = Convert.ToByte(macAddress.Substring(2, 2), 16);
            bArray[4] = mac3 = Convert.ToByte(macAddress.Substring(4, 2), 16);
            bArray[6] = mac4 = Convert.ToByte(macAddress.Substring(6, 2), 16);
            bArray[7] = mac5 = Convert.ToByte(macAddress.Substring(8, 2), 16);
            bArray[9] = mac6 = Convert.ToByte(macAddress.Substring(10, 2), 16);
            bArray[10] = mac7 = Convert.ToByte(macAddress.Substring(12, 2), 16);
            bArray[11] = mac8 = Convert.ToByte(macAddress.Substring(14, 2), 16);
        }

        private void randomGeneratorKey()
        {
            bArray[5] = key1 = (byte)random.Next(0, 255);
            bArray[8] = key2 = (byte)random.Next(0, 255);
        }

        private void randomGeneratorReserved()
        {
            bArray[0] = reserved1 = (byte)random.Next(0, 255);
            bArray[1] = reserved2 = (byte)random.Next(0, 255);
            bArray[12] = reserved3 = (byte)random.Next(0, 255);
            bArray[13] = reserved4 = (byte)random.Next(0, 255);
            bArray[14] = reserved5 = (byte)random.Next(0, 255);
            bArray[15] = reserved6 = (byte)random.Next(0, 255);
        }

        private void operatorKey1XorOdd()
        {
            bArray[2] ^= bArray[5];
            bArray[4] ^= bArray[5];
            bArray[7] ^= bArray[5];
            bArray[10] ^= bArray[5];        
        }

        private void operatorKey2XorEven()
        {
            bArray[3] ^= bArray[8];
            bArray[6] ^= bArray[8];
            bArray[9] ^= bArray[8];
            bArray[11] ^= bArray[8];
        }


        private void operatorKey1XorOdd(byte[] value)
        {
            value[2] ^= value[5];
            value[4] ^= value[5];
            value[7] ^= value[5];
            value[10] ^= value[5];
        }

        private void operatorKey2XorEven(byte[] value)
        {
            value[3] ^= value[8];
            value[6] ^= value[8];
            value[9] ^= value[8];
            value[11] ^= value[8];
        }

      

        public static void RotateRight(byte[] value, int bytes)
        {
            int i;
            byte temp = 0, last = 0;

            for (i = 0; i < bytes; i++)
            {
                if (i == 0)/* value[0] */
                {
                    last = (byte)(value[i] & 0x01);
                    value[i] = (byte)(value[i] >> 1);
                }
                else if (i > 0 && i < bytes)/* value[1]~value[15] */
                {
                    temp = last;
                    last = (byte)(value[i] & 0x01);
                    value[i] >>= 1;
                    value[i] = (byte)(value[i] | (temp << 7));
                }
            }
            value[0] = (byte)(value[0] | (last << 7)); 
        }      

        public static void RotateLeft(byte[] value, int bytes)
        {
            int i;
            byte temp = 0, first = 0;


            for (i = bytes - 1; i != -1; i--)
            {
                if (i == bytes - 1) /*value[15]*/
                {
                    first = (byte)(value[i] & 0x80); ;
                    value[i] = (byte)(value[i] << 1);
                }
                else if (i >= 0 && i < bytes) /*value[14]~/*value[0]*/
                {
                    temp = first;
                    first = (byte)(value[i] & 0x80);
                    value[i] <<= 1;
                    value[i] = (byte)(value[i] | (temp >> 7));
                }
            }
            value[bytes - 1] = (byte)(value[bytes - 1] | (first >> 7));
        }

        public static void rigthRotation(byte[] value)
        {
            RotateRight(value, 16);
        }

        public static void leftRotation(byte[] value)
        {
            RotateLeft(value, 16);
        }

        public byte[] encryption(string macAddress)
        {
            generatorMacaddress(macAddress);
            /* GeneratorKey , Reserved */
            randomGeneratorKey();
            randomGeneratorReserved();
            /* Xor MacAddress */
            operatorKey1XorOdd();            
            operatorKey2XorEven();
            /* Right Shift 3 times*/
            rigthRotation(bArray);
            rigthRotation(bArray);
            rigthRotation(bArray);
            return bArray;

           //fillByteArray();
        }

        public  string dencryption(string license)
        {
            string Mac1, Mac2, Mac3, Mac4, Mac5, Mac6, Mac7, Mac8;

            byte[] data = HexStringToByteArray(license);
            
            leftRotation(data);
            leftRotation(data);
            leftRotation(data);

            /* Xor MacAddress */
            operatorKey2XorEven(data);
            operatorKey1XorOdd(data);            

            Mac1 = data[2].ToString("X2");
            Mac2 = data[3].ToString("X2");
            Mac3 = data[4].ToString("X2");
            Mac4 = data[6].ToString("X2");
            Mac5 = data[7].ToString("X2");
            Mac6 = data[9].ToString("X2");
            Mac7 = data[10].ToString("X2");
            Mac8 = data[11].ToString("X2");

            //MessageBox.Show("Mac = "+Mac1+Mac2+Mac3+Mac4+Mac5+Mac6+Mac7+Mac8);

            return Mac1 + Mac2 + Mac3 + Mac4 + Mac5 + Mac6 + Mac7 + Mac8;
        }
    }
}
