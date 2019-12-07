/**********************************************************
 * Database Utilities class
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 * ********************************************************/

// http://support.microsoft.com/kb/301240

using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text.RegularExpressions;

namespace SQL {

    /// <summary>
    /// Summary description for Utils
    /// </summary>
    public class Utils {
        public Utils() {

        }
        /// <summary>
        /// An infinitely useful way to lookup a value in a database. It builds a query, submits, it, and captures the results.
        /// </summary>
        /// <param name="pTarget">The column to return</param>
        /// <param name="pDomain">The table where the column is</param>
        /// <param name="pCriteria">The filter to apply. It's everything but the WHERE keyword</param>
        /// <param name="pAggregate">The GROUP BY clause, without the GROUP BY keyword</param>
        /// <returns>The value in pTarget after the query is executed</returns>
        public static object MyDLookup(String pTarget, String pDomain, String pCriteria, String pAggregate) {
            String criteria;
            //bool keepGoing;
            String aggregate;
            String asName;
            object result = null;
            System.Data.SqlClient.SqlDataReader reader = null;

            if (pAggregate.Trim().Length != 0) {
                aggregate = pAggregate;      // MAX, MIN, etc.
                asName = "foo";              // We need a unique name because this is a calculated field
            } else {
                aggregate = "";
                asName = "foo";              // We can't use pTarget here because it causes an SQL "Circular Reference" error
            }
            //  If the domain is a select statement, don't do anything to it. We can't perform an agregate function on SQL.
            //    Whoever calls this function should configure the SQL to have the desired record at the top of the cursor
            //    before calling this function.
            if ((pDomain.Length > 7) && (pDomain.Substring(1, 6) == "SELECT")) {
                criteria = pDomain;
                asName = pTarget;
            } else {
                criteria = "SELECT " + aggregate + "(" + pTarget + ") AS " + asName + " FROM " + pDomain;
                if (pCriteria == "") {
                } else {
                    criteria = criteria + " WHERE " + pCriteria;
                }
                criteria = criteria + ";";
            }
            //keepGoing = true;

            try {
                //MySqlCommand command = new MySqlCommand(criteria, myConnection);
                try { Config.myConnection.Close(); } catch (Exception e) { }
                CheckConnection();
                System.Data.SqlClient.SqlCommand command = Config.myConnection.CreateCommand();
                command.CommandText = criteria;

                reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                if (reader.HasRows) {
                    reader.Read();       // Get the first row. We always assume it's the first row, in this function
                    result = reader.GetValue(0);
                } else {
                    result = null;
                }

                reader.Close();
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                result = null;                // null means we failed
                try { reader.Close(); } catch (Exception ex) { }
            }
            return result;
        }
        /// <summary>
        /// Check the connection to the db
        /// </summary>
        /// <returns>true if the connection is active, false otherwise.</returns>
        public static bool CheckConnection() {
            // todo: Add a select case to handle all the possible states of myConnection.State
            bool status = true, justGotConnString = false;

            if (Config.myConnection == null) {
                Config.myConnection = new System.Data.SqlClient.SqlConnection(Config.connectionString);
                justGotConnString = true;
            }
            if (Config.myConnection.State != System.Data.ConnectionState.Open) {
                if (!justGotConnString) { Config.myConnection.ConnectionString = Config.connectionString; }
                try {
                    Config.myConnection.Open();
                } catch (Exception ex) {
                    status = false;
                }
            }
            return status;
        }
        /// <summary>
        /// Submit an action query to the db
        /// </summary>
        /// <param name="pSQL">The query</param>
        /// <param name="pCommandType">Default to text if you're not sure</param>
        /// <param name="pSQLCmd">Not used. Set to null when you invoke this method</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(String pSQL,
                                          System.Data.CommandType pCommandType,
                                          System.Data.SqlClient.SqlCommand pSQLCmd) {
            int status = -1;
            try {
                // I don't know why the Framework method is called "ExecuteNonQuery" but I named this
                //  function the same, to reduce confusion. The name should be "ExecuteActionQuery"

                CheckConnection();
                System.Data.SqlClient.SqlCommand objCmd = Config.myConnection.CreateCommand();
                objCmd.CommandText = pSQL;
                objCmd.CommandType = pCommandType;      // The default is 'text', which implies an SQL string
                objCmd.Parameters.Clear();               // Just in case we used any the last time we called this
                objCmd.ExecuteNonQuery();
                return status;
            } catch (Exception ex) {
                try {
                    //ErrorLog.LogEvent(pSQL + " ERROR in ExcecuteNonQuery() : " + ex.Message, 0,  0);
                    System.Console.WriteLine(DateTime.Now + " ExecuteNonQuery() : " + ex.Message + " : " + pSQL);
                    status = 1;
                } catch (Exception ex1) {
                    status = 0;
                }
                return status;
            }
        }

        /// <summary>
        /// Delimit a string with quotes. 
        /// </summary>
        /// <param name="s">The string to delimit</param>
        /// <returns>The delimited string</returns>
        public static String QuoteMe(String s) {
            return (Config.quote + s + Config.quote);
        }

        /*
         *  SQL Server wants strings delimited with single quotes
         */
        public static String QuoteMeForSQL(String s) {
            return ("'" + s + "'");
        }

    }
}