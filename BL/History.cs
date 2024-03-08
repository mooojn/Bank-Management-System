using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainBusinessApp
{
    internal class History
    {
        private string type;
        private int amount;
        private DateTime date;
        public History(string type, int amount, DateTime date)
        {
            this.type = type;
            this.amount = amount;
            this.date = date;
        }
    }
}
