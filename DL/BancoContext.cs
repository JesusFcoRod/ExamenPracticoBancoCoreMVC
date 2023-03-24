using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class BancoContext : DbContext
{
    public BancoContext()
    {
    }

    public BancoContext(DbContextOptions<BancoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Banco> Bancos { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    public virtual DbSet<RazonSocial> RazonSocials { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database= Banco; User ID=sa; TrustServerCertificate=True; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Banco>(entity =>
        {
            entity.HasKey(e => e.IdBanco).HasName("PK__Banco__D8FFCB751478B504");

            entity.ToTable("Banco");

            entity.Property(e => e.IdBanco).HasColumnName("idBanco");
            entity.Property(e => e.IdPais).HasColumnName("idPais");
            entity.Property(e => e.IdRazonSocial).HasColumnName("idRazonSocial");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Bancos)
                .HasForeignKey(d => d.IdPais)
                .HasConstraintName("FK__Banco__idPais__145C0A3F");

            entity.HasOne(d => d.IdRazonSocialNavigation).WithMany(p => p.Bancos)
                .HasForeignKey(d => d.IdRazonSocial)
                .HasConstraintName("FK__Banco__idRazonSo__15502E78");
        });

        modelBuilder.Entity<Pai>(entity =>
        {
            entity.HasKey(e => e.IdPais).HasName("PK__Pais__BD2285E3A073B3F4");

            entity.Property(e => e.IdPais).HasColumnName("idPais");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RazonSocial>(entity =>
        {
            entity.HasKey(e => e.IdRazonSocial).HasName("PK__RazonSoc__B0709B89D3DA0ACE");

            entity.ToTable("RazonSocial");

            entity.Property(e => e.IdRazonSocial).HasColumnName("idRazonSocial");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
