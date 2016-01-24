using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kosus.DataAccess.MySql.InformationSchema
{
    public class TableInfo
    {
        private Kosus.DataAccess.MySql.MultiCon multiCon = null;

        public class RowData
        {
            public string table_schema { get; set; }
            public string table_name { get; set; }
            public string column_name { get; set; }
        }

        private List<RowData> listData = new List<RowData>();

        public TableInfo(Kosus.DataAccess.MySql.MultiCon multiCon)
        {
            this.multiCon = multiCon;
            LoadDataToMemory();
        }

        public void LoadDataToMemory()
        {
            listData = multiCon.GetIEnumerable<RowData>("SELECT `TABLE_SCHEMA` , `TABLE_NAME` , `COLUMN_NAME` FROM `information_schema`.`COLUMNS` ").ToList();
        }

        public IEnumerable<RowData> GetRowData(string databaseName, string tableName)
        {
            return listData.Where(n => n.table_schema.Equals(databaseName, StringComparison.InvariantCultureIgnoreCase) && n.table_name.Equals(tableName, StringComparison.InvariantCultureIgnoreCase));
        }

        public IEnumerable<Tuple<string, string>> GetDatabasesAndTables()
        {
            return listData.Select(n => new Tuple<string, string>(n.table_schema, n.table_name)).Distinct();
        }

        public IEnumerable<string> GetDatabases()
        {
            return listData.Select(n => n.table_schema).Distinct();
        }

        public IEnumerable<string> GetTables(string databaseName)
        {
            return listData.Where(n => n.table_schema.Equals(databaseName, StringComparison.InvariantCultureIgnoreCase)).Select(n => n.table_name).Distinct();
        }

        public IEnumerable<string> GetColumns(string databaseName, string tableName)
        {
            return listData.Where(n => n.table_schema.Equals(databaseName, StringComparison.InvariantCultureIgnoreCase) && n.table_name.Equals(tableName, StringComparison.InvariantCultureIgnoreCase)).Select(n => n.table_name).Distinct();
        }

        public IEnumerable<Tuple<string, string>> GetDatabaseAndTables()
        {
            return listData.Select(n => new Tuple<string, string>(n.table_schema, n.table_name)).Distinct();
        }

        public List<RowData> GetAllData()
        {
            return listData;
        }

    }
}
