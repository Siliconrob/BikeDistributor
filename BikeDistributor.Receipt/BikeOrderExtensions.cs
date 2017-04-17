using System;
using System.Collections.Generic;
using System.Linq;

namespace BikeDistributor.Receipt
{
  public static class BikeOrderExtensions
  {
    public static ItemizedReceipt ToReceipt(this Customer customer, int orderId)
    {
      if (orderId <= 0)
      {
        return new ItemizedReceipt();
      }
      customer = customer ?? new Customer();
      var allOrders = customer.Orders ?? new List<BikeOrder>();
      if (!allOrders.Any())
      {
        return new ItemizedReceipt();
      }
      var currentOrder = allOrders.FirstOrDefault(z => z.Id == orderId) ?? new BikeOrder();
      if (currentOrder.Id == 0)
      {
        return new ItemizedReceipt();
      }

      var lines = currentOrder.ToLineItems();
      var sum = lines.Sum(z => z.Total);
      var tax = (Tax.Cities().FirstOrDefault(z => z.Key.Equals(customer.Addresses.Billing.City)).Value ?? (j => 0)).Invoke(sum);

      var receipt = new ItemizedReceipt
      {
        Items = lines,
        Tax = tax,
        Total = sum + tax
      };
      return receipt;
    }

    private static List<LineItem> ToLineItems(this BikeOrder currentOrder)
    {
      return (from order in currentOrder.Details
        let lineAmount = Calculator.Price(order)
        select new LineItem
        {
          Quantity = order.Quantity,
          Total = lineAmount,
          Text = $"{order.Quantity} x {order.Unit.Brand} {order.Unit.Model} = {lineAmount}"
        }).ToList();
    }
  }
}