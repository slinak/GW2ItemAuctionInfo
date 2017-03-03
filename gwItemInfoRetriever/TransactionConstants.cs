﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gwItemInfoRetriever
{
    class TransactionConstants
    {
        //This nonrefundable cost covers listing (or selling instantly) and holding your items for sale. This fee has a minimum of 1
        //5%
        const double SellingListFee = .05;
        //After a successful trade, the item exchange fee is deducted from coins delivered to the seller. This fee has a minimum of 1
        //10%
        const double SellingExchangeFee = .1;
    }
}
