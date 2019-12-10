using Example.Business.Interfaces;
using Example.Business.Models;
using Example.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.WebAPI.Controllers {
    public class ControllerHelperFunctions {
        public static void databaseWordTransaction(String[] words, DBInteraction _DB) {
            //Persist word/char stats
            for (int i = 0; i < words.Length; i++)
            {
                _DB.AddUsedWord(words[i]);
            }
        }

        public static void databaseCharacterTransaction() {
            
        }
    }
}