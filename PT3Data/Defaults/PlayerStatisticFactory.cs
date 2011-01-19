using DataCore;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT3Data.Defaults
{
    public class PlayerStatisticFactory
    {
        public static DataSet generate(Player player)
        {
            // this isn't a real query, just an example
            string statement = String.Format("SELECT * ",
                                             "FROM player ",
                                             "WHERE player = '{0}'", player.name);
            return DBUtil.runQuery(statement);
        }
    }
}
