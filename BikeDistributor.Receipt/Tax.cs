using System;
using System.Collections.Generic;

namespace BikeDistributor.Receipt
{
  public static class Tax
  {
    public static IEnumerable<Func<decimal, decimal>> Jurisdictions()
    {
      var theRates = new List<Func<decimal, decimal>>
      {
        unitPrice => unitPrice * .0725M
      };
      return theRates;
    }
  }
}
