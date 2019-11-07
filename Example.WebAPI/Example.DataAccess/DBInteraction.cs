using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Example.DataAccess
{
    class DBInteraction
    {
        public string connString;

        void AddUsedWord(string word)
        { }

        void AddUsedChar(char character)
        { }

        string FilterUnsavvy(string word)
        {
            return "";
        }

        string FilterSynonym(string word)
        {
            return "";
        }

        SqlConnection ConnectToDB()
        {
            return new SqlConnection();
        }

        int GetWordUse(string word)
        {
            return 0;
        }

        int GetCharUse(char character)
        {
            return 0;
        }
    }
}
