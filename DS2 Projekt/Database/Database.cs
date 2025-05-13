using System;
using System.Data;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data.SqlClient;

namespace DS2_Projekt
{
    /// <summary>
    /// Represents a Oracle Database
    /// </summary>
    public class Database
    {
        private OracleConnection Connection { get; set; }
        private OracleTransaction SqlTransaction { get; set; }
        public string Language { get; set; }

        public Database()
        {
            Connection = new OracleConnection();
            Language = "en";
        }

        public void InitialiseDatabase() {
            
        }

        /// <summary>
        /// Connect
        /// </summary>
        public bool Connect(String conString)
        {
            if (Connection.State != System.Data.ConnectionState.Open)
            {
                Connection.ConnectionString = conString;
                Connection.Open();
            }
            return true;
        }

        /// <summary>
        /// Connect
        /// </summary>
        public bool Connect()
        {
            if (Connection.State == ConnectionState.Open)
                return true;

            var connStr = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=dbsys.cs.vsb.cz)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=oracle)));User Id=nikdo;Password=nictuneni;Connection Timeout=45;";

            return Connect(connStr);
        }

        /// <summary>
        /// Close.
        /// </summary>
        public void Close()
        {
            Connection.Close();
        }

        /// <summary>
        /// Begin a transaction.
        /// </summary>
        public void BeginTransaction()
        {
           SqlTransaction = Connection.BeginTransaction(IsolationLevel.Serializable);
        }

        /// <summary>
        /// End a transaction.
        /// </summary>
        public void EndTransaction()
        {
            // command.Dispose()
            SqlTransaction.Commit();
        }

        /// <summary>
        /// If a transaction is failed call it.
        /// </summary>
        public void Rollback()
        {
            SqlTransaction.Rollback();
        }

        /// <summary>
        /// Insert a record encapulated in the command.
        /// </summary>
        public int ExecuteNonQuery(OracleCommand command)
        {
            int rowNumber = 0;
            rowNumber = command.ExecuteNonQuery();
            return rowNumber;
        }

        /// <summary>
        /// Create command.
        /// </summary>
        public OracleCommand CreateCommand(string strCommand)
        {
            OracleCommand command = new OracleCommand(strCommand, Connection);

            if (SqlTransaction != null)
            {
                command.Transaction = SqlTransaction;
            }
            return command;
        }
        /// <summary>
        /// Select encapulated in the command.
        /// </summary>
        public OracleDataReader Select(OracleCommand command)
        {
            //command.Prepare();
            OracleDataReader sqlReader = command.ExecuteReader();
            return sqlReader;
        }
        public static Database Connect(Database pDb)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = pDb;
            }
            return db;
        }
        public static void Close(Database pDb, Database db)
        {
            if (pDb == null)
            {
                db.Close();
            }
        }
    }
}

