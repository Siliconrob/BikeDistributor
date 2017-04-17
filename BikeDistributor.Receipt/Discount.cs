using System;
using System.Collections.Generic;
using System.Linq;

namespace BikeDistributor.Receipt
{
  public static class Discount
  {
    private static IEnumerable<Func<int, decimal, decimal>> All()
    {
      return new Func<int, decimal, decimal>[]
      {
        (units, costPerUnit) => units >= 20 && costPerUnit == 1000 ? units * costPerUnit * .9M : units * costPerUnit,
        (units, costPerUnit) => units >= 10 && costPerUnit == 2000 ? units * costPerUnit * .8M : units * costPerUnit,
        (units, costPerUnit) => units >= 5 && costPerUnit == 5000 ? units * costPerUnit * .8M : units * costPerUnit
      };
    }


    public static IEnumerable<Func<int, decimal, decimal>> Applicable(BikeOrder input)
    {




      //public static IEnumerable<Func<BikeOrder, double>> Applicable()
      //{
      //  var theRates = new List<Func<BikeOrder, double>>
      //  {
      //    new Func<BikeOrder, double>(order => { return order.Details. })

      //  };
      //  return theRates;
      //}
    }
  }