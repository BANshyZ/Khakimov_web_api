using System;
using System.Collections.Generic;

namespace SHURALE.Models;

public partial class Ram
{
    public int Ramid { get; set; }

    public string? Model { get; set; }

    public string? MemoryType { get; set; }

    public int? Capacity { get; set; }

    public virtual ICollection<Motherboard> Motherboards { get; set; } = new List<Motherboard>();
}
