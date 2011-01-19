using DataCore;
using PT3Data.Defaults;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataService
{
    public class Fetch
    {
        public static DataSet playerStatistic(string playerName)
        {
            Player player = new Player(playerName);
            // could just return this result, or maybe set up player.statistic w/ a new PlayerStatistic
            // set of info derived from the result of PlayerStatisticFactory.generate(player). then you
            // could do more with the data before returning the results. that's up to you. either way, 
            // this is where this kind of stuff goes.
            return PlayerStatisticFactory.generate(player);
        }
    }
}
