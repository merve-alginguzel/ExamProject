using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataConnection
{
    public class DBUtilities
    {
        private SqliteConnection _cn;
        private SqliteCommand _cmd;

        public string conStrSql { get { return "Data Source=Db/ExamSQL.s3db"; } }
        public SqliteCommand cmd { get { return _cmd; } }

        public SqliteConnection cn { get { return _cn; } }
        public DBUtilities()
        {
            _cn = new SqliteConnection(conStrSql);
            _cmd = new SqliteCommand();
            _cmd.CommandType = System.Data.CommandType.Text;
            _cmd.Connection = _cn;

        }

        /// </summary>
        public void endC()
        {
            this.cn.Close();
            this.cmd.Parameters.Clear();
            this.cmd.Dispose();
            this.cn.Dispose();
        }
    }
}
