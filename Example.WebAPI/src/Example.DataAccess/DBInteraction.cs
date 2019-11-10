using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Example.DataAccess
{
    public class DBInteraction
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

        public int GetWordUse(string word)
        {
            string queryString = "SELECT USES FROM WORD_USE WHERE WORD = \'" + word + "\';";
            SqlConnection sqlConn = ConnectToDB();
            SqlCommand command = new SqlCommand(queryString, sqlConn);

            sqlConn.Open();

            SqlDataReader reader = command.ExecuteReader();

            reader.Read();

           string result = reader.GetString(1);

            int count = Convert.ToInt32(result);

            return count;
        }

        public int GetCharUse(char character)
        {
            string queryString = "SELECT USES FROM CHAR_USE WHERE Letter = \'" + character + "\';";
            SqlConnection sqlConn = ConnectToDB();
            SqlCommand command = new SqlCommand(queryString, sqlConn);

            sqlConn.Open();

            SqlDataReader reader = command.ExecuteReader();

            reader.Read();

            string result = reader.GetString(1);

            int count = Convert.ToInt32(result);

            return count;
        }
    }
}
