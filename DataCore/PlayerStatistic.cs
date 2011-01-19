using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataCore
{
    class PlayerStatistic
    {
        // volume put in pot %
        public double vpip { get; set; }
        // preflop raise %
        public double pfr { get; set; }
        // overall agression factor average
        public double afr { get; set; }
        // preflop aggression factor
        public double pfAfr { get; set; }
        // flop aggression factor
        public double fAfr { get; set; }
        // turn aggression factor
        public double tAfr { get; set; }
        // river aggression factor
        public double rAfr { get; set; }
    }
}
