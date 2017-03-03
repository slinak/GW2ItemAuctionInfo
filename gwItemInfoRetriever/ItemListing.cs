using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gwItemInfoRetriever
{
    class ItemListing
    {
        public int id { get; set; }
        public Listing[] buys { get; set; }
        public Listing[] sells { get; set; }
    }
}
