using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SHURALE.Models;

public partial class CompHelperContext : DbContext
{
    public CompHelperContext()
    {
    }

    public CompHelperContext(DbContextOptions<CompHelperContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Case> Cases { get; set; }

    public virtual DbSet<Cooler> Coolers { get; set; }

    public virtual DbSet<Cpu> Cpus { get; set; }

    public virtual DbSet<Gpu> Gpus { get; set; }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<Motherboard> Motherboards { get; set; }

    public virtual DbSet<PowerSupply> PowerSupplies { get; set; }

    public virtual DbSet<Ram> Rams { get; set; }

    public virtual DbSet<Storage> Storages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Case>(entity =>
        {
            entity.HasKey(e => e.CaseId).HasName("PK__Cases__6CAE526CF988E6CD");

            entity.Property(e => e.CaseId).HasColumnName("CaseID");
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.MotherBoardFormFactor).HasMaxLength(86);
            entity.Property(e => e.PowerSupplyFormFactor).HasMaxLength(36);

            entity.HasMany(d => d.Motherboards).WithMany(p => p.Cases)
                .UsingEntity<Dictionary<string, object>>(
                    "CaseToMotherboardCompat",
                    r => r.HasOne<Motherboard>().WithMany()
                        .HasForeignKey("MotherboardId")
                        .HasConstraintName("FK__CaseToMot__Mothe__5629CD9C"),
                    l => l.HasOne<Case>().WithMany()
                        .HasForeignKey("CaseId")
                        .HasConstraintName("FK__CaseToMot__CaseI__5535A963"),
                    j =>
                    {
                        j.HasKey("CaseId", "MotherboardId").HasName("PK__CaseToMo__1C21B0424FA7FE62");
                        j.ToTable("CaseToMotherboardCompat");
                        j.IndexerProperty<int>("CaseId").HasColumnName("CaseID");
                        j.IndexerProperty<int>("MotherboardId").HasColumnName("MotherboardID");
                    });
        });

