using MangoSharp.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoSharp
{
    /// <summary>
    /// Client for accessing the DotA 2 Web-API
    /// </summary>
    public class MangoClient
    {
        public string Key { get; private set; }

        /// <summary>
        /// Contructor for the MangoClient
        /// </summary>
        /// <param name="key">Developer API Key</param>
        public MangoClient(string key)
        {
            Key = key;
            Repository.Key = Key;
            Repository.LoadHeroes();
            Repository.LoadItems();
        }
    }
}
