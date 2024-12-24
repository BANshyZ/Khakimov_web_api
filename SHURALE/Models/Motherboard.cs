using System;
using System.Collections.Generic;

namespace SHURALE.Models;

public partial class Motherboard
{
    public int MotherboardId { get; set; }

    public string? Model { get; set; }

    public string? Socket { get; set; }

    public string? Ramtype { get; set; }

    public string? ConnectionInterface { get; set; }

    public string? MemoryInterface { get; set; }

    public virtual ICollection<Case> Cases { get; set; } = new List<Case>();

    public virtual ICollection<Cooler> Coolers { get; set; } = new List<Cooler>();

    public virtual ICollection<Cpu> Cpus { get; set; } = new List<Cpu>();

    public virtual ICollection<Gpu> Gpus { get; set; } = new List<Gpu>();

    public virtual ICollection<Ram> Rams { get; set; } = new List<Ram>();

    public virtual ICollection<Storage> Storages { get; set; } = new List<Storage>();
}
