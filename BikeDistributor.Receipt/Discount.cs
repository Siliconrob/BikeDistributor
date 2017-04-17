using System;
using System.Collections.Generic;

namespace BikeDistributor.Receipt
{
  public static class Discount
  {
    public static IEnumerable<Func<int, decimal, decimal>> All()
    {
      return new Func<int, decimal, decimal>[]
      {
        (units, costPerUnit) => units >= 20 && costPerUnit == 1000 ? units * costPerUnit * .9M : 0,
        (units, costPerUnit) => units >= 10 && costPerUnit == 2000 ? units * costPerUnit * .8M : 0,
        (units, costPerUnit) => units >= 5 && costPerUnit == 5000 ? units * costPerUnit * .8M : 0
      };
    }
  }
}