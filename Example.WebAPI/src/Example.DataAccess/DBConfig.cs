using System;
using System.Collections.Generic;
using System.Text;

namespace Example.DataAccess
{
    public static class DBConfig
    {

        public static string ParseConfigFile(string filename)
        {
            string [] text = System.IO.File.ReadAllLines(@"" + filename + ".dbcfg");
            int dataStart;
            int dataLen;
            string dataSource ="", init ="", user = "", pass = "", result = "";

            foreach (string line in text)
            {
                if (line[0] != '#')
                {
                    if (line.Contains("DataSource"))
                    {
                        dataStart = line.IndexOf('\'') + 1;
                        dataLen = line.LastIndexOf('\'') - dataStart;
                        dataSource = line.Substring(dataStart, dataLen);
                    }
                    else if (line.Contains("Init"))
                    {
                        dataStart = line.IndexOf('\'') + 1;
                        dataLen = line.LastIndexOf('\'') - dataStart;
                        init = line.Substring(dataStart, dataLen);
                    }
                    else if (line.Contains("User"))
                    {
                        dataStart = line.IndexOf('\'') + 1;
                        dataLen = line.LastIndexOf('\'') - dataStart;
                        user = line.Substring(dataStart, dataLen);
                    }
                    else if (line.Contains("Pass"))
                    {
                        dataStart = line.IndexOf('\'') + 1;
                        dataLen = line.LastIndexOf('\'') - dataStart;
                        pass = line.Substring(dataStart, dataLen);
                    }
                }
            }

            result = "Data Source = " + dataSource + "; Initial Catalog = " + init + "; User ID = " + user + "; Password = " + pass;
            return result;
        }
    }
}
