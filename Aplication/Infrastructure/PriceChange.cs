﻿using System;
using System.Collections.Generic;

namespace VapeShopAplication.entitiSQLDataBaseMyVapeShop;

public partial class PriceChange
{
    public int ProductId { get; set; }

    public DateTime DatePriceChange { get; set; }

    public decimal NewPrice { get; set; }

    public virtual Product Product { get; set; } = null!;
}
