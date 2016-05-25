using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySmartHouse
{
    public interface ILighting
    {
        Lighting lightingState { get; set; }
    }
}
