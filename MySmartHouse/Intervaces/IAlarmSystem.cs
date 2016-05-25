using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySmartHouse
{
    public interface IAlarmSystem
    {
        string AlarmSystemState { get; }
        void ChangeAlarmSystemState();
    }
}
