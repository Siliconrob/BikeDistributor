namespace BikeDistributor
{
  public class UnitDetail<T> where T : class, new()
  {
    public T Unit { get; set; }
    public int Quantity { get; set; }
  }
}
