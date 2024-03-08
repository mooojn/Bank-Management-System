using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainBusinessApp
{
    internal class Asset
    {
        private string name;
        private int worth;
        public Asset(string name, int worth)
        {
            this.name = name;
            this.worth = worth;
        }
    }
}
