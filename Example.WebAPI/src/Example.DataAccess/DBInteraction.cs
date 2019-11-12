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
            string connString = DBConfig.ParseConfigFile("apidb");

            return new SqlConnection(connString);
        }

        public int GetWordUse(string word)
        {
            string queryString = "SELECT USES FROM WORD_USE WHERE WORD = \'" + word + "\';";
            SqlConnection sqlConn = ConnectToDB();
            SqlCommand command = new SqlCommand(queryString, sqlConn);

            sqlConn.Open();

            SqlDataReader reader = command.ExecuteReader();

            reader.Read();

            int count = reader.GetInt32(0);

            sqlConn.Close();

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

            int count = reader.GetInt32(0);

            return count;
        }
    }
}
