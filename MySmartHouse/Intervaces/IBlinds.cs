using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySmartHouse
{
    public interface IBlinds
    {
        string Blinds { get; }
        void GetLoweredBlinds();
        void GetRaisedBlinds();

    }
}
