using System.Collections.Generic;

namespace BikeDistributor.Receipt
{
  public class ItemizedReceipt
  {
    public string Title { get; set; }
    public IEnumerable<LineItem> Items { get; set; }
    public decimal Tax { get; set; }
    public decimal Total { get; set; }
  }
}