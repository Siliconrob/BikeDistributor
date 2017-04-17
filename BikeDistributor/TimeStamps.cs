using System;

namespace BikeDistributor
{
  public class TimeStamps
  {
    public DateTime Received { get; set; }
    public DateTime Fulfilled { get; set; }
    public DateTime Shipped { get; set; }
    public DateTime Delivered { get; set; }
  }
}