﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


namespace C303_Produce
{
    class CSV
    {
        //write a new file, existed file will be overwritten
        public static void WriteCSV(string filePathName, List<String[]> ls)
        {
            WriteCSV(filePathName, false, ls);
        }
        //write a file, existed file will be overwritten if append = false
        public static void WriteCSV(string filePathName, bool append, List<String[]> ls)
        {
            try
            {
                StreamWriter fileWriter = new StreamWriter(filePathName, append, Encoding.Default);

                foreach (String[] strArr in ls)
                {              
                    fileWriter.WriteLine(String.Join(",", strArr));
                }
                fileWriter.Flush();
                fileWriter.Close();
            }
            catch (Exception ex) { }

        }

        public static List<String[]> ReadCSV(string filePathName)
        {
            List<String[]> ls = new List<String[]>();
            StreamReader fileReader = new StreamReader(filePathName);
            string strLine = "";
            while (strLine != null)
            {
                strLine = fileReader.ReadLine();
                if (strLine != null && strLine.Length > 0)
                {
                    ls.Add(strLine.Split(','));
                    //Debug.WriteLine(strLine);
                }
            }
            fileReader.Close();
            return ls;
        }
       
    }
}
