using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySmartHouse
{
    public interface IAirConditioning
    {
        byte TempConditioning { get; }
        bool ConditioningState { get; }
        void OnConditioning(byte t);
        void OffConditioning();
    }
}
