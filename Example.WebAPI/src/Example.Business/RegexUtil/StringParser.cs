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

            return generateNewString(inputString, dbi.GetTable("tableName"));
        }

        public static String generateNewString(String inputString, LinkedList<string[]> stringTable)
        {
            Random random = new Random();

            string outputString;
            outputString = inputString.ToLower();
            int randomNumber = 1;

            foreach (string[] stringArray in stringTable)
            {
                while ((Regex.Matches(outputString, ".*" + stringArray[0] + ".*")).Count > 0)
                {
                    randomNumber = random.Next(4) + 1;
                    outputString = Regex.Replace(outputString, stringArray[0], stringArray[randomNumber]);
                }
            }

            return outputString;

        }
    }
}