        modelBuilder.Entity<Cooler>(entity =>
        {
            entity.HasKey(e => e.CoolerId).HasName("PK__Coolers__E5C71B68AD626730");

            entity.Property(e => e.CoolerId).HasColumnName("CoolerID");
            entity.Property(e => e.ConstructionType).HasMaxLength(33);
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.SocketSupport).HasMaxLength(128);

            entity.HasMany(d => d.Motherboards).WithMany(p => p.Coolers)
                .UsingEntity<Dictionary<string, object>>(
                    "CoolerMotherboardCompat",
                    r => r.HasOne<Motherboard>().WithMany()
                        .HasForeignKey("MotherboardId")
                        .HasConstraintName("FK__CoolerMot__Mothe__52593CB8"),
                    l => l.HasOne<Cooler>().WithMany()
                        .HasForeignKey("CoolerId")
                        .HasConstraintName("FK__CoolerMot__Coole__5165187F"),
                    j =>
                    {
                        j.HasKey("CoolerId", "MotherboardId").HasName("PK__CoolerMo__9548F946ABFBA31E");
                        j.ToTable("CoolerMotherboardCompat");
                        j.IndexerProperty<int>("CoolerId").HasColumnName("CoolerID");
                        j.IndexerProperty<int>("MotherboardId").HasColumnName("MotherboardID");
                    });
        });

        modelBuilder.Entity<Cpu>(entity =>
        {
            entity.HasKey(e => e.Cpuid).HasName("PK__CPUs__7D9B6772B23C65AB");

            entity.ToTable("CPUs");

            entity.Property(e => e.Cpuid).HasColumnName("CPUID");
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.Socket).HasMaxLength(50);

            entity.HasMany(d => d.Motherboards).WithMany(p => p.Cpus)
                .UsingEntity<Dictionary<string, object>>(
                    "CputoMotherboardCompat",
                    r => r.HasOne<Motherboard>().WithMany()
                        .HasForeignKey("MotherboardId")
                        .HasConstraintName("FK__CPUToMoth__Mothe__5DCAEF64"),
                    l => l.HasOne<Cpu>().WithMany()
                        .HasForeignKey("Cpuid")
                        .HasConstraintName("FK__CPUToMoth__CPUID__5CD6CB2B"),
                    j =>
                    {
                        j.HasKey("Cpuid", "MotherboardId").HasName("PK__CPUToMot__0D14855CA4C12689");
                        j.ToTable("CPUToMotherboardCompat");
                        j.IndexerProperty<int>("Cpuid").HasColumnName("CPUID");
                        j.IndexerProperty<int>("MotherboardId").HasColumnName("MotherboardID");
                    });
        });

        modelBuilder.Entity<Gpu>(entity =>
        {
            entity.HasKey(e => e.Gpuid).HasName("PK__GPUs__8A41A909D70BE25B");

            entity.ToTable("GPUs");

            entity.Property(e => e.Gpuid).HasColumnName("GPUID");
            entity.Property(e => e.ConnectionInterface).HasMaxLength(8);
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.VideoMemoryType).HasMaxLength(5);

            entity.HasMany(d => d.Motherboards).WithMany(p => p.Gpus)
                .UsingEntity<Dictionary<string, object>>(
                    "GputoMotherboardCompat",
                    r => r.HasOne<Motherboard>().WithMany()
                        .HasForeignKey("MotherboardId")
                        .HasConstraintName("FK__GPUToMoth__Mothe__619B8048"),
                    l => l.HasOne<Gpu>().WithMany()
                        .HasForeignKey("Gpuid")
                        .HasConstraintName("FK__GPUToMoth__GPUID__60A75C0F"),
                    j =>
                    {
                        j.HasKey("Gpuid", "MotherboardId").HasName("PK__GPUToMot__FACE4B2785D4F973");
                        j.ToTable("GPUToMotherboardCompat");
                        j.IndexerProperty<int>("Gpuid").HasColumnName("GPUID");
                        j.IndexerProperty<int>("MotherboardId").HasColumnName("MotherboardID");
                    });
        });

        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Guest__3213E83F9AA856FD");

            entity.ToTable("Guest");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Motherboard>(entity =>
        {
            entity.HasKey(e => e.MotherboardId).HasName("PK__Motherbo__08FE22E6F55DC9F6");

            entity.Property(e => e.MotherboardId).HasColumnName("MotherboardID");
            entity.Property(e => e.ConnectionInterface).HasMaxLength(8);
            entity.Property(e => e.MemoryInterface).HasMaxLength(8);
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.Ramtype)
                .HasMaxLength(5)
                .HasColumnName("RAMType");
            entity.Property(e => e.Socket).HasMaxLength(50);

            entity.HasMany(d => d.Rams).WithMany(p => p.Motherboards)
                .UsingEntity<Dictionary<string, object>>(
                    "MotherboardRamcompat",
                    r => r.HasOne<Ram>().WithMany()
                        .HasForeignKey("Ramid")
                        .HasConstraintName("FK__Motherboa__RAMID__59FA5E80"),
                    l => l.HasOne<Motherboard>().WithMany()
                        .HasForeignKey("MotherboardId")
                        .HasConstraintName("FK_MotherboardRAMCompat_Motherboards"),
                    j =>
                    {
                        j.HasKey("MotherboardId", "Ramid").HasName("PK__Motherbo__283502B4E493F204");
                        j.ToTable("MotherboardRAMCompat");
                        j.IndexerProperty<int>("MotherboardId").HasColumnName("MotherboardID");
                        j.IndexerProperty<int>("Ramid").HasColumnName("RAMID");
                    });

            entity.HasMany(d => d.Storages).WithMany(p => p.Motherboards)
                .UsingEntity<Dictionary<string, object>>(
                    "StorageToMotherboardCompat",
                    r => r.HasOne<Storage>().WithMany()
                        .HasForeignKey("StorageId")
                        .HasConstraintName("FK_StorageToMotherboardCompat_Storage"),
                    l => l.HasOne<Motherboard>().WithMany()
                        .HasForeignKey("MotherboardId")
                        .HasConstraintName("FK_StorageToMotherboardCompat_Motherboards"),
                    j =>
                    {
                        j.HasKey("MotherboardId", "StorageId");
                        j.ToTable("StorageToMotherboardCompat");
                        j.IndexerProperty<int>("MotherboardId").HasColumnName("MotherboardID");
                        j.IndexerProperty<int>("StorageId").HasColumnName("StorageID");
                    });
        });

        modelBuilder.Entity<PowerSupply>(entity =>
        {
            entity.HasKey(e => e.PowerSupplyId).HasName("PK__PowerSup__0E834E68148F63CB");

            entity.ToTable("PowerSupply");

            entity.Property(e => e.PowerSupplyId).HasColumnName("PowerSupplyID");
            entity.Property(e => e.FormFactor).HasMaxLength(36);
            entity.Property(e => e.Model).HasMaxLength(50);

            entity.HasMany(d => d.Cases).WithMany(p => p.PowerSupplies)
                .UsingEntity<Dictionary<string, object>>(
                    "PowerSupplyCaseCompat",
                    r => r.HasOne<Case>().WithMany()
                        .HasForeignKey("CaseId")
                        .HasConstraintName("FK__PowerSupp__CaseI__656C112C"),
                    l => l.HasOne<PowerSupply>().WithMany()
                        .HasForeignKey("PowerSupplyId")
                        .HasConstraintName("FK__PowerSupp__Power__6477ECF3"),
                    j =>
                    {
                        j.HasKey("PowerSupplyId", "CaseId").HasName("PK__PowerSup__D849AB4E255FDE62");
                        j.ToTable("PowerSupplyCaseCompat");
                        j.IndexerProperty<int>("PowerSupplyId").HasColumnName("PowerSupplyID");
                        j.IndexerProperty<int>("CaseId").HasColumnName("CaseID");
                    });
        });

        modelBuilder.Entity<Ram>(entity =>
        {
            entity.HasKey(e => e.Ramid).HasName("PK__RAMs__0CB205236B2D4B17");

            entity.ToTable("RAMs");

            entity.Property(e => e.Ramid).HasColumnName("RAMID");
            entity.Property(e => e.MemoryType).HasMaxLength(5);
            entity.Property(e => e.Model).HasMaxLength(50);
        });

        modelBuilder.Entity<Storage>(entity =>
        {
            entity.HasKey(e => e.StorageId).HasName("PK__Storage__8A247E3739B85EB5");

            entity.ToTable("Storage");

            entity.Property(e => e.StorageId).HasColumnName("StorageID");
            entity.Property(e => e.MemoryInterface).HasMaxLength(8);
            entity.Property(e => e.MemoryType).HasMaxLength(3);
            entity.Property(e => e.Model).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
