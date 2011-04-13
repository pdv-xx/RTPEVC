using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PT3Data
{
    /*
     * Refer to http://npgsql.projects.postgresql.org/docs/manual/UserManual.html for
     * help with the Npgsql API and understanding the code below.
     */
    public class DBUtil
    {
        public static DataSet executeQuery(string statement)
        {
            /*
             * Jordan:
             * Every piece of this DSN needs to be derived from the configs. It can't stay
             * hard-coded here.
             */
            string dsn = "Server=127.0.0.1;port=5432;User Id=admin;Password=admin;Database=pokertracker;";
            DataSet result = null;
            using (NpgsqlConnection conn = new NpgsqlConnection(dsn))
            {
                try
                {
                    conn.Open();
                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(statement, conn))
                    {
                        da.Fill(result);
                    }
                }
                catch (Exception e)
                {
                    /* 
                     * Log this exception. We don't have a logging module, so maybe this is a component we can 
                     * add..? Take a look at NLog, whoever wants to take this on. This is a component that cross-
                     * cuts through the entire project, since emission of logs is important for every component.
                     */
                }
                finally 
                {
                    conn.Close();
                }
            }
            return result;
        }
    }
}
