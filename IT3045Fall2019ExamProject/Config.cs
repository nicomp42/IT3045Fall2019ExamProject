/**********************************************************
 * Configuration class
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 * ********************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL {
    class Config {
        public const char quote = (char)(34);
        public static System.Data.SqlClient.SqlConnection myConnection;
        public static String connectionString;
        public const char backQuote = (char)(96);          // 
        public const char singleQuote = (char)(39);
        /// <summary>
        /// Constructor
        /// </summary>
        static Config() {
            connectionString = "Data Source=il-server-001.uccc.uc.edu\\mssqlserver2012;Initial Catalog=Cat3045;Persist Security Info=True;User ID=Cat3045Login;Password=P@ssword";
        }
    }
}


/* Sample
    public static int AttemptLogIn(String pUserName, String pPassword)
    {
        int intUserID = 0;                   // Assume the worst
        intUserID = Convert.ToInt32(Utils.MyDLookup("UserID",
                                              "tUser",
                                              "UserName = N" + config.singleQuote + pUserName + config.singleQuote + " AND Password = N" + config.singleQuote + pPassword + config.singleQuote,
                                              ""));
        return intUserID;
    }
*/