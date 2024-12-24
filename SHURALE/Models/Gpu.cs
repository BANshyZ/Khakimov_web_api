using System;
using System.Collections.Generic;

namespace SHURALE.Models;

public partial class Gpu
{
    public int Gpuid { get; set; }

    public string? Model { get; set; }

    public string? VideoMemoryType { get; set; }

    public string? ConnectionInterface { get; set; }

    public virtual ICollection<Motherboard> Motherboards { get; set; } = new List<Motherboard>();
}
