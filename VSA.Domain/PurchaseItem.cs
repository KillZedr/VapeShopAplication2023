﻿using System;
using System.Collections.Generic;

namespace VSA.Domain;
public partial class PurchaseItem
{
    public int PurchaseId { get; set; }

    public int ProductId { get; set; }

    public decimal ProductCount { get; set; }

    public decimal ProductPrice { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Purchase Purchase { get; set; } = null!;
}
