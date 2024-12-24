using System;
using System.Collections.Generic;

namespace SHURALE.Models;

public partial class Case
{
    public int CaseId { get; set; }

    public string? Model { get; set; }

    public string? MotherBoardFormFactor { get; set; }

    public string? PowerSupplyFormFactor { get; set; }

    public virtual ICollection<Motherboard> Motherboards { get; set; } = new List<Motherboard>();

    public virtual ICollection<PowerSupply> PowerSupplies { get; set; } = new List<PowerSupply>();
}
