using System.Collections.Generic;
using BikeDistributor.Location;

namespace BikeDistributor
{
  public class Customer
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public AddressDetails Addresses { get; set; }
    public ContactInfomation Contact { get; set; }
    public List<BikeOrder> Orders { get; set; }
  }
}