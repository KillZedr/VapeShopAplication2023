using System;
using System.Collections.Generic;

namespace VSA.Domain;
public partial class Store
{
    public int StoreId { get; set; }

    public string StoreName { get; set; } = null!;

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
