using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoSharp.Domain
{
    public class Match
    {
        public DateTime Date { get; set; }
        public List<Player> TeamRadient { get; set; }
        public List<Player> TeamDire { get; set; }
    }
}
