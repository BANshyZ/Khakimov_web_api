using System;
using System.Collections.Generic;

namespace SHURALE.Models;

public partial class PowerSupply
{
    public int PowerSupplyId { get; set; }

    public string? Model { get; set; }

    public int? PowerRating { get; set; }

    public string? FormFactor { get; set; }

    public virtual ICollection<Case> Cases { get; set; } = new List<Case>();
}
