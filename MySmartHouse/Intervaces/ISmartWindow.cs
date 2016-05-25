using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySmartHouse
{
    public interface ISmartWindow
    {
        bool FrostedGlassState { get; }
        byte DimmingGlass { get; }
        void FrostedGlassOnOff();
        void SetDimmingGlass(byte p);
    }
}
