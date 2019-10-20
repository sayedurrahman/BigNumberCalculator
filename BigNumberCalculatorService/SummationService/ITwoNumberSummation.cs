using BigNumberCalculator.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigNumberCalculator.Core.SummationService
{
    public interface ITwoNumberSummation
    {
        string DoTheSum(BigNumberString firstbigNumberString, BigNumberString secondBigNumberString);
    }
}
