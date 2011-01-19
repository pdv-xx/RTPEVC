using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataCore
{
    public class Player
    {
        // This is one constructor that allows you to set the player's name right off the bat.
        // You would use it like:
        // Player player = new Player("bob");
        public Player(string name)
        {
            this.name = name;
        }
        // This is an alternative constructor that expects nothing to be set when a new "Player" is created.
        // If you don't define a C# constructor, this is the one that is implemented by default by .Net.
        public Player() { }
        // Following are getters and setters for the pieces of info that Player objects can store.
        public string name { get; set; }
        public PlayerStatistic statistic { get; set; }
    }
}
