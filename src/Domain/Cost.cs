using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Cost
    {
        public decimal Amount { get; set; }

        public string EventDate { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public decimal CashAmount { get; set; }
    }
}
