using System;
using System.Collections.Generic;

namespace VapeShopAplication.entitiSQLDataBaseMyVapeShop;

public partial class Delivery
{
    public int ProductId { get; set; }

    public int? StoreId { get; set; }

    public DateTime DeliveryDate { get; set; }

    public decimal ProductCount { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Store? Store { get; set; }
}
