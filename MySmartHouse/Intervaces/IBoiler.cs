using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySmartHouse
{
    public interface IBoiler
    {
        Heating boiler { get; set; }
    }
}
