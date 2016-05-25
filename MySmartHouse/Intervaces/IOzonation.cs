using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySmartHouse
{
    public interface IOzonation
    {
        TimerOzonation OzonationState { get;}
        void SetTimerOzonation(TimerOzonation v);
        

    }
}
