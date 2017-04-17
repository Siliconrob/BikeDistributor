using System;
using System.Collections.Generic;

namespace BikeDistributor.Receipt
{
  public static class Tax
  {
    public static IEnumerable<Func<double, double>> Jurisdictions()
    {
      var theRates = new List<Func<double, double>>
      {
        unitPrice => unitPrice * .0725d
      };
      return theRates;
    }
  }
}
