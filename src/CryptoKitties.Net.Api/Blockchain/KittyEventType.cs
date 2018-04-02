using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoKitties.Net.Blockchain
{
    public enum KittyEventType
    {
        Unknown = 0,
        AuctionCreated = 1,
        AuctionSuccessful = 2,
        AuctionCancelled = 3,
        Pause = 4,
        Unpause = 5,
        // TODO: Core contract events
    }
}
