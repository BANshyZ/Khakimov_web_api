using System;
using System.Collections.Generic;

namespace SHURALE.Models;

public partial class Cpu
{
    public int Cpuid { get; set; }

    public string? Model { get; set; }

    public string? Socket { get; set; }

    public int? Cores { get; set; }

    public int? Threads { get; set; }

    public virtual ICollection<Motherboard> Motherboards { get; set; } = new List<Motherboard>();
}
