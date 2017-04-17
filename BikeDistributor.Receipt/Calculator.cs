using System.Linq;

namespace BikeDistributor.Receipt
{
  public static class Calculator
  {
    public static decimal Price(OrderDetail<Bike> lineItem)
    {
      var normalPrice = (decimal) lineItem.Unit.Price * lineItem.Quantity;
      var discountPrice = Discount.All()
        .Select(z => z.Invoke(lineItem.Quantity, lineItem.Unit.Price))
        .FirstOrDefault(y => y > 0);

      if (discountPrice != 0 && normalPrice > discountPrice)
      {
        return discountPrice;
      }
      return normalPrice;
    }
  }
}
