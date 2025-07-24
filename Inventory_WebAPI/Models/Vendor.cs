using System;
using System.Collections.Generic;

namespace Inventory_WebAPI.Models;

public partial class Vendor
{
    public int VId { get; set; }

    public string? VName { get; set; }

    public string? VAddress { get; set; }

    public virtual ICollection<Sparepart> Spareparts { get; set; } = new List<Sparepart>();
}
