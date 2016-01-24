﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kosus.DataAccess.MySql.Misc
{
    public class Log
    {
        private readonly object _lock = new object();

        private ulong mysqlQueries = 0;
        private ulong mysqlUpdates = 0;

        public ulong GetAndResetMysqlUpdates()
        {
            try
            {
                lock (_lock)
                    return mysqlUpdates;
            }
            finally
            {
                lock (_lock)
                    mysqlUpdates = 0;
            }
        }

        public ulong GetAndResetMysqlQueries()
        {
            try
            {
                lock (_lock)
                    return mysqlQueries;
            }
            finally
            {
                lock (_lock)
                    mysqlQueries = 0;
            }
        }

        public ulong GetMysqlQueries()
        {
            lock (_lock) return mysqlQueries;
        }

        public ulong GetMysqlUpdates()
        {
            lock (_lock) return mysqlUpdates;
        }

        public void ResetUpdatesAndQueriesCount()
        {
            lock (_lock)
            {
                mysqlQueries = 0;
                mysqlUpdates = 0;
            }
        }

        public void IncreaseUpdates(ulong updates)
        {
            lock (_lock)
                mysqlUpdates += updates;
        }

        public void IncreaseQueries(ulong queries)
        {
            lock (_lock)
                mysqlQueries += queries;
        }
    }
}
