using System;
using System.Collections.Generic;

namespace Inventory_WebAPI.Models;

public partial class Expense
{
    public int ExpId { get; set; }

    public string? ExpType { get; set; }

    public string? ExpValue { get; set; }

    public string? ExpName { get; set; }
}
