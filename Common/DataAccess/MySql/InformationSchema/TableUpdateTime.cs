﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Kosus.DataAccess.MySql.InformationSchema
{
    /// <summary>
    /// Table update check class
    /// </summary>
    public class TableUpdateTime
    {
        private readonly object _lock = new object();
        private Dictionary<Tuple<string, string, string>, DateTime> dictUpdates = new Dictionary<Tuple<string, string, string>, DateTime>();
        private MultiCon multiCon = null;
        private DateTime lastCheck = new DateTime(1970, 1, 1);

        /// <summary>
        /// Constructor for connection string
        /// </summary>
        public TableUpdateTime(ConnectionString connectionString)
        {
            this.multiCon = new MultiCon(connectionString);
        }

        /// <summary>
        /// Constructor for connectiong string class
        /// </summary>
        public TableUpdateTime(MultiCon multiCon)
        {
            this.multiCon = multiCon;
        }

        /// <summary>
        /// Returns true if table has been updated since last HasChanged check. First time always returns true
        /// Update time is not available for INNODB
        /// </summary>
        public bool HasChanged(string database, string table, uint updateIntervalSeconds = 0, string askerId = null)
        {
            lock (_lock)
            {
                if (updateIntervalSeconds > 0)
                    if ((DateTime.Now - lastCheck).TotalSeconds < updateIntervalSeconds)
                        return false;
                    else
                        lastCheck = DateTime.Now;

                Tuple<string, string, string> identifier = new Tuple<string, string, string>(askerId, database, table);

                string query = "SELECT `UPDATE_TIME` FROM `information_schema`.`TABLES` WHERE `TABLE_SCHEMA`=@database && `TABLE_NAME`=@table LIMIT 1;";

                DateTime lastModified = multiCon.GetObject<DateTime>(query, false, new ParameterData("database", database), new ParameterData("table", table));
                
                if (!dictUpdates.ContainsKey(identifier))
                    dictUpdates.Add(identifier, lastModified);
                else
                    if (dictUpdates[identifier] == lastModified)
                        return false;
                    else
                        dictUpdates[identifier] = lastModified;
            }
            return true;
        }
    }
}
