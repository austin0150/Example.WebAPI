using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Example.DataAccess;

namespace Example.Business.RegexUtil
{
    class StringParser
    {
        public static String generateNewString(String inputString, String tableName)
        {
            DBInteraction dbi = new DBInteraction();

            return generateNewString(inputString, dbi.getTable("tableName"));
        }

        public static String generateNewString(String inputString, LinkedList<string[]> stringTable)
        {
            Regex regex;
            Random random = new Random();

            string outputString = inputString.ToLower();
            int randomNumber = 1;

            foreach (string[] stringArray in stringTable)
            {
                regex = new Regex(stringArray[0]);
                while (regex.IsMatch("(?s).*" + stringArray[0] + ".*"))
                {
                    randomNumber = random.Next(4);
                    regex.Replace(outputString, stringArray[randomNumber], 1, 0);
                }
            }

            return outputString;

        }
    }
}
