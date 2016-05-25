using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySmartHouse
{
    public interface IThermometer
    {
        double Temperature { get; set; }
        byte Humidity { get; set; }

    }
}
