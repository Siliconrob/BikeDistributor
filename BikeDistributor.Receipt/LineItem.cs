namespace BikeDistributor.Receipt
{
  public class LineItem
  {
    public int Quantity { get; set; }
    public string Text { get; set; }
    public decimal Total { get; set; }
  }
}