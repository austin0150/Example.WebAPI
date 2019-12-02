using Example.Business.Interfaces;
using Example.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Example.DataAccess;

namespace Example.Business {
    public class Lowercase : ILowercase {
        public LowercaseResponse ProcessRequest(LowercaseRequest request) {
            LowercaseResponse response = new LowercaseResponse();
            HelperFunctions helper = new HelperFunctions();

            DBInteraction interaction = new DBInteraction();
            String changeString = request.stringToModify;

            // //Store database Metrics
            // String[] dbArray = changeString.Split(".");
            // foreach (String sentence in dbArray) {
            //     String[] word = sentence.Split(" ");
            //     foreach (String wordVal in word) {
            //         interaction.AddUsedWord(wordVal.ToLower());
            //     }
            // }

            if (request.firstCharOnly) {
                int count = 0;
                //Find the total amount of white spaces
                for (int i = 0; i < changeString.Length; i++) {
                        if (changeString[i] == ' ') {
                            count++;
                        }
                        else {
                            break;
                        }
                    }

                changeString = changeString.TrimStart();
                Console.WriteLine(changeString);

                if (changeString.Length >= 1) {
                    char changeStringChar = changeString[0];
                    changeStringChar = Char.ToLower(changeStringChar);
                    changeString = changeString.Remove(0, 1);
                    changeString = changeString.Insert(0, changeStringChar.ToString());
                }
                
                for (int x = 0; x < count; x++)
                {
                    //reinsert white spaces
                    changeString = changeString.Insert(0, " ");
                    //changeString = " " + changeString;
                }
            }
            else {
                changeString = changeString.ToLower();
            }
            
            if (request.trimPrecedingWhiteSpace) {
                changeString = changeString.TrimStart();
            }

            if (request.trimTrailingWhiteSpace) {
                changeString = changeString.TrimEnd(); 
            }

            response.modifiedString = changeString;
            response.originalString = request.stringToModify;
            return response;
        }

        public void ValidateRequest(LowercaseRequest request) {
            if (request.firstCharOnly && request.stringToModify.StartsWith(' ') && !request.trimPrecedingWhiteSpace)
            {
                throw new Exception("Cannot convert the first char to lowercase if it is a space. Set Trim Preceding White Space true, or remove the preceding spaces from the request");
            }
        }

        
    }
}