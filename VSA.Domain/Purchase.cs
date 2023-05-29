using System;
using System.Collections.Generic;

namespace VSA.Domain;
public partial class Purchase
{
    public int PurchaseId { get; set; }

    public int CustomerId { get; set; }

    public int StoreId { get; set; }

    public DateTime PurchaseDate { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();

    public virtual Store Store { get; set; } = null!;
}
