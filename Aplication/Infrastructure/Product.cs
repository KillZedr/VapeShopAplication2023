using System;
using System.Collections.Generic;

namespace VapeShopAplication.entitiSQLDataBaseMyVapeShop;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int? ManufacturerId { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Manufacturer? Manufacturer { get; set; }

    public virtual ICollection<PriceChange> PriceChanges { get; set; } = new List<PriceChange>();

    public virtual ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();
}
