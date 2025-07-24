using System;
using System.Collections.Generic;

namespace Inventory_WebAPI.Models;

public partial class Sparepart
{
    public string? SpName { get; set; }

    public string? SpAddress { get; set; }

    public decimal? SpPrice { get; set; }

    public int? SpQuantity { get; set; }

    public int SpId { get; set; }

    public int SpVendorId { get; set; }

    public virtual Vendor SpVendor { get; set; } = null!;
}
