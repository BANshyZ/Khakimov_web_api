using System;
using System.Collections.Generic;

namespace SHURALE.Models;

public partial class Cooler
{
    public int CoolerId { get; set; }

    public string? Model { get; set; }

    public string? SocketSupport { get; set; }

    public string? ConstructionType { get; set; }

    public virtual ICollection<Motherboard> Motherboards { get; set; } = new List<Motherboard>();
}
