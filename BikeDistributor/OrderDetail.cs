namespace BikeDistributor
{
  public class OrderDetail<T> where T : class, new()
  {
    public T Unit { get; set; }
    public int Quantity { get; set; }
  }
}
