using System.Collections.Generic;

namespace BikeDistributor
{
  public class BikeOrder
  {
    public int Id { get; set; }
    public TimeStamps TimeStamps { get; set; }
    public IEnumerable<OrderDetail<Bike>> Details { get; set; }
  }
}
