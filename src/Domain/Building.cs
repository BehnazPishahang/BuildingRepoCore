using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Building:BaseEntity
    {
        public string Title { get; set; }

        public string Address { get; set; }

        public int FloorCount { get; set; }

        public int Plaque { get; set; }

        public string CityName { get; set; }
    }
}
