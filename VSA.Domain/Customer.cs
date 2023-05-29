using System;
using System.Collections.Generic;

namespace VSA.Domain;
public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerFname { get; set; } = null!;

    public string CustomerLname { get; set; } = null!;

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
