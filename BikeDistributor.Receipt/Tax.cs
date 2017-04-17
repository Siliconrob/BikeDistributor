using System;
using System.Collections.Generic;

namespace BikeDistributor.Receipt
{
  public static class Tax
  {
    public static Dictionary<string, Func<decimal, decimal>> Cities()
    {
      var theRates = new Dictionary<string, Func<decimal, decimal>>
      {
        { "Jumbotown", value => value * .0725M },
        { "Badlands", value => value * .0105M }
      };
      return theRates;
    }
  }
}
