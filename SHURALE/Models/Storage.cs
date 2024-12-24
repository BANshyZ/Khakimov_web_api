using System;
using System.Collections.Generic;

namespace SHURALE.Models;

public partial class Storage
{
    public int StorageId { get; set; }

    public string? Model { get; set; }

    public string? MemoryType { get; set; }

    public string? MemoryInterface { get; set; }

    public int? Capacity { get; set; }

    public virtual ICollection<Motherboard> Motherboards { get; set; } = new List<Motherboard>();
}
