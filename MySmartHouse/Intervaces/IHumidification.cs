using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySmartHouse
{
    public interface IAirHumidification
    {
        TimerHumidification HumidificationState { get;}
        void SetTimerHumidification(TimerHumidification v);
    }
}
