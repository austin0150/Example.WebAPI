using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Example.DataAccess
{
    public class DBInteraction
    {
        public string connString;

        public DBInteraction()
        {
            connString = DBConfig.ParseConfigFile("apidb");
        }

        public void AddUsedWord(string word)
        {
            //Convert everything to uppercase first
            word = word.ToUpper();

            for(int i = 0; i < word.Length; i++)
            {
                AddUsedChar(word[i]);
            }

            int preCount = GetWordUse(word);
            string cmdString = "";

            if(preCount > 0)
            {
                cmdString = "UPDATE WORD_USE SET USES = " + (preCount + 1) + " WHERE WORD = \'" + word +"\';";
            }
            else
            {
                cmdString = "INSERT INTO WORD_USE (WORD, USES) VALUES (\'" + word + "\', 1)";
            }

            SqlConnection conn = ConnectToDB();

            SqlCommand cmd = new SqlCommand(cmdString, conn);


            conn.Open();

            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public void AddUsedChar(char character)
        {
            int preCount = GetCharUse(character) ;
            string cmdString = "";

            if (preCount > 0)
            {
                cmdString = "UPDATE CHAR_USE SET USES = " + (preCount + 1) + " WHERE LETTER = \'" + character + "\';";
            }
            else
            {
                cmdString = "INSERT INTO CHAR_USE (LETTER, USES) VALUES (\'" + character + "\', 1)";
            }

            SqlConnection conn = ConnectToDB();

            SqlCommand cmd = new SqlCommand(cmdString, conn);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
            return;
 
        }

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
            return new SqlConnection(connString);
        }

        public int GetWordUse(string word)
        {
            //convert to upper case
            word = word.ToUpper();

            string queryString = "SELECT USES FROM WORD_USE WHERE WORD = \'" + word + "\';";
            SqlConnection sqlConn = ConnectToDB();
            SqlCommand command = new SqlCommand(queryString, sqlConn);

            sqlConn.Open();

            SqlDataReader reader = command.ExecuteReader();

            if(reader.HasRows)
            {
                reader.Read();

                int count = reader.GetInt32(0);

                sqlConn.Close();

                return count;
            }
            else
            {
                return 0;
            }
            
        }

        public int GetCharUse(char character)
        {
            character = char.ToUpper(character);
            string queryString = "SELECT USES FROM CHAR_USE WHERE Letter = \'" + character + "\';";
            SqlConnection sqlConn = ConnectToDB();
            SqlCommand command = new SqlCommand(queryString, sqlConn);

            sqlConn.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                int count = reader.GetInt32(0);

                sqlConn.Close();

                return count;
            }
            else
            {
                sqlConn.Close();
                return 0;
            }
        }

        public LinkedList<string[]> GetTable(string tableName)
        {
            LinkedList<string[]> outputString = new LinkedList<string[]>();

            string queryString = "SELECT * FROM " + tableName;
            SqlConnection sqlConn = ConnectToDB();
            SqlCommand command = new SqlCommand(queryString, sqlConn);

            sqlConn.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.HasRows)
            {
                reader.Read();

                outputString.AddLast(new string[]{reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)});

                sqlConn.Close();
            }

            return outputString;
        }
    }
}
